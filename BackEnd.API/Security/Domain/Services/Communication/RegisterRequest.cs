using System.ComponentModel.DataAnnotations;

namespace BackEnd.API.Security.Domain.Services.Communication;

public class RegisterRequest
{
    [Required]
    public string Nombre { get; set; }
    
    [Required]
    public string Apellido { get; set; }
    
    [Required]
    [MinLength(9, ErrorMessage = "DNI can only have 9 digits.")]
    [MaxLength(9, ErrorMessage = "DNI can only have 9 digits.")]
    public string Dni { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Telefono { get; set; }
    
    [Required]
    //Pendiente si se quiere confirmación de password
    public string Password { get; set; }
}