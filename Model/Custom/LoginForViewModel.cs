using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Ingrese su Email", AllowEmptyStrings = false)]
        public string username { get; set; }

        [Required(ErrorMessage = "Ingrese su contraseña", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }

    public class UpdatePassword
    {


        public int IdUser { get; set; }


        [Required(ErrorMessage = "Ingrese su Email es Obligatorio", AllowEmptyStrings = false)]
        public string username { get; set; }

        [Required(ErrorMessage = "Ingrese su Password actual", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Required(ErrorMessage = "Ingrese Una Nueva Contraseña", AllowEmptyStrings = false)]
        [MaxLength(450, ErrorMessage = "El numero de caracteres excedio")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener por lo menos 8 caracteres")]

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [MinLength(8, ErrorMessage = "La contraseña debe tener por lo menos 8 caracteres")]
        [MaxLength(450, ErrorMessage = "El numero de caracteres excedio")]
        [Compare("NewPassword", ErrorMessage = "Las contraseñas deben ser iguales")]
        [DataType(DataType.Password)]
        public string RepPassword { get; set; }

    }

}
