using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CursoMVC.Models.ViewModels
{
    public class UserViewModels
    {
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage ="El {0} debe tener al menos {1} caracteres",  MinimumLength =1)]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Confirma contraseña")]
        [Compare("Password", ErrorMessage = "Las constraseñas no son iguales")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int Edad { get; set; }
    }
}