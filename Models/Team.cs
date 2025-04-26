using System.ComponentModel.DataAnnotations;

namespace JugadoresFutbolPeruano.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Assignment> Assignments { get; set; }
    }
}
