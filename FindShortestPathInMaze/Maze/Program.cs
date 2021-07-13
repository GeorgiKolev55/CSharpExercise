using System;
using System.Collections;
using System.Collections.Generic;

namespace Maze
{

    class Program
    {

        static void Main(string[] args)
        {

            int[,] maze =
            {
                  {1, 0, 1, 1, 1, 1 },
                  {1, 0, 1, 0, 1, 1 },
                  {1, 1, 1, 0, 1, 1 },
                  {0, 0, 1, 0, 1, 0 },
                  {1, 1, 1, 0, 1, 1 },
                  {1, 0, 1, 1, 1, 1 }

            };

            PrintMaze(maze);

            Node finalCell = FindShortestPath(0, 0, maze);
            if (finalCell != null)
            {
                int steps = PrintPath(finalCell);

                Console.WriteLine("Shortest Path is {0} steps", steps);
            }
            else
            {
                Console.WriteLine("The path is not valid !");
            }

        }
        private static void PrintMaze(int[,] maze)
        {

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        //Function for printing the shortest path
        private static int PrintPath(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            int len = PrintPath(node.Previous);

            Console.Write("({0}) ", node.ToString());
            return len + 1;
        }
        private static bool IsInBoundraies(int x, int y, int[,] matrix)
        {
            return x >= 0 && x < matrix.GetLength(0) && y >= 0 && y < matrix.GetLength(1);
        }
        public static Node FindShortestPath(int x, int y, int[,] martix)
        {

            int[] destinationCell = { martix.GetLength(0) - 1, martix.GetLength(1) - 1 };

            Node source = new Node(x, y, null);

            //These two arrays detail all four possible movements from a cell
            int[] rowCordinates = { -1, 0, 0, 1 };
            int[] colCordinates = { 0, -1, 1, 0 };

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(source);

            HashSet<string> isVisited = new HashSet<string>();

            isVisited.Add(source.X + " " + source.Y);


            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();
                if (currentNode.X == destinationCell[0] && currentNode.Y == destinationCell[1])
                {
                    return currentNode;
                }

                //Check all four possible directions
                for (int i = 0; i < rowCordinates.Length; i++)
                {
                    int row = currentNode.X + rowCordinates[i];
                    int col = currentNode.Y + colCordinates[i];

                    if (IsInBoundraies(row, col, martix) && !isVisited.Contains(row + " " + col) && martix[row, col] == 1)
                    {
                        queue.Enqueue(new Node(row, col, currentNode));
                        isVisited.Add(row + " " + col);
                    }
                }
            }
            //return null if path is not possible
            return null;

        }

    }
}
