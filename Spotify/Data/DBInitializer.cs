﻿using Spotify.Models;
using static Biblioteca.Biblioteca;

namespace Spotify.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Context context)
        {
            // Exclui o esquema, copia as queries, cria esquema/tabelas, popula o BD;
            bool resetarBd = false;
            if (resetarBd)
            {
                context.Database.EnsureDeleted(); // Excluir o esquema e as tabelas;
                // string sqlErro = context.Database.GenerateCreateScript(); // Query para criar as tabelas;
                context.Database.EnsureCreated(); // Recriar o esquema e as tabelas;

                Seed(context);
            }
        }

        public static void Seed(Context context)
        {
            // Hora atual;
            DateTime dataAgora = HorarioBrasilia();

            #region seed_usuarios
            if (!context.UsuariosTipos.Any())
            {
                context.UsuariosTipos.Add(new UsuarioTipo() { UsuarioTipoId = 1, Tipo = "Administrador", Descricao = "Administrador do sistema", IsAtivo = 1, DataCriacao = dataAgora });
                context.UsuariosTipos.Add(new UsuarioTipo() { UsuarioTipoId = 2, Tipo = "Usuário", Descricao = "Usuário comum", IsAtivo = 1, DataCriacao = dataAgora });
            }

            if (!context.Usuarios.Any())
            {
                context.Usuarios.Add(new Usuario() { UsuarioId = 1, NomeCompleto = "Administrador", Email = "adm@Hotmail.com", NomeUsuarioSistema = "adm", Senha = Criptografar("123"), DataCriacao = dataAgora, UsuarioTipoId = 1, Foto = "", IsAtivo = 1, IsPremium = 1, IsVerificado = 1 });
                context.Usuarios.Add(new Usuario() { UsuarioId = 2, NomeCompleto = "Junior", Email = "juninholorena@Hotmail.com", NomeUsuarioSistema = "junioranheu", Senha = Criptografar("123"), DataCriacao = dataAgora, UsuarioTipoId = 2, Foto = "", IsAtivo = 1, IsPremium = 1, IsVerificado = 1 });
            }

            if (!context.UsuariosInformacoes.Any())
            {
                context.UsuariosInformacoes.Add(new UsuarioInformacao()
                {
                    UsuarioInformacaoId = 1,
                    UsuarioId = 2,
                    Genero = 1,
                    DataAniversario = dataAgora,
                    CPF = "44571955880",
                    Telefone = "12 98271-3939",
                    Rua = "José Benedito Ferrari",
                    NumeroResidencia = "480",
                    CEP = "12605-110",
                    Bairro = "Vila Passos",
                    DataUltimaAlteracao = null
                });
            }
            #endregion

            #region seed_musicas
            if (!context.Artistas.Any())
            {
                context.Artistas.Add(new Artista() { ArtistaId = 1, Nome = "Freddie Mercury", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 2, Nome = "Brian May", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 3, Nome = "John Deacon", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 4, Nome = "Mike Grose", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 5, Nome = "Liam Gallagher", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 6, Nome = "Noel Gallagher", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 7, Nome = "Alex Turner", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 8, Nome = "Matt Helders", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 9, Nome = "Kevin Parker", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 10, Nome = "Matt Shultz", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 11, Nome = "Julian Casablancas", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 12, Nome = "Albert Hammond Jr", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 13, Nome = "Fabrizio Moretti", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 14, Nome = "Nikolai Fraiture", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 15, Nome = "James Mercer", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 16, Nome = "Danger Mouse", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 17, Nome = "Joe Newman", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 18, Nome = "Gus Under-Hamilton", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 19, Nome = "Jesse Rutherford", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 20, Nome = "Harry Styles", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 21, Nome = "Zayn Malik", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 22, Nome = "Liam Payne", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 23, Nome = "Louis Tomlison", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 24, Nome = "Niall Horan", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 25, Nome = "Billie Eilish", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 26, Nome = "Chaleco Israel", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 27, Nome = "Junior", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
            }

            if (!context.Bandas.Any())
            {
                context.Bandas.Add(new Banda() { BandaId = 1, Nome = "Queen", Sobre = "", Foto = "1.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 2, Nome = "Oasis", Sobre = "", Foto = "2.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 3, Nome = "Arctic Monkeys", Sobre = "", Foto = "3.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 4, Nome = "Tame Impala", Sobre = "", Foto = "4.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 5, Nome = "Cage The Elephant", Sobre = "", Foto = "5.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 6, Nome = "The Strokes", Sobre = "", Foto = "6.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 7, Nome = "Broken Bells", Sobre = "", Foto = "7.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 8, Nome = "The Shins", Sobre = "", Foto = "8.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 9, Nome = "alt-J", Sobre = "", Foto = "9.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 10, Nome = "The Neighbourhood", Foto = "10.webp", Sobre = "", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 11, Nome = "One Direction", Sobre = "", Foto = "11.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 12, Nome = "Harry Styles", Sobre = "", Foto = "12.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 13, Nome = "Billie Eilish", Sobre = "", Foto = "13.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 14, Nome = "Zayn", Sobre = "", Foto = "14.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 15, Nome = "Chaleco's Group", Sobre = "", Foto = "15.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
            }

            if (!context.BandasArtistas.Any())
            {
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 1, BandaId = 1, ArtistaId = 1, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 2, BandaId = 1, ArtistaId = 2, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 3, BandaId = 1, ArtistaId = 3, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 4, BandaId = 1, ArtistaId = 4, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 5, BandaId = 2, ArtistaId = 5, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 6, BandaId = 2, ArtistaId = 6, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 7, BandaId = 3, ArtistaId = 7, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 8, BandaId = 3, ArtistaId = 8, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 9, BandaId = 4, ArtistaId = 9, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 10, BandaId = 5, ArtistaId = 10, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 11, BandaId = 6, ArtistaId = 11, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 12, BandaId = 6, ArtistaId = 12, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 13, BandaId = 6, ArtistaId = 13, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 14, BandaId = 6, ArtistaId = 14, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 15, BandaId = 7, ArtistaId = 15, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 16, BandaId = 7, ArtistaId = 16, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 17, BandaId = 8, ArtistaId = 15, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 18, BandaId = 9, ArtistaId = 17, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 19, BandaId = 9, ArtistaId = 18, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 20, BandaId = 10, ArtistaId = 19, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 21, BandaId = 11, ArtistaId = 20, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 22, BandaId = 11, ArtistaId = 21, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 23, BandaId = 11, ArtistaId = 22, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 24, BandaId = 11, ArtistaId = 23, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 25, BandaId = 11, ArtistaId = 24, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 26, BandaId = 12, ArtistaId = 20, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 27, BandaId = 13, ArtistaId = 25, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 28, BandaId = 14, ArtistaId = 21, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 29, BandaId = 15, ArtistaId = 26, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 30, BandaId = 15, ArtistaId = 27, IsAtivo = 1, DataRegistro = dataAgora });
            }

            if (!context.Musicas.Any())
            {
                context.Musicas.Add(new Musica() { MusicaId = 1, Nome = "Bohemian Rhapsody", Ouvintes = 0, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 2, Nome = "Live forever", Ouvintes = 0, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 3, Nome = "Happier than ever", Ouvintes = 0, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 4, Nome = "E aí, gordo", Ouvintes = 0, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 5, Nome = "Is This It", Ouvintes = 0, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 6, Nome = "Soma", Ouvintes = 0, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 7, Nome = "Fluorescent Adolescent", Ouvintes = 0, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 8, Nome = "505", Ouvintes = 0, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
            }

            if (!context.MusicasBandas.Any())
            {
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 1, MusicaId = 1, BandaId = 1, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 2, MusicaId = 2, BandaId = 2, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 3, MusicaId = 3, BandaId = 13, IsAtivo = 1, DataRegistro = dataAgora });

                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 4, MusicaId = 4, BandaId = 15, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 5, MusicaId = 4, BandaId = 13, IsAtivo = 1, DataRegistro = dataAgora });

                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 6, MusicaId = 5, BandaId = 6, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 7, MusicaId = 6, BandaId = 6, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 8, MusicaId = 7, BandaId = 3, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 9, MusicaId = 8, BandaId = 3, IsAtivo = 1, DataRegistro = dataAgora });
            }

            if (!context.Albuns.Any())
            {
                context.Albuns.Add(new Album() { AlbumId = 1, Nome = "Is This It", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 6, IsAtivo = 1, DataRegistro = dataAgora });
                context.Albuns.Add(new Album() { AlbumId = 2, Nome = "Favourite Worst Nightmare", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 3, IsAtivo = 1, DataRegistro = dataAgora });
            }

            if (!context.AlbunsMusicas.Any())
            {
                context.AlbunsMusicas.Add(new AlbumMusica() { AlbumMusicaId = 1, AlbumId = 1, MusicaId = 5, IsAtivo = 1, DataRegistro = dataAgora });
                context.AlbunsMusicas.Add(new AlbumMusica() { AlbumMusicaId = 2, AlbumId = 1, MusicaId = 6, IsAtivo = 1, DataRegistro = dataAgora });

                context.AlbunsMusicas.Add(new AlbumMusica() { AlbumMusicaId = 3, AlbumId = 2, MusicaId = 7, IsAtivo = 1, DataRegistro = dataAgora });
                context.AlbunsMusicas.Add(new AlbumMusica() { AlbumMusicaId = 4, AlbumId = 2, MusicaId = 8, IsAtivo = 1, DataRegistro = dataAgora });
            }
            #endregion

            context.SaveChanges();
        }
    }
}

