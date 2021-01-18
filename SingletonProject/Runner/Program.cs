using SingletonProject.DbConnector;

namespace SingletonProject.Runner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MySqlConnector.GetMySqlConnector().ExecuteQuery("SELECT doctor_name FROM doctors WHERE doctor_id = 2");
            MySqlConnector.GetMySqlConnector().ExecuteQuery("SELECT doctor_name FROM doctors WHERE doctor_id = 3");
            MySqlConnector.GetMySqlConnector().CloseConnection();
            MySqlConnector.GetMySqlConnector().ExecuteQuery("SELECT doctor_name FROM doctors WHERE doctor_id = 2");
            MySqlConnector.GetMySqlConnector().CloseConnection();
        }
    }
}