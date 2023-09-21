using System.Collections;
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
            case 2:
                return result;
            case 3:
                return result;
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
        while (columnIndex < board.Count && rowIndex < board[columnIndex].Length)
        {
            for (int i = rowIndex; i < board[columnIndex].Length; i++)
            {
                StringBuilder editColumn = new StringBuilder(board[columnIndex]);
                editColumn[i] = 'Q';
                board[columnIndex] = editColumn.ToString();
                QueenPlacer(board, columnIndex + 1, 0);
                board[columnIndex] = board[columnIndex].Replace('Q', '.');
            }
            columnIndex++;
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

        //check diagonal
        for (int i = 0; i < board.Count; i++)
        {
            var qIndex = board[i].IndexOf('Q');

            if (i == 0)
            {
                int modifier = 1;
                int currentI = i + 1;
                while (currentI <= board.Count - 1)
                {
                    if (qIndex + modifier <= board.Count - 1)
                    {
                       if (board[currentI][qIndex + modifier] == 'Q')
                        {
                            return false;
                        }
                    }
                    if (qIndex - modifier >= 0)
                    {
                        if (board[currentI][qIndex - modifier] == 'Q')
                        {
                            return false;
                        }
                    }
                    currentI++;
                    modifier++;
                }

            }
        }
        return true;
    }
}
