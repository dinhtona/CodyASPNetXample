using Cody_v2.Repositories.Entities;
using Cody_v2.Repositories.Generics;
using Cody_v2.Repositories.Helpers;
using Cody_v2.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;

namespace Cody_v2.Repositories.Contexts
{
    //Cody_v2.Repositories.Contexts.AppDbContext
    public class AppDbContext : IdentityDbContext<AppUser,IdentityRole,string>, IAppDbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public System.Data.IDbConnection Connection => Database.GetDbConnection();

        protected override async void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //foreach (Type type in GetEntityType(typeof(BaseEntity)))
            //{
            //    var method = SetGlobalQueryMethod.MakeGenericMethod(type);
            //    method.Invoke(this, new object[] { builder });
            //}

            // Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
            // tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
            // Đoạn mã sau chạy khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố đó
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (!string.IsNullOrEmpty(tableName) && tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

        }
        public void SetGlobalQuery<T>(ModelBuilder builder) where T : BaseEntity
        {
            builder.Entity<T>().Property(o => o.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<T>().Property(o => o.CreatedDate).HasDefaultValueSql("GETDATE()");
            builder.Entity<T>().Property(o => o.UpdatedDate).HasDefaultValueSql("GETDATE()");
            builder.Entity<T>().Property(o => o.CreatedIPAddress).HasDefaultValueSql("''");
            builder.Entity<T>().Property(o => o.CreatedPCName).HasDefaultValueSql("''");
            builder.Entity<T>().Property(o => o.UpdatedIPAddress).HasDefaultValueSql("''");
            builder.Entity<T>().Property(o => o.UpdatedPCName).HasDefaultValueSql("''");
            builder.Entity<T>().Property(o => o.IsDeleted).HasDefaultValueSql("0");

        }

        private static IList<Type> _entityTypeCache;
        private static IList<Type> GetEntityType(Type type)
        {
            if (_entityTypeCache != null && _entityTypeCache.First().BaseType == type)
            {
                return _entityTypeCache.ToList();
            }

            _entityTypeCache = (from a in GetReferencingAssemblies()
                                from t in a.DefinedTypes
                                where t.BaseType == type
                                select t.AsType()
                              ).ToList();
            return _entityTypeCache;
        }

        private static IEnumerable<Assembly> GetReferencingAssemblies()
        {
            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries;

            foreach (var library in dependencies)
            {
                try
                {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
                    assemblies.Add(assembly);
                }
                catch (FileNotFoundException)
                {
                }

            }
            return assemblies;
        }

        private static readonly MethodInfo SetGlobalQueryMethod = typeof(AppDbContext)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");

        public async Task<int> SaveChangesAsync()
        {
            System.Net.IPAddress[] lsClientIPAddress = System.Net.Dns.GetHostAddresses(Environment.MachineName);
            string strClientMachineName = Environment.MachineName.ToString().Trim();

            string strIPAddress = "";
            foreach (var ip in lsClientIPAddress)
            {
                if (Utilities.IsIPFormat(ip.ToString()))
                {
                    if (string.IsNullOrEmpty(strIPAddress))
                    {
                        strIPAddress = ip.ToString();
                    }
                    else
                    {
                        strIPAddress += " | " + ip.ToString();
                    }
                }
            }
            var userIdString = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
            var userId = userIdString!=null? new Guid(userIdString):Guid.Empty;
            var modifiedEnties = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);
            foreach (var item in modifiedEnties)
            {
                if (item.Entity is BaseEntity)
                {
                    var baseEntity = item.Entity as BaseEntity;
                    if (baseEntity != null)
                    {
                        baseEntity.UpdatedDate = DateTime.Now;
                        baseEntity.UpdatedIPAddress = strIPAddress;
                        baseEntity.UpdatedPCName = strClientMachineName;
                        baseEntity.UpdatedBy = userId;
                    }
                }
            }

            var addedEnties = ChangeTracker.Entries().Where(e => e.State == EntityState.Added);
            foreach (var item in addedEnties)
            {
                if (item.Entity is BaseEntity)
                {
                    var baseEntity = item.Entity as BaseEntity;
                    if (baseEntity != null)
                    {
                        baseEntity.Id = Guid.NewGuid();

                        baseEntity.CreatedBy = userId;
                        baseEntity.CreatedDate = DateTime.Now;
                        baseEntity.CreatedPCName = strClientMachineName;
                        baseEntity.CreatedIPAddress = strIPAddress;
                        baseEntity.IsDeleted = false;

                        baseEntity.UpdatedDate = DateTime.Now;
                        baseEntity.UpdatedIPAddress = strIPAddress;
                        baseEntity.UpdatedPCName = strClientMachineName;
                        baseEntity.UpdatedBy = userId;
                    }
                }
            }

            return await base.SaveChangesAsync();
        }

    }
}