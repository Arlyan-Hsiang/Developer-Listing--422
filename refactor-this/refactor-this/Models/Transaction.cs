using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace refactor_this.Models
{
    public class Transaction
    {
        public String Date { get; set; }

        public Decimal Amount { get; set; }

        public Transaction() { }

        public List<Transaction> Get(Guid id)
        {
            var transactions = new List<Transaction>();
            using (var connection = ConnectDB.NewConnection())
            {
                //Query the transaction by accountid
                var st = new StringBuilder();
                st.Append("select Amount, Date from Transactions");
                st.Append($" where AccountId = '{id}'");
                SqlCommand command = new SqlCommand($"" + st, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var transaction = new Transaction();
                    transaction.Date = Convert.ToDateTime(reader["Date"]).ToString("yyyy-MM-dd");
                    transaction.Amount = Convert.ToDecimal(reader["Amount"]);
                    transactions.Add(transaction);
                }
            }
            return transactions;
        }

        public bool Insert(Guid id)
        {
            Account account = new Account();
            using (var connection = ConnectDB.NewConnection())
            {
                SqlCommand command;
                //insert a transaction log.
                var stinsert = new StringBuilder();
                stinsert.Append("INSERT INTO Transactions (Id, Amount, Date, AccountId) VALUES");     
                stinsert.Append($" ('{Guid.NewGuid()}', {Amount}, '{DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss")}', '{id}')");
                command = new SqlCommand($"" + stinsert, connection);
                connection.Open();
                if (command.ExecuteNonQuery() != 1)
                    return false;
                //Execute Sucessfully
                return true;
            }
        }
    }
}