

using System.ComponentModel.DataAnnotations;

namespace Bakery.Dtos;


public class RegisterDto
{
    [Required]
    public string? Username { get; set; }

    [Required]
    public string? Password { get; set; }
    [Required]
    public string? Rank { get; set; }
}