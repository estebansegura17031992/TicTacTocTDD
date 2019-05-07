using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Services
{
    public interface IGameWinnerService
    {
        char Validate(char[,] gameBoard);
    }

    public class GameWinnerService:IGameWinnerService
    {
        private const char SymbolForNoWinner = ' ';
        private char actualSymbol;
        private char[] threeInARow = new char[3] { ' ',' ',' '};

        public char Validate(char[,] gameBoard)
        {
            var currentWinnerSymbol = SymbolForNoWinner;
            currentWinnerSymbol = CheckForThreeInARowInHorizontalRow(gameBoard);
            if(currentWinnerSymbol == SymbolForNoWinner)
            {
                currentWinnerSymbol = CheckForThreeInARowInAVerticalColumn(gameBoard);
                if(currentWinnerSymbol == SymbolForNoWinner)
                {
                    currentWinnerSymbol = CheckForThreeInARowDiagonally(gameBoard);
                }
            }
            return currentWinnerSymbol;
        }

        private char CheckForThreeInARowInHorizontalRow(char[,] gameBoard)
        {
            for(var horizontalRow = 0;horizontalRow < 3; horizontalRow++)
            {
                for(var verticalRow = 0;verticalRow < 3; verticalRow++)
                {
                    threeInARow[verticalRow] = gameBoard[horizontalRow, verticalRow];
                }
                actualSymbol = CheckForAWinner(threeInARow);
                if(actualSymbol != SymbolForNoWinner)
                {
                    return actualSymbol;
                }
            }
            return actualSymbol;
        }

        private char CheckForThreeInARowInAVerticalColumn(char[,] gameBoard)
        {
            for (var horizontalRow = 0; horizontalRow < 3; horizontalRow++)
            {
                for (var verticalRow = 0; verticalRow < 3; verticalRow++)
                {
                    threeInARow[verticalRow] = gameBoard[verticalRow, horizontalRow];
                }
                actualSymbol = CheckForAWinner(threeInARow);
                if (actualSymbol != SymbolForNoWinner)
                {
                    return actualSymbol;
                }
            }
            return actualSymbol;
        }

        private char CheckForThreeInARowDiagonally(char[,] gameBoard)
        {
            var verticalRow = 2;
            var threeInAInverseRow = new char[3] { ' ', ' ', ' ' };
            for (var horizontalRow = 0; horizontalRow < 3; horizontalRow++)
            {
                threeInARow[horizontalRow] = gameBoard[horizontalRow, horizontalRow];
                threeInAInverseRow[horizontalRow] = gameBoard[horizontalRow, verticalRow];
                verticalRow--;
            }
            actualSymbol = CheckForAWinner(threeInARow);
            if(actualSymbol == SymbolForNoWinner)
            {
                actualSymbol = CheckForAWinner(threeInAInverseRow);
            }
            return actualSymbol;
        }

        private static char CheckForAWinner(char[] LineChar)
        {
            if(LineChar[0] == LineChar[1] &&
                LineChar[1] == LineChar[2])
            {
                return LineChar[0];
            }
            return SymbolForNoWinner;
        }
    }
}
