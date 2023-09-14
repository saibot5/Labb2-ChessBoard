using System.Runtime.CompilerServices;
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


            //Default squares and chesspiece if user dont choose
            string defaultPiece = "♟️";
            string defaultBlack = "◼︎";
            string defaultWhite = "◻︎";
            string placementDefualt = "A1";

            //Variables to hold choices
            string black;
            string white;
            string piece;
            string sizeInput;
            string placement;
            int boardSize = 0;



            //loop until valid input
            do
            {
                Console.WriteLine("Hur stort bräde? (max 26)");
                sizeInput = Console.ReadLine();
            } while (!Int32.TryParse(sizeInput, out boardSize) || boardSize > 26);



            //choose black look. if null or empty choose default
            Console.WriteLine("Hur ska svarta rutor se ut? (lämna tomt för standard)");
            string blackInput = Console.ReadLine();
            if (blackInput == null || blackInput == "")
            {
                black = defaultBlack;
            }
            else
            {
                black = blackInput;
            }


            //choose white look. if null or empty choose default
            Console.WriteLine("Hur ska vita rutor se ut? (lämna tomt för standard)");
            string whiteInput = Console.ReadLine();
            if (whiteInput == null || whiteInput == "")
            {
                white = defaultWhite;
            }
            else
            {
                white = whiteInput;
            }

            //choose Chess piece. if null or empty choose default
            Console.WriteLine("Hur ska pjäsen se ut (lämna tomt för standard)");
            string pieceInput = Console.ReadLine();
            if (pieceInput == null || pieceInput == "")
            {
                piece = defaultPiece;
            }
            else
            {
                piece = pieceInput;
            }

            //choose where to place piece. if null or empty choose default
            Console.WriteLine("Var ska pjäsen stå? (ex. E4)");
            string placementInput = Console.ReadLine();
            if (placementInput == null || placementInput == "")
            {
                placement = placementDefualt;
            }
            else
            {
                placement = placementInput;
            }

            StringBuilder stringBuilder = new StringBuilder();
            //convert letter position in alphabet to int by removing 64 from ASCII position to get column
            //Remove first letter using stringbuilder and parse number to int to get row
            stringBuilder.Append(placement.ToUpper());
            int column = stringBuilder[0] - 64;
            stringBuilder.Remove(0,1);
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
    }
}