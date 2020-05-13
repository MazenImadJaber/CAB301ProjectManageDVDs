using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CAB301ProjectManageDVDs
{
    class MovieCollection
    {
        public class Node
        {
            public Movie movie;
            public Node left;
            public Node right;

            public Node(Movie movie)
            {
                this.movie = movie;
                left = null;
                right = null;
            }

        }


        int numOfMovies = 0;
      
        public Node root;
        public MovieCollection()
        {
            root = null;
        }
        public MovieCollection(Movie movie)
        {
            root = new Node(movie);
        }


        /// <summary>
        /// non-recursive add
        /// </summary>
        /// <param name="movie"></param>
        public void Add(Movie movie)
        {
          //  movieArray[numOfMovies] = movie;

            if (root == null) // tree is empty 
            {
                Node node = new Node(movie);
                root = node;
                numOfMovies++;

            }
            else
            {
                Node current = root;
                bool added = false;
                do
                {
                    int possition = string.Compare(movie.name,current.movie.name);
                    // go left
                    if (possition == -1)
                    {
                        if (current.left == null)
                        {
                            current.left = new Node(movie);
                            added = true;
                            numOfMovies++;
                        }
                        else
                        {
                            current = current.left;
                        }
                    }

                    if (possition == 0)
                    {
                        current.movie.AddCopies(movie.numberOfCopies);
                        added = true;
                    }
                    if (possition == 1)
                    {
                        if (current.right == null)
                        {
                            current.right = new Node(movie);
                            added = true;
                            numOfMovies++;
                        }
                        else
                        {
                            current = current.right;
                        }
                    }

                } while (!added);

            }

        }
        public bool Remove(Movie movie)
        {
            return false;
        }

        int ii = 0;
        public void Deque(Node n, Movie[] movieArray)
        {

            if (n == null)
            {
                              
                return;
            }


            Deque(n.left, movieArray);
            movieArray[ii++]= n.movie;
            Deque(n.right, movieArray);
        }
      
        public Movie[] ToArray()
        {
            Movie[] movieArray = new Movie[numOfMovies];
            Deque(root, movieArray);
                 return movieArray;
        }

        public Movie[] TopTen()
        {

            Movie[] movies = ToArray();
            return movies;
        }

    }
}
