namespace MyNQueens.Tests;

[TestClass]
public class UnitTest1
{
    public QueenBoard _test;
    public UnitTest1()
    {
        _test = new QueenBoard();
    }

    [TestMethod]
    public void ICallSolveNQueens_WithFour_ReturnTrue()
    {
        _test.SolveNQueens(4);
    }

    [TestMethod]
    public void ICallChecker_WithValidBoard_ReturnTrue()
    {
        IList<string> boardOne = new List<string> { ".Q..",
                                                    "...Q",
                                                    "Q...",
                                                    "..Q."};

        var result = _test.Checker(boardOne);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ICallSolveNQueens_WithOne_ReturnSingleQueen()
    {
        IList<IList<string>> result = _test.SolveNQueens(1);
        IList<string> list = new List<string> { "Q" };
        IList<IList<string>> expectedList = new List<IList<string>>();
        expectedList.Add(list);
        var one = result[0][0];
        var two = expectedList[0][0];
        Assert.IsTrue(one == two);
    }

    [TestMethod]
    public void ICallChecker_WithInvalidRow_ReturnFalse()
    {
        IList<IList<string>> board = new List<IList<string>>();
        IList<string> boardOne = new List<string> { "Q..Q",
                                                    "....",
                                                    ".Q..",
                                                    "..Q." };
        var result = _test.Checker(boardOne);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ICallChecker_WithInvalidColumn_ReturnFalse()
    {
        IList<string> boardOne = new List<string> { "Q...",
                                                    "Q...",
                                                    "...Q",
                                                    "Q..." };
        var result = _test.Checker(boardOne);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ICallChecker_WithInvalidDiagonal_ReturnFalse()
    {
        IList<string> boardOne = new List<string> { "Q...",
                                                    ".Q..",
                                                    "..Q.",
                                                    "...Q" };
        var result = _test.Checker(boardOne);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ICallChecker_WithInvalidDiagonalTwo_ReturnFalse()
    {
        IList<string> boardOne = new List<string> { "...Q",
                                                    "..Q.",
                                                    ".Q..",
                                                    "Q..." };
        var result = _test.Checker(boardOne);
        Assert.IsFalse(result);
    }
    [TestMethod]
    public void ICallChecker_WithInvalidDiagonalThree_ReturnFalse()
    {
        IList<string> boardOne = new List<string> { "Q...",
                                                    "..Q.",
                                                    "...Q",
                                                    ".Q.." };
        var result = _test.Checker(boardOne);
        Assert.IsFalse(result);
    }
    [TestMethod]
    public void ICallChecker_WithNothing_ReturnFalse()
    {
        IList<string> boardOne = new List<string>       { "....",
                                                        "....",
                                                        "....",
                                                        "...." };
        var result = _test.Checker(boardOne);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ICallBoardMaker_WithFour_ReturnEmptyFourByFour()
    {
        IList<string> board = new List<string> { "....",
                                                 "....",
                                                 "....",
                                                 "...."};
        var result = _test.BoardMaker(4);
        Assert.IsTrue(board.SequenceEqual(result));
    }

    [TestMethod]
    public void ICallQueenPlacer_LetsSeeWhatHappens()
    {
        IList<string> board = _test.BoardMaker(5);
        _test.QueenPlacer(board, 0, 0);
        Assert.IsTrue(_test.result.Any());
    }
    [TestMethod]
    public void ICallSolveNQueens_ItReturnsValidBoard()
    {
        IList<string> board = _test.BoardMaker(4);
        IList<IList<string>> resultBoard = _test.SolveNQueens(4);
        IList<IList<string>> result = new List<IList<string>>();
        IList<string> board1 = new List<string> {".Q..",
                                                 "...Q",
                                                 "Q...",
                                                 "..Q."};
        IList<string> board2 = new List<string> {"..Q.",
                                                 "Q...",
                                                 "...Q",
                                                 ".Q.."};
        result.Add(board1);
        result.Add(board2);
        bool areEqual = true;
        for (int i = 0; i < resultBoard.Count; i++)
        {
            if (!resultBoard[i].SequenceEqual(result[i]))
            {
                areEqual = false;
            }
        }
        Assert.IsTrue(areEqual);
    }
}