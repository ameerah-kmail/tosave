using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task4_userAPI.Models
{
    public class user :baseMode
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public ICollection<post> posts { get; set; }   
    }
}
