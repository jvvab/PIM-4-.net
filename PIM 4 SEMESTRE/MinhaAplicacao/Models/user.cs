using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}