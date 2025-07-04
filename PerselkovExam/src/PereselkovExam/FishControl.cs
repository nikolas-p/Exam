using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PereselkovExam
{
    class FishControl
    {
        public List<Fish> fishCollection = new List<Fish>();

        public Fish? CreateFish()
        {
            Console.WriteLine("Введите данные о рыбе : ");
            Console.Write("Название : ");
            string name = Console.ReadLine().Trim();
            if (name == "")
            {
                Console.WriteLine("не может быть пустое название");
                return null;
            }
            Console.Write("Производитель : ");
            string manufacture = Console.ReadLine().Trim();
            if (name == "")
            {
                Console.WriteLine("не может быть пустой производитель");
                return null;
            }
            Console.Write("Стоимость : ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("неверный формат для цены");
                return null;

            }
            if (price < 0)
            {
                Console.WriteLine("стоимость не может быть меньше нуля");
                return null;
            }


            Fish newFish = new Fish(name, manufacture, price);

            foreach (Fish fish in fishCollection)
            {
                if (fish.FishTipe == newFish.FishTipe
                    && fish.Manufacture == newFish.Manufacture 
                    && fish.Price == newFish.Price)
                {
                    Console.WriteLine("данная рыба есть в коллекции, и не была добавлена");
                    return null;
                }
            }
            return newFish;
        }

        public void AddFish()
        {
            Fish newFish = CreateFish();
            if (newFish == null)
            {
                Console.WriteLine("рыба не создана");
                return;
            }

            fishCollection.Add(newFish);
            Console.WriteLine("рыба добавлена");
        }

        public void Sorted()
        {
            Console.WriteLine("SORT BY MANUFACTIRE {0}", fishCollection.Count());
            SortByTypeAndPrice(fishCollection);
        }

        private void SortByTypeAndPrice(List<Fish> list)
        {
            for (int i = 1; i < list.Count(); i++)
            {
                Fish current = list[i];
                int j = i - 1;

                while
                    (j >= 0 &&
                    string.Compare(list[j].Manufacture, current.Manufacture, StringComparison.OrdinalIgnoreCase) < 0
                    )
                {


                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = current;
            }
        }

        public void WriteInFile()
        {
            if (fishCollection.Count() == 0)
            {
                Console.WriteLine("В КОЛЛЕКЦИИ НЕТ ЗАПИСЕЙ ДЛЯ СОХРАНЕНИЯ В ФАЙЛ");
                return;
            }

            Console.WriteLine("Введите название файла");
            string fileName = Console.ReadLine();
            fileName += ".txt";

            using var writer = new StreamWriter(fileName, false, Encoding.UTF8);

            foreach (Fish fish in fishCollection)
            {
                writer.WriteLine(fish.ToString());
            }
            Console.WriteLine("данные занесены в файл {0}", fileName);
        }

        public void ShowCollection()
        {
            if (fishCollection.Count() == 0)
            {
                Console.WriteLine("КОЛЛЕКЦИЯ ПУСТА");
                return;
            }
            foreach (Fish fish in fishCollection)
            {
                Console.WriteLine(fish.ToString());
            }
        }



    }
}


