namespace MyNQueens.Tests;

[TestClass]
public class UnitTest1
{
    private readonly QueenBoard _test;
    public UnitTest1()
    {
        _test = new QueenBoard();
    }
    [TestMethod]
    public void ICall_WithValidBoard_ReturnTrue()
    {
        IList<IList<string>> board = new List<IList<string>>();
        IList<string> rowOne = new List<string> { ".", "Q", ".", "." };
        IList<string> rowTwo = new List<string> { ".", ".", ".", "Q" };
        IList<string> rowThree = new List<string> { "Q", ".", ".", "." };
        IList<string> rowFour = new List<string> { ".", ".", "Q", "." };
        board.Add(rowOne);
        board.Add(rowTwo);
        board.Add(rowThree);
        board.Add(rowFour);
        var result = _test.Checker(board);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ICall_WithOne_ReturnSingleQueen()
    {
        IList<IList<string>> result = _test.SolveNQueens(1);
        IList<string> list = new List<string>{"Q"};
        IList<IList<string>> expectedList = new List<IList<string>>();
        expectedList.Add(list);
        var one = result[0][0];
        var two = expectedList[0][0];
        Assert.IsTrue(one == two);
    }

    [TestMethod]
    public void ICall_WithInvalidBoard_ReturnFalse()
    {
        IList<IList<string>> board = new List<IList<string>>();
        IList<string> rowOne = new List<string> { "Q", ".", ".", "." };
        IList<string> rowTwo = new List<string> { ".", ".", ".", "Q" };
        IList<string> rowThree = new List<string> { ".", "Q", ".", "." };
        IList<string> rowFour = new List<string> { ".", ".", "Q", "." };
        board.Add(rowOne);
        board.Add(rowTwo);
        board.Add(rowThree);
        board.Add(rowFour);
        var result = _test.Checker(board);
        Assert.IsFalse(result);
    }
}