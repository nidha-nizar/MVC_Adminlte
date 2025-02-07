using System.ComponentModel.DataAnnotations;

namespace MVC_Adminlte.Models
{
    public class ViewModelLogin
    {
        [Required]
        public string eamil { get; set; }
        [Required]
        public string password { get; set; }
    }
}
