using System;
using System.Collections;
using System.Collections.Generic;

namespace Maze
{


    class Program
    {
        static void Main(string[] args)
        {

            int[,] matrinx =
            {
                  {1, 0, 1, 1, 1, 1 },
                  {1, 0, 1, 0, 1, 1 },
                  {1, 1, 1, 0, 1, 1 },
                  {0, 0, 1, 0, 1, 0 },
                  {1, 1, 1, 0, 1, 1 },
                  {1, 0, 1, 1, 1, 1 }
                  
            };

            PrintMaze(matrinx);

            Node final = FindShortestPath(0, 0, matrinx);

            int steps =PrintPath(final);

            Console.WriteLine("Shortest Path is {0} steps",steps);
        }
        public static Node FindShortestPath(int x, int y, int[,] martix)
        {
            int[] exit = { martix.GetLength(0) - 1, martix.GetLength(1) - 1 };

            Node source = new Node(x, y, null);

            int[] rowCordinates = { -1, 0, 1, 0 };
            int[] colCordinates = { 0, -1, 0, 1 };

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(source);

            HashSet<string> isVisited = new HashSet<string>();
            isVisited.Add(source.X + " " + source.Y);


            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();
                if (currentNode.X == exit[0] && currentNode.Y == exit[1])
                {
                    return currentNode;
                }

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
            return null;

        }
        private static void PrintMaze(int[,] maze)
        {

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i,j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        private static int PrintPath(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            int len = PrintPath(node.Previous);

            Console.Write("({0}) ",node.ToString());
            return len + 1;
        }
        private static bool IsInBoundraies(int x, int y, int[,] matrix)
        {
            return x >= 0 && x < matrix.GetLength(0) && y >= 0 && y < matrix.GetLength(1);
        }
    }
}
