// author: Hritik "Ricky" Gupta
// version: 2022.22.1.1

namespace SudokuSolver.Solver; 

/// <summary>
/// Represents the methods needed for a config of a puzzle to be generated.
/// </summary>
public interface IConfiguration {
    
    /// <summary>
    /// Checks if a given configuration is a solution or not.
    /// </summary>
    /// <returns>true if the config is a solution, false otherwise</returns>
    bool IsSolution();
    
    /// <summary>
    /// Finds all possible next iterations of the puzzle, valid or not.
    /// </summary>
    /// <returns>ICollection of configs that are successors to the intial config</returns>
    ICollection<IConfiguration> GetSuccessors();
    
    /// <summary>
    /// Checks if a given config is a valid state of the puzzle.
    /// </summary>
    /// <returns>true if config is valid, false otherwise</returns>
    bool IsValid();
}