using System; // what for ?
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripInfo.API.Entities;

[Table("User", Schema = "Security")]
public class UserBase
{
    [Required()]
    [Key()]
    public Guid UserId { get; set; }

    [Required()]
    public string UserName { get; set; }

    [Required()]
    public string Password { get; set; }
}
