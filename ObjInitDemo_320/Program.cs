using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//применить инициализаторы объектов в свойствах
namespace ObjInitDemo_320
{
    class MyClass
    {
        //теперь это свойства
        public int Count { get; set; }
        public string Str { get; set; }
    }
    class ObjInitDemo
    {
        static void Main(string[] args)
        {
            //сконструировать объект типа MyClass c помощью инициализаторов объектов
            MyClass obj = new MyClass { Count = 100, Str = "Тестирование" };
            Console.WriteLine(obj.Count + " " + obj.Str);
        }
    }
}
