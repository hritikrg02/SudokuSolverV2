// author: Hritik "Ricky" Gupta
// version: 2022.22.1.1

namespace SudokuSolver.Puzzle;

using Solver;
using System.IO;

/// <summary>
/// Represents a configuration of a Sudoku puzzle.
/// </summary>
public class SudokuConfig : IConfiguration{
    
    public const char Empty = '-';
    
    private static int _sDim;
    private char[,] _board;

    public SudokuConfig(string path) {
        using (var sr = File.OpenText(path)) {
            _sDim = sr.Read();
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
        throw new NotImplementedException();
    }

    public bool IsSolution() {
        throw new NotImplementedException();
    }
    
    public bool IsValid() {
        throw new NotImplementedException();
    }
}

// for (var row = 0; row < _sDim; row++) {
//     for (var col = 0; col < _sDim; col++) {
//                 
//     }
// }