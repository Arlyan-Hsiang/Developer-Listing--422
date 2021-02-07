using System.Data.SqlClient;

namespace refactor_this
{
    public class ConnectDB
    {
        //Establish connection with DB here
        public static SqlConnection NewConnection()
        {
            var st = new System.Text.StringBuilder();
            st.Append("Data Source=(LocalDB)\\MSSQLLocalDB;");
            st.Append("AttachDbFilename=|DataDirectory|\\refactor-this.mdf;");
            st.Append("Integrated Security=True;");
            st.Append("Connect Timeout=30");
            return new SqlConnection(@"" + st);
        }
    }
}