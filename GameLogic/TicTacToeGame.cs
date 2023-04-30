namespace TicTacToeAPI.GameLogic
{
    public class TicTacToeGame
    {
        private string[][] board; //The game board
        private Player currentPlayer; //the current player

        public TicTacToeGame()
        {
            //initialize the game board
            board = new string[3][];
            for (int i = 0; i < 3; i++)
            {
                board[i] = new string[3];
                for (int j = 0; j < 3; j++)
                {
                    board[i][j] = "";
                }
            }

            //set the first player to X
            currentPlayer = Player.X;
        }

        public bool MakeMove(int row, int column)
        {
            //check if the move is valid
            if (row < 0 || row > 2 || column < 0 || column > 2 || board[row][column] != "")
            {
                throw new ArgumentException("Invalid move");
            }

            //update the board with current player's mark
            board[row][column] = currentPlayer.ToString();

            //switch to the next player
            currentPlayer = (currentPlayer == Player.X) ? Player.O : Player.X;

            return true;

        }

        public string[][] GetBoard()
        {
            //return a copy of the game board
            return (string[][])board.Clone();
        }

        public string GetCurrentPlayer()
        {
            return currentPlayer.ToString();
        }

        public bool IsGameOver()
        {
            //check if the game is over
            return IsBoardFull() || GetWinner() != null;
        }

        public bool IsBoardFull()
        {
            //check if the board is full
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i][j] == "")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public string GetWinner()
        {
            //check for horizontal wins
            for (int i = 0; i < 3; i++)
            {
                if (board[i][0] != "" && board[i][0] == board[i][1] && board[i][1] == board[i][2])
                {
                    return board[i][0];
                }
            }
            //check for vertical wins
            for (int j = 0; j < 3; j++)
            {
                if (board[0][j] != "" && board[0][j] == board[1][j] && board[1][j] == board[2][j])
                {
                    return board[0][j];
                }
            }
            //check for diagonal wins
            if (board[0][0] != "" && board[0][0] == board[1][1] && board[1][1] == board[2][2])
            {
                return board[0][0];
            }
            if (board[0][2] != "" && board[0][2] == board[1][1] && board[1][1] == board[2][0])
            {
                return board[0][2];
            }
            //no winner
            return null;
        }

        public void ResetGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i][j] = "";
                }
            }

            currentPlayer = Player.X;
        }
    }

        public enum Player
        {
            X,
            O
        }
    }

