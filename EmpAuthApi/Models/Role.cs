using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpAuthApi.Models
{
    public class Role
    {
        [Key]
        public int roleid { get; set; }
        public string rolename { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Activityrole> activityrole { get; set; }
      

    }
}
