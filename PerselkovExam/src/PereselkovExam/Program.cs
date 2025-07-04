using System;

namespace PereselkovExam
{

    class Program
    {
        public static int Menu()
        {
            Console.WriteLine();
            Console.WriteLine("0 - завершить программу");
            Console.WriteLine("1 - добавить запись");
            Console.WriteLine("2 - отсортировать по убыванию по полям производитель + стоимость");
            Console.WriteLine("3 - запись в файл");
            Console.WriteLine("4 - показать коллекцию");
            Console.Write("ВАШ ВЫБОР: ");
            return int.TryParse(Console.ReadLine(), out int choise) ? choise : -1;

        }

        static void Main(string[] args)
        {

            var collecton = new FishControl();
           
            while (true)
            {
                switch (Menu())
                {
                    case 0: return;
                    case 1: collecton.AddFish(); break;
                    case 2: collecton.Sorted(); break;
                    case 3: collecton.WriteInFile(); break;
                    case 4: collecton.ShowCollection(); break;
                    default: Console.WriteLine("команда не распознана"); break;
                }
            }
        }
    }
}
