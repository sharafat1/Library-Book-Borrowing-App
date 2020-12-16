using System;
using System.Collections.Generic;
using System.Text;

namespace assign_cab301
{
    public class Member
    {

        //Create an object to model a member
        private string userFirstName;
        private string userLastName;
        private string userPhoneNumber;
        private string userPassword;
        private string userAddress;
        private string[] memberBorrowedMovies;
        private int totalMemberBorrowedMovies;


        public Member() { }

        /// <summary>
        /// This is an object declaration which models the Member class.
        /// </summary>
        /// <param name="userFirstName"></param>
        /// <param name="userLastName"></param>
        /// <param name="userAddress"></param>
        /// <param name="userPhoneNumber"></param>
        /// <param name="userPassword"></param>
        public Member(string userFirstName, string userLastName, string userAddress, string userPhoneNumber, string userPassword )
       {
            
            this.userFirstName = userFirstName;
            this.userLastName = userLastName;
            this.userPhoneNumber = userPhoneNumber;
            this.userPassword = userPassword;
            this.userAddress = userAddress;
            memberBorrowedMovies = new string[10]; //array size is set to 10 movies
            totalMemberBorrowedMovies = 0;

            
       }
        
   
        /// <summary>
        /// This function is a helper function which is used to show movie currectly borrowed.
        /// </summary>
        public void showMovieDVDsCurrentlyBorrowed()
        {
            if (totalMemberBorrowedMovies < 10)
            {
                if (totalMemberBorrowedMovies > 0)
                {
                    Console.WriteLine("You are currently borrowing:");
                    for (int i = 0; i < this.totalMemberBorrowedMovies; i++)
                    {
                        Console.WriteLine(memberBorrowedMovies[i]);
                    }
                }
                else
                {
                    Console.WriteLine("You have not borrowed movie yet.");
                    
                }
            }
            else
            {
                Console.WriteLine("A registered member can borrow up to 10 movies at any time.");
            }
}


        /// <summary>
        /// This function is a helper function which is used to check whether a movies is borrowed or not.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool checkIsMovieBorrowed(string title)
        {
            for (int i = 0; i < totalMemberBorrowedMovies; i++)
            {
                if (memberBorrowedMovies[i] == title)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This function is a helper function for the functionality of return borrowed movies.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public int returnBorrowedMovie(string title)
        {
            for (int i = 0; i < totalMemberBorrowedMovies; i++)
            {
                if (memberBorrowedMovies[i] == title)
                {
                    return i;
                }
            }
            return -1; //throw an error
        }

        /// <summary>
        /// This method allows to borrow movie
        /// </summary>
        /// <param name="title"></param>
        public void borrowingMovie(string title)
        {
            memberBorrowedMovies[totalMemberBorrowedMovies] = title;
            totalMemberBorrowedMovies++;
        }


        /// <summary>
        ///  This method allows to return movie
        /// </summary>
        /// <param name="titleOfMovie"></param>
        public void memberReturnedMovie(string titleOfMovie)
        {
            int moviePos = returnBorrowedMovie(titleOfMovie);
            for (int i = moviePos; i < totalMemberBorrowedMovies - 1; i++)
            {
                memberBorrowedMovies[i] = memberBorrowedMovies[i + 1];
            }
            totalMemberBorrowedMovies--;
        }

        public string Username {get{return UserLastName + UserFirstName;}}
        public string UserPassword {get{return userPassword;}}
        public string UserFirstName {get{return userFirstName;}}
        public string UserLastName { get{ return userLastName; }}
        public string UserAddress { get { return userAddress; }}
        public string UserPhoneNumber{ get { return userPhoneNumber; }}
    }
}
