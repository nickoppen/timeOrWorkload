using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Globalization;
using static Program;

class Program
{
    public void slowProcess(int work, int workLimit = int.MaxValue, long ticks = 864000000000)  // one day
    {
        int i;
        var timeLimit = new TimeSpan(ticks);
        Stopwatch timer= new Stopwatch();
        timer.Start();

        for (i = 0; i < work; i++)
        {
            Thread.Sleep(10);
            if (i > workLimit)
            {
                Console.WriteLine("Working too hard. Counter got to:" + i.ToString());
                timer.Stop();
                return;
            }
            if (timer.Elapsed > timeLimit)
            {
                Console.WriteLine("Working too long. Counter got to:" + i.ToString());
                timer.Stop();
                return;
            }

        }
        Console.WriteLine("Job done. Counter got to: " + i.ToString());
        timer.Stop();
    }

    static void Main()
    {
        var p = new Program();

        p.slowProcess(200);
        p.slowProcess(3000, 200);
        p.slowProcess(100, 200);
        p.slowProcess(100, ticks: 1000000);
        p.slowProcess(10, ticks: 100000000);
        p.slowProcess(1000, workLimit: 2000, ticks: 1000000);
        p.slowProcess(1000, workLimit: 2000, ticks: 10000000);
        p.slowProcess(1000, workLimit: 2000, ticks: 100000000);
        p.slowProcess(1000, workLimit: 600, ticks: 100000000);
        p.slowProcess(1000, workLimit: 2000, ticks: 1000000000);

        Environment.Exit(0);
    }

    static int j = 0;
    static int k = 0;
}
