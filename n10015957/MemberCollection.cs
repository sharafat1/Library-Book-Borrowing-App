using System;


namespace assign_cab301
{
    public class MemberCollection
    {
        /*This class uses array to store members details such as passwords, usernames, firstname, lastname etc.
         This class will use the members class as an object to allow us access the fields, members, 
         and methods of that class.*/

        //This class use some fields and members
        private Member[] storageForMembers;
        private int totalMembersInStorage;

        //A method of this class
        public MemberCollection()
        {
            this.storageForMembers = new Member[100]; //this is an array to store upto 50
            this.totalMembersInStorage = 0;
        }

        /// <summary>
        /// This method will allow us to add new members to the membercollection class which uses arrays for storing data.
        /// </summary>
        /// <param name="member">member</param>
        public void memberAdder(Member member)
        {
            this.storageForMembers[this.totalMembersInStorage] = member;
            this.totalMembersInStorage++;
        }


        /// <summary>
        /// This method will allow the staff member to find a members phone number, by typing their first and last name.
        /// </summary>
        /// <param name="userFirstName"></param>
        /// <param name="userLastName"></param>
        /// <returns></returns>
        public Member membersPhoneNumberFinder(string userFirstName, string userLastName)
        {

            /*this for loop go through the array and checks if there is use with the first and last name matching if 
             * there is one return it's phone number. 
             */
            for(int i =0; i<totalMembersInStorage; i++)
            {
                if( (storageForMembers[i].UserFirstName.Equals(userFirstName)) && 
                    storageForMembers[i].UserLastName.Equals(userLastName))
                {
                    return this.storageForMembers[i];
                }
            }
            return null;
        }


        /// <summary>
        /// This function helps the login process for the users. It checks the users entered password and user name.
        /// If their username or password doesn't match than what is recorded in the storage for that memeber
        /// Then they wont be allowed to login.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public Member userLoginToLibrary(string uName, string uPass)
        {
            //Console.WriteLine("Hey this is for checking in line 68 Membercollection");
            for (int i = 0; i < this.totalMembersInStorage; i++)
            { 
                if (this.storageForMembers[i].Username.Equals(uName) && this.storageForMembers[i].UserPassword.Equals(uPass))
                {
                    return this.storageForMembers[i];
                }
            }
            return null;
        }


        /// <summary>
        /// This function checks if a user is already added by staff or not. using their first and last name 
        /// to check if their first and last name exists in the array. Then it will return true. 
        /// </summary>
        /// <param name="userFirstName"></param>
        /// <param name="userLastName"></param>
        /// <returns></returns>
        public bool memberIsAddedAlready(string userFirstName, string userLastName)
        {
            /*this for loop go through the array and checks if there is user with the first and last name matching if 
             * there is then the boolean will become true. This function is used to let the staff know that there is 
             * member registered/added already with this name
             */
            for (int i = 0; i < totalMembersInStorage; i++)
            {
                if ((storageForMembers[i].UserFirstName.Equals(userFirstName)) &&
                    storageForMembers[i].UserLastName.Equals(userLastName))
                {
                    return true; 
                }
            }
            return false;
        }


    }
}


