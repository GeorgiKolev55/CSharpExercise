using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    class Node
    {
        private readonly int x;
        private readonly int y;
        private readonly Node previous;
        public Node(int x,int y,Node previous)
        {
            this.x = x;
            this.y = y;
            this.previous = previous;
        }

        public int X { get { return this.x; } }
        public int Y { get { return this.y; } }
        public Node Parent { get { return this.previous; } }

        public override string ToString()
        {
            return this.X+" "+this.Y;
        }
    }
}
