using System.Numerics;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            Board.DrawBoard();

            Game.Round();
           
        }
    }


    class Board
    {

        public static char[,] startBorad =
        {
            { '1', ' ', '2', ' ', '3' },
            { '4', ' ', '5', ' ', '6' },
            { '7', ' ', '8', ' ', '9' }
        };



        //gameBord = Dublication startBoard
        public static char[,] gameBoard = startBorad.Clone() as char[,];



        public static void DrawBoard()
        {
            for (int y = 0; y < gameBoard.GetLength(0); y++)
            {
                for (int x = 0; x < gameBoard.GetLength(1); x++)
                {
                    Console.Write(gameBoard[y, x]);
                }
                Console.WriteLine("\n");
            }
        }
    }
                                     


   class Game : Board
   {

        public static bool Player1_Won = false;
        public static bool Player2_Won = false;
        public static bool PlayerIsNext = true;// true - player 1 move,
                                                // false - player 2 move

        //One move = One Round
        public static void Round()//Move
        {
            for (int round = 0; round < gameBoard.Length; round++)
            {
                //Console.Clear();

                if (PlayerIsNext) //player 1 move,
                {
                    PlayerIsNext = true;
                }
                else //player 2 move,
                {
                    PlayerIsNext = false;
                }

                //Finished
                if (Player1_Won || Player2_Won)
                    break;
            }
        }
   }
   
}