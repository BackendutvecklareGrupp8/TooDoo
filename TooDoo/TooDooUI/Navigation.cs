using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TooDooUI
{
    public static class Navigation
    {
        public static object BLL { get; private set; }
        private static List<ToDoList> toDoLists;

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
                case "2":
                    GoToCreateList();
                    break;   
                default:
                    break;
            }
        }

        /// <summary>
        /// Skapa ny ToDo-lista
        /// </summary>
        private static void GoToCreateList()
        {
            Console.Clear();


        }

        /// <summary>
        /// Listar alla ToDo-listor, ger möjlighet att välja en
        /// </summary>
        private static void GoToLists()
        {
            Console.Clear();
            Console.WriteLine("Välj den lista du vill öppna och tryck enter");
            Console.WriteLine("");

            var toDoRepository = new ToDoRepository();
            var lists = toDoRepository.GetToDoLists().d;
            toDoLists = lists;

            

            foreach (var list in lists)
            {
                var listNo = lists.IndexOf(list) + 1;

                Console.WriteLine(listNo + " " + list.Name);
            }

            Console.WriteLine("");
            int ListNoInput;
            var errorMessage = "";

            while (Helpers.TryParseIntWithRange(Console.ReadLine(), 1, lists.Count, out ListNoInput, out errorMessage) == false)
            {
                Console.WriteLine(errorMessage);
            }

            GoToList(ListNoInput);
                
           }

        private static void GoToList(int listNo)
        {
            Console.Clear();

            var list = toDoLists[listNo - 1];
            var toDoRepository = new ToDoRepository();
            var toDoListWrapper = toDoRepository.GetToDoListItems(list.Name);


            Console.WriteLine(string.Format("Listans namn: {0}", list.Name));
            Console.WriteLine("Löpnr	 Beskrivning	    Skapad datum		Deadline		Beräknad tidsåtgång (min)	Färdig");

            foreach (var listitem in toDoListWrapper.d)
            {
                Console.WriteLine(string.Format("{0}        {1}         {2}         {3}            {4}                 {5}", listitem.Id, listitem.Description, listitem.CreatedDate, listitem.DeadLine, listitem.EstimationTime, listitem.Finnished));
            }

        }

        
    }
}
    