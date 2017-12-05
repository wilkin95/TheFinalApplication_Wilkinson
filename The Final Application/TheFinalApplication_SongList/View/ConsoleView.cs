﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalApplication_SongList;

namespace TheFinalApplication_SongList
{

    public static class ConsoleView
    {
        //window size
        private const int WINDOW_WIDTH = ViewSettings.WINDOW_WIDTH;
        private const int WINDOW_HEIGHT = ViewSettings.WINDOW_HEIGHT;

        //horizontal and vertical margins in console window for display
        private const int DISPLAY_HORIZONTAL_MARGIN = ViewSettings.DISPLAY_HORIZONTAL_MARGIN;
        private const int DISPLAY_VERTICAL_MARGIN = ViewSettings.DISPLAY_VERTICAL_MARGIN;
        private static object Cursor;

        #region METHODS

        //method to display the manager menu and get user's choice
        public static AppEnum.ManagerAction GetUserActionChoice()
        {
            AppEnum.ManagerAction userActionChoice = AppEnum.ManagerAction.None;

            //set a string variable with a length equal to the horizontal margin and filled with spaces
            string leftTab = ConsoleUtil.FillStringWithSpaces(DISPLAY_HORIZONTAL_MARGIN);

            //set up display area
            DisplayReset();

            //display the menu
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.Write(ConsoleUtil.Center("Song Manager Menu", WINDOW_WIDTH));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            DisplayMessage("");
            Console.ResetColor();
            Console.WriteLine(ConsoleUtil.Center("1. Display All Songs".PadRight(24), WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("2. Display Song Detail".PadRight(24), WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("3. Add a Song".PadRight(24), WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("4. Delete a Song".PadRight(24), WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("5. Edit a Song".PadRight(24), WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("6. Query Songs by Artist".PadRight(24), WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("7. Query Songs by Album".PadRight(24), WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("8. Query Songs by Genre".PadRight(24), WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("9. Play Song".PadRight(24), WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("E. Exit".PadRight(24), WINDOW_WIDTH));

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            DisplayMessage("");
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.Write(ConsoleUtil.Center("Enter the number/letter for the menu choice:".PadRight(24), WINDOW_WIDTH));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            Console.ResetColor();
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            Console.SetCursorPosition(left + 100, top + 1);
            ConsoleKeyInfo userResponse = Console.ReadKey(true);

            switch (userResponse.KeyChar)
            {
                case '1':
                    userActionChoice = AppEnum.ManagerAction.ListAllSongs;
                    break;
                case '2':
                    userActionChoice = AppEnum.ManagerAction.DisplaySongDetail;
                    break;
                case '3':
                    userActionChoice = AppEnum.ManagerAction.AddSong;
                    break;
                case '4':
                    userActionChoice = AppEnum.ManagerAction.DeleteSong;
                    break;
                case '5':
                    userActionChoice = AppEnum.ManagerAction.UpdateSong;
                    break;
                case '6':
                    userActionChoice = AppEnum.ManagerAction.QuerySongByArtist;
                    break;
                case '7':
                    userActionChoice = AppEnum.ManagerAction.QuerySongByAlbum;
                    break;
                case '8':
                    userActionChoice = AppEnum.ManagerAction.QuerySongByGenre;
                    break;
                case '9':
                    userActionChoice = AppEnum.ManagerAction.PlaySong;
                    break;
                case 'E':
                case 'e':
                    userActionChoice = AppEnum.ManagerAction.Quit;
                    break;
                default:
                    DisplayMessage("");
                    DisplayMessage("");
                    DisplayMessage("It appears you have selected an incorrect choice.");
                    DisplayMessage("");
                    DisplayMessage("Press any key to try again or the ESC key to exit.");

                    userResponse = Console.ReadKey(true);
                    if (userResponse.Key == ConsoleKey.Escape)
                    {
                        userActionChoice = AppEnum.ManagerAction.Quit;
                    }
                    break;
            }
            return userActionChoice;
        }

        //method to display all song info
        public static void DisplayAllSongs(List<Song> songs)
        {
            DisplayReset();
            Console.WriteLine(ConsoleUtil.Center("Display All Songs", WINDOW_WIDTH));
            // DisplayMessage("All of the existing songs are displayed below.");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            StringBuilder columnHeader = new StringBuilder();
            columnHeader.Append("ID".PadRight(8));
            columnHeader.Append("Song".PadRight(40));
            columnHeader.Append("Artist".PadRight(40));
            columnHeader.Append("Album".PadRight(55));
            columnHeader.Append("Length".PadRight(15));
            columnHeader.Append("Genre".PadRight(20));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.Write(ConsoleUtil.Center(columnHeader.ToString(), WINDOW_WIDTH));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            // DisplayMessage(columnHeader.ToString());
            DisplayMessage("");
            Console.ResetColor();
            foreach (Song song in songs)
            {
                StringBuilder songListInfo = new StringBuilder();
                songListInfo.Append(song.ID.ToString().PadRight(8));
                songListInfo.Append(song.Title.PadRight(40));
                songListInfo.Append(song.Artist.PadRight(40));
                songListInfo.Append(song.Album.PadRight(55));
                songListInfo.Append(song.Length.ToString().PadRight(15));
                songListInfo.Append(song.Genre.PadRight(20));

                Console.Write(ConsoleUtil.Center(songListInfo.ToString(), WINDOW_WIDTH));

                //  DisplayMessage(songListInfo.ToString());
            }
        }

         
        //method to get user's choice of song id
        public static int GetSongID(List<Song> songs)
        {
             int songID = -1;
            
                DisplayReset();
            Console.CursorVisible = true;
                DisplayAllSongs(songs);
                DisplayMessage("");
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
                //   DisplayPromptMessage("Enter the song ID: ");
                Console.Write(ConsoleUtil.Center("Enter the song ID: ", WINDOW_WIDTH));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            Console.ResetColor();
            Console.SetCursorPosition(left + 100, top +1);
         
            songID = ConsoleUtil.ValidateSongIDIntegerResponse(songs,"Enter the song ID and hit ENTER: ", Console.ReadLine());
            
            return songID;
        }

        //method to display song info
        public static void DisplaySong(Song song)
        {
            
            
            DisplayReset();
             DisplayMessage("");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.Write(ConsoleUtil.Center("Song Detail", WINDOW_WIDTH));
            
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            DisplayMessage("");
            Console.ResetColor();

            string id = String.Format("ID: {0}", song.ID.ToString());
            Console.WriteLine(ConsoleUtil.Center(id.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string title = String.Format("Title: {0}", song.Title);
            Console.WriteLine(ConsoleUtil.Center(title.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string artist = String.Format("Artist: {0}", song.Artist);
            Console.WriteLine(ConsoleUtil.Center(artist.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string album = String.Format("Album: {0}", song.Album);
            Console.WriteLine(ConsoleUtil.Center(album.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string length = String.Format("Length: {0}", song.Length.ToString());
            Console.WriteLine(ConsoleUtil.Center(length.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string genre = String.Format("Genre: {0}", song.Genre);
            Console.WriteLine(ConsoleUtil.Center(genre.PadRight(30), WINDOW_WIDTH));
        }

        //method to display song info
        public static void DisplayUpdatedSong(Song song)
        {
            DisplayReset();
            DisplayMessage("");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.Write(ConsoleUtil.Center("Updated Song Detail", WINDOW_WIDTH));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            DisplayMessage("");
            Console.ResetColor();

            string id = String.Format("ID: {0}", song.ID.ToString());
            Console.WriteLine(ConsoleUtil.Center(id.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string title = String.Format("Title: {0}", song.Title);
            Console.WriteLine(ConsoleUtil.Center(title.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string artist = String.Format("Artist: {0}", song.Artist);
            Console.WriteLine(ConsoleUtil.Center(artist.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string album = String.Format("Album: {0}", song.Album);
            Console.WriteLine(ConsoleUtil.Center(album.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string length = String.Format("Length: {0}", song.Length.ToString());
            Console.WriteLine(ConsoleUtil.Center(length.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string genre = String.Format("Genre: {0}", song.Genre);
            Console.WriteLine(ConsoleUtil.Center(genre.PadRight(30), WINDOW_WIDTH));

            Console.WriteLine();
            Console.WriteLine();
             Console.WriteLine(ConsoleUtil.Center("**********  YOUR SONG HAS BEEN UPDATED  **********", WINDOW_WIDTH));

        }


        //method to add song info
        public static Song AddSong()
        {
            Song song = new Song();

            DisplayReset();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.Write(ConsoleUtil.Center("Add a Song", WINDOW_WIDTH));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.ResetColor();
            DisplayMessage("");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            

            Console.Write(ConsoleUtil.CenterPrompt("Enter the song ID: ".PadRight(25), WINDOW_WIDTH));
     
            song.ID = ConsoleUtil.ValidateIntegerResponse("Please enter the song ID: ", Console.ReadLine());
            DisplayMessage("");

            Console.Write(ConsoleUtil.CenterPrompt("Enter the song Title: ".PadRight(25), WINDOW_WIDTH));
            song.Title = ConsoleUtil.ValidateStringResponse("Enter the song Title: ", Console.ReadLine());
            DisplayMessage("");

            Console.Write(ConsoleUtil.CenterPrompt("Enter the song Artist: ".PadRight(25), WINDOW_WIDTH));
            song.Artist = ConsoleUtil.ValidateStringResponse("Enter the song Artist: ", Console.ReadLine());
            DisplayMessage("");

            Console.Write(ConsoleUtil.CenterPrompt("Enter the song Album: ".PadRight(25), WINDOW_WIDTH));
            song.Album = ConsoleUtil.ValidateStringResponse("Enter the song Album: ", Console.ReadLine());
            DisplayMessage("");

            Console.Write(ConsoleUtil.CenterPrompt("Enter the song Length: ".PadRight(25), WINDOW_WIDTH));
            song.Length = ConsoleUtil.ValidateIntegerResponse("Enter the song Length: ", Console.ReadLine());
            DisplayMessage("");

            Console.Write(ConsoleUtil.CenterPrompt("Enter the song Genre: ".PadRight(25), WINDOW_WIDTH));
            song.Genre = ConsoleUtil.ValidateStringResponse("Enter the song Genre: ", Console.ReadLine());
            DisplayMessage("");
            DisplayMessage("");

            Console.Write(ConsoleUtil.CenterPrompt("*****  The song has been added to your library.  *****", WINDOW_WIDTH));

            return song;
        }

        public static Song UpdateSong(Song song)
        {
             DisplayReset();
            UpdateSongTitle(song);
            UpdateSongArtist(song);
            UpdateSongAlbum(song);
            UpdateSongLength(song);
            UpdateSongGenre(song);
            DisplayUpdatedSong(song);

            DisplayGoBackToMenu();
            return song;
        }

        public static Song UpdateSongTitle(Song song)
        {
            string userResponse;
            DisplayReset();

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.Write(ConsoleUtil.Center("Edit a Song", WINDOW_WIDTH));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.ResetColor();
            DisplayMessage("");
            string id = String.Format("ID: {0}", song.ID.ToString());
            Console.WriteLine(ConsoleUtil.Center(id.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
 
            string title = String.Format("Current Title: {0}", song.Title);
            Console.WriteLine(ConsoleUtil.Center(title, WINDOW_WIDTH));
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(ConsoleUtil.CenterPrompt("Enter a new song title or just press \"Enter\" to keep the current title: ", WINDOW_WIDTH));
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                song.Title = userResponse;
            }

            return song;
        }

        public static Song UpdateSongArtist(Song song)
        {
            string userResponse;
            DisplayReset();

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.Write(ConsoleUtil.Center("Edit a Song", WINDOW_WIDTH));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.ResetColor();
            DisplayMessage("");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            string id = String.Format("ID: {0}", song.ID.ToString());
            Console.WriteLine(ConsoleUtil.Center(id.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string title = String.Format("Title: {0}", song.Title);
            Console.WriteLine(ConsoleUtil.Center(title.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            string artist = String.Format("Current Artist: {0}", song.Artist);
            Console.WriteLine(ConsoleUtil.Center(artist, WINDOW_WIDTH));
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(ConsoleUtil.CenterPrompt("Enter a new song artist or just press \"Enter\" to keep the current artist: ", WINDOW_WIDTH));
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                song.Artist = userResponse;
            }

            return song;
        }

        public static Song UpdateSongAlbum(Song song)
        {
            string userResponse;
            DisplayReset();

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.Write(ConsoleUtil.Center("Edit a Song", WINDOW_WIDTH));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.ResetColor();
            DisplayMessage("");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            string id = String.Format("ID: {0}", song.ID.ToString());
            Console.WriteLine(ConsoleUtil.Center(id.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string title = String.Format("Title: {0}", song.Title);
            Console.WriteLine(ConsoleUtil.Center(title.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string artist = String.Format("Artist: {0}", song.Artist);
            Console.WriteLine(ConsoleUtil.Center(artist.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            string album = String.Format("Current Album: {0}", song.Album);
            Console.WriteLine(ConsoleUtil.Center(album, WINDOW_WIDTH));
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(ConsoleUtil.CenterPrompt("Enter a new song album or just press \"Enter\" to keep the current album: ", WINDOW_WIDTH));
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                song.Album = userResponse;
            }

            return song;
        }

        public static Song UpdateSongLength(Song song)
        {
            DisplayReset();

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.Write(ConsoleUtil.Center("Edit a Song", WINDOW_WIDTH));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.ResetColor();
            DisplayMessage("");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            string id = String.Format("ID: {0}", song.ID.ToString());
            Console.WriteLine(ConsoleUtil.Center(id.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string title = String.Format("Title: {0}", song.Title);
            Console.WriteLine(ConsoleUtil.Center(title.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string artist = String.Format("Artist: {0}", song.Artist);
            Console.WriteLine(ConsoleUtil.Center(artist.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string album = String.Format("Album: {0}", song.Album);
            Console.WriteLine(ConsoleUtil.Center(album.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            string length = String.Format("Current Length: {0}", song.Length);
            Console.WriteLine(ConsoleUtil.Center(length, WINDOW_WIDTH));
            Console.WriteLine();
            Console.WriteLine();
            int songLength = -1;

            Console.Write(ConsoleUtil.CenterPrompt("Enter a new song length or just press \"Enter\" to keep the current length: ", WINDOW_WIDTH));
            string userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                songLength = ConsoleUtil.ValidateIntegerResponse("Enter the song Length: ", userResponse);
                if (songLength != -1)
                {
                    song.Length = songLength;
                }
            }
            return song;
        }

        public static Song UpdateSongGenre(Song song)
        {
            DisplayReset();
            string userResponse;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.Write(ConsoleUtil.Center("Edit a Song", WINDOW_WIDTH));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.ResetColor();
            DisplayMessage("");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            string id = String.Format("ID: {0}", song.ID.ToString());
            Console.WriteLine(ConsoleUtil.Center(id.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string title = String.Format("Title: {0}", song.Title);
            Console.WriteLine(ConsoleUtil.Center(title.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string artist = String.Format("Artist: {0}", song.Artist);
            Console.WriteLine(ConsoleUtil.Center(artist.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string album = String.Format("Album: {0}", song.Album);
            Console.WriteLine(ConsoleUtil.Center(album.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
            string length = String.Format("Length: {0}", song.Length.ToString());
            Console.WriteLine(ConsoleUtil.Center(length.PadRight(30), WINDOW_WIDTH));
            Console.WriteLine();
      
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            string genre = String.Format("Current Genre: {0}", song.Genre);
            Console.WriteLine(ConsoleUtil.Center(genre, WINDOW_WIDTH));
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(ConsoleUtil.CenterPrompt("Enter a new song genre or just press \"Enter\" to keep the current genre: ", WINDOW_WIDTH));
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                song.Genre = userResponse;
            }

            return song;
        }

        public static string GetGenreQuery()
        {
            string genre = "";
            string userResponse = "";
            DisplayReset();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.Write(ConsoleUtil.Center("Query Songs by Genre", WINDOW_WIDTH));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.Write(ConsoleUtil.CenterPrompt("Enter the Genre to query: ", WINDOW_WIDTH));
            userResponse = Console.ReadLine().Trim().ToUpper();
            if (userResponse != "")
            {
                genre = userResponse;
            }
            return genre;
        }


        public static string GetAlbumQuery()
        {
            string album = "";
            string userResponse = "";
            DisplayReset();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.Write(ConsoleUtil.Center("Query Songs by Album", WINDOW_WIDTH));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.Write(ConsoleUtil.CenterPrompt("Enter the album name to query: ", WINDOW_WIDTH));
            userResponse = Console.ReadLine().Trim().ToUpper();
            if (userResponse != "")
            {
                album = userResponse;
            }
            return album;
        }


        public static string GetArtistQuery()
        {
            string artist = "";
            string userResponse = "";
            DisplayReset();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.Write(ConsoleUtil.Center("Query Songs by Artist", WINDOW_WIDTH));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.Write(ConsoleUtil.CenterPrompt("Enter the artist name to query: ", WINDOW_WIDTH));
            userResponse = Console.ReadLine().Trim().ToUpper();
            if (userResponse != "")
            {
                artist = userResponse;
            }
            return artist;
        }

        public static void DisplayQueryResults(List<Song> matchingSongs)
        {
            DisplayReset();
            DisplayMessage("");

            Console.Write(ConsoleUtil.Center("Song Query Results", WINDOW_WIDTH));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            StringBuilder columnHeader = new StringBuilder();
            columnHeader.Append("ID".PadRight(8));
            columnHeader.Append("Song".PadRight(40));
            columnHeader.Append("Artist".PadRight(40));
            columnHeader.Append("Album".PadRight(55));
            columnHeader.Append("Length".PadRight(15));
            columnHeader.Append("Genre".PadRight(20));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.Write(ConsoleUtil.Center(columnHeader.ToString(), WINDOW_WIDTH));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            Console.ResetColor();
            foreach (Song song in matchingSongs)
            {
                Console.WriteLine();
                StringBuilder songInfo = new StringBuilder();
                songInfo.Append(song.ID.ToString().PadRight(8));
                songInfo.Append(song.Title.PadRight(40));
                songInfo.Append(song.Artist.PadRight(40));
                songInfo.Append(song.Album.PadRight(55));
                songInfo.Append(song.Length.ToString().PadRight(15));
                songInfo.Append(song.Genre.PadRight(20));

                Console.Write(ConsoleUtil.Center(songInfo.ToString(), WINDOW_WIDTH));

            }
            Console.WriteLine();
        }


        //method to display song controls
        public static int DisplaySongControls()
        {
            Console.CursorVisible = true;
            Console.WriteLine();
            bool validResponse = true;
            int controlChoice = -1;

            while (validResponse)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write(ConsoleUtil.Center("Type 1 to PLAY song or 2 to STOP song.", WINDOW_WIDTH));
                controlChoice = ConsoleUtil.ValidateIntegerResponse("Please enter 1 to PLAY song or 2 to STOP song: ", Console.ReadLine());

                if (controlChoice == 1 || controlChoice == 2)
                {
                    validResponse = false;
                }
                else
                {
                    Console.WriteLine("That is not a valid response.");
                }
            }
            Console.ResetColor();

            return controlChoice;

        }

        //reset display
        public static void DisplayReset()
        {
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);
            Console.Clear();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("The Song List Library", WINDOW_WIDTH));
            //  Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            Console.ResetColor();
            Console.WriteLine();
        }

        //display the continue prompt
        public static void DisplayGoBackToMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.Write(ConsoleUtil.Center("Press any key to go back to menu.", WINDOW_WIDTH));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            ConsoleKeyInfo response = Console.ReadKey();
            Console.CursorVisible = true;
            Console.ResetColor();
        }

        //display the continue prompt
        public static void DisplayContinuePrompt()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.Write(ConsoleUtil.Center("Press any key to continue.", WINDOW_WIDTH));
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            ConsoleKeyInfo response = Console.ReadKey();
            Console.CursorVisible = true;
            Console.ResetColor();
        }

        //display exit prompt
        public static void DisplayExitPrompt()
        {
            DisplayReset();
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            DisplayMessage("Thank you for using the Song Application. Press any key to Exit.");
            Console.Write(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.ResetColor();

            Console.ReadKey();
            System.Environment.Exit(1);
        }

        //display welcome screen
        public static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH -80));
            Console.WriteLine(ConsoleUtil.Center("Welcome to", WINDOW_WIDTH - 80));
            Console.WriteLine(ConsoleUtil.Center("The Song List Library", WINDOW_WIDTH - 80));
            //  Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.ResetColor();
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        //display a message in message area
        public static void DisplayMessage(string message)
        {
            //calculate message area on console window
            const int MESSAGE_BOX_TEXT_LENGTH = WINDOW_WIDTH - (2 * DISPLAY_HORIZONTAL_MARGIN);
            const int MESSAGE_BOX_HORIZONTAL_MARGIN = DISPLAY_HORIZONTAL_MARGIN;

            // message is not an empty line, display text
            if (message != "")
            {
                //
                // create a list of strings to hold the wrapped text message
                //
                List<string> messageLines;

                //
                // call utility method to wrap text and loop through list of strings to display
                //
                messageLines = ConsoleUtil.Wrap(message, MESSAGE_BOX_TEXT_LENGTH, MESSAGE_BOX_HORIZONTAL_MARGIN);
                foreach (var messageLine in messageLines)
                {
                    Console.Write(ConsoleUtil.Center(message, WINDOW_WIDTH));
                    // Console.WriteLine(messageLine);
                }
            }
            // display an empty line
            else
            {
                Console.WriteLine();
            }
        }

        //display a message in message area
   

        //display a message without new line for prompt
        public static void DisplayPromptMessage(string message)
        {
            //
            // calculate the message area location on the console window
            //
            const int MESSAGE_BOX_TEXT_LENGTH = WINDOW_WIDTH - (2 * DISPLAY_HORIZONTAL_MARGIN);
            const int MESSAGE_BOX_HORIZONTAL_MARGIN = DISPLAY_HORIZONTAL_MARGIN;

            //
            // create a list of strings to hold the wrapped text message
            //
            List<string> messageLines;

            //
            // call utility method to wrap text and loop through list of strings to display
            //
            messageLines = ConsoleUtil.Wrap(message, MESSAGE_BOX_TEXT_LENGTH, MESSAGE_BOX_HORIZONTAL_MARGIN);

            for (int lineNumber = 0; lineNumber < messageLines.Count() - 1; lineNumber++)
            {
                Console.WriteLine(messageLines[lineNumber]);
            }

            Console.Write(messageLines[messageLines.Count() - 1]);
        }

    }
}

#endregion