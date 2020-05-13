using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
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

        int  ii = 0;
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
            if(numOfMovies>0)
            {
                Deque(root, movieArray);
                ii = 0;
            }
          
                 return movieArray;
        }
        private Movie RemoveMaxNode(Node n)
        {
            
            Node current = n;
            Node parent = n;
            if (n.right == null)
            {
                numOfMovies--;
                return n.movie;
                
            }
           
            while(current.right != null)
            {
                parent = current;
                current = current.right;
            }
            Movie a = current.movie;
            if ( current.left != null)
            {
                parent.right = current.left;
            }
            else
            {
                parent.right = null;
            }
            numOfMovies--;
            return a;
        }
        public bool Remove(string title)
        {
            if (root == null)
            {
                Console.WriteLine("Collection is Empty!");
                return false;
            }
            Movie[] movieArray = ToArray();
            bool movieExists = false ;
            foreach (Movie m in movieArray)
            {
                if (string.Compare(m.name.ToUpper().Replace(" ",string.Empty)
                    , title.ToUpper().Replace(" ", string.Empty)) == 0)
                {
                    movieExists = true;
                    break;
                }
            }
           
           if (!movieExists)
            {
                Console.WriteLine("No movie with this title is in the collection!");
                return false;
            }
            else
            {
                Node current = root;
                Node parant = new Node(null);
                bool deleted = false;
                 bool left = false;

                do
                {
                    int possition = string.Compare(title.ToUpper().Replace(" ", string.Empty),
                        current.movie.name.ToUpper().Replace(" ", string.Empty) );
                   
                    // go left
                    if (possition == -1)
                    {
                        parant = current;
                        current = current.left;
                        left = true;
                       


                    }

                    if (possition == 0)
                    {
                        if (movieArray.Length == 1)
                        {
                            root = null;
                        }
                        // remove leaf
                        if (current.left ==null && current.right == null)
                        {
                            if (left)
                            {
                                parant.left = null;
                            }
                            else
                            {
                                parant.right = null;
                            }
                            numOfMovies--;
                            deleted = true;
                            
                        } 
                        else if (current.left == null && current.right != null && current != root)
                        {
                            if (left)
                            {
                                parant.left = current.right;
                            }
                            else
                            {
                                parant.right = current.right;
                            }
                            numOfMovies--;
                            deleted = true;

                        }
                        else if (current.left != null && current.right == null && current != root)
                        {
                            if (left)
                            {
                                parant.left = current.left;
                            }
                            else
                            {
                                parant.right = current.left;
                            }
                            numOfMovies--;
                            deleted = true;

                        }
                        else if (current == root)
                        {
                            
                            Movie m = RemoveMaxNode(current.left);
                           if(current.left.movie == m)
                            {
                                current.left = null;
                            }
                            root.movie = m;
                             deleted = true;
                        }
                        else 
                        {
                            if (left)
                            {
                                parant.left.movie = RemoveMaxNode(current.left);
                            }
                            else
                            {
                                parant.right.movie = RemoveMaxNode(current.left);
                            }
                            numOfMovies--;
                            deleted = true;

                        }
                    }
                    if (possition == 1)
                    {
                        parant = current;
                        current = current.right;
                        left = false;
                    }

                } while (!deleted);

                Console.WriteLine("Movie with the \"{0}\" title is now removed from collection", title);
                return true;
            }
           
            

        }


        public Movie[] TopTen()
        {

            Movie[] movies = ToArray();
            return movies;
        }

    }
}
