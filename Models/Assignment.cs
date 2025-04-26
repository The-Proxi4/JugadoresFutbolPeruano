// Comentario agregado para habilitar el 
// Pull Request de deature/modelo -datos :)

using System.ComponentModel.DataAnnotations.Schema;

namespace JugadoresFutbolPeruano.Models
{
    public class Assignment
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
