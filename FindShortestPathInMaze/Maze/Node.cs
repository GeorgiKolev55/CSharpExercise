using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    class Node
    {
        //x and y are cordinates of a cell in the matrix(maze)
        private readonly int x;
        private readonly int y;

        //maintain the previous node for printing the final path
        private readonly Node previous;

        public Node(int x,int y,Node previous)
        {
            this.x = x;
            this.y = y;
            this.previous = previous;
           
        }

        public int X { get { return this.x; } }
        public int Y { get { return this.y; } }
        public Node Previous { get { return this.previous; } }

        public override string ToString()
        {
            return this.X+" "+this.Y;
        }
    }
}
