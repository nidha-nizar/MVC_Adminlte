using System.ComponentModel.DataAnnotations;

namespace MVC_Adminlte.Models
{
    public class hospital
    {
        [Key]
        public int h_id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string loc { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }
    }
}
