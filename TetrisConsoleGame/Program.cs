using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace TetrisConsoleGame
{
    class Program
    {
        //settings
        static int TetrisRows = 20;
        static int TetrisCols = 10;
        static int InfoCols = 10;
        static int ConsoleRows = 1 + TetrisRows + 1;
        static int ConsolCols = 1 + TetrisCols + 1 + InfoCols + 1;
        static List<bool[,]> tetrisFigures = new List<bool[,]>()
        {
            new bool[,]//O
            {
                { true,true},
                { true,true}
            },
            new bool[,]// T
            {
                { false,true,false},
                { true,true,true}
            },
            new bool[,]// S
            {
                { false,true,true},
                { true,true,false}
            },
            new bool[,]// Z
            {
                { true,true,false},
                {false,true,true}
            },
            new bool[,]// L
            {
                { true,false,false},
                { true,true,true}
            },
            new bool[,]// J
            {
                { false,false,true},
                { true,true,true}
            },
            new bool[,]{ { true,true,true,true} }// ----
        };
        //state
        static int Score = 0;
        static int Frame = 0;
        static int FramesToMoveFigure = 15;
        static Random Random = new Random();    
        static bool[,] currentFigure = null;
        static int currentFigureRow = 0;
        static int currentFigureCol = 0;
        static bool[,] tetrisField = new bool[TetrisRows, TetrisCols];
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Title = "Tetris version1.0";
            Console.CursorVisible=false;
            Console.WindowHeight = ConsoleRows;
            Console.WindowWidth = ConsolCols;
            Console.BufferHeight = ConsoleRows;
            Console.BufferWidth = ConsolCols;
            currentFigure = tetrisFigures[Random.Next(0, tetrisFigures.Count)];


            while (true)
            {
                Frame++;
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if (key.Key==ConsoleKey.Escape)
                    {
                        return;
                    }
                    if (key.Key==ConsoleKey.LeftArrow||key.Key==ConsoleKey.A)
                    {
                        if (currentFigureCol>=1)
                        {
                            currentFigureCol--;
                        }
                    }
                    if (key.Key==ConsoleKey.RightArrow||key.Key==ConsoleKey.D)
                    {
                        if (currentFigureCol<TetrisCols-currentFigure.GetLength(1))
                        {
                            currentFigureCol++;
                        }
                    }
                    if (key.Key==ConsoleKey.DownArrow||key.Key==ConsoleKey.S)
                    {
                        Frame = 1;
                        Score++;
                        currentFigureRow++;
                    }
                    if (key.Key==ConsoleKey.Spacebar||key.Key==ConsoleKey.UpArrow||key.Key==ConsoleKey.W)
                    {
                        RotateCurrentFigure();
                    }
                }
                if (Frame%FramesToMoveFigure==0)
                {
                    currentFigureRow++;
                    Frame = 0;
                   
                }
                if (Collision(currentFigure))
                {
                    AddCurrentFigureToTetrisField();
                    int lines = CheckForFullLines();
                    Score += lines;
                    currentFigure = tetrisFigures[Random.Next(0, tetrisFigures.Count)];
                    currentFigureRow = 0;
                    currentFigureCol = 0;
                    if (Collision(currentFigure))
                    {
                        File.AppendAllLines("scores.text",new List<string>
                        {
                            $"[{DateTime.Now.ToString()}] {Environment.UserName} =>{Score}"
                        });
                        Write("╔═══════╗", 7,6);
                        Write("║ Game  ║",8, 6);
                        Write("║ over! ║", 9, 6);
                        Write("╚═══════╝", 10, 6);
                        Thread.Sleep(100000);
                        return;
                    }
                    
                }
                DrowBorder();
                DrawInfo();
                DrawTetrisField();
                DrawCurrentFigure();
                
                Thread.Sleep(40);
            }
        }

        private static void RotateCurrentFigure()
        {
            var newFigure = new bool[currentFigure.GetLength(1),currentFigure.GetLength(0)];
            for (int i = 0; i < currentFigure.GetLength(0); i++)
            {
                for (int j = 0; j < currentFigure.GetLength(1); j++)
                {
                    newFigure[j, currentFigure.GetLength(0) - i - 1] = currentFigure[i, j];
                }
            }
            if (!Collision(newFigure))
            {
               currentFigure = newFigure;
            }
                 
        }

        private static int CheckForFullLines()
        {
            int lines = 0;
            for (int row = 0; row < tetrisField.GetLength(0); row++)
            {
                bool rowIsFull = true;
                for (int col = 0; col < tetrisField.GetLength(1); col++)
                {
                    if (tetrisField[row, col] == false)
                    {
                        rowIsFull = false;
                        break;
                    }
                }
                if (rowIsFull)
                {
                    for (int rowToMove =row ; rowToMove >=1; rowToMove--)
                    {
                        for (int col = 0; col < tetrisField.GetLength(1); col++)
                        {
                            tetrisField[rowToMove, col] = tetrisField[rowToMove - 1, col];
                        }
                    }
                    lines++;
                    Score += 10;
                }
            }
            return 0;
        }

        private static void AddCurrentFigureToTetrisField()
        {
            for (int i = 0; i < currentFigure.GetLength(0); i++)
            {
                for (int j = 0; j < currentFigure.GetLength(1); j++)
                {
                    if (currentFigure[i,j])
                    {
                        tetrisField[currentFigureRow+i,currentFigureCol+j]=true;
                    }
                }
            }
        }

        static bool Collision(bool[,]figure)
        {
            if (currentFigureCol>TetrisCols-figure.GetLength(1))
            {
                return true;
            }
            if (currentFigureRow+figure.GetLength(0)==TetrisRows)
            {
                return true;
            }
            for (int i = 0; i < figure.GetLength(0); i++)
            {
                for (int j = 0; j < figure.GetLength(1); j++)
                {
                    if (figure[i,j]&&
                        tetrisField[currentFigureRow+i+1,currentFigureCol+j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private static void DrawInfo()
        {
            Write("Score:", 1, 3+TetrisCols);
            Write(Score.ToString(), 2, 3 + TetrisCols);
           
            Write("Position",7, 3 + TetrisCols);
            Write($"{currentFigureRow},{currentFigureCol}", 8, 3 + TetrisCols);
        }
        static void Write(string text,int row,int col)
        {
           
            Console.SetCursorPosition(col,row);
            Console.Write(text);
         
        }

        static void DrowBorder()
        {
            Console.SetCursorPosition(0, 0);
            string line="╔";
            line += new string('═', TetrisCols);
            
            
            line += "╦";
            line += new string('═',InfoCols);
            
            line += "╗";
            Console.WriteLine(line);

            for (int i = 0; i < TetrisRows; i++)
            {
                string middleLine = "║";
                middleLine += new string(' ', TetrisCols);
                middleLine+= "║";
                middleLine += new string(' ', InfoCols);
                middleLine+= "║";
                Console.WriteLine(middleLine);
            }
            string endLine = "╚";
            endLine += new string('═',TetrisCols);
            endLine += "╩";
            endLine += new string('═',InfoCols);
            endLine += "╝";
            Console.Write(endLine);
        }
         static void DrawTetrisField()
        {
            for (int i = 0; i < tetrisField.GetLength(0); i++)
            {string line = "";
                for (int j = 0; j < tetrisField.GetLength(1); j++)
                {
                    
                    if (tetrisField[i,j])
                    {
                        line += "*";
                    }
                    else
                    {
                        line += " ";
                    }
                }
                Write(line,i+1,1);
            }
        }
        static void DrawCurrentFigure()
        {
            
            for (int row = 0; row <currentFigure.GetLength(0); row++)
            {
                string lines="";
                for (int col = 0; col < currentFigure.GetLength(1); col++)
                {
                    if (currentFigure[row,col])
                    {
                        lines += "*";
                    }
                    else
                    {
                        lines += " ";
                    }
                }
                Write(lines, row + 1 + currentFigureRow,1 + currentFigureCol);
            }
        }
    }
}
