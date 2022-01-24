// author: Hritik "Ricky" Gupta
// version: 2022.1.22.1

namespace SudokuSolver.Solver; 

/// <summary>
/// Attempts to find a solution to a puzzle using a DFS algorithm.
/// </summary>
public class Solver {
    /// <summary>
    /// Number of configs that have been generated.
    /// </summary>
    private long _numConfigs = 0;
    
    /// <summary>
    /// Property for the number of configs that have been generated.
    /// </summary>
    public long NumConfigs {
        get => _numConfigs;
        private set => _numConfigs = value;
    }
    
    /// <summary>
    /// Uses a recursive backtracker to solve a given config.
    /// </summary>
    /// <param name="config">A configuration of a puzzle</param>
    /// <returns></returns>
    public List<IConfiguration> Solve(IConfiguration config) {
        if (config.IsSolution()) {
            var optional = new List<IConfiguration>();
            optional.Add(config);
            return optional;
        }

        foreach (var child in config.GetSuccessors()) {
            NumConfigs++;
            if (child.IsValid()) {
                var sol = Solve(child);
                if (sol.Any()) {
                    return sol;
                }
            }
        }

        return new List<IConfiguration>();
    }
}