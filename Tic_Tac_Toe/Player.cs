using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tic_Tac_Toe
{

    interface IMoving
    {
        bool MakeMove(char[,] startBoard, char[,] gameBoard);
    }


    abstract class generalPlay
    {
        public string Name { get; set; }
        public char Flage { get; set; }


        public bool checkIfPlayerWon(char[,] gameBoard)
        {
            int heightY = gameBoard.GetLength(0);
            int widthX = gameBoard.GetLength(1);

            if (heightY != widthX)
                throw new Exception("The board is not square!"); ;



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
            for (int x = 0; x < widthX; x++)
            {
                int colSum = 0;

                for (int y = 0; y < heightY; y++)
                {
                    if (gameBoard[y, x] == Flage)
                        colSum++;
                }
                if (colSum == heightY)
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

        public bool PlaceSymbol(char n, char[,] startBoard, char[,] gameBoard)
        {
            int heightY = gameBoard.GetLength(0);
            int widthX = gameBoard.GetLength(1);

            if (heightY != startBoard.GetLength(0) || widthX != startBoard.GetLength(1))
                throw new Exception("The boards have different sizes!");

            for (int y = 0; y < heightY; y++)
                for (int x = 0; x < widthX; x++)
                    if ((gameBoard[y, x] == n) && (gameBoard[y, x] == startBoard[y, x]))
                    {
                        gameBoard[y, x] = Flage;
                        return true;
                    }

            // else, return unsuccess
            return false;
        }
    }



    class HumanPlayer : generalPlay, IMoving
    {
        public bool MakeMove(char[,] startBoard, char[,] gameBoard)
        {
            //Human: move
            char chosenPlacePlayer;

            do
            {
                Console.Write("Choose an empty place: ");
                chosenPlacePlayer = Console.ReadKey().KeyChar;
                Console.WriteLine();

            }
            while (!PlaceSymbol(chosenPlacePlayer, startBoard, gameBoard));

            return checkIfPlayerWon(gameBoard);
        }
    }

    class AI : generalPlay, IMoving
    {
        public bool MakeMove(char[,] startBoard, char[,] gameBoard)
        {
            //AI: move
            Random rnd = new Random();
            char chosenPlaceAI;

            do
            {
                int p = rnd.Next(1, gameBoard.Length + 1); // random 1-9
                chosenPlaceAI = p.ToString()[0];
            }
            while (!PlaceSymbol(chosenPlaceAI, startBoard, gameBoard));

            Thread.Sleep(2000);

            return checkIfPlayerWon(gameBoard);
        }
    }

}
