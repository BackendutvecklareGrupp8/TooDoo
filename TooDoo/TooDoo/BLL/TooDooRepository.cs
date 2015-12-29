using Core.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TooDooRepository
    {
        public void AddToDo(ToDo toDo)
        {
            var dataRepository = new DataRepository();
            dataRepository.AddToDo(toDo);
        }

        public void DeleteToDo(int id)
        {
            var dataRepository = new DataRepository();
            dataRepository.DeleteToDo(id);
        }

        public List<ToDo> GetToDoListByName(string name)
        {
            var dataRepository = new DataRepository();
            var tempList = dataRepository.GetToDoListByName(name);

            foreach (var listItem in tempList)
            {
                listItem.IsImportant = listItem.Description.Contains("!");
            }

            return tempList;
        }

        public List<ToDoList> GetToDoLists()
        {
            var dataRepository = new DataRepository();
            var toDoList = dataRepository.GetToDoList();
            var toDoListsTemp = toDoList
                .GroupBy(g => g.Name)
                .Select(grp => grp.ToList())
                .ToList();
            var toDoLists = new List<ToDoList>();

            foreach (var list in toDoListsTemp)
            {
                toDoLists.Add(new ToDoList { Name = list.First().Name});
            }

            return toDoLists;
            
        }


    }
}
