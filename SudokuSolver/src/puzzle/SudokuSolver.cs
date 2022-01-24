// author: Hritik "Ricky" Gupta
// version: 2022.1.24.1

namespace SudokuSolver.Puzzle;

using System.Diagnostics;
using Solver;

/// <summary>
/// Contains the main method.
/// </summary>
public class SudokuSolver {
    public static void Main(string[] args) {
        if (args.Length != 1) {
            Console.WriteLine("Usage: dotnet run path");
            return;
        }
        
        Console.WriteLine("Starting solver...");

        var solver = new Solver();
        var config = new SudokuConfig(args[0]);
        
        var sw = new Stopwatch();
        sw.Start();

        var solution = solver.Solve(config);
        
        sw.Stop();
        var totalTime = sw.ElapsedMilliseconds;

        if (!solution.Any()) {
            Console.WriteLine("No solution for this puzzle.");
        } else {
            Console.WriteLine("Solution found:");
            Console.WriteLine(solution[0].ToString());
        }
        
        Console.WriteLine("Time elapsed: {0} ms", totalTime);
        Console.WriteLine("Number of configs generated: {0}", solver.NumConfigs);
    }
}