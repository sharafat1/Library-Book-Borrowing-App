using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

namespace assign_cab301
{
    public class MovieCollection
    {

        private HelperNode root;

       /// <summary>
       /// This is a constructor for the MovieCollectionClass
       /// </summary>
       public MovieCollection()
        {
            root = null;
        }
        
        /// <summary>
        /// This funciton uses the Binary search algorithm and allow the staff to add movies.  
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public bool BinarySearchAddMovie(Movie movie)
        {
            HelperNode movieNode = new HelperNode(movie);

            if(root == null)
            {
                root = movieNode;
                return true;
            }
            else
            {
                HelperNode newMovieNode = root;
                HelperNode topMovieNode;

                while (true)
                {
                    topMovieNode = newMovieNode;
                    int res = newMovieNode.Movie.MovieTitle.CompareTo(movie.MovieTitle);
                    if(res < 0)
                    {
                        //Check the left node of the binarysearchtree. if the movie is can be stored there
                        //Then move to right node or child and check there. 
                        newMovieNode = newMovieNode.LeftNode;
                        if(newMovieNode == null)
                        {
                            topMovieNode.LeftNode = movieNode;
                            return true;
                        }
                    }
                    else if(res > 0)
                    {
                        //Checking the rightnode if it can store the movie.
                        newMovieNode = newMovieNode.RightNode;
                        if(newMovieNode == null)
                        {
                            topMovieNode.RightNode = movieNode;
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }



        /// <summary>
        /// This function delete moives in the node or tree.
        /// </summary>
        /// <param name="movieName"></param>
        /// <returns></returns>
        public bool deleteMovie(string movieName)
        {
            HelperNode movieNodeObjRoot = removeNodeMovie(root, movieName);
            if(movieNodeObjRoot != root)
            {
                return false;
            }
            root = movieNodeObjRoot;
            return true;
        }



        /// <summary>
        /// This function remove the node for the movie.
        /// </summary>
        /// <param name="contentRoot"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        HelperNode removeNodeMovie(HelperNode contentRoot, string title)
        {
            if (contentRoot == null) return contentRoot;
            
            int res = contentRoot.Movie.MovieTitle.CompareTo(title);
            if(res < 0)
            {
                contentRoot.LeftNode = removeNodeMovie(contentRoot.LeftNode, title);
            }
            else if(res < 0)
            {
                contentRoot.RightNode = removeNodeMovie(contentRoot.RightNode, title);
            }
            else
            {
                if(contentRoot.LeftNode == null)
                {
                    return contentRoot.RightNode;
                }
                else if(contentRoot.RightNode == null)
                {
                    return contentRoot.LeftNode;
                }
                contentRoot.Movie = numberOfMoviesInNode(contentRoot.RightNode);
                contentRoot.RightNode = removeNodeMovie(contentRoot.RightNode, contentRoot.Movie.MovieTitle);
            }
            return contentRoot;
        }

        /// <summary>
        /// This function is a helper function to view number of moveis in node.
        /// </summary>
        /// <param name="nodeRoot"></param>
        /// <returns></returns>
        private Movie numberOfMoviesInNode(HelperNode nodeRoot)
        {
            Movie inNodeMovie = nodeRoot.Movie;
            while(nodeRoot.LeftNode != null)
            {
                inNodeMovie = nodeRoot.LeftNode.Movie;
                nodeRoot = nodeRoot.LeftNode;
            }
            return inNodeMovie;
        }


        /// <summary>
        /// This function will allow users to borrow moviies and is a helper function. 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool movieBorrowingProcess(string title)
        {

            return movieBorrowingProcess(root, title);
        }


        /// <summary>
        /// This is a helper function which does the movie borrowing process. 
        /// </summary>
        /// <param name="rootObj"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        private bool movieBorrowingProcess(HelperNode rootObj, string title)
        {
            while(rootObj != null)
            {
                int res = rootObj.Movie.MovieTitle.CompareTo(title);
                if(res < 0)
                {
                    rootObj = rootObj.LeftNode;
                }
                else if(res > 0)
                {
                    rootObj = rootObj.RightNode;
                }
                else
                {
                    if(rootObj.Movie.MovieAvailableCopies > 0)
                    {
                        rootObj.Movie.howManyTimesRented();
                        return true;
                    }
                }
            }
            return true;
        }


        /// <summary>
        /// This method retuns the root so it can be used.
        /// </summary>
        /// <returns></returns>
        public int shape()
        {
            return shape(root);
        }

        /// <summary>
        /// This function is also a helper function which helps to check in binarytree.
        /// </summary>
        /// <param name="nodeShape"></param>
        /// <returns></returns>
        private int shape(HelperNode nodeShape)
        {
            if(nodeShape == null)
            {
                return 0;
            }
            else
            {
                return (shape(nodeShape.LeftNode) + 1 + shape(nodeShape.RightNode));
            }
        }
    
        

       
        /// <summary>
        /// This function is a helper function of showing moives in an alphabetical order.
        /// </summary>
        /// <param name="helperNode"></param>
        private void showMoviesInAlphaOrder(HelperNode helperNode)
        {
            if(helperNode != null)
            {

                showMoviesInAlphaOrder(helperNode.RightNode);
                Console.Write(helperNode.Movie.ToString() + "\n");
                showMoviesInAlphaOrder(helperNode.LeftNode);

            }
        }


        /// <summary>
        /// This function shows movies in a order alphabetical order.
        /// </summary>
        public void showMoviesInOrder()
        {
            showMoviesInAlphaOrder(root);
        }


        private HelperNode mostTimesBorrowedOrderMovieNode; //declaration of helperNode obj


        /// <summary>
        /// This function shows a list of popular movies that are rented 10 times.
        /// </summary>
        public void showingPopularMoviesRentedTenTimes()
        {
            check = 0;
            mostTimesBorrowedOrderMovieNode = null;
            mostTimesBorrowedOrderMovieNodeAddition(root);
            showingPopularMoviesRentedTenTimes(mostTimesBorrowedOrderMovieNode);    
        }

        /// <summary>
        /// This method is a helper function of the member menu and shows the most times borrowed mobies in an order.
        /// </summary>
        /// <param name="hNode"></param>
        private void mostTimesBorrowedOrderMovieNodeAddition(HelperNode hNode)
        {
            if(hNode != null)
            {
                mostTimesBorrowedOrderMovieNodeAddition(hNode.RightNode);
                mostTimesBorrowedOrderMovieNode = sortedMoviesByRentedTimesInsertion(
                    mostTimesBorrowedOrderMovieNode, 
                    hNode.Movie);
                mostTimesBorrowedOrderMovieNodeAddition(hNode.LeftNode);
            }
            
        }

        private int check = 0;

        /// <summary>
        /// This method helps in showing the popular movies.
        /// </summary>
        /// <param name="hNode"></param>
        private void showingPopularMoviesRentedTenTimes(HelperNode hNode)
        {
            if(hNode != null && check < 10)
            {
                check = check + 1;
                showingPopularMoviesRentedTenTimes(hNode.RightNode);
                Console.WriteLine(hNode.Movie.MovieTitle + " borrowed " +
                    hNode.Movie.MovieTimesRented.ToString() + " times.");
                showingPopularMoviesRentedTenTimes(hNode.LeftNode);
            }

        }

        /// <summary>
        /// This is a helpernode method and is used to binarysearch tree and return and helps to sort movies by number of times they're rented.
        /// </summary>
        /// <param name="hNode"></param>
        /// <param name="objMovie"></param>
        /// <returns></returns>
        private HelperNode sortedMoviesByRentedTimesInsertion(HelperNode hNode, Movie objMovie)
        {
            if(hNode == null)
            {
                return new HelperNode(objMovie);
            }
            if (objMovie.MovieTimesRented < hNode.Movie.MovieTimesRented)
            {
                hNode.LeftNode = sortedMoviesByRentedTimesInsertion(hNode.LeftNode, objMovie);
            }
            else
            {
                hNode.RightNode = sortedMoviesByRentedTimesInsertion(hNode.RightNode, objMovie);
            }

            return hNode;
        }
    }
}
