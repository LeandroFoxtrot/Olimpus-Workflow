using System.ComponentModel.DataAnnotations;

namespace Lead7.Olimpus.Web.Models.Config.Usuario
{
    public class LoginModel : ModelBase
    {
        [Required]
        public string Usuario { get; set; } 

        [Required]
        public string Senha { get; set; }
    }
}