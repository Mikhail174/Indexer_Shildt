using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//двумерный отказоустойчивый массив
namespace TwoDIndexerDemo_312
{
    class FailSofArray2D
    {
        int[,] a; // ссылка на базовый двумерный массив
        int rows, cols; //размеры массива
        public int Length; //открытая переменная длины массива.
        public bool ErrFlag;//обозначает результат последней операции.
        //построить массив заданных размеров
        public FailSofArray2D(int r, int c)
        {
            rows = r;
            cols = c;
            a = new int[rows, cols];
            Length = rows * cols;
        }
        //это индексатор для класса FailSoftArray2D
        public int this[int index1, int index2]
        {
            //это аксессор get
            get
            {
                if (ok(index1, index2))
                {
                    ErrFlag = false;
                    return a[index1, index2];
                }
                else
                {
                    ErrFlag = true;
                    return 0;
                }
            }
            //это аксессор set
            set
            {
                if (ok(index1, index2))
                {
                    a[index1, index2] = value;
                    ErrFlag = false;
                }
                else ErrFlag = true;
            }
        }
        //возвратить значение true, если индексы находятся в установленных пределах
        private bool ok(int index1, int index2)
        {
            if (index1 >= 0 & index1 < rows & index2 >= 0 & index2 < cols)
                return true;
            else return false;
        }

    }
    class TwoDIndexerDemo
    {
        static void Main(string[] args)
        {
            FailSofArray2D fs = new FailSofArray2D(3, 5);
            int x;

            //выявить скрытые сбои
            Console.WriteLine("Скрытый сбой");
            for (int i = 0; i < 6; i++)
            {
                fs[i, i] = i * 10;
            }
            for (int i = 0; i < 6; i++)
            {
                x = fs[i, i];
                if (x != -1) Console.Write(x + " ");
            }
            Console.WriteLine();
            //А теперь показать сбои
            Console.WriteLine("\nСбой с уведомлением об ошибках");
            for (int i = 0; i < 6; i++)
            {
                fs[i, i] = i * 10;
                if (fs.ErrFlag) Console.WriteLine("fs[" + i + ", " + i + "] вне границ");
            }
            for (int i = 0; i < 6; i++)
            {
                x = fs[i, i];
                if (!fs.ErrFlag) Console.Write(x + " ");
                else Console.WriteLine("fs[" + i + ", " + i + "] вне границ");

            }
        }
    }
}
