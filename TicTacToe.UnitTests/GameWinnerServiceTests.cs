using NUnit.Framework;
using TicTacToc.Services;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class GameWinnerServiceTests
    {
        IGameWinnerService gameWinnerService;
        private char[,] gameBoard;
        private const char expectedEmpty = ' ';
        private const char expectedSelected = 'X';
        [SetUp]
        public void SetUpUnitTest()
        {
            gameWinnerService = new GameWinnerService();
            gameBoard = new char[3, 3]  {
                                                {' ',' ',' '},
                                                {' ',' ',' '},
                                                {' ',' ',' '}
                                            };
        }

        [Test]
        public void NeitherPlayerHasThreeInARow()
        {
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expectedEmpty, actual);
        }

        [Test]
        public void PlayerWithAllSpaceInTopRowIsWinner()
        {
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                gameBoard[0, columnIndex] = expectedSelected;
            }
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expectedSelected.ToString(), actual.ToString());
        }

        [Test]
        public void PlayerWithAllSpaceInMiddleRowIsWinner()
        {
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                gameBoard[1, columnIndex] = expectedSelected;
            }
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expectedSelected.ToString(), actual.ToString());
        }

        [Test]
        public void PlayerWithAllSpaceInBottomRowIsWinner()
        {
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                gameBoard[2, columnIndex] = expectedSelected;
            }
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expectedSelected.ToString(), actual.ToString());
        }

        [Test]
        public void PlayerWithAllSpacesInFirstColumnIsWinner()
        {
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                gameBoard[columnIndex, 0] = expectedSelected;
            }
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expectedSelected.ToString(), actual.ToString());
        }

        [Test]
        public void PlayerWithAllSpacesInSecodColumnIsWinner()
        {
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                gameBoard[columnIndex, 1] = expectedSelected;
            }
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expectedSelected.ToString(), actual.ToString());
        }

        [Test]
        public void PlayerWithAllSpacesInThirdColumnIsWinner()
        {
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                gameBoard[columnIndex, 2] = expectedSelected;
            }
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expectedSelected.ToString(), actual.ToString());
        }
        [Test]
        public void PlayerWithThreeInARowDiagonallyDownAndToRigthIsWinner()
        {
            for (var cellIndex = 0; cellIndex < 3; cellIndex++)
            {
                gameBoard[cellIndex, cellIndex] = expectedSelected;
            }
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expectedSelected.ToString(), actual.ToString());
        }

        [Test]
        public void PlayerWithThreeInARowDiagonalDownAndToLeftIsWinner()
        {
            var cellIndexInverse = 2;
            for (var cellIndex = 0; cellIndex < 3; cellIndex++)
            {
                gameBoard[cellIndex, cellIndexInverse] = expectedSelected;
                cellIndexInverse -= 1;
            }
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expectedSelected.ToString(), actual.ToString());
        }
    }
}