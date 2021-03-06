// author: Hritik "Ricky" Gupta
// version: 2022.1.26.2

namespace SudokuSolver.Solver; 

/// <summary>
/// Attempts to find a solution to a puzzle using a DFS algorithm.
/// </summary>
public class Solver {
    /// <summary>
    /// Property for the number of configs that have been generated.
    /// </summary>
    public long NumConfigs {
        get;
        private set;
    }
    
    /// <summary>
    /// Uses a recursive backtracker to solve a given config.
    /// </summary>
    /// <param name="config">A configuration of a puzzle</param>
    /// <returns></returns>
    public List<IConfiguration> Solve(IConfiguration config) {
        if (config.IsSolution()) {
            return new List<IConfiguration>() {config};
        }

        foreach (var child in config.GetSuccessors()) {
            NumConfigs++;
            if (!child.IsValid()) {
                continue;
            }
            var sol = Solve(child);
            if (sol.Any()) {
                return sol;
            }
        }

        return new List<IConfiguration>();
    }
}