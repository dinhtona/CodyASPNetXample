using Cody_v2.Repositories.Entities;

namespace Cody_v2.Services.RequestDTOs.User
{
    public class UserListModel
    {
        public int totalUsers { get; set; }
        public int countPages { get; set; }

        public int ITEMS_PER_PAGE { get; set; } = 10;

        public int currentPage { get; set; }

        public List<UserAndRole> users { get; set; }

    }

    public class UserAndRole : Cody_v2.Repositories.Entities.AppUser
    {
        public string RoleNames { get; set; }
    }

}