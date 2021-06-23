using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;


//zestaw A na ocenę 3
namespace Kolokwium_PO_w61933
{
    public class Root
    {
        class Owoc
        {
            public string Kolor { get; set; }
            public int Wielkosc { get; set; }
            public float Waga { get; set; }
           
            public static void countFruit(List<Owoc> listFruit)
            {
                int count = 0;
                
                foreach (var lf in listFruit)
                {
                    if (lf.Waga < 0.5)
                    {
                        count++;
                    }
                }

                Console.WriteLine($"Ilość owoców z wagą mniejszą niż 0.5kg {count}");
                string answear = null;
                while (answear != "zerwij owoc")
                {
                    answear = Console.ReadLine();
                    if (answear == "zerwij owoc")
                    {
                        var owoc = randomFruit(listFruit);
                        if (owoc.Wielkosc < 100)
                        {
                            Console.WriteLine("Owoc niedojrzały – doszło do zatrucia");
                            break;
                        }
                        else if (owoc.Wielkosc == 420)
                        {
                            Console.WriteLine("Zerwałeś granat – uciekaj!");
                            break;
                        }
                        else if (owoc.Wielkosc >= 100)
                        {
                            Console.WriteLine("Owoc dojrzały – smacznego");
                            answear = null;
                        }
                        else
                        {
                            Console.WriteLine("zła komenda");
                        }

                    }
                }
            }
            public static Owoc randomFruit(List<Owoc> listFruit)
            {
                var rand = new Random();
                var randomFruit = rand.Next(0, listFruit.Count - 1);
                return listFruit[randomFruit];
            }
            public class Program
            {


            }

            static void Main(string[] args)
            {
                List<Owoc> listFruit;
                using (var sr = new StreamReader("drzewo.json"))
                {
                    var line = sr.ReadToEnd();
                    listFruit = JsonConvert.DeserializeObject<List<Owoc>>(line);
                }
                countFruit(listFruit);

            }
        }
    }
}
