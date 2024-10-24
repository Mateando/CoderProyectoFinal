using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities;

public class UserEntity
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El Nombre es requerido.")]
    [MaxLength(70, ErrorMessage = "El Nombre no puede tener más de 70 caracteres.")]
    [MinLength(3, ErrorMessage = "El Nombre debe tener al menos 3 caracteres.")]
    [Display(Name = "Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "El Apellido es requerido.")]
    [MaxLength(70, ErrorMessage = "El Apellido no puede tener más de 70 caracteres.")]
    [MinLength(3, ErrorMessage = "El Apellido debe tener al menos 3 caracteres.")]
    [Display(Name = "LastName")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "El Nombre de Usuario es requerido.")]
    [MaxLength(70, ErrorMessage = "El Nombre de Usuario no puede tener más de 70 caracteres.")]
    [MinLength(3, ErrorMessage = "El Nombre de Usuario debe tener al menos 3 caracteres.")]
    [Display(Name = "UserName")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "La Contraseña es requerida.")]
    [MaxLength(20, ErrorMessage = "La Contraseña no puede tener más de 20 caracteres.")]
    [MinLength(8, ErrorMessage = "La Contraseña debe tener al menos 8 caracteres.")]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Required(ErrorMessage = "El Correo es requerido.")]
    [MaxLength(70, ErrorMessage = "El Correo no puede tener más de 70 caracteres.")]
    [MinLength(3, ErrorMessage = "El Correo debe tener al menos 3 caracteres.")]
    [Display(Name = "Mail")]
    public string Mail { get; set; }
}
