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
    public void ICall_WithNothing_ReturnTrue()
    {
        IList<string> list = new List<string>();
        var result = _test.Checker(list);
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
}