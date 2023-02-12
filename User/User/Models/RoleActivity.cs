using System.ComponentModel.DataAnnotations;

namespace User.Models
{
    public class RoleActivity
    {
        [Key]
        public int RAid { get; set; }
        public bool create { get; set; }
        public bool update { get; set; }
        public bool delete { get; set; }
        public bool read { get; set; }
        public int activityid { get; set; }
        public Activity Activities { get; set; }
        public int roleid { get; set;}
        public Role Role { get; set; }
    }
}
