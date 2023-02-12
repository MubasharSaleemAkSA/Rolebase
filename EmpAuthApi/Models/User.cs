using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace EmpAuthApi.Models
{
    public class User
    {

        [Key]
        public int userid { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string cnic { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
        public string token { get; set; }
        public string role { get; set; }


        public DateTime date { get; set; }

        public int FRid { get; set; }
        public Role Role { get; set; }


    }
}
