using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace TheFinalApplication_SongList
{
    public class Controller
    {
        bool active = true;
        static ISongListRepository songListRepository;

        public Controller()
        {
            songListRepository = new SongListRepositoryXML();
            ApplicationControl();
        }

        private void ApplicationControl()
        {
            ConsoleView.DisplayWelcomeScreen();

            while (active)
            {
                AppEnum.ManagerAction userActionChoice;

                userActionChoice = ConsoleView.GetUserActionChoice();

                switch (userActionChoice)
                {
                    case AppEnum.ManagerAction.None:
                        break;
                    case AppEnum.ManagerAction.ListAllSongs:
                        ListAllSongs();
                        break;
                    case AppEnum.ManagerAction.DisplaySongDetail:
                        DisplaySongDetail();
                        break;
                    case AppEnum.ManagerAction.DeleteSong:
                        DeleteSong();
                        break;
                    case AppEnum.ManagerAction.AddSong:
                        AddSong();
                        break;
                    case AppEnum.ManagerAction.UpdateSong:
                        UpdateSong();
                        break;
                    case AppEnum.ManagerAction.QuerySongByArtist:
                        QuerySongsByArtist();
                        break;
                    case AppEnum.ManagerAction.QuerySongByAlbum:
                        QuerySongsByAlbum();
                        break;
                    case AppEnum.ManagerAction.SortSongByLength:
                        SortSongsByLength();
                        break;
                    case AppEnum.ManagerAction.PlaySong:
                        PlaySong();
                        break;
                    case AppEnum.ManagerAction.Quit:
                        active = false;
                        break;
                    default:
                        break;
                }
            }
            ConsoleView.DisplayExitPrompt();
        }

        private static void PlaySong()
        {
            var myPlayer = new System.Media.SoundPlayer();
            SongListBusiness songListBusiness = new SongListBusiness(songListRepository);
            List<Song> songs;
            Song song;
            int songID;
            bool usingPlayer = true;
            bool usingControls = false;

            using (songListBusiness)
            {
                songs = songListBusiness.SelectAll();
                ConsoleView.DisplayAllSongs(songs);
                songID = ConsoleView.GetSongID(songs);

                song = songListBusiness.SelectByID(songID);
            }

            while (usingPlayer == true)
            {

                while (!usingControls)
                {
                    Console.Clear();
                    ConsoleView.DisplaySong(song);

                    int songControl = ConsoleView.DisplaySongControls();

                    if (songControl == 1)
                    {
                        if (songID == 1)
                        {
                            myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\Failure.wav";
                            myPlayer.Play();
                            usingPlayer = true;
                            break;
                        }
                        if (songID == 2)
                        {
                            myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\AngelsFall.wav";
                            myPlayer.Play();
                            break;
                        }
                        if (songID == 3)
                        {
                            myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\TheSoundOfSilence.wav";
                            myPlayer.Play();
                            break;
                        }
                        if (songID == 4)
                        {
                            myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\WrongSideOfHeaven.wav";
                            myPlayer.Play();
                            break;
                        }
                        if (songID == 5)
                        {
                            myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\WashItAllAway.wav";
                            myPlayer.Play();
                            break;
                        }
                        if (songID == 6)
                        {
                            myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\IfTodayWasYourLastDay.wav";
                            myPlayer.Play();
                            break;
                        }
                        if (songID == 7)
                        {
                            myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\GottaBeSomebody.wav";
                            myPlayer.Play();
                            break;
                        }
                        if (songID == 8)
                        {
                            myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\YouDontOwnMe.wav";
                            myPlayer.Play();
                            break;
                        }
                        if (songID == 9)
                        {
                            myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\ComeWithMeNow.wav";
                            myPlayer.Play();
                            break;
                        }
                        if (songID == 10)
                        {
                            myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\TheUnforgiven.wav";
                            myPlayer.Play();
                            break;
                        }
                        if (songID == 11)
                        {
                            myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\Broken.wav";
                            myPlayer.Play();
                            break;
                        }
                        if (songID == 12)
                        {
                            myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\Numb.wav";
                            myPlayer.Play();
                            break;
                        }
                        if (songID == 13)
                        {
                            myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\InTheEnd.wav";
                            myPlayer.Play();
                            break;
                        }
                        if (songID == 14)
                        {
                            myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\Radioactive.wav";
                            myPlayer.Play();
                            break;
                        }
                        if (songID == 15)
                        {
                            myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\GoToWar.wav";
                            myPlayer.Play();
                            break;
                        }
                        else
                        {
                            ConsoleView.SongNotAvailableToPlay();
                            usingPlayer = false;
                        }
                        usingControls = true;
                    }
                    if (songControl == 2)
                    {
                        myPlayer.Stop();
                        usingPlayer = false;
                        usingControls = false;
                        break;
                    }

                }
            }
            ConsoleView.DisplayGoBackToMenu();

        }
        private static void ListAllSongs()
        {
            SongListBusiness songListBusiness = new SongListBusiness(songListRepository);
            List<Song> songs;

            using (songListBusiness)
            {
                songs = songListBusiness.SelectAll();
                ConsoleView.DisplayAllSongs(songs);
                ConsoleView.DisplayGoBackToMenu();
            }
        }



        private static void DisplaySongDetail()
        {
            SongListBusiness songListBusiness = new SongListBusiness(songListRepository);
            List<Song> songs;
            Song song;
            int songID;

            using (songListBusiness)
            {
                songs = songListBusiness.SelectAll();
                songID = ConsoleView.GetSongID(songs);
                song = songListBusiness.SelectByID(songID);
            }
            ConsoleView.DisplaySong(song);
            ConsoleView.DisplayGoBackToMenu();
        }

        private static void AddSong()
        {
            SongListBusiness songListBusiness = new SongListBusiness(songListRepository);
            List<Song> songs;
            Song song;


            using (songListBusiness)
            {
                songs = songListBusiness.SelectAll();
                song = ConsoleView.AddSong(songs);
                songListBusiness.Insert(song);
            }
            ConsoleView.DisplayGoBackToMenu();
        }

        private static void UpdateSong()
        {
            SongListBusiness songListBusiness = new SongListBusiness(songListRepository);
            List<Song> songs;
            Song editSong;
            int songID;
            bool exist = false;
            using (songListBusiness)
            {
                songs = songListBusiness.SelectAll();
                songID = ConsoleView.GetSongID(songs);
                foreach (Song song in songs)
                {
                    if (song.ID == songID)
                    {
                        editSong = songListBusiness.SelectByID(songID);
                        editSong = ConsoleView.UpdateSong(editSong);
                        songListBusiness.Update(editSong);
                        exist = true;
                    }                    
                }
                if (exist == false)
                {                     
                        Console.WriteLine(ConsoleUtil.Center("That song ID does not exist. ", 160));                    
                }

            }
            ConsoleView.DisplayGoBackToMenu();

        }

        private static void DeleteSong()
        {
            SongListBusiness songListBusiness = new SongListBusiness(songListRepository);
            List<Song> songs;
            int songID;
            string message;
            bool checkingSongs = true;

            using (songListBusiness)
            {

                songs = songListBusiness.SelectAll();
                songID = ConsoleView.GetSongID(songs);
                
                while (checkingSongs)
                {
                    foreach (Song song in songs)
                    {
                        if (song.ID == songID)
                        {
                            songListBusiness.Delete(songID);

                            ConsoleView.DisplayReset();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            message = String.Format("Song ID: {0} has been deleted.", songID);

                            ConsoleView.DisplayMessage(message);
                            checkingSongs = false;
                            break;
                        }

                    }
                    if (checkingSongs == true)
                    {
                        Console.WriteLine(ConsoleUtil.Center("That song ID does not exist. ", 160));
                        checkingSongs = false;
                        break;
                    }
                }

            }

            //Console.Write(ConsoleUtil.Center("Press any key to go back to menu.", 160));
            //ConsoleKeyInfo response = Console.ReadKey();
            //Console.CursorVisible = true;

             ConsoleView.DisplayGoBackToMenu();
        }

        private static void QuerySongsByArtist()
        {
            SongListBusiness songListBusiness = new SongListBusiness(songListRepository);

            List<Song> matchingSongs;


            string artist = ConsoleView.GetArtistQuery();
            if (artist != "")
            {
                using (songListBusiness)
                {
                    matchingSongs = songListBusiness.QueryByArtist(artist);
                }
                ConsoleView.DisplayQueryResults(matchingSongs);
            }
            else
            {
                Console.WriteLine();
                Console.Write(ConsoleUtil.Center("No name was entered.", 160));

            }
            ConsoleView.DisplayGoBackToMenu();

        }

        private static void QuerySongsByAlbum()
        {
            SongListBusiness songListBusiness = new SongListBusiness(songListRepository);

            List<Song> matchingSongs;


            string album = ConsoleView.GetAlbumQuery();
            if (album != "")
            {
                using (songListBusiness)
                {
                    matchingSongs = songListBusiness.QueryByAlbum(album);
                }
                ConsoleView.DisplayQueryResults(matchingSongs);
            }
            else
            {
                Console.WriteLine();
                Console.Write(ConsoleUtil.Center("No name was entered.", 160));

            }
            ConsoleView.DisplayGoBackToMenu();

        }

        private static void SortSongsByLength()
        {
            SongListBusiness songListBusiness = new SongListBusiness(songListRepository);

            List<Song> sortedSongs;

            using (songListBusiness)
            {
                sortedSongs = songListBusiness.SelectAll().OrderByDescending(s => s.Length).ToList();
            }
            ConsoleView.DisplayQueryResults(sortedSongs);
            ConsoleView.DisplayGoBackToMenu();

        }
    }
}

