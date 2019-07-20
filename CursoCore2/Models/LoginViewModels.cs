using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoCore2.Models
{
    public class LoginViewModels
    {
        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage ="El campo correo electronico es obligatorio")]  //Validacion de engreso de datos
            [EmailAddress(ErrorMessage ="El correo electronico no es valida.")]
            public string Email { get; set; }

            [Required(ErrorMessage ="El campo contrasena es obligatorio")]
            [StringLength(100,ErrorMessage ="El numero de caracteres del {0} debe ser al menos {2}.",MinimumLength =6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
