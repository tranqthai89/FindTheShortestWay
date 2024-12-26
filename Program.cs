using System;
using System.Collections.Generic;

namespace FindTheShortestWay
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Find the shortest way");

			int[][] _labyrinth = {
				new int[]{ 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
				new int[]{ 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,1},
				new int[]{ 1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1},
				new int[]{ 1,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1},
				new int[]{ 1,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,0,1},
				new int[]{ 1,0,0,0,1,0,0,0,1,0,0,0,1,0,1,0,1,0,1},
				new int[]{ 1,0,1,0,1,0,1,0,1,0,1,1,1,0,1,0,1,0,1},
				new int[]{ 1,0,1,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,1},
				new int[]{ 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
				new int[]{ 1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0,1,0,1},
				new int[]{ 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
				new int[]{ 1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0,1},
				new int[]{ 1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,0,1},
				new int[]{ 1,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1},
				new int[]{ 1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
				new int[]{ 1,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1},
				new int[]{ 1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,0,1},
				new int[]{ 1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
				new int[]{ 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
			};

			List<List<MyLocation>> _listTotalWaysCanMove = new List<List<MyLocation>>();
			MyLocation _startLocation = new MyLocation(17, 1);

			MyNode _node = new MyNode(_labyrinth, _startLocation.row, _startLocation.col, true);
			_node.ProcessNode();

			_node.Evalf();
            //for (int i = 0; i < _node.listChild.Length; i++)
            //{
            //    Console.WriteLine(">>> " + _node.listChild[i].point);
            //}
            _node.GetWay(ref _listTotalWaysCanMove);

			if (_listTotalWaysCanMove.Count == 0)
			{
				Console.WriteLine(">>> Can not find the shortest path");
			}
			else
			{
				//			for(int i = 0; i < _listTotalWaysCanMove.Count; i++) {
				//				Console.WriteLine(">>>>>>>>>>>>> " + i +" <<<<<<<<<<<<<");
				//				for(int j = 0; j < _listTotalWaysCanMove.get(i).Count; j++) {
				//					labyrinth[_listTotalWaysCanMove.get(i).get(j).dong][_listTotalWaysCanMove.get(i).get(j).cot] = 4;
				//					System.out.print(_listTotalWaysCanMove.get(i).get(j).ToStrDebug());
				//					if(j < _listTotalWaysCanMove.get(i).Count - 1) {
				//						System.out.print(" , ");
				//					}
				//				}
				//				Console.WriteLine("");
				//			}
				//			Console.WriteLine("");

				// ----- Find all shortest paths ------ //
				List<List<MyLocation>> _listShortestWays = new List<List<MyLocation>>();
				int _tmpLength;
				if (_listTotalWaysCanMove.Count > 0)
				{
					// - Get list shorstest ways
					_tmpLength = _listTotalWaysCanMove[0].Count;
					for (int i = 1; i < _listTotalWaysCanMove.Count; i++)
					{
						if (_listTotalWaysCanMove[i].Count < _tmpLength)
						{
							_tmpLength = _listTotalWaysCanMove[i].Count;
						}
					}

					for (int i = 0; i < _listTotalWaysCanMove.Count; i++)
					{
						if (_listTotalWaysCanMove[i].Count == _tmpLength)
						{
							_listShortestWays.Add(_listTotalWaysCanMove[i]);
						}
					}
					// ----------------- //

					Console.WriteLine(">>> Have " + _listShortestWays.Count + " shortest ways! Total steps: " + (_tmpLength + 1) + " (End point included)");
					int[][] _shortestWayMatrix;
					for (int i = 0; i < _listShortestWays.Count; i++)
					{
						Console.WriteLine("");
						Console.WriteLine(">>>>>>>>>>>>> " + i + " <<<<<<<<<<<<<");
						Console.WriteLine("");
						_shortestWayMatrix = MyConstant.ShalowCopy(_labyrinth);
						for (int j = 0; j < _listShortestWays[i].Count; j++)
						{
							_shortestWayMatrix[_listShortestWays[i][j].row][_listShortestWays[i][j].col] = MyConstant.ID_LAND_CHECKED;
						}
						Display(_shortestWayMatrix);
						Console.WriteLine("");
						Console.WriteLine("-------------------------------------------------------------------");
					}
					Console.WriteLine("");
				}
				// ------------------------------------------- //


				// ----- Find all longest paths ------ //
				List<List<MyLocation>> _listLongestWays = new List<List<MyLocation>>();
				_tmpLength = 0;
				if (_listTotalWaysCanMove.Count > 0)
				{
					// - Get list longest ways
					_tmpLength = _listTotalWaysCanMove[0].Count;
					for (int i = 1; i < _listTotalWaysCanMove.Count; i++)
					{
						if (_listTotalWaysCanMove[i].Count > _tmpLength)
						{
							_tmpLength = _listTotalWaysCanMove[i].Count;
						}
					}

					for (int i = 0; i < _listTotalWaysCanMove.Count; i++)
					{
						if (_listTotalWaysCanMove[i].Count == _tmpLength)
						{
							_listLongestWays.Add(_listTotalWaysCanMove[i]);
						}
					}
					// ---------------- //

					Console.WriteLine(">>> Have " + _listLongestWays.Count + " longest ways! Total steps: " + (_tmpLength + 1) + " (End point included)");
					int[][] _longestWayMatrix;
					for (int i = 0; i < _listLongestWays.Count; i++)
					{
						Console.WriteLine("");
						Console.WriteLine(">>>>>>>>>>>>> " + i + " <<<<<<<<<<<<<");
						Console.WriteLine("");
						_longestWayMatrix = MyConstant.ShalowCopy(_labyrinth);
						for (int j = 0; j < _listLongestWays[i].Count; j++)
						{
							_longestWayMatrix[_listLongestWays[i][j].row][_listLongestWays[i][j].col] = MyConstant.ID_LAND_CHECKED;
						}
						Display(_longestWayMatrix);
						Console.WriteLine("");
						Console.WriteLine("-------------------------------------------------------------------");
					}
					Console.WriteLine("");
				}
				// ------------------------------------------- //
			}
		}
		private static void Display(int[][] _labyrinth)
		{
			for (int y = 0; y < _labyrinth.Length; y++)
			{
				string _tmpStr = string.Empty;
				for (int x = 0; x < _labyrinth[y].Length; x++)
				{
					_tmpStr += ToCharacter(_labyrinth[y][x]);
				}
				Console.WriteLine(_tmpStr);
			}
		}
		private static string ToCharacter(int i)
		{
			switch (i)
			{
				case MyConstant.ID_WALL:
					return "# ";
				case MyConstant.ID_START:
					return "S ";
				case MyConstant.ID_END:
					return "G ";
				case MyConstant.ID_LAND_CHECKED:
					return ". ";
				default:
					return "  ";
			}
		}
	}
}
