using System;

namespace TripleT {
    class Program {
        static void Main(string[] args) {
            char[,] game = new Char[3, 3] { { '.', '.', '.' }, { '.', '.', '.' }, { '.', '.', '.' } };
            bool gameOver = false;
            int timesRun = 1;

            while (!gameOver) {
                RenderBoard(game);

                game = MakeMove(timesRun % 2 == 0 ? 'X' : 'O', game);

                timesRun++;
                gameOver = CheckGameOver(game);
            }

            Console.Clear();
            Console.WriteLine("You have won the game");
        }

        static bool CheckGameOver(char[,] game) {
            bool gameOver = false;

            for(int index_row = 0; index_row < game.GetLength(0); index_row++) {
                for(int index_column = 0; index_column < game.GetLength(1); index_column++) {
                    if (index_column == 0) {
                        // Horizontal Check
                        if (game[index_row, 1] == game[index_row, 0] && game[index_row, 2] == game[index_row, 0] && game[index_row, 0] != '.') {
                            gameOver = true;
                        }

                        // Vertical Check
                        if (game[1, index_column] == game[0, index_column] && game[2, index_column] == game[0, index_column] && game[0, index_column] != '.') {
                            gameOver = true;
                        }

                        if ((game[0, 0] == game[1, 1] && game[0, 0] == game[2, 2] && game[0, 0] != '.') || (game[0, 2] == game[1, 1] && game[0, 2] == game[2, 0] && game[0, 2] != '.')) {
                            gameOver = true;
                        }
                    }
                }
            }

            return gameOver;
        }

        static void RenderBoard(char[,] game) {
            string board = "";
            Console.Clear();

            for (int index_row = 0; index_row < game.GetLength(0); index_row++) {
                for (int index_column = 0; index_column < game.GetLength(1); index_column++) {
                    board += index_column % 2 != 0 ? game[index_row, index_column].ToString() : "  " + game[index_row, index_column].ToString() + "  ";
                }

                board += "\n";
            }

            Console.WriteLine(board);
        }

        static char[,] MakeMove(char user, char[,] game) {
            bool validInput = true;
            bool newPosition = true;
            int row;
            int column;

            do {
                if (!newPosition) {
                    Console.WriteLine("That position has been played!");
                }

                do {
                    if (!validInput) {
                        Console.WriteLine("Invalid input, put a number between 1 and 3.");
                    }

                    Console.Write("Enter Row > ");
                    char string_row = Console.ReadKey().KeyChar;

                    validInput = Int32.TryParse(string_row.ToString(), out row);
                    validInput = !validInput ? validInput : row < 4;
                    Console.WriteLine();

                } while (!validInput);

                do {
                    if (!validInput) {
                        Console.WriteLine("Invalid input, put a number between 1 and 3.");
                    }

                    Console.Write("Enter Column > ");
                    char string_column = Console.ReadKey().KeyChar;

                    validInput = Int32.TryParse(string_column.ToString(), out column);
                    validInput = !validInput ? validInput : row < 4;
                    Console.WriteLine();


                } while (!validInput);

                newPosition = game[row - 1, column - 1] == '.';

            } while (!newPosition);


            game[row - 1, column - 1] = user;

            return game;
        }
    }
}
