using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TooDooUI
{
    public class ToDoRepository
    {
        public ToDoListWrapper GetToDoListItems(string name)
        {
            var httpRequestHelper = new HttpRequestHelper();
            var toDoList = httpRequestHelper.ExecuteApiCall<ToDoListWrapper>("GetToDoListByName", "name=" + name);

            return toDoList;
        }

        public ToDoListsWrapper GetToDoLists()
        {
            var httpRequestHelper = new HttpRequestHelper();
            var toDoLists = httpRequestHelper.ExecuteApiCall<ToDoListsWrapper>("GetToDoLists", "");

            return toDoLists;
        }



    }
}
