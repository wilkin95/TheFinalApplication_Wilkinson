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

            while(active)
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
                    case AppEnum.ManagerAction.QuerySongByGenre:
                        QuerySongsByGenre();
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


            using (songListBusiness)
            {
                songs = songListBusiness.SelectAll();
                ConsoleView.DisplayAllSongs(songs);
                songID = ConsoleView.GetSongID(songs);
                song = songListBusiness.SelectByID(songID);
            }

            while (usingPlayer == true)
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
                    }
                    if (songID == 2)
                    {
                        myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\AngelsFall.wav";
                        myPlayer.Play();
                    }
                    if (songID == 3)
                    {
                        myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\TheSoundOfSilence.wav";
                        myPlayer.Play();
                    }
                    if (songID == 4)
                    {
                        myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\WrongSideOfHeaven.wav";
                        myPlayer.Play();
                    }
                    if (songID == 5)
                    {
                        myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\WashItAllAway.wav";
                        myPlayer.Play();
                    }
                    if (songID == 6)
                    {
                        myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\IfTodayWasYourLastDay.wav";
                        myPlayer.Play();
                    }
                    if (songID == 7)
                    {
                        myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\GottaBeSomebody.wav";
                        myPlayer.Play();
                    }
                    if (songID == 8)
                    {
                        myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\YouDontOwnMe.wav";
                        myPlayer.Play();
                    }
                    if (songID == 9)
                    {
                        myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\ComeWithMeNow.wav";
                        myPlayer.Play();
                    }
                    if (songID == 10)
                    {
                        myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\TheUnforgiven.wav";
                        myPlayer.Play();
                    }
                    if (songID == 11)
                    {
                        myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\Broken.wav";
                        myPlayer.Play();
                    }
                    if (songID == 12)
                    {
                        myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\Numb.wav";
                        myPlayer.Play();
                    }
                    if (songID == 13)
                    {
                        myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\InTheEnd.wav";
                        myPlayer.Play();
                    }
                    if (songID == 14)
                    {
                        myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\Radioactive.wav";
                        myPlayer.Play();
                    }
                    if (songID == 15)
                    {
                        myPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Controller\\GoToWar.wav";
                        myPlayer.Play();
                    }
                }
                if (songControl == 2)
                {
                    myPlayer.Stop();
                    usingPlayer = false;
                }
                //else
                //{
                //    Console.WriteLine("I'm sorry, there is not a music file for that song yet.");
                //    usingPlayer = false;
                //}
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
            Song song;

            song = ConsoleView.AddSong();
            using (songListBusiness)
            {
                songListBusiness.Insert(song);
            }
            ConsoleView.DisplayGoBackToMenu();
        }

        private static void UpdateSong()
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
                song = ConsoleView.UpdateSong(song);
                songListBusiness.Update(song);
            }
        }

        private static void DeleteSong()
        {
            SongListBusiness songListBusiness = new SongListBusiness(songListRepository);
            List<Song> songs;
            int songID;
            string message;

            using (songListBusiness)
            {
                songs = songListBusiness.SelectAll();
                songID = ConsoleView.GetSongID(songs);
               
                songListBusiness.Delete(songID);
            }
            ConsoleView.DisplayReset();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            message = String.Format("Song ID: {0} has been deleted.", songID);
            
            ConsoleView.DisplayMessage(message);
            ConsoleView.DisplayMessage(message);

            ConsoleView.DisplayGoBackToMenu();
        }

        private static void QuerySongsByArtist()
        {
            SongListBusiness songListBusiness = new SongListBusiness(songListRepository);

            List<Song> matchingSongs;
            

           string artist = ConsoleView.GetArtistQuery();
            
            using (songListBusiness)
            {
                matchingSongs = songListBusiness.QueryByArtist(artist);
            }
             ConsoleView.DisplayQueryResults(matchingSongs);
            ConsoleView.DisplayGoBackToMenu();

            }

        private static void QuerySongsByAlbum()
        {
            SongListBusiness songListBusiness = new SongListBusiness(songListRepository);

            List<Song> matchingSongs;


            string album = ConsoleView.GetAlbumQuery();

            using (songListBusiness)
            {
                matchingSongs = songListBusiness.QueryByAlbum(album);
            }
            ConsoleView.DisplayQueryResults(matchingSongs);
            ConsoleView.DisplayGoBackToMenu();

        }

        private static void QuerySongsByGenre()
        {
            SongListBusiness songListBusiness = new SongListBusiness(songListRepository);

            List<Song> matchingSongs;


            string genre = ConsoleView.GetGenreQuery();

            using (songListBusiness)
            {
                matchingSongs = songListBusiness.QueryByGenre(genre);
            }
            ConsoleView.DisplayQueryResults(matchingSongs);
            ConsoleView.DisplayGoBackToMenu();

        }
    }
    }
 
