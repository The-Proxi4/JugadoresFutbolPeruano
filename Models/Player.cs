using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JugadoresFutbolPeruano.Models
{
public class Player
{
    public int PlayerId { get; set; }

    [Required]
    public string Name { get; set; }

    [Range(15, 50)]
    public int Age { get; set; }

    [Required]
    public string Position { get; set; }

    [Required]
    public int TeamId { get; set; }

    public Team Team { get; set; }
}

}
