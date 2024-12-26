
public static class MyConstant {

	public const int ID_LAND = 0;
	public const int ID_WALL = 1;
	public const int ID_START = 2;
	public const int ID_END = 3;
	public const int ID_LAND_CHECKED = 4;
	

	public static int[][] ShalowCopy(int[][] _originalMatrix) {
		int _numberRow = _originalMatrix.Length;
		int _numberCol;
		int[][] _dataClone = new int[_numberRow][];
		for (int _row = 0; _row < _numberRow; _row++) {
			_numberCol = _originalMatrix[_row].Length;
			_dataClone[_row] = new int[_numberCol];
			for (int _col = 0; _col < _numberCol; _col++) {
				_dataClone[_row][_col] = _originalMatrix[_row][_col];
			}
		}
		return _dataClone;
	}
}
