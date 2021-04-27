using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace FormUI
{
    public class DataAccess
    {

        
        public List<Person> GetPeople(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("sqldataaccessdemodb")))
            {
                connection.Open();
                var output = connection.Query<Person>($"select * from People where LastName = '{lastName}'").ToList();
                return output;
            };
        }
    }
}
