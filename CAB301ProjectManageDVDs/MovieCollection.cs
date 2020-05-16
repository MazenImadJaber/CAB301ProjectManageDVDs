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
        /// <summary>
        /// Node class for BST
        /// </summary>
        public class Node
        {
            public Movie movie;
            public Node left;
            public Node right;
            /// <summary>
            /// Node for BST 
            /// </summary>
            /// <param name="movie"></param>
            public Node(Movie movie)
            {
                this.movie = movie;
                left = null;
                right = null;
            }

        }


        int numOfMovies = 0; // number of movies in the library
        int ii = 0; // itroator for array
        public Node root;
        /// <summary>
        /// empty collection 
        /// </summary>
        public MovieCollection()
        {
            root = null;
        }
        /// <summary>
        /// collection with the root value
        /// </summary>
        /// <param name="movie"></param>
        /// root value 
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
                    int possition = string.Compare(movie.title, current.movie.title);
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


        /// <summary>
        /// Deques nodes in a tree n into an array
        /// </summary>
        /// <param name="n"></param>
        /// tree (root) node
        /// <param name="movieArray"></param>
        /// output array 
        private void Deque(Node n, Movie[] movieArray)
        {

            if (n == null)
            {

                return;
            }


            Deque(n.left, movieArray);
            movieArray[ii++] = n.movie;
            Deque(n.right, movieArray);


        }


        /// <summary>
        /// returns collection as an array
        /// </summary>
        /// <returns></returns>
        /// Movies array
        public Movie[] ToArray()
        {
            Movie[] movieArray = new Movie[numOfMovies];
            if (numOfMovies > 0)
            {
                Deque(root, movieArray);
                ii = 0; // reset to zero
            }

            return movieArray;
        }


        /// <summary>
        /// remove the most right node of a subtree
        /// </summary>
        /// <param name="n"></param>
        /// subtree
        /// <param name="parent"></param>
        /// parent of subtree
        /// <returns></returns>
        private Movie RemoveMaxNode(Node n, Node parent)
        {

            Node current = n;
            // if current node has no right child 
            if (n.right == null)
            {
                Movie b = current.movie;
                // remove current 
                parent.left = null;

                return b;

            }
            // get most right child
            while (current.right != null)
            {
                parent = current;
                current = current.right;
            }
            Movie a = current.movie;
            // if the most right child has a left child 
            if (current.left != null)
            {
                parent.right = current.left;
            }
            else

            {
                parent.right = null;
            }

            return a;
        }


        /// <summary>
        /// Remove movie given the title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool Remove(string title)
        {
            // if collection is empty 
            if (root == null)
            {
                Console.WriteLine("Collection is Empty!");
                return false;
            }

            else
            {
                Movie[] movieArray = ToArray();
                bool movieExists = false;
                foreach (Movie m in movieArray)
                {
                    if (string.Compare(m.title.ToUpper().Replace(" ", string.Empty)
                        , title.ToUpper().Replace(" ", string.Empty)) == 0)
                    {
                        movieExists = true;
                        break;
                    }
                }
                // movie is not in the collection 
                if (!movieExists)
                {
                    Console.WriteLine("No movie with this title is in the collection!");
                    return false;
                }
                // movie is in the collection 
                else
                {
                    Node current = root;
                    Node parant = new Node(null);
                    bool deleted = false;
                    bool left = false;

                    do
                    {
                        int possition = string.Compare(title.ToUpper().Replace(" ", string.Empty),
                            current.movie.title.ToUpper().Replace(" ", string.Empty));

                        // if current is less than title go left
                        if (possition == -1)
                        {
                            parant = current;
                            current = current.left;
                            left = true;



                        }
                        // match 
                        if (possition == 0)
                        {
                            // removing the root if its the only element 
                            if (movieArray.Length == 1)
                            {
                                root = null;
                                numOfMovies--;
                                deleted = true;
                            }
                            // removing the root 
                            else if (current == root)
                            {

                                Movie m = RemoveMaxNode(current.left, current);

                                root.movie = m;
                                deleted = true;
                                numOfMovies--;
                            }
                            // remove leaf
                            else if (current.left == null && current.right == null)
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
                            // remove node with right child only
                            else if (current.left == null && current.right != null)
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
                            // remove node with left child only 
                            else if (current.left != null && current.right == null)
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
                            // remove node with two children 
                            else
                            {
                                if (left)
                                {
                                    parant.left.movie = RemoveMaxNode(current.left, current);
                                }
                                else
                                {
                                    parant.right.movie = RemoveMaxNode(current.left, current);
                                }

                                deleted = true;
                                numOfMovies--;

                            }
                        }
                        // if current is more than title go left
                        if (possition == 1)
                        {
                            parant = current;
                            current = current.right;
                            left = false;
                        }

                    } while (!deleted); // exist loop when delted is true

                    Console.WriteLine("Movie with the \"{0}\" title is now removed from collection", title);
                    return true;
                }

            }

        }


        /// <summary>
        /// Use buble sort to sort movies according to frequncey 
        /// </summary>
        /// <returns></returns>
        /// an array of the ten most borrowed movies
        public Movie[] TopTen()
        {
            // get all movies in an array
            Movie[] movies = ToArray();

            int n = movies.Length - 2;
            // buble sort
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n - i; j++)
                {
                    if (movies[j + 1].timesBorrowed < movies[j].timesBorrowed)
                    {
                        Movie temp = movies[j + 1];
                        movies[j + 1] = movies[j];
                        movies[j] = temp;
                    }
                }
            }
            // get the number of elements in output array, defult is 10
            int top = 10;
            if (movies.Length < 10)
            {
                top = movies.Length;
                Console.WriteLine("only {0} movies are in the collection", top);
            }
            Movie[] top10 = new Movie[top];
            // order from most borrowed to least
            for (int ii = 0; ii < top; ii++)
            {
                top10[ii] = movies[movies.Length - 1 - ii];
            }
            return top10;
        }

        /// <summary>
        /// marks movie as borrowed and passes a copy of it given it's title 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public Movie borrow(string title)
        {
            // if collection is empty 
            if (root == null)
            {
                Console.WriteLine("Collection is Empty!");
                return null;
            }

            else
            {
                Movie[] movieArray = ToArray();
                bool movieExists = false;
                foreach (Movie m in movieArray)
                {
                    if (string.Compare(m.title.ToUpper().Replace(" ", string.Empty)
                        , title.ToUpper().Replace(" ", string.Empty)) == 0)
                    {
                        movieExists = true;
                        break;
                    }
                }
                // movie is not in the collection 
                if (!movieExists)
                {
                    Console.WriteLine("No movie with this title is in the collection!");
                    return null;
                }
                // movie is in the collection 
                else
                {
                    Node current = root;

                    bool borrowed = false;


                    do
                    {
                        int possition = string.Compare(title.ToUpper().Replace(" ", string.Empty),
                            current.movie.title.ToUpper().Replace(" ", string.Empty));

                        // if current is less than title go left
                        if (possition == -1)
                        {
                            current = current.left;

                        }
                        // match 
                        if (possition == 0)
                        {
                            borrowed = true;
                            return current.movie.Borrow();

                        }
                        // if current is more than title go left
                        if (possition == 1)
                        {

                            current = current.right;

                        }

                    } while (!borrowed); // exist loop when delted is true

                    return null;

                }

            }
        }
        public void addCpies(string title, int numberOfCopies)
        {
            Node current = root;




            do
            {
                int possition = string.Compare(title.ToUpper().Replace(" ", string.Empty),
                    current.movie.title.ToUpper().Replace(" ", string.Empty));

                // if current is less than title go left
                if (possition == -1)
                {
                    if (current.left == null)
                    {
                        Console.WriteLine("Unsuccessful!");
                        break;
                    }
                    current = current.left;

                }
                // match 
                if (possition == 0)
                {

                    current.movie.AddCopies(numberOfCopies);
                    break;

                }
                // if current is more than title go left
                if (possition == 1)
                {
                    if (current.right == null)
                    {
                        Console.WriteLine("Unsuccessful!");
                        break;
                    }

                    current = current.right;

                }

            } while (true); // exist loop when delted is true




        }

    }
}
