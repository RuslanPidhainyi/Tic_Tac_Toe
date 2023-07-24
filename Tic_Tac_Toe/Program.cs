using System.Numerics;
using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            bool start = true;

            do
            {
                Console.Clear();

                HumanPlayer you = new HumanPlayer();
                AI bot = new AI();

                Console.WriteLine("Please, entre your name and click button\"Enter\". ");
                you.Name = Console.ReadLine(); //"Player";

                Console.Clear();
                Console.WriteLine($"Thank you {you.Name}! Have a nice game)");
                Thread.Sleep(2000);

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
                        Console.WriteLine($"{you.Name} move");
                        Player1_Won = you.MakeMove(startBorad, gameBoard);

                        PlayerIsNext = false;
                    }
                    else //player 2 move,
                    {
                        Console.WriteLine($"{bot.Name} move");
                        Player2_Won = bot.MakeMove(startBorad, gameBoard);

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

                if (Player1_Won)
                    Console.WriteLine($"Winner: {you.Name}");
                else if (Player2_Won)
                    Console.WriteLine($"Winner: {bot.Name}");
                else Console.WriteLine("A tie");


                Console.WriteLine("\nIf you want close game \"x\", or if you want continue click button \"Enter\" \n");
                start = Console.ReadLine() == "x";
            }
            while (!start);
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        static void DrawBoard(char[,] board)
        {
            for (int y = 0; y < board.GetLength(0); y++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                    Console.Write(board[y, x]);
                Console.WriteLine("\n");
            }
        }
    }

    

    
}