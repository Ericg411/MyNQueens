namespace MyNQueens;
public class QueenBoard
{
    public IList<IList<string>> result = new List<IList<string>>();
    public IList<IList<string>> SolveNQueens(int n)
    {
        switch (n)
        {
            case 1:
                IList<string> list = new List<string> { "Q" };
                result.Add(list);
                return result;
                break;
            case 2:
                return result;
                break;
            case 3:
                return result;
                break;
            default:
                break;
        }



        return result;
    }

    public void BoardMaker(IList<IList<string>> board)
    {

    }

    public bool Checker(IList<IList<string>> board)
    {
        //check horizontal
        foreach (IList<string> row in board)
        {
            int rowCount = 0;

            foreach (string s in row)
            {
                if (s == "Q")
                {
                    rowCount++;
                }
                if (rowCount > 1)
                {
                    return false;
                }
            }
            
        }
        //check vertical
        for (int i = 0; i < board.Count; i++)
        {
            for (int j = 0; j < board[i].Count; j++)
            {
                if (board[i][j] == "Q")
                {
                    int counter = i + 1;
                    while (counter < board.Count)
                    {
                        if (board[counter][j] == "Q")
                        {
                            return false;
                        }
                        counter++;
                    }
                }
            }
        }
        //check diagonal
        for (int i = 0; i < board.Count; i++)
        {
            for (int j = 0; j < board[i].Count; j++)
            {
                if (board[i][j] =="Q")
                {
                    int counterI = i;
                    int counterJ = j;
                    int reverseI = i;
                    int reverseJ = j;
                    while (reverseI > 0 || reverseJ > 0 || counterI < board.Count || counterJ < board[i].Count)
                    {
                        reverseI--;
                        reverseJ--;
                        counterI++;
                        counterJ++;
                        if (reverseI >= 0 && reverseJ >= 0)
                        {
                            if (board[reverseI][reverseJ] == "Q")
                            {
                                return false;
                            }
                        }
                        if (counterI < board.Count && counterJ < board[i].Count)
                        {
                            if (board[counterI][counterJ] == "Q")
                            {
                                return false;
                            }
                        }
                    }

                }
            }
        }

        return true;
    }
}
