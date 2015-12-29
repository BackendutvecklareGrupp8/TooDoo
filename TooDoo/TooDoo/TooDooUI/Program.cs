using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TooDooUI;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            Navigation.GoToStart();
        }   

        




        private static void PrintToDoList()
        {
            //Metod för att göra ett API-anrop via REST, få tillbaka en JSON-sträng, deserialisera (omforma) den till ett objekt 

            var url = "http://localhost:55020/ToDoListService.svc/GetToDoListByName";   // Min lokala endpoint till API:et och metoden GetToDoListByName
            var urlParameters = "?name=Hamid";                                          // URL-parametern, i det här fallet namnet på listan

            HttpClient client = new HttpClient();   //Klass som sköter kommunikationen över nätverket/internet
            client.BaseAddress = new Uri(url);      //Sätter url:en på httpclient-objektet

            Console.WriteLine("Tryck enter för att starta anropet");
            Console.ReadLine();                                         //Stopp för att säkerställa att API hinner starta innan konsolen efterfrågar något

            client.DefaultRequestHeaders.Accept.Add(                    //Sätter en header i anropet för att tala om vilken typ av data den vill ha tillbaka
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;   // Här görs http-requesten. Metoden GetAsync returnerar ett response-objekt
            if (response.IsSuccessStatusCode)                                       // Kontrollerar om http-status är 200-nånting (success)
            {
                var toDoListWrapper = response.Content.ReadAsAsync<ToDoListWrapper>().Result;   // Gör om JSON-strängen till ett objekt av typen ToDoListWrapper

                foreach (var d in toDoListWrapper.d)                                            // För varje ToDo i ToDoListWrapper
                {
                    Console.WriteLine("{0} ({1})", d.Description, d.IsImportant);               // Skriv ut radens namn    
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);    // Felhantering
            }

        }

        
    }
}
