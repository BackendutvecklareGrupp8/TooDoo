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

        public List<ToDo> GetToDoLists()
        {
            var dataRepository = new DataRepository();
            return dataRepository.GetToDoList();
        }
    }
}
