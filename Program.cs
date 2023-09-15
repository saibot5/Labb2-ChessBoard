using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ChessBoard
{
    // Tobias Söderqvist .NET23

    internal class Program
    {

        static void Main(string[] args)
        {
            //unicode to show the squares, and setting a unicode standard output
            Console.OutputEncoding = System.Text.Encoding.Unicode;


            //Variables with default choices
            string black = "◼︎";
            string white = "◻︎";
            string piece = "♟️";
            string placement = "A1";
            int boardSize = 0;
            string sizeInput;

            //loop until valid input
            do
            {
                Console.WriteLine("Hur stort bräde? (max 26)");
                sizeInput = Console.ReadLine();
            } while (!Int32.TryParse(sizeInput, out boardSize) || boardSize > 26);

            //Take input for choices
            Console.WriteLine("Hur ska svarta rutor se ut? (lämna tomt för standard)");
            black = TakeInput(black);

            Console.WriteLine("Hur ska vita rutor se ut? (lämna tomt för standard)");
            white = TakeInput(white);

            Console.WriteLine("Hur ska pjäsen se ut (lämna tomt för standard)");
            piece = TakeInput(piece);

            Console.WriteLine("Var ska pjäsen stå? (ex. E4)");
            placement = TakeInput(placement);

         
            StringBuilder stringBuilder = new StringBuilder();

            //convert letter position in alphabet to int by removing 64 from ASCII position to get column
            //Remove first letter using stringbuilder and parse number to int to get row
            stringBuilder.Append(placement.ToUpper());
            int column = stringBuilder[0] - 64;
            stringBuilder.Remove(0, 1);
            int row = Int32.Parse(stringBuilder.ToString());


            //Loop to create board and place chess piece using stringbuilder
            //Start "i" loop at the top and count down to make bottom row 1 for piece placement 
            for (int i = boardSize - 1; i >= 0; i--)
            {
                stringBuilder.Clear();
                for (int j = 0; j < boardSize; j++)
                {
                    if (i == row - 1 && j == column - 1)
                    {
                        stringBuilder.Append(piece);
                        continue;
                    }

                    if (i % 2 == 1)
                    {
                        if (j % 2 == 1)
                        {
                            stringBuilder.Append(white);
                        }
                        else
                        {
                            stringBuilder.Append(black);
                        }
                    }
                    else
                    {
                        if (j % 2 == 1)
                        {
                            stringBuilder.Append(black);
                        }
                        else
                        {
                            stringBuilder.Append(white);
                        }
                    }
                }
                Console.WriteLine(stringBuilder);
            }


        }


        //Take input. If empty/null return default value;
        static string TakeInput(string X)
        {
            string input = Console.ReadLine();

            if (input == null || input == "")
            {
                return X;
            }
            else
            {
                return input;
            }
        }

    }



}