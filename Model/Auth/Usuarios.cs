using Common;
using Common.CustomFilters;
using Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Auth
{
    public class Usuarios : ISoftDeleted
    {
        public int Id { get; set; }

        [Display(Name = "Nombres")]
        [StringLength(120)]
        [Column(TypeName = "varchar")]
        [Required]
        public string Nombres { get; set; }
        [StringLength(120)]
        [Column(TypeName = "varchar")]
        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
        [StringLength(120)]
        [Column(TypeName = "varchar")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(120)]
        [Column(TypeName = "varchar")]
        [Required]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required]
        [StringLength(1)]
        [Column(TypeName = "char")]
        public string Sexo { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(120)]
        [MaxLength(120)]
        public string Foto { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(120)]
        [MaxLength(120)]
        public string Foto2 { get; set; }

        [Column(TypeName = "varchar")]
        [Required, StringLength(100), Index("SlugUsers", IsUnique = true)]
        public string Slug { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(8)]
        [Required(ErrorMessage ="Ingrese el DNI")]
        public string Dni { get; set; }

        public bool Deleted { get; set; }


        [ForeignKey("IdRol")]
        public Roles Rol { get; set; }
        public int IdRol { get; set; }

        public DateTime? CreatedAt { get; set; }

        [NotMapped]
        public string PictureForView
        {
            get
            {
                return string.IsNullOrEmpty(Foto) ? Parameters.UploadPathUsersGeneral + Parameters.Nopictureuser : Foto;
            }
        }


    }
}
