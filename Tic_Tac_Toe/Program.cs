using System.Numerics;
using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool start = true;

            //do
            //{


            //    Board.DrawBoard();

            //    Game.Round();

            //    Console.WriteLine("\nJeżelei chcesz wyjść napisz \"x\", jeżeli  chcesz kontynować klikni \"Enter\" \n");
            //    start = Console.ReadLine() == "x";
            //}
            //while (!start);

            HumanPlayer you = new HumanPlayer();
            AI bot = new AI();

            you.Name = "Player";
            bot.Name = "PC";
            you.Flage = 'x';
            bot.Flage = 'o';

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            char[,] startBorad =
            {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' }
            };


            //gameBord = Dublication startBoard
            char[,] gameBoard = startBorad.Clone() as char[,];

           

           bool Player1_Won = false;
           bool Player2_Won = false;
           bool PlayerIsNext = true; // true - player 1 move,
                                     // false - player 2 move

            //////////////////////////////////////////////////////////////////////////////////////////////////

            //One move = One Round
            
            
                for (int round = 0; round < gameBoard.Length; round++)
                {
                    Console.Clear();
                    DrawBoard(gameBoard);

                    if (PlayerIsNext) //player 1 move,
                    {
                        Console.WriteLine(you.Name + " move");
                        Player1_Won = you.MakeMove(startBorad, gameBoard);

                        PlayerIsNext = false;
                    }
                    else //player 2 move,
                    {
                        Console.WriteLine(you.Name + " move");
                        Player2_Won = you.MakeMove(startBorad, gameBoard);

                        PlayerIsNext = true;
                    }

                    //Finished
                    if (Player1_Won || Player2_Won)
                        break;
                }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            // End the game
            Console.Clear();
            DrawBoard(gameBoard);
            Console.Write("Game ended! ");
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        static void DrawBoard(char[,] board)
        {
            for (int y = 0; y < board.GetLength(0); y++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    Console.Write(board[y, x]);
                }
                Console.WriteLine("\n");
            }
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////

    interface IMoving
    {
        bool MakeMove(char[,] startBoard, char[,] gameBoard);
    }


    abstract public class generalPlay
    {
        public  string Name { get; set; }
        public  char Flage { get; set; }

    
        public  bool checkIfPlayerWon(char[,] gameBoard)
        {
            int heightY = gameBoard.GetLength(0);
            int widthX = gameBoard.GetLength(1);

            if (heightY != widthX)
                //throw new Exception("The board is not square!"); ;



            // Check rows
            for (int y = 0; y < heightY; y++)
            {
                int rowSum = 0;

                for (int x = 0; x < widthX; x++)
                {
                    if (gameBoard[y, x] == Flage)
                        rowSum++;   
                }
                if (rowSum == widthX)
                    return true;
            }


            // Check colms
            for(int x=0; x < widthX;x++)
            {
                int colSum = 0;

                for(int y = 0; y<heightY; y++)
                {
                    if (gameBoard[y, x] == Flage)
                        colSum++;
                }
                if(colSum == heightY)
                    return true;
            }


            //Check diagonals
            int diagSumA = 0;
            int diagSumB = 0;


            for (int z = 0; z < widthX; z++)
            {
                if (gameBoard[z, z] == Flage)
                    diagSumA++;
                if (gameBoard[z, widthX - 1 - z] == Flage)
                    diagSumB++;
            }

            if (diagSumA == widthX || diagSumB == widthX)
                return true;

            //Else, no win
            return false;   
        }
    }

    class HumanPlayer : generalPlay, IMoving
    {
        public bool MakeMove(char[,] startBoard, char[,] gameBoard)
        {
            //Human: move
            return checkIfPlayerWon(gameBoard);
        }
    }

    class AI : generalPlay, IMoving
    {
        public bool MakeMove(char[,] startBoard, char[,] gameBoard)
        {
            //AI: move
            return checkIfPlayerWon(gameBoard);
        }
    }
}