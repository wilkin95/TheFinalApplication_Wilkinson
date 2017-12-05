using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalApplication_SongList
{
    // TODO rename your class to "Song"
    public class Song
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public int Length { get; set; }
        public DateTime Published { get; set; }
        public string Genre { get; set; }


        public Song()
        {

        }

        public Song(int ID, string Title, string Artist, string Album, int Length, DateTime Published, string Genre)
        {
            this.ID = ID;
            this.Title = Title;
            this.Artist = Artist;
            this.Album = Album;
            this.Length = Length;
            this.Published = Published;
            this.Genre = Genre;
        }


    }
    
}
