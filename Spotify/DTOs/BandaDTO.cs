﻿using System.ComponentModel.DataAnnotations;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.DTOs
{
    public class BandaDTO
    {
        [Key]
        public int BandaId { get; set; }
        public string? Nome { get; set; } = null;
        public string? Sobre { get; set; } = null;
        public string? Foto { get; set; } = null;
        public int Seguidores { get; set; } = 0;
        public string? CorDominante { get; set; } = null;

        public bool IsAtivo { get; set; } = true;
        public DateTime DataRegistro { get; set; } = HorarioBrasilia();

        // Fk (De cá pra lá);
        public List<MusicaBandaDTO>? MusicasBandas { get; set; }

        // Fk (De cá pra lá);
        public List<BandaArtistaDTO>? BandasArtistas { get; set; }
    }
}
