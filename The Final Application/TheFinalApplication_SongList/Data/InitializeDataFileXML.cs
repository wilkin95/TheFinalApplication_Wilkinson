using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TheFinalApplication_SongList
{
     public class InitializeDataFileXML
    {
        public static void AddTestData()
        {
            List<Song> songs = new List<Song>();

           // initialize the IList of high scores - note: no instantiation for an interface
           // songs.Add(new SongList() { ID = 1, Title = "Failure", Artist = "Breaking Benjamin", Album = "Dark Before Dawn", Length = 340, Published = 03-23-2015, Genre = "Alternative Rock"});
             

            WriteAllSongs(songs, DataSettings.dataFilePath);
    }

        //method to write all song info to data file
        public static void WriteAllSongs(List<Song> songs, string dataFilePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Song>), new XmlRootAttribute("Song"));
            
            StreamWriter sWriter = new StreamWriter(dataFilePath);

            using (sWriter)
            {
                serializer.Serialize(sWriter, songs);
            }
        }
    }
}
