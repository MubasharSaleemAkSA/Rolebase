using System.ComponentModel.DataAnnotations;

namespace User.Models
{
    public class Role
    {
        [Key]
        public int roleid { get; set; }
        public string rolename { get; set; }
        public ICollection<UserData> users { get; set; }
        public ICollection<RoleActivity> RoleActivity { get; set; }

    }
}
