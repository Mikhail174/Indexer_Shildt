using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Создать класс со специально указываемыми пределами индексирования массива.
 Класс RangeArray допускает индексирование массива с любого значения, а не только с нуля. При создании объекта класса RangeArray указываются
 начальный и конечный индексы. Допускается также указывать отрицательные индексы. Например, можно создать массивы, индексируемые от -5 до 5,
 от 1 до 10, или от 50 до 56.*/
namespace RangeArrayDemo_324
{
    class RangeArray
    { 
        //закрытые данные
        int[] a;
        int lowerBound;//наименьший индекс
        int upperBound;//наименьший индекс

        //Автоматически реализуемое и доступное только для чтения свойство Length
        public int Length { get; private set; }

        //Автоматически реализуемое и доступное только для чтения свойство Error
        public bool Error { get; private set; }

        //Построить массив по заданному размеру
        public RangeArray(int low, int high)
        {
            high++;
            if (high <= low)
            {
                Console.WriteLine("Неверные индексы");
                high = 1; //создать для надеждности минимально допустимый массив
                low = 0;
            }
            a = new int[high - low];
            Length = high - low;
            lowerBound = low;
            upperBound = --high;
        }
        //это индексатор для класса RangeArray 
        public int this [int index]
        {
            //это аксессор get
            get
            {
                if (ok(index))
                {
                    Error = false;
                    return a[index-lowerBound]; //индекс, передаваемый в кач-ве парам-ра index, преобр-ся в индекс с отсчётом от нуля, пригодный для индексиров-ия с любым значением lowerBound
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
                    a[index - lowerBound] = value; //индекс, передаваемый в кач-ве парам-ра index, преобр-ся в индекс с отсчётом от нуля, пригодный для индексиров-ия с любым значением lowerBound
                    Error = false;
                }
                else Error = true;
            }
        }
        // возвратить значение true, если индекс находится в установленных границах
        private bool ok(int index)
        {

            if (index >= lowerBound & index <= upperBound) return true;
            return false;
        }
    }
 // продемонстрировать применение массива с произвольно задаваемыми пределами индексирования
    class RangeArrayDemo
    {
        static void Main(string[] args)
        {
            RangeArray ra = new RangeArray(-5,5);
            RangeArray ra2 = new RangeArray(1,10);
            RangeArray ra3 = new RangeArray(-20, -12);

            //использовать объект ra в качестве массива
            Console.WriteLine("Длина массива ra: " + ra.Length);
            for (int i = -5; i <= 5; i++)
                ra[i] = i;
            Console.Write("Содержимое массива ra: ");
            for (int i = -5; i <= 5; i++)
                Console.Write(ra[i] + " ");
            Console.WriteLine();

            //использовать объект ra2 в качестве массива
            Console.WriteLine("Длина массива ra2: " + ra2.Length);
            for (int i = 1; i <= 10; i++)
                ra2[i] = i;
            Console.Write("Содержимое массива ra2: ");
            for (int i = 1; i <= 10; i++)
                Console.Write(ra2[i] + " ");
            Console.WriteLine();

            //использовать объект ra3 в качестве массива
            Console.WriteLine("Длина массива ra3: " + ra3.Length);
            for (int i = -20; i <= -12; i++)
                ra3[i] = i;
            Console.Write("Содержимое массива ra3: ");
            for (int i = -20; i <= -12; i++)
                Console.Write(ra3[i] + " ");
            Console.WriteLine();



        }
    }
}
