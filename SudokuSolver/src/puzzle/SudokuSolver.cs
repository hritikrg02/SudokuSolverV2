// author: Hritik "Ricky" Gupta
// version: 2022.1.23.1

using System.Diagnostics;

namespace SudokuSolver.Puzzle; 

using Solver;

/// <summary>
/// Contains the main method.
/// </summary>
public class SudokuSolver {
    public static void Main(string[] args) {
        if (args.Length != 1) {
            Console.WriteLine("Usage: dotnet run path");
        }

        var solver = new Solver();
        var config = new SudokuConfig(args[0]);
        var sw = new Stopwatch();

        var solution = solver.Solve(config);
        var totalTime = sw.ElapsedMilliseconds;

        if (solution.Any()) {
            Console.WriteLine("No solution for this puzzle.");
        } else {
            Console.WriteLine("Solution found:");
            Console.WriteLine(solution[0].ToString());
        }
        
        Console.WriteLine("Time elapsed: {0} seconds", totalTime);
        Console.WriteLine("Number of configs generated: {0}", solver.NumConfigs);
    }
}