using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TooDooUI
{
    class DeleteToDo
    {
        public class ToDoRepository
        {
            public ToDoListsWrapper DeleteToDo()
            {
                //Metod för att göra ett API-anrop via REST, få tillbaka en JSON-sträng, deserialisera (omforma) den till ett objekt 

                var url = "http://localhost:55020/ToDoListService.svc/DeleteToDo";    // Min lokala endpoint till API:et och metoden GetToDoListByName
                var urlParameters = "?id=3";                                                 // URL-parametern, i det här fallet namnet på listan
                ToDoListsWrapper toDoListWrapper = new ToDoListsWrapper();

                HttpClient client = new HttpClient();   //Klass som sköter kommunikationen över nätverket/internet
                client.BaseAddress = new Uri(url);      //Sätter url:en på httpclient-objektet

                //Console.WriteLine("Tryck enter för att starta anropet");
                //Console.ReadLine();                                         //Stopp för att säkerställa att API hinner starta innan konsolen efterfrågar något

                client.DefaultRequestHeaders.Accept.Add(                    //Sätter en header i anropet för att tala om vilken typ av data den vill ha tillbaka
                new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(urlParameters).Result;   // Här görs http-requesten. Metoden GetAsync returnerar ett response-objekt
                if (response.IsSuccessStatusCode)                                       // Kontrollerar om http-status är 200-nånting (success)
                {
                    toDoListWrapper = response.Content.ReadAsAsync<ToDoListsWrapper>().Result;   // Gör om JSON-strängen till ett objekt av typen ToDoListWrapper


                }
                else
                {
                    /*Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);  */  // Felhantering

                }

                return toDoListWrapper;

            }
        }
    }
}
