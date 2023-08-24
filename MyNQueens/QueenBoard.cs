using System.Text;

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

        IList<string> startingBoard = BoardMaker(n);

        QueenPlacer(startingBoard, 0, 0);

        return result;
    }

    public IList<string> BoardMaker(int n)
    {
        IList<string> board = new List<string>();

        foreach (int i in Enumerable.Range(1, n))
        {
            string row = "";

            foreach (int j in Enumerable.Range(1, n))
            {
                row += ".";
            }

            board.Add(row);
        }

        return board;
    }

    public void QueenPlacer(IList<string> board, int columnIndex, int rowIndex)
    {
        while (columnIndex < board.Count)
        {
            StringBuilder test = new StringBuilder(board[columnIndex]);
            test[rowIndex] = 'Q';
            board[columnIndex] = test.ToString();
            QueenPlacer(board, columnIndex + 1, rowIndex + 1);
            board[columnIndex].Replace('Q', '.');
            columnIndex++;
            rowIndex++;
        }

        if (Checker(board))
        {
            result.Add(board);
        }
    }

    public bool Checker(IList<string> board)
    {
        //check rows

        foreach (string row in board)
        {
            var indexOne = row.IndexOf('Q');
            var indexTwo = row.LastIndexOf('Q');
            if (indexOne != indexTwo)
            {
                return false;
            }
        }

        //check columns
        var hashset = new HashSet<string>();
        foreach (string row in board)
        {
            if (!hashset.Add(row))
            {
                return false;
            }
        }

        //DIAGONAL MATTERS AND YOU HAVE TO FIX IT, ERIC

        return true;
    }
}
