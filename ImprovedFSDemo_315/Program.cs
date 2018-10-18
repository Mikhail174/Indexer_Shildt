using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Добавить свойство Length в класс FailSoftArray

namespace ImprovedFSDemo_315
{
    class FailSoftArray
    {
        int[] a;//ссылка на базовый массив
        int len; //длина массива- служит основанием для свойства Length
        public bool ErrFlag; // обозначает результат последней операции
                             //постросить массив заданного размера
        public FailSoftArray(int size)
        {
            a = new int[size];
            len = size;
        }
        //свйоство Length только для чтения
        public int Length
        {
            get { return len; }

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
        // возвратить значение true, если индекс находится в установленных границах
        private bool ok(int index)
        {

            if (index >= 0 & index < Length) return true;
            return false;
        }

    }
 //продемонстрировать применение усовершенствованного отказоустойчивого массива 
    class ImprovedFSDemo
    {
        static void Main(string[] args)
        {
            FailSoftArray fs = new FailSoftArray(10);
            int x;
            //разрешить чтение свойства Length
            for (int i = 0; i < fs.Length; i++)
                fs[i] = i * 10;
            for (int i = 0; i < fs.Length; i++)
            {
                x = fs[i];
                if (x != -1) Console.Write(x + " ");
            }
            Console.WriteLine();
            //fs.Length = 10; ошибка, запись запрещена

        }
    }
}
