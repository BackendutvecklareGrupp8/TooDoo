using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TooDooUI
{
    public static class Navigation
    {
        public static void GoToStart()
        {
            Console.WriteLine("MENY");
            Console.WriteLine("");
            Console.WriteLine("1. Visa mig alla listor");
            Console.WriteLine("2. Skapa ny lista");
            Console.WriteLine("");
            Console.WriteLine("Välj ett alternativ och tryck enter.");
            var userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    GoToLists();
                    break;

                default:
                    break;
            }
        }
        
        /// <summary>
        /// Listar alla ToDo-listor, ger möjlighet att välja en
        /// </summary>
        private static void GoToLists()
        {
            Console.Clear();
            Console.WriteLine("Välj den lista du vill öppna och tryck enter");

            var toDoRepository = new ToDoRepository();
            var lists = toDoRepository.GetToDoLists().d;

            foreach (var list in lists)
            {
                Console.WriteLine(list.Name);
            }
        }

        //private static void ShowListsMenu()
        //{
        //    PrintToDoLists();
        //    Console.WriteLine("");
        //    Console.WriteLine("");
        //    var userChoice = Console.ReadLine();

        //}
    }
}
