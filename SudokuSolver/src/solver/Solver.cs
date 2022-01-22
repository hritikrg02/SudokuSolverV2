// author: Hritik "Ricky" Gupta
// version: 2022.22.1.1

namespace SudokuSolver.Solver; 

/// <summary>
/// Attempts to find a solution to a puzzle using a DFS algorithm.
/// </summary>
public class Solver {
    private long _numConfigs = 0;

    public long NumConfigs {
        get => _numConfigs;
        private set => _numConfigs = value;
    }

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