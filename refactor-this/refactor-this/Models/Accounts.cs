using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace refactor_this.Models
{
    public class Account
    {
        //private bool isNew;

        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Number { get; set; }

        public Decimal Amount { get; set; }

        public Account()
        {
            
        }
        
        public List<Account> Get()
        {
            using (var connection = ConnectDB.NewConnection())
            {
                var st = new StringBuilder();
                //Query Accounts table
                st.Append("select * from Accounts");
                SqlCommand command = new SqlCommand($"" + st, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                var accounts = new List<Account>();
                while (reader.Read())
                {
                    var id = Guid.Parse(reader["Id"].ToString());
                    var account = new Account();
                    account.Id = id;
                    account.Name = reader["Name"].ToString();
                    account.Number = reader["Number"].ToString();
                    account.Amount = Convert.ToDecimal(reader["Amount"]);
                    accounts.Add(account);
                }
                return accounts;
            }
        }

        public Account Get(Guid id)
        {
            var account = new Account();
            using (var connection = ConnectDB.NewConnection())
            {
                var st = new StringBuilder();
                //Query Accounts by id
                st.Append("select * from Accounts");
                st.Append($" where Id = '{id}'");
                SqlCommand command = new SqlCommand($"" + st, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                //if there is no data, return blank
                reader.Read();
                account.Id = id;
                account.Name = reader["Name"].ToString();
                account.Number = reader["Number"].ToString();
                account.Amount = Convert.ToDecimal(reader["Amount"]);
            }
            return account;
        }

        public bool Insert()
        {
            using (var connection = ConnectDB.NewConnection())
            {
                var st = new StringBuilder();
                st.Append("insert into Accounts (Id, Name, Number, Amount) values");
                st.Append($" ('{Guid.NewGuid()}', '{Name}', '{Number}', 0)");
                SqlCommand command = new SqlCommand($"" + st, connection);
                connection.Open();
                //return false when insert unsuccessfully.
                if (command.ExecuteNonQuery() != 1)
                    return false;
            }
            return true;
        }

        public bool UpdateName(Guid id)
        {
            using (var connection = ConnectDB.NewConnection())
            {
                var st = new StringBuilder();
                st.Append($"update Accounts set Name = '{Name}'");
                st.Append($" where Id = '{id}'");
                SqlCommand command = new SqlCommand($"" + st, connection);
                connection.Open();
                //return false when update unsuccessfully.
                if (command.ExecuteNonQuery() != 1)
                    return false;
            }
            return true;

        } 

        public bool UpdateAmount(Guid id,decimal amount)
        {
            using (var connection = ConnectDB.NewConnection())
            {
                var st = new StringBuilder();
                st.Append($"update Accounts set Amount = Amount + {amount}");
                st.Append($" where Id = '{id}'");
                SqlCommand command = new SqlCommand($"" + st, connection);
                connection.Open();
                //return false when update unsuccessfully.
                if (command.ExecuteNonQuery() != 1)
                    return false;
            }
            return true;
        }

        public bool Delete(Guid id)
        {
            using (var connection = ConnectDB.NewConnection())
            {
                var st = new StringBuilder();
                st.Append("delete from Accounts");
                st.Append($" where Id = '{id}'");
                SqlCommand command = new SqlCommand($"" + st, connection);
                connection.Open();
                //return false when delete unsuccessfully.
                if (command.ExecuteNonQuery() != 1)
                   return false;
            }
            return true;
        }
    }
}