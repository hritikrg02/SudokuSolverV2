// author: Hritik "Ricky" Gupta
// version: 2022.1.23.4

namespace SudokuSolver.Puzzle;

using System.Text;
using System.Text.RegularExpressions;
using Solver;
using System.IO;
using System.Linq;


/// <summary>
/// Represents a configuration of a Sudoku puzzle.
/// </summary>
public class SudokuConfig : IConfiguration{
    
    public const char Empty = '-';
    public const int AsciiConst = 48;
    
    private static int _sDim;
    private char[,] _board;

    public SudokuConfig(string path) {
        using (var sr = File.OpenText(path)) {
            _sDim = int.Parse(sr.ReadLine());
            _board = new char[_sDim, _sDim];

            for (var row = 0; row < _sDim; row++) {
                var rowValues = sr.ReadLine().Split();
                for (var col = 0; col < _sDim; col++) {
                    _board[row, col] = char.Parse(rowValues[col]);
                }
            }
        }
    }

    public SudokuConfig(SudokuConfig other) {
        _board = new char[_sDim, _sDim];
        _board = other._board.Clone() as char[,];
    }

    public ICollection<IConfiguration> GetSuccessors() {
        var successors = new List<IConfiguration>();
        
        for (var row = 0; row < _sDim; row++) {
            for (var col = 0; col < _sDim; col++) {
                
                if (_board[row, col] != Empty) {
                    continue;
                }
                
                for (var i = 1; i <= _sDim; i++) {
                    var successor = new SudokuConfig(this);
                    successor._board[row, col] = Convert.ToChar(i + AsciiConst);
                    successors.Add(successor);
                }
                
                return successors;
            }
        }
        
        return successors; //should never be here
    }

    public bool IsSolution() {
        foreach (var tile in _board) {
            if (tile == Empty) {
                return false;
            }
        }
        
        return IsValid();
    }
    
    public bool IsValid() {
        var loopedCols = new HashSet<int>();
        var subDim = Math.Sqrt(_sDim);
        
        for (var row = 0; row < _sDim; row++) {
            var outputRow = new StringBuilder();
            
            for (var col = 0; col < _sDim; col++) {
                outputRow.Append(_board[row, col]);
                
                if (loopedCols.Add(col)) {
                    continue;
                }
                
                var outputCol = new StringBuilder();
                for (var colRow = 0; colRow < _sDim; colRow++) {
                    outputCol.Append(_board[colRow, col]);
                }

                for (var i = 1; i <= _sDim; i++) {
                    var rgx = new Regex(".*" + i + ".*" + i + ".*");
                    if (rgx.IsMatch(outputCol.ToString())) {
                        return false;
                    }
                }
            }
            
            for (var j = 1; j <= _sDim; j++) {
                var rgx = new Regex(".*" + j + ".*" + j + ".*");
                if (rgx.IsMatch(outputRow.ToString())) {
                    return false;
                }
            }
        }

        for (var subBoardRow = 0; subBoardRow < subDim; subBoardRow++) {
            for (var subBoardCol = 0; subBoardCol < subDim; subBoardCol++) {
                if (!CheckSubBoard(subBoardRow, subBoardCol)) {
                    return false;
                }
            }
        }

        return true;
    }

    private bool CheckSubBoard(int row, int col) {
        var subBoard = new StringBuilder();
        var subDim = Convert.ToInt32(Math.Sqrt(_sDim));

        for (var subRow = 0; subRow < subDim; subRow++) {
            for (var subCol = 0; subCol < subDim; subCol++) {
                subBoard.Append(_board[(row * subDim) + subRow, (col * subDim) + subCol]);
            }
        }

        for (var i = 1; i <= _sDim; i++) {
            var rgx = new Regex(".*" + i + ".*" + i + ".*");
            if (rgx.IsMatch(subBoard.ToString())) {
                return false;
            }
        }

        return true;
    }

    public override string ToString() {
        var output = new StringBuilder();
        var subDim = Convert.ToInt32(Math.Sqrt(_sDim));
        output.AppendLine();
        
        for (var row = 0; row < _sDim; row++) {
            for (var col = 0; col < _sDim; col++) {
                
                if (col % subDim == 0) {
                    output.Append("| ");
                }
                
                output.Append(_board[row, col]);
                output.Append(" ");
            }

            output.Append("|");
            output.AppendLine();
        }
        
        return output.ToString();
    }
}

// for (var row = 0; row < _sDim; row++) {
//     for (var col = 0; col < _sDim; col++) {
//                 
//     }
// }