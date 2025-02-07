using System.ComponentModel.DataAnnotations;

namespace MVC_Adminlte.Models
{
    public class doctor
    {
        [Key]
        public int h_id { get; set; }
        [Required]
        public string d_name { get; set; }
        [Required]
        public string dept { get; set; }
    }
}
