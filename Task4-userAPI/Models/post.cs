using System.ComponentModel.DataAnnotations;

namespace Task4_userAPI.Models
{
    public class post : baseMode
    {
        public string Title { get; set; }

        user user { get; set; }
        public int userId { get; set; }
        public int ceartDate { get; set; }
        public string ceartBY { get; set; }
        public int updateDate { get; set; }
        public string updateBY { get; set; }
    }
}
