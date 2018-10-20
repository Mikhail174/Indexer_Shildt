using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//применить автоматически реализуемые и доступные только для чтения свойства Length и Error
/*для опробования автоматич. реализуемых вариантов свойств Length и Error в классе FailSoftArray 
удалим сначала переменные len и ErrFlag, поскольку они больше не нужны, а затем заменим каждое
применение переменных len и ErrFlag свойствами Length и Error*/
namespace FailSoftArray_322
{
    class FailSoftArray
    {
        int[] a; //ссылка на базовый массив

        //постросить массив по заданному размеру
        public FailSoftArray(int size)
        {
            a = new int[size];
            Length = size;
        }

        //автоматически реализуемое и доступное только для чтения свойство Length
        public int Length { get; private set; }
        //автоматически реализуемое и доступное только для чтения свойство Error
        public bool Error { get; private set; }
        //это индексатор для массива FailSoftArray
        public int this[int index]
        {//это аксессор get
            get
            {
                if (ok(index))
                {
                    Error = false;
                    return a[index];
                }
                else
                {
                    Error = true;
                    return 0;
                }
            }
            // это аксессор set
            set
            {
                if (ok(index))
                {
                    a[index] = value;
                    Error = false;
                }
                else Error = true;
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
    class FinalFSDemo
    {
        static void Main(string[] args)
        {
            FailSoftArray fs = new FailSoftArray(5);
            int x;
            //использовать свойство Error
            for (int i = 0; i < fs.Length + 1; i++)
            {
                fs[i] = i * 10;
                if (fs.Error) Console.WriteLine("Ошибка в индексе " + i);
            }
            for (int i = 0; i < fs.Length + 1; i++)
            {
                x = fs[i];
                Console.Write(x + " ");
            }


        }
    }
}
