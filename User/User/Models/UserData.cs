using System.ComponentModel.DataAnnotations;

namespace User.Models
{
    public class UserData
    {

        [Key]
        public int userid { get; set; }
        public string username { get; set; }
        public string email { get; set; }
  
        public string password { get; set; }
 
        public string token { get; set; }
        public DateTime date { get; set; }
       

        public int Fid { get; set; }
        public Role Role { get; set; }
    }
}
