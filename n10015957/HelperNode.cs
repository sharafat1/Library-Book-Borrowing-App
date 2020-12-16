using System;
using System.Collections.Generic;
using System.Text;

namespace assign_cab301
{
    public class HelperNode
    {
        /// <summary>
        /// this is a getter and setter for the LeftNode
        /// </summary>
        public HelperNode LeftNode { get; set; }
        
        /// <summary>
        /// This is a getter and setter for the RightNode
        /// </summary>
        public HelperNode RightNode { get; set; }
        
        /// <summary>
        /// This is the getter and setter for the Movie class/obj
        /// </summary>
        public Movie Movie { get; set; }


        /// <summary>
        /// This is a function which is used for Movie and its left and right nodes.
        /// </summary>
        /// <param name="movie"></param>
        public HelperNode(Movie movie)
        {
            Movie = movie;
            LeftNode = RightNode = null;
        }
    }

}
