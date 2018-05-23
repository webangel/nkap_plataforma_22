using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public class Categoria : AuditEntity, ISoftDeleted
    {

        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [Display(Name = "Nombre Categoria")]
        [Required(ErrorMessage = "Ingrese una categoria"), StringLength(100)]
        public string NombreCategoria { get; set; }

        public bool Deleted { get; set; }

    }
}
