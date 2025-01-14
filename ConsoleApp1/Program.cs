using ConsoleApp1;
using System.Drawing;
using System.Numerics;

//Console.WriteLine(new Solution1().GetResult());

Console.WriteLine(new Solution4().GetResult(Data.InputNumbers4));
public class Solution1
{
	private int[] numbers = [3747,
	9006,
	6747,
	4175,
	8004,
	3319,
	2793,
	6607,
	6468,
	9799,
	2095,
	4894,
	7144,
	1738,
	6699,
	9884,
	4540,
	8269,
	1117,
	6100,
	1343,
	6052,
	3321,
	5866,
	9318,
	5945,
	7037,
	6858,
	7026,
	9905,
	8770,
	1381,
	9025,
	7496,
	1688,
	6514,
	1319,
	3331,
	4953,
	8544,
	8022,
	9408,
	2826,
	9897,
	8669,
	4583,
	3276,
	4828,
	5895,
	2258,
	9927,
	7120,
	3212,
	2073,
	6202,
	8377,
	6575,
	6580,
	8915,
	3046,
	8196,
	7908,
	3032,
	6358,
	6515,
	5620,
	4977,
	1265,
	3808,
	4616,
	8120,
	3526,
	2300,
	1391,
	3451,
	1814,
	4916,
	8091,
	9664,
	8500,
	2963,
	5615,
	5652,
	5477,
	7347,
	2490,
	2830,
	6190,
	6177,
	1380,
	3177,
	6993,
	6007,
	5754,
	2621,
	4756,
	8826,
	6487,
	2020,
	9453,
	5392,
	4948,
	9834,
	6513,
	6730,
	3455,
	5850,
	6345,
	2758,
	1265,
	3808,
	4616,
	8120,
	3526,
	2300,
	1391,
	3451,
	1814,
	4916,
	8091,
	9664,
	8500,
	2963,
	5615,
	5652,
	5477,
	7347,
	2490,
	2830,
	6190,
	6177,
	1380,
	3177,
	6993,
	6007,
	5754,
	2621,
	4756,
	8826,
	6487,
	2020,
	9453,
	5392,
	4948,
	9834,
	6513,
	6730,
	3455,
	5850,
	6345,
	2758,
	1265,
	3808,
	4616,
	8120,
	3526,
	2300,
	1391,
	3451,
	1814,
	4916,
	8091,
	9664,
	8500,
	2963,
	5615,
	5652,
	5477,
	7347,
	2490,
	2830,
	6190,
	6177,
	1380,
	3177,
	6993,
	6007,
	5754,
	2621,
	4756,
	8826,
	6487,
	2020,
	9453,
	5392,
	4948,
	9834,
	6513,
	6730,
	3455,
	5850,
	6345,
	2758,
	1265,
	3808,
	4616,
	8120,
	3526,
	2300,
	1391];

//	private int[] numbers = [
//		4528,
//2491,
//3161,
//4209,
//5910,
//8891];

	public BigInteger GetResult()
	{
		BigInteger result = 1;
		for (var i = 0; i < numbers.Length; i += 2)
		{
			var number = numbers[i];
			var expectedNumber = numbers[i + 1];
			var count = 4;
			int tmpResult = 0;
			while (count > 0)
			{
				count--;
				var m = number % 10;
				var n = expectedNumber % 10;
				tmpResult += Math.Min(Math.Abs(m-n), 10 - Math.Abs(m - n));
				number /= 10;
				expectedNumber /= 10;
			}
			var lastResult = result;
			result *= (ulong)tmpResult;
		}
		return result;
	}

}

public class Solution2
{
	public int GetResult(int[][] numbers)
	{
		int[][] results = new int[numbers.Length][];

		for (int i = 0; i < results.Length; i++)
		{
			results[i] = new int[numbers[i].Length];
		}

		for (int i = 0; i < numbers.Length; i++)
		{
			var array = numbers[i];
			if (array.Length == 1)
			{
				continue;
			}
			for (var j = array.Length - 1; j >= 0; j--)
			{
				for (var k = j + 1; k < array.Length; k++)
				{
					if (array[j] > array[k])
					{
						results[i][j] += 1;
					}
					else if (array[j] == array[k])
					{
						results[i][j] += results[i][k];
						break;
					}
				}
			}
		}
		var medians = new int[numbers.Length];
		for (int i = 0;i < medians.Length;i++)
		{
			Array.Sort(results[i]);
			if (results[i].Length % 2 == 0)
			{
				var tmp = (results[i][results[i].Length / 2] + results[i][results[i].Length / 2 - 1]+(decimal)1)/2;
				medians[i] = (int)tmp;
			}
			else
			{
				medians[i] = results[i][results[i].Length / 2];
			}
		}
		return medians.Sum();
	}
}

public class Solution3
{
	public int GetResult(char[][][] inputChars)
	{
		var result = 0;
		foreach (var chars in inputChars)
		{
			Dictionary<char, char> dict = new Dictionary<char, char>();
			var valid = true;
			foreach (var item in chars)
			{
				var root = GetRoot(dict, item[0]);
				if (root == item[1])
				{
					valid = false;
					break;
				}
				dict[item[1]] = root;
			}
			if(valid)
			{
				result++;
			}
		}
		return result;
	}

	private char GetRoot(Dictionary<char, char> dict, char ch)
	{
		while (dict.ContainsKey(ch))
		{
			ch = dict[ch];
		}
		return ch;
	}
}

public class Solution4
{
	//dfs
	public int GetResult(int[][] grid)
	{
		var m = grid.Length;
		var n = grid[0].Length;
		var max = 0;
		Stack<Point> stack = new();
		for (var i = 0; i < m; i++)
			for (var j = 0; j < n; j++)
			{
				if (grid[i][j] == 1)
				{
					var result = 0;
					stack.Push(new Point(i, j));
					while (stack.TryPop(out var point))
					{
						var x = point.X;
						var y = point.Y;
						if (x < 0 || x >= m || y < 0 || y >= n || grid[x][y] == 0)
							continue;
						grid[x][y] = 0;
						result++;
						stack.Push(new Point(x - 1, y));
						stack.Push(new Point(x + 1, y));
						stack.Push(new Point(x, y - 1));
						stack.Push(new Point(x, y + 1));
						stack.Push(new Point(x - 1, y - 1));
						stack.Push(new Point(x + 1, y + 1));
						stack.Push(new Point(x - 1, y + 1));
						stack.Push(new Point(x + 1, y - 1));
					}
					max = Math.Max(max, result);
				}
			}
		return max;
	}
}