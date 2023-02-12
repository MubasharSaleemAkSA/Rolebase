using System.ComponentModel.DataAnnotations;

namespace EmpAuthApi.Models
{
    public class Activity
    {
        [Key]
        public int activityid { get; set; }
        public string activityname { get; set; }
        public string description { get; set; }
        public ICollection<Activityrole> activityrole { get; set; }
    }
}
