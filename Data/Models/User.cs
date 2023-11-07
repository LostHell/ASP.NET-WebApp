using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class User
{
    public User()
    {
        this.Id = Guid.NewGuid().ToString();
    }

    public string Id { get; set; }

    [Required] public string Username { get; set; }

    [Required] public string Email { get; set; }

    [Required] public int Age { get; set; }
}