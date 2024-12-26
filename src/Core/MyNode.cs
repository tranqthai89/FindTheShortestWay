using System.Collections.Generic;

namespace FindTheShortestWay {
	public class MyNode {
		public int[][] matrix;
		public List<MyLocation> myWay;
		public int level;
		public int row, col;
		public int point;
		public bool isRoot;
		public bool isMax;
		protected short count;
		protected short MAX_BUFFER;
		public MyNode[] listChild;

		public MyNode(int[][] _matrix, int _row, int _col, bool _isRoot = false) {
			isRoot = _isRoot;
			isMax = false;
			level = 0;
			row = _row;
			col = _col;
			point = 0;
			count = 0;
			MAX_BUFFER = 0;
			listChild = null;

			matrix = MyConstant.ShalowCopy(_matrix);
			myWay = new List<MyLocation>();
		}

		public short Size() { return count; }

		public void AddChild(MyNode _node) {
			MyNode[] temp = new MyNode[MAX_BUFFER + 1];
			for (short i = 0; i < MAX_BUFFER; i++)
				temp[i] = listChild[i];

			temp[MAX_BUFFER] = _node;
			listChild = temp;
			MAX_BUFFER++;
			count = MAX_BUFFER;
		}

		public void RemoveChild(short _index) 
		{ 
			if (0 <= _index && _index < count) 
			{
				for (short i = _index; i < count - 1; i++)
				{
					listChild[i] = listChild[i + 1]; count--;
				}
			} 
		}
	}
}
