using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalApplication_SongList
{
   public class AppEnum
    {
        public enum ManagerAction
        {
            None,
            ListAllSongs,
            DisplaySongDetail,
            DeleteSong,
            AddSong,
            UpdateSong,
            QuerySongByArtist,
            QuerySongByAlbum,
            QuerySongByGenre,
            PlaySong,
            Quit
     
        }
    }
}
