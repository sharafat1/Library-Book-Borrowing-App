using System;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace assign_cab301
{
    class Program
    {
        //Create objects of the class that we have written
        private static MovieCollection movieCollectionObj;
        private static MemberCollection memberCollectionObj;
        private static Member memberObj;

        /// <summary>
        /// This is the main method and is the starting point for the program 
        /// This is the place where everything gets called.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int userInputs = -1;
            movieCollectionObj = new MovieCollection();
            memberCollectionObj = new MemberCollection();
            do
            {
                Console.WriteLine(
                    "\nWelcome to the Community Library\n" +
                    "===========Main Menu============\n" +
                    " 1. Staff Login\n" +
                    " 2. Membr Login\n" +
                    " 0. Exit\n" +
                    "================================\n");
                userInputs = getUserInputsInt(" Please make a selection (1-2, or 0 to exit): ", 0, 2);
                if (userInputs == 1 || userInputs == 2)
                {
                    Console.Write("Enter Username: (LastnameFirstname): ");
                    string uName = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string uPass = Console.ReadLine();
                    if (userInputs == 1)
                    {
                        if (uName == "staff" && uPass == "today123")
                        {
                            Console.WriteLine();
                            menuForStaffAndItsOperation();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Password or Username! Try again\n");
                        }

                    }
                    if (userInputs == 2)
                    {
                        memberObj = memberCollectionObj.userLoginToLibrary(uName, uPass);
                        if (memberObj != null)
                        {
                            Console.WriteLine();
                            menuForMemberAndItsOperation();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Password or Username! Try again.\n");
                        }
                    }

                }
            } while (userInputs != 0);
        }


        /// <summary>
        /// This function is for the member's menu to allow members do the 
        /// operation of displaying, borrowing, returning, listing, 
        /// displaying top 10 movies and retuning to main menu. 
        /// </summary>
        public static void menuForMemberAndItsOperation()
        {
            int userInputs = -1;

            while (userInputs != 0)
            {
                Console.WriteLine(
                    "\n\n" +
                    "===========Member Menu============\n" +
                    "1. Display all movies\n" +
                    "2. Borrow a movie DVD\n" +
                    "3. Return a movie DVD\n" +
                    "4. List current borrowed movie DVDs\n" +
                    "5. Display top 10 most popular movies\n" +
                    "0. Return to main menu\n" +
                    "==================================\n");
                userInputs = getUserInputsInt(" Please make a selection (1-5 or 0 to return to main menu): ", 0, 5);

                switch (userInputs)
                {
                    case 0:
                        //exit to main menu
                        break;
                    case 1:
                        memberDisplayEntireAddedMovies();
                        break;
                    case 2:
                        memberBorrowingMovies();
                        break;
                    case 3:
                        memberReturnsMovieToLibrary();
                        break;
                    case 4:
                        showAListForEachMemberOfCurrentlyBorrowedMovies();
                        break;
                    case 5:
                        showTheTopTenPopularMovies();
                        break;
                }
            }
        }

        /// <summary>
        /// This function is a helper function which helps the member-menu functionality and helping in showing top ten moives
        /// </summary>
        private static void showTheTopTenPopularMovies()
        {
            movieCollectionObj.showingPopularMoviesRentedTenTimes();
        }

        /// <summary>
        /// This function shows a list of movies each member have borrowed.
        /// </summary>
        private static void showAListForEachMemberOfCurrentlyBorrowedMovies()
        {
            memberObj.showMovieDVDsCurrentlyBorrowed();
        }

        /// <summary>
        /// This function is also a member functionality which allow the member to return movies to the library.
        /// </summary>
        private static void memberReturnsMovieToLibrary()
        {
            Console.Write("Enter movie title: ");
            string userInput = Console.ReadLine();
            if (memberObj.checkIsMovieBorrowed(userInput))
            {

                memberObj.memberReturnedMovie(userInput);
                Console.WriteLine("You have successfully returned Movie DVD \n");
            }
            else
            {
                Console.WriteLine("You have not borrowed movie now.\n\n");
            }
        }

        /// <summary>
        /// This function allow the members to borrow movies which is a helper function of the member-menu functionality.
        /// </summary>
        public static void memberBorrowingMovies()
        {
            Console.Write("Enter movie title: ");
            string userInput = Console.ReadLine();
            if (!memberObj.checkIsMovieBorrowed(userInput))
            {
                if (movieCollectionObj.movieBorrowingProcess(userInput)){
                    memberObj.borrowingMovie(userInput);
                    Console.WriteLine("You borrowed " + userInput + "\n");
                }
            }
            else
            {
                Console.WriteLine("You have already borrowed movie.\n");
            }
        }

        /// <summary>
        /// This function is a helper function for the member-menu which allow users to display all available movies.
        /// </summary>
        public static void memberDisplayEntireAddedMovies()
        {
            movieCollectionObj.showMoviesInOrder();
        }


        /// <summary>
        /// This method/function is for staff menu and it's operationss, its display and its error handling.
        /// </summary>
        private static void menuForStaffAndItsOperation()
        {
            int userInputs = -1;
            
            while(userInputs != 0)
            {
                Console.WriteLine(
              "\n===========Staff Menu============\n" +
              "1. Add a new movie DVD\n" +
              "2. Remove a movie DVD\n" +
              "3. Register a new member\n" +
              "4. Find a registered member's phone number\n" +
              "0. Return to main menu\n" +
              "==================================\n");
                userInputs = getUserInputsInt(" Please make a selection (1-4 or 0 to return to main menu): ", 0, 4);
                switch (userInputs)
                {
                    case 0:
                        //exit to main menu
                        break;
                    case 1:
                        functionalityOfNewMovieAddition();
                        break;
                    case 2:
                        staffRemoveMovie();
                        break;
                    case 3:
                        staffRegisteringNewMembersToSystem();
                        break;
                    case 4:
                        phoneNumberLookUpForMembers();
                        break;
                }
            }
           
        }

        /// <summary>
        /// This function is a helper function of the staff-menu functionality, which allow the staff member to 
        /// look up a member's phone number by typing their first and last name.
        /// </summary>
        private static void phoneNumberLookUpForMembers()
        {
            Console.Write("Enter member's first name: ");
            string fName = Console.ReadLine();
            Console.Write("Enter member's last name: ");
            string lName = Console.ReadLine();
            Member objMember = memberCollectionObj.membersPhoneNumberFinder(fName, lName);
            if (objMember != null)
            {
                Console.WriteLine(fName + " " + lName + "'s  phone number is: " + objMember.UserPhoneNumber + "\n");
            }
            else
            {
                Console.WriteLine("This member does not exist." + "\n");
            }
        }

       
        /// <summary>
        /// This function is a helper function of the staff-menu functionality which allows the staff to 
        /// register new members to the system.
        /// </summary>
        private static void staffRegisteringNewMembersToSystem()
        {
            Console.Write("Enter member's first name: ");
            string fName = Console.ReadLine();
            Console.Write("Enter member's last name: ");
            string lName = Console.ReadLine();
            if (!memberCollectionObj.memberIsAddedAlready(fName, lName))
            {
                Console.Write("Enter member's address: ");
                string userAddr = Console.ReadLine();
                Console.Write("Enter member's phone number: ");
                string userPhoneNo = Console.ReadLine();
                string userPassword = "";
                while (!inputedCorrectPass(userPassword))
                {
                    Console.Write("Enter member's password(4 digits): ");
                    userPassword = Console.ReadLine();
                }
                memberCollectionObj.memberAdder(new Member(fName, lName, userAddr, userPhoneNo, userPassword));
                Console.WriteLine("Successfully added " + fName + " " + lName + "\n");
            }
            else
            {
                Console.WriteLine(fName + " " + lName + " has already registered." + "\n");
            }
        } 

        /// <summary>
        /// This function is a helper function of the staff-menu. Which checks the staff members password to see its correct or not.
        /// </summary>
        /// <param name="userInputPassword"></param>
        /// <returns></returns>
        private static bool inputedCorrectPass(string userInputPassword)
        {
            if (userInputPassword.Length != 4) {
                return false;
            }
            for (int i = 0; i < userInputPassword.Length; i++) {
                if (Char.IsLetter(userInputPassword[i])) {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// This function is a helper function which help staff to remove movies that they have added to the system.
        /// </summary>
        private static void staffRemoveMovie()
        {
            Console.Write("Enter movie title: ");
            string movieTitle = Console.ReadLine();
            if (!movieCollectionObj.deleteMovie(movieTitle))
            {
                Console.WriteLine(movieTitle + " was deleted successfully.\n");
            }
            else
            {
                Console.WriteLine(movieTitle+ " does not exist.\n");
            }
        }


        /// <summary>
        /// This method is for adding new movies by staff members and it is a helper function of the staff menu.
        /// </summary>
        private static void functionalityOfNewMovieAddition()
        {
            string[] movieClassificationInfo = {"General (G)", "Parental Guidance (PG)", "Mature (M15+)", "Mature Accompanied (MA15+)"};
            string[] movieGenreInfo = { "Drama", "Adventure", "Family", "Action", "Sci-Fi", "Comedy", "Thriller", "Other"};

            int choiceOfClassification = 0;
            int choiceOfGenre = 0;

            //These are console application notes asking the staff member on what to do.
            Console.Write("Enter the movie title: ");
            string movieTitle = Console.ReadLine();
            Console.Write("Enter the starring actor(s): ");
            string star = Console.ReadLine();
            Console.Write("Enter the director(s): ");
            string directorNames = Console.ReadLine();
            Console.WriteLine("Select the genre: ");

            for (int i = 0; i < movieGenreInfo.Length; i++)
            {
                Console.WriteLine((i + 1).ToString() + ". " + movieGenreInfo[i]);
            }
            choiceOfGenre = getUserInputsInt("Make selection(1-8): ", 1, 8);
            Console.WriteLine("Select the classification: ");
            for (int i = 0; i < movieClassificationInfo.Length; i++) {
                Console.WriteLine((i + 1).ToString() + ". " + movieClassificationInfo[i]);
            }

            choiceOfClassification = getUserInputsInt("Make selection(l - 4): ", 1, 4);
            int movieDuration = getUserInputsInt("Enter the duration (minutes): ", 0, 20000);
            int movieReleaseDate = getUserInputsInt("Enter the release date (year): ", 1, 2030);
            int movieCopiesAvailable = getUserInputsInt("Enter the number of copies available: ", 0, 2000000);

            if (movieCollectionObj.BinarySearchAddMovie(new Movie(movieCopiesAvailable, movieDuration, 0,
                movieReleaseDate, movieTitle,
                movieClassificationInfo[choiceOfClassification - 1],
                movieGenreInfo[choiceOfGenre - 1], directorNames, star))){

                Console.WriteLine(movieTitle + " was added." + "\n");
            }
            else 
            {
                    Console.WriteLine("Movie " + movieTitle + " already exists." + "\n");               
            }
            Console.WriteLine();
        }


        /// <summary>
        /// This method will get user inputs and then convert it to an integer type of data. 
        /// Then it will check if they have entered inputs other than 0, 1, or 2 or any number of inputs 
        /// </summary>
        /// <param name="mesg"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        private static int getUserInputsInt( string mesg, int minimum, int maximum)
        {
            int userInputs = -1;
            bool running = false;
            while (!running)
            {
                try
                {
                    Console.Write(mesg);
                    userInputs = int.Parse(Console.ReadLine());
                    if(userInputs >= minimum && userInputs <= maximum)
                    {
                        running = true;
                    }
                }
                catch
                {

                }
            }
            return userInputs;
        }
    }
}
