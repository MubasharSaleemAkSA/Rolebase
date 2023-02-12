using System.ComponentModel.DataAnnotations;

namespace User.Models
{
    public class Activity
    {
        [Key]
        public int activityid { get; set; }
        public string activityname { get; set; }
     
        public string description { get; set; }
        public ICollection<RoleActivity> RoleActivity { get; set; }
    }
}
