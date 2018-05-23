using Common.CustomFilters;
using Model.Auth;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Model.Core
{
    public class Roles : ISoftDeleted
    {

        public int Id { get; set; }
        [StringLength(100)]
        [Column(TypeName = "varchar")]
        [Required]
        public string Rol { get; set; }



        public ICollection<Usuarios> Usuarios { get; set; }

        public bool Deleted { get; set; }

    }
}
