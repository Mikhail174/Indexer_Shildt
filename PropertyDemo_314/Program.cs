using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*общая форма свойства:
 тип имя{
 get {} //код аксессора для чтения из поля
 set {} код аксессора для запси в поле
 }*/
namespace PropertyDemo_314
{//простой пример применения свойства
    class SimpProp
    {
        int prop; //поле, управляемое свойством MyProp
        public SimpProp()
        {
            prop = 0;
        }
        /*это свойство обеспечивает доступ к закрытой перменной экземпляра prop.Оно допускает присваивание только положительных значений*/
        public int MyProp
        {
            get { return prop; }
            set { if (value >= 0) prop = value; }
        }
    }
    //продемонстрировать применение свойства
    class PropertyDemo
    {
        static void Main(string[] args)
        {
            SimpProp ob = new SimpProp();
            Console.WriteLine("Первоначальное значение ob.MyProp: " + ob.MyProp);
            ob.MyProp = 100;//присвоить значение
            Console.WriteLine("Текущее значение ob.MyProp: " + ob.MyProp);
            //переменной prop нельзя присвоить отрицательное значение
            Console.WriteLine("Попытка присвоить отрицательное значение -10 свойству ob.MyProp");
            ob.MyProp = -10;
            Console.WriteLine("Текущее значение ob.MyProp: " + ob.MyProp);


        }
    }
}
