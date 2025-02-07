using System.ComponentModel.DataAnnotations;

namespace MVC_Adminlte.Models
{
    public class registers
    {
        [Key]
        public int r_id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string eamil { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string status { get; set; }
    }
}
