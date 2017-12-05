using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TheFinalApplication_SongList
{
    //method to write all song list info to the data file
   public class SongListRepositoryXML : IDisposable, ISongListRepository
    {
        private List<Song> _songs;

        public SongListRepositoryXML()
        {
            _songs = ReadSongListData(DataSettings.dataFilePath);
        }

        //method to read song list info from the data file and return it as a list of song list objects
        public List<Song> ReadSongListData(string dataFilePath)
        {
            List<Song> songs;

            // TODO Change your root to "Songs"
            XmlSerializer serializer = new XmlSerializer(typeof(List<Song>), new XmlRootAttribute("Songs"));

            using (FileStream stream = File.OpenRead(DataSettings.dataFilePath))
            {
                songs = (List<Song>)serializer.Deserialize(stream);
            }
            return songs;
        }

        //method to write all of the list of songs to the XML file
        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Song>), new XmlRootAttribute("Song"));

            using (FileStream stream = File.OpenWrite(DataSettings.dataFilePath))
            {
                serializer.Serialize(stream, _songs);
            }
        }

        //method to add a new song
        public void Insert(Song song)
        {
            _songs.Add(song);
            Save();
        }

        //method to delete a song by ID
        public void Delete(int ID)
        {
            _songs.RemoveAll(s => s.ID == ID);
            Save();
        }

        //method to update an existing song
        public void Update(Song song)
        {
            Delete(song.ID);
            Insert(song);
            Save();
        }

        //method to return a song object given the ID
        public Song SelectByID(int ID)
        {
            Song song = null;

            song = _songs.FirstOrDefault(s => s.ID == ID);

            return song;
        }

        //method to return a list of song objects
        public List<Song> SelectAll()
        {
            return _songs;
        }

        //method to handle the IDisposable interface contract
        public void Dispose()
        {
            _songs = null;
        }
    }
}
