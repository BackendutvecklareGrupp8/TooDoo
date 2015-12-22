using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Core.Model;
using BLL;

namespace Api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ToDoListService : IToDoListService
    {
        public List<ToDo> GetToDoListByName(string name)
        {
            var tooDooRepository = new TooDooRepository();
            return tooDooRepository.GetToDoListByName(name);
        }

        public List<ToDoList> GetToDoLists()
        {
            var tooDooRepository = new TooDooRepository();
            var toDoList = tooDooRepository.GetToDoLists();
            var toDoListsTemp = toDoList
                .GroupBy(g => g.Name)
                .Select(grp => grp.ToList())
                .ToList();
            var toDoLists = new List<ToDoList>();

            foreach (var list in toDoListsTemp)
            {
                toDoLists.Add(new ToDoList { Name = list.First().Name });
            }

            return toDoLists;

        }
    }
}
