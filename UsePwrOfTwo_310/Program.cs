using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//индексаторы совсем не обязательно должны оперировать отдельными массивами
namespace UsePwrOfTwo_310
{
    class PwrOfTwo
    {
        //доступ к логическому массиву, содерж. степени числа от 0 до 15
        public int this [int index]
        {
            //вычислить и возвратить степень числа 2
            get
            {
                if ((index >= 0) && (index < 16)) return power(index);
                else return -1;
            }

            //аксессор set отсутствует
        }
        int power (int p)
        {
            int result = 1;
            for (int i = 0; i < p; i++)
                result *= 2;
            return result;
        }
    }
    class UsePwrOfTwo
    {
        static void Main(string[] args)
        {
            PwrOfTwo pwr = new PwrOfTwo();
            Console.Write("первые 10 степеней числа 2: ");
            for (int i = 0; i < 10; i++)
             Console.Write(pwr[i] + " "); //работает аксессор get на 15 строке, в котором есть метод int power считает степени числа 2
            Console.WriteLine();
            //pwr[0] = 11; //ошибка компиляции, т.к. отсутствует аксессор set

            Console.WriteLine("А это некоторые ошибки");
            Console.Write(pwr[-1] + " " + pwr[17]); // срабатывает ветвь else на 18 строке
            Console.WriteLine();

        }
    }
}
