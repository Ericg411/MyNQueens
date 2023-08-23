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

    public bool Checker(IList<string> list)
    {
        return true;
    }
}
