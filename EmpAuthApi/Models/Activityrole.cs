using System.ComponentModel.DataAnnotations;

namespace EmpAuthApi.Models
{
    public class Activityrole
    {
        [Key]
        public int acid { get; set; }
        public int activityid { get; set; }
        public Activity Activities { get; set; }
        public int roleid { get; set; }
        public Role Role { get; set; }
    }
}
