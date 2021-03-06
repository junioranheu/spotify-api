using Microsoft.EntityFrameworkCore;
using Spotify.Data;
using Spotify.Interfaces;
using Spotify.Models;

namespace Spotify.Repositories
{
    public class MusicaRepository : IMusicaRepository
    {
        public readonly Context _context;

        public MusicaRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Musica>> GetTodos()
        {
            var itens = await _context.Musicas.
                Include(mb => mb.MusicasBandas).ThenInclude(b => b.Bandas).
                ThenInclude(ba => ba.BandasArtistas).ThenInclude(a => a.Artistas).
                Include(am => am.AlbunsMusicas).ThenInclude(a => a.Albuns).
                OrderBy(n => n.Nome).AsNoTracking().ToListAsync();

            return itens;
        }

        public async Task<Musica> GetPorId(int id)
        {
            var item = await _context.Musicas.
                Include(mb => mb.MusicasBandas).ThenInclude(b => b.Bandas).
                ThenInclude(ba => ba.BandasArtistas).ThenInclude(a => a.Artistas).
                Include(am => am.AlbunsMusicas).ThenInclude(a => a.Albuns).
                Where(m => m.MusicaId == id).AsNoTracking().FirstOrDefaultAsync();

            return item;
        }

        public async Task<List<Musica>> GetPorPlaylist(int id)
        {
            var item = await _context.Musicas.
            Include(pm => pm.PlaylistsMusicas).ThenInclude(m => m.Playlists).

            Include(mb => mb.MusicasBandas).ThenInclude(b => b.Bandas).
            ThenInclude(ba => ba.BandasArtistas).ThenInclude(a => a.Artistas).
            Include(am => am.AlbunsMusicas).ThenInclude(a => a.Albuns).

            Where(p => p.IsAtivo == 1 && p.PlaylistsMusicas.All(z => z.PlaylistId == id)).AsNoTracking().ToListAsync();

            return item;
        }

        public async Task<int> PostCriar(Musica musica)
        {
            _context.Add(musica);
            var isOk = await _context.SaveChangesAsync();

            return isOk;
        }

        public async Task<int> PostAtualizar(Musica musica)
        {
            int isOk;

            try
            {
                _context.Update(musica);
                isOk = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return isOk;
        }

        public async Task<int> PostDeletar(int id)
        {
            var dados = await _context.Musicas.FindAsync(id);

            if (dados == null)
            {
                throw new Exception("Registro com o id " + id + " não foi encontrado");
            }

            _context.Musicas.Remove(dados);
            var isOk = await _context.SaveChangesAsync();

            return isOk;
        }

        private async Task<bool> IsExiste(int id)
        {
            return await _context.Musicas.AnyAsync(m => m.MusicaId == id);
        }

        public async Task<int> PostIncrementarOuvinte(int musicaId)
        {
            int isOk;

            try
            {
                var musica = await _context.Musicas.Where(m => m.MusicaId == musicaId).AsNoTracking().FirstOrDefaultAsync();

                if (musica == null)
                {
                    throw new Exception($"Nenhuma música foi encontrada com o id {musicaId}");
                }

                musica.Ouvintes += 1;

                _context.Update(musica);
                isOk = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return isOk;
        }

        public async Task<List<Musica>> GetPorPalavraChave(string palavraChave)
        {
            var item = await _context.Musicas.
            Include(pm => pm.PlaylistsMusicas).ThenInclude(m => m.Playlists).
            Include(mb => mb.MusicasBandas).ThenInclude(b => b.Bandas).ThenInclude(ba => ba.BandasArtistas).ThenInclude(a => a.Artistas).
            Include(am => am.AlbunsMusicas).ThenInclude(a => a.Albuns).

            Where(p => p.IsAtivo == 1 && (
                                            p.Nome.Contains(palavraChave) || // Nome da música;
                                            p.MusicasBandas.All(z => z.Bandas.Nome.Contains(palavraChave)) // Nome da banda;
                                         )).AsNoTracking().ToListAsync();

            return item;
        }
    }
}
