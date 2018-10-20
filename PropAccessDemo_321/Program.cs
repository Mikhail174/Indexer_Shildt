using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//применить модификатор доступа в аксессоре
namespace PropAccessDemo_321
{
    class PropAcces
    {
        int prop; // поле, управляемое свойством MyProp
        public PropAcces() { prop = 0; }
        /*Это свойство обеспечивает доступ к закрытой пемернной экземпляра prop. Оно разрешает получать значение переменной
         prop из любого кода, но устанавливать его - только членам своего класса */
         public int MyProp
        {
            get { return prop; }
            private set { prop = value; } //теперь это закрытый аксессор
        }
        //этот член класса инкрементирует значение свойства MyProp
            public void IncrProp()
        {
            MyProp++; //допускается в том же самом классе
        }
        
    }
    //продемеонстрировать применение модификатора доступа в аксессоре свойства
    class PropAccesDemo
    {
        static void Main(string[] args)
        {
            PropAcces ob = new PropAcces();
            Console.WriteLine("Первоначальное значение ob.MyProp: " + ob.MyProp);

            //ob.MyProp = 100; //недоступно для установки

            ob.IncrProp();
            Console.WriteLine("Значение ob.MyProp после инкрементирования: " + ob.MyProp);
        }
    }
}
