using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TooDooUI
{
    public class HttpRequestHelper
    {
        private const string baseUrl = "http://localhost:55020/ToDoListService.svc/";

        public T ExecuteApiCall<T>(string methodName, string parameters)
        {
            //Metod för att göra ett API-anrop via REST, få tillbaka en JSON-sträng, deserialisera (omforma) den till ett objekt 

            var url = baseUrl + methodName   ;                                              // Min lokala endpoint till API:et och metoden GetToDoListByName
            var urlParameters = "?" + parameters;                                           // URL-parametern, i det här fallet namnet på listan
            T responseObject = (T)Activator.CreateInstance(typeof(T));

            HttpClient client = new HttpClient();   //Klass som sköter kommunikationen över nätverket/internet
            client.BaseAddress = new Uri(url);      //Sätter url:en på httpclient-objektet
            
            client.DefaultRequestHeaders.Accept.Add(                    //Sätter en header i anropet för att tala om vilken typ av data den vill ha tillbaka
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;   // Här görs http-requesten. Metoden GetAsync returnerar ett response-objekt
            if (response.IsSuccessStatusCode)                                       // Kontrollerar om http-status är 200-nånting (success)
            {
                responseObject = response.Content.ReadAsAsync<T>().Result;   // Gör om JSON-strängen till ett objekt 

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);    // Felhantering
            }

            return responseObject;
        }


    }
}
