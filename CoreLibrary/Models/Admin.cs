using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLibrary.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
