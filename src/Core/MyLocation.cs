
namespace FindTheShortestWay
{
    public class MyLocation{
	    public int row;
        public int col;

        public MyLocation(){
            row = 0; 
            col = 0;
        }

        public MyLocation(int _dong, int _cot){ 
    	    InitData(_dong, _cot);
        }
    
        public void InitData(int _dong, int _cot){ 
            row = _dong; 
            col = _cot; 
        }

        public bool IsEqual(MyLocation _other){
            if(row == _other.row && col == _other.col){
                return true;
            }
            return false;
        }
    
        public bool IsEqual(byte _dong, byte _cot){
            if(row == _dong && col == _cot){
                return true;
            }
            return false;
        }
    
        public MyLocation Clone() {
            MyLocation other = (MyLocation)this.MemberwiseClone();
            return other;
        }

        public string ToStrDebug(){
            return "[" + row + "," + col + "]";
        }
    }
}
