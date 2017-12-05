using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalApplication_SongList
{
   public class SongListBusiness: IDisposable
    {
        ISongListRepository _songListRepository;

        public SongListBusiness(ISongListRepository repository)
        {
            _songListRepository = repository;
        }
        public void Insert(Song song)
        {
            _songListRepository.Insert(song);
        }
        public void Delete(int ID)
        {
            _songListRepository.Delete(ID);
        }
        public void Update(Song song)
        {
            _songListRepository.Update(song);
        }
        public Song SelectByID(int id)
        {
            return _songListRepository.SelectByID(id);
        }
        public List<Song> SelectAll()
        {
            return _songListRepository.SelectAll();
        }

        //Method to query the song list by Artist
        public List<Song> QueryByArtist(string artist)
        {
            List<Song> songs = _songListRepository.SelectAll();

            return songs.Where(s => s.Artist.Trim().ToUpper() == artist.Trim().ToUpper()).ToList();
        }

        //Method to query the song list by Album
        public List<Song> QueryByAlbum(string album)
        {
            List<Song> songs = _songListRepository.SelectAll();

            return songs.Where(s => s.Album.Trim().ToUpper() == album.Trim().ToUpper()).ToList();
        }

        //Method to query the song list by Genre
        public List<Song> QueryByGenre(string genre)
        {
            List<Song> songs = _songListRepository.SelectAll();

            return songs.Where(s => s.Genre.Trim().ToUpper() == genre.Trim().ToUpper()).ToList();
        }

        public void Dispose()
        {
            _songListRepository = null;
        }
    }
}
