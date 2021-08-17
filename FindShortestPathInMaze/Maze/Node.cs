
namespace Maze
{
    class Node
    {
        
        private readonly int rowCordinate;
        private readonly int colCordinate;

        //maintain the previous node for printing the final path
        private readonly Node previous;
        
        //x and y are cordinates of a cell in the matrix(maze)
        public Node(int x,int y,Node previous)
        {
            this.rowCordinate = x;
            this.colCordinate = y;
            this.previous = previous;
           
        }

        public int RowCordinate { get { return this.rowCordinate; } }
        public int ColCordinate { get { return this.colCordinate; } }
        public Node Previous { get { return this.previous; } }

        public override string ToString()
        {
            return this.RowCordinate+" "+this.ColCordinate;
        }
    }
}
