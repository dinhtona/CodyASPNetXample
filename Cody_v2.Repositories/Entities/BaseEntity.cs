using System.ComponentModel.DataAnnotations;

namespace Cody_v2.Repositories.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public Guid? UpdatedBy { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        [MaxLength(1024)]
        public string CreatedIPAddress { get; set; } = "";
        [MaxLength(256)]
        public string CreatedPCName { get; set; } = "";
        [MaxLength(256)]
        public string UpdatedIPAddress { get; set; } = "";
        [MaxLength(256)]
        public string UpdatedPCName { get; set; } = "";
    }
}
