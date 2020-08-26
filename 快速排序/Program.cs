using System;
public class Sort
{
    public class Quick_Sort
    {
        private static int QuickSort_Once(int[] _pnArray, int _pnLow, int _pnHigh)
        {
            int nPivot = _pnArray[_pnLow];      //将首元素作为枢轴
            int i = _pnLow, j = _pnHigh;
            while (i < j)
            {
                //从右到左,寻找首个小于nPivot的元素
                while (_pnArray[j] >= nPivot && i < j) j--;
                //执行到此,j已指向从右端起首个小于nPivot的元素
                //执行替换
                _pnArray[i] = _pnArray[j];
                //从左到右,寻找首个大于nPivot的元素
                while (_pnArray[i] <= nPivot && i < j) i++;
                //执行到此,i已指向从左端起首个大于nPivot的元素
                //执行替换
                _pnArray[j] = _pnArray[i];
            }
        
            //推出while循环,执行至此,必定是i=j的情况
            //i(或j)指向的即是枢轴的位置,定位该趟排序的枢轴并将该位置返回
            _pnArray[i] = nPivot;
            return i;
        }
    
        private static void QuickSort(int[] _pnArray, int _pnLow, int _pnHigh)
        {
            if (_pnLow >= _pnHigh) return;        
            int _nPivotIndex = QuickSort_Once(_pnArray, _pnLow, _pnHigh);
            //对枢轴的左端进行排序
            QuickSort(_pnArray, _pnLow, _nPivotIndex - 1);
            //对枢轴的右端进行排序
            QuickSort(_pnArray, _nPivotIndex + 1, _pnHigh);
        }
    
        public static void Main()
        {
            Console.WriteLine("请输入待排序数列(以\",\"分割):");
            string _s = Console.ReadLine();
            string[] _sArray = _s.Split(",".ToCharArray());
            int _nLength = _sArray.Length;
            int[] _nArray = new int[_nLength];
            for (int i = 0; i < _nLength; i++)
            {
                _nArray[i] = Convert.ToInt32(_sArray[i]);
            }
            QuickSort(_nArray, 0, _nLength - 1);
            Console.WriteLine("排序后的数列为:");
            foreach (int _n in _nArray)
            {
                Console.WriteLine(_n.ToString());
            }
        }
    }
}
