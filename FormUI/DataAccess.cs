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
                //   var output = connection.Query<Person>("dbo.GetPeopleByLastName @LastName", new { LastName = lastName }).ToList();

                //     MySqlCommand cmd = new MySqlCommand("GetPeopleByLastName", connection);
                //     cmd.CommandType = CommandType.StoredProcedure;
                //     cmd.Parameters.Add(new MySqlParameter("lastName", new { LastName = lastName }));
                //     var result = cmd.BeginExecuteNonQuery();

                //    Procedure or function '[GetPeopleByLastName]' cannot be found in database 'sqldataaccessdemodb'.
                //    Verify that user 'root'@'localhost' has enough privileges to execute. // line var results....
                //      var procedure = "[GetPeopleByLastName]";
                //     var values = new { LastName = lastName };
                //      var results = connection.Query<Person>(procedure, values, commandType: CommandType.StoredProcedure).ToList();

                //var sql = "[GetPeopleByLastName] @LastName";
                //var values = new { LastName = lastName };
                //var results = connection.Query(sql, values).ToList();

                return output;
            };
        }

        internal void InsertPerson(string firstName, string lastName, string email, string phone)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("sqldataaccessdemodb")))
            {
                //                connection.Open();
                List<Person> people = new List<Person>();
                people.Add(new Person
                {
                    FirstName = firstName,
                    LastName = lastName,
                    EmailAddress = email,
                    PhoneNumber = phone
                });

                connection.Execute(
                    $"INSERT INTO people(firstName, lastName, emailAddress, phonNumber)" +
                    $"  VALUES ({firstName}, {lastName}, {email}, {phone})");
            }
        }
    }
}
