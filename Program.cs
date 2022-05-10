using System;

namespace RoundRobinAlgo
{
    class Program
    {
		static void findWaitingTime(int[] processes, int n, int[] bt, int[] wt, int quantum)
		{
			int[] rem_bt = new int[n];

			for (int i = 0; i < n; i++)
				rem_bt[i] = bt[i];

			int t = 0; 

			while (true)
			{
				bool done = true;

				for (int i = 0; i < n; i++)
				{
					if (rem_bt[i] > 0)
					{
						done = false;

						if (rem_bt[i] > quantum)
						{
							t += quantum;

							rem_bt[i] -= quantum;
						}

						else
						{
							t = t + rem_bt[i];

							wt[i] = t - bt[i];

							rem_bt[i] = 0;
						}
					}
				}

				if (done == true)
					break;
			}
		}

		static void findTurnAroundTime(int[] processes,	int n, int[] bt, int[] wt, int[] tat)
		{
			for (int i = 0; i < n; i++)
				tat[i] = bt[i] + wt[i];
		}

		static void findavgTime(int[] processes, int n,	int[] bt, int quantum)
		{
			int[] wt = new int[n];
			int[] tat = new int[n];
			int total_wt = 0, total_tat = 0;

			findWaitingTime(processes, n, bt, wt, quantum);

			findTurnAroundTime(processes, n, bt, wt, tat);

			Console.WriteLine("Processes " + " Burst time " +" Waiting time " + " Turn around time");

			for (int i = 0; i < n; i++)
			{
				total_wt = total_wt + wt[i];
				total_tat = total_tat + tat[i];
				Console.WriteLine(" " + (i + 1) + "\t\t" + bt[i]+ "\t " + wt[i] + "\t\t " + tat[i]);
			}

			Console.WriteLine("Average waiting time = " +(float)total_wt / (float)n);
			Console.Write("Average turn around time = " +(float)total_tat / (float)n);
		}

		public static void Main()
		{
			int[] processes = { 1, 2, 3 };
			int n = processes.Length;

			int[] burst_time = { 10, 5, 8 };

			int quantum = 2;
			findavgTime(processes, n, burst_time, quantum);
		}
	}
}

