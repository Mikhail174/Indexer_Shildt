using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//перегрузить индексатор массива класса FailSoftArray
namespace FSDemo_307
{
    class FailSoftArray
    {
        int[] a; //ссылка на базовый массив
        public int Length; //открытая переменная длины массива
        public bool ErrFlag; // обозначает результат последней операции
        //постросить массив заданного размера
        public FailSoftArray(int size)
        {
            a = new int[size];
            Length = size;
        }
        //это индексатор для класса FailSoftArray
        public int this[int index]
        {//это аксессор get
            get
            {
                if (ok(index))
                {
                    ErrFlag = false;
                    return a[index];
                }
                else
                {
                    ErrFlag = true;
                    return 0;
                }
            }
            // это аксессор set
            set
            {
                if (ok(index))
                {
                    a[index] = value;
                    ErrFlag = false;
                }
                else ErrFlag = true;
            }
        }
        //это ещё один индексатор для массива FailSoftArray. Он округляет свой аргумент до ближайшего целого индекса
        public int this[double idx]
        {
            //это аксессор get
            get
            {
                int index;
                //округлить до ближайшего целого
                if (idx - (int)idx < 0.5) index = (int)idx;
                else index = (int)idx + 1;

                if (ok(index))
                {
                    ErrFlag = false;
                    return a[index];
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
                int index;
                //округлить до ближайшего целого
                if (idx - (int)idx < 0.5) index = (int)idx;
                else index = (int)idx + 1;

                if (ok(index))
                {
                    a[index] = value;
                    ErrFlag = false;
                }
                else ErrFlag = true;

            }
        }
        // возвратить значение true, если индекс находится в установленных границах
        private bool ok(int index)
        {

            if (index >= 0 & index < Length) return true;
            return false;
        }

    }
    //продемонстрировать применение отказоустойчивого массива 
    class FSDemo
    {
        static void Main(string[] args)
        {
            FailSoftArray fs = new FailSoftArray(5);

            //поместить ряд значений в массив fs
            for (int i = 0; i < fs.Length; i++)
                fs[i] = i;
            //а теперь воспользоваться индексами типа int и double для обращения к массиву
            Console.WriteLine("fs[1]: " + fs[1]);
            Console.WriteLine("fs[2]: " + fs[2]);

            Console.WriteLine("fs[1]: " + fs[1.1]);
            Console.WriteLine("fs[2]: " + fs[1.6]);
        }
    }
}
