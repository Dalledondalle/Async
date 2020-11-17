using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static readonly Random s_rnd = new Random();
    static Stopwatch s;

    static async Task Main()
    {
        s = new Stopwatch();
        s.Start();
        Console.WriteLine($"You rolled {await GetDiceRollAsync()}");
    }

    static async ValueTask<int> GetDiceRollAsync()
    {
        Console.WriteLine("Shaking dice...");

        int roll1 = await RollAsync();
        int roll2 = await RollAsync();
        Console.WriteLine($"Should be 2nd {s.ElapsedMilliseconds}");

        return roll1 + roll2;
    }

    static async ValueTask<int> RollAsync()
    {
        await Task.Delay(500);

        int diceRoll = s_rnd.Next(1, 7);
        return diceRoll;
    }
}