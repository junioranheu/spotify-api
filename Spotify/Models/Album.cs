using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Spotify.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        public string? Nome { get; set; }
        public string? Sobre { get; set; }
        public string? Foto { get; set; }
        public DateTime DataLancamento { get; set; }

        // Fk (De lá pra cá);
        public int BandaId { get; set; }
        [JsonIgnore]
        public Banda? Bandas { get; set; }

        public int IsAtivo { get; set; }
        public DateTime DataRegistro { get; set; }

        // Fk (De cá pra lá);
        [JsonIgnore]
        public ICollection<AlbumMusica> AlbunsMusicas { get; set; }
    }
}
