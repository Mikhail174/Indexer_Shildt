using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*общая форма одномерного индексатора:
 тип_элемента this [int] индекс 
    {
        //аксессор для получения данных
        get {} //возврат значения, которое определяет индекс
        //аксессор для установки данных
        set {} //Установка значения, которое определяет индекс
    }
тип элемента обозначает конкретный тип индексатора, этот тип соответствует типу элемента массива
параметр индекс получает конкретный индекс элемента, к которому осуществляется доступ
Аксессоры получают индекс в качестве параметра
Если индексатор указывается в левой части оператора присваивания=> то вызывется аксессор set, если в правой => get, и возвращается значение
сооветветсвтующее параметру индекс. Аксессор set получает неявный параметр value, содерж. знач-ие , присваиваемое по указ. адресу
*/
namespace Indexer_Shildt
{// использовать индексатор для создания отказоустойчивого массива
    class FailSoftArray1
    {
        int[] a; //ссылка на базовый массив
        public int Length; //открытая переменная длины массива
        public bool ErrFlag; // обозначает результат последней операции
        //постросить массив заданного размера
        public FailSoftArray1(int size)
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
            // возвратить значение true, если индекс находится в установленных границах
        private bool ok(int index)
        {

            if (index >= 0 & index < Length) return true;
            return false;
        }
    }
}
       //продемонстрировать применение отказоустойчивого массива 
 
    class FSDemo
    {
        static void Main(string[] args)
        {
        FailSoftArray fs = new FailSoftArray();
        }
    }
}

