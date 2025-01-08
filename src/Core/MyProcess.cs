using System;
using System.Collections.Generic;

namespace FindTheShortestWay
{
	public static class MyProcess {

		//public MyProcess(int[][] _matrix) {
		//	//matrix = _matrix;
		//	//maxDong = matrix.Length;
		//	//maxCot = matrix[0].Length;
		//}

		public static void ProcessNode(this MyNode _node) {
			if (!_node.isRoot) {
				if (_node.matrix[_node.row][_node.col] == MyConstant.ID_END) { // tới đích
					_node.isMax = true;
					_node.point = 1;
					_node.matrix = null;
					return;
				}
				if (_node.matrix[_node.row][_node.col] == MyConstant.ID_WALL || _node.matrix[_node.row][_node.col] == MyConstant.ID_START || _node.matrix[_node.row][_node.col] == MyConstant.ID_LAND_CHECKED) {
					_node.matrix = null;
					return;
				}
				if (_node.matrix[_node.row][_node.col] == MyConstant.ID_LAND) {
					_node.matrix[_node.row][_node.col] = MyConstant.ID_LAND_CHECKED;
				}
			} else {
				if (_node.matrix[_node.row][_node.col] != MyConstant.ID_START) {
					Console.WriteLine(">>> [Error] This is not the Starting location");
					return;
				}
			}

			MyNode _tmpNode = new MyNode(_node.matrix, _node.row - 1, _node.col); // Check above
			ProcessNode(_tmpNode);
			_node.AddChild(_tmpNode);

			_tmpNode = new MyNode(_node.matrix, _node.row + 1, _node.col); // Check below
			ProcessNode(_tmpNode);
			_node.AddChild(_tmpNode);

			_tmpNode = new MyNode(_node.matrix, _node.row, _node.col - 1); // Check left side
			ProcessNode(_tmpNode);
			_node.AddChild(_tmpNode);

			_tmpNode = new MyNode(_node.matrix, _node.row, _node.col + 1); // Check right side
			ProcessNode(_tmpNode);
			_node.AddChild(_tmpNode);
		}

		public static void Evalf(this MyNode _node)
		{ // Evaluation function
			if (_node.Size() == 0)
			{
				return;
			}
			MyNode _tmpNode;
			for (short i = 0; i < _node.Size(); i++)
			{
				_tmpNode = _node.listChild[i];
				Evalf(_tmpNode);
				if (!_node.isRoot)
				{
					_node.point += _tmpNode.point;
				}
			}
		}

		public static void GetWay(this MyNode _node, ref List<List<MyLocation>> _listWays)
		{
			if (_node.Size() == 0)
			{
				return;
			}
			MyNode _tmpNode;
			for (short i = 0; i < _node.Size(); i++)
			{
				_tmpNode = _node.listChild[i];
				if (!_node.isRoot)
				{
					if (_tmpNode.point > 0)
					{
						_tmpNode.myWay.Add(new MyLocation(_node.row, _node.col));
						for (int j = 0; j < _node.myWay.Count; j++)
						{
							_tmpNode.myWay.Add(_node.myWay[j]);
						}
					}
				}
				GetWay(_tmpNode, ref _listWays);
				if (_tmpNode.isMax)
				{
					if (_node.isRoot) // case start location and end location are overlap 
					{
						List<MyLocation> _tmp = new List<MyLocation>();
						_tmp.Add(new MyLocation(_tmpNode.row, _tmpNode.col));
						_listWays.Add(_tmp);
					}
					else
					{
						_listWays.Add(_tmpNode.myWay);
					}
				}
			}
		}
	}
}