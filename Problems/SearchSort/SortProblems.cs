using System;
using System.Linq;
using System.Collections.Generic;

namespace Problems.SearchSort
{
  public class SortProblems
  {
    public class Pair
    {
      public readonly int distance;
      public readonly int bikeIndex;
      public readonly int workerIndex;

      public Pair(int workerIndex, int bikeIndex, int distance)
      {
        this.distance = distance;
        this.bikeIndex = bikeIndex;
        this.workerIndex = workerIndex;
      }
    }

    public int[] AssignBikes(int[][] workers, int[][] bikes)
    {
      var results = new int[workers.Length];
      var pairs = new List<Pair>();

      for (var i = 0; i < workers.Length; i++)
      {
        for (var j = 0; j < bikes.Length; j++)
        {
          pairs.Add(new Pair(i, j, Math.Abs(workers[i][0] - bikes[j][0]) + Math.Abs(workers[i][1] - bikes[j][1])));
        }
      }

      var markerBikes = new bool[bikes.Length];
      var markerWorkers = new bool[workers.Length];

      foreach (var pair in pairs.OrderBy(p => p.distance))
      {
        if (markerBikes[pair.bikeIndex])
        {
          continue;
        }

        if (markerWorkers[pair.workerIndex])
        {
          continue;
        }

        results[pair.workerIndex] = pair.bikeIndex;

        markerBikes[pair.bikeIndex] = markerWorkers[pair.workerIndex] = true;
      }

      return results;
    }
  }
}