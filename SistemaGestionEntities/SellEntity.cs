using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities;

public class SellEntity
{
    [Key]
    public int Id { get; set; }


    [Required(ErrorMessage = "El campo Comentario es requerido.")]
    [MaxLength(250, ErrorMessage = "El comentario no puede tener más de 250 caracteres.")]
    [MinLength(5, ErrorMessage = "El comentario debe tener al menos 5 caracteres.")]
    [Display(Name = "comments")]
    public string Comments { get; set; }
    public int UserId { get; set; }

}
