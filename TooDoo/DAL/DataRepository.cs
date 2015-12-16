using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataRepository : DAL
    {
        private const string _connectionString = @"Data Source = server name; Initial Catalog = DB_ToDoList; User ID = RestFullUser; Password = RestFull123";
        
        public DataRepository() : base (_connectionString)
        {

        }    
    }


}
