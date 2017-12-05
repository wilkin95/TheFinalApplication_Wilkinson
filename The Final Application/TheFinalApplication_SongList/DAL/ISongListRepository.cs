using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalApplication_SongList
{
   public interface ISongListRepository
    {
        List<Song> SelectAll();
        Song SelectByID(int id);
        void Insert(Song obj);
        void Update(Song obj);
        void Delete(int id);
        void Save();
    }
}
