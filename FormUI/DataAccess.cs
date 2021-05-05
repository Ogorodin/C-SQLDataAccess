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

                var procedure = "GetPeopleByLastName";
                var values = new { input = lastName };
                var result = connection.Query<Person>(procedure, values, commandType: CommandType.StoredProcedure).ToList();

                return result;
            };
        }

        internal void InsertPerson(string firstName, string lastName, string email, string phone)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("sqldataaccessdemodb")))
            {
                connection.Open();
                var procedure = "PeopleInsert";
                var values = new
                {
                    firstName = firstName,
                    lastName = lastName,
                    emailAddress = email,
                    phoneNumber = phone
                };
                connection.Query<Person>(procedure, values, commandType: CommandType.StoredProcedure);



            }
        }
    }
}
