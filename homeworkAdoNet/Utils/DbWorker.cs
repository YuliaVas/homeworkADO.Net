using homeworkAdoNet.Models;
using System.Data.Common;
namespace homeworkAdoNet.Utils
{
  
    using System.Data;
    using System.Data.SqlClient;
    public class DbWorker
    {
        private string _connectionString;
        public DbWorker()
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = "DESKTOP-IMNEGUS";
            stringBuilder.TrustServerCertificate = true;
            stringBuilder.InitialCatalog = "SaleOfTrainTickets";
            stringBuilder.IntegratedSecurity = true;
            _connectionString = stringBuilder.ConnectionString;
        }
        public IEnumerable<Ticket_> GetTickets()
        {
            List <Ticket_> tickets = new List<Ticket_>();
            using (SqlConnection conn= new SqlConnection(_connectionString))
            {
                //try
                //{
                    conn.Open();
                //    Console.WriteLine(conn.Database);
                //}
                //catch(Exception exception)
                //{
                //    Console.WriteLine(exception.Message);
                //}
                using(SqlCommand command = conn.CreateCommand())
                {
                    command.CommandType= CommandType.Text;
                    command.CommandText = "SELECT*FROM Ticket";
                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            Ticket_ ticket_=new Ticket_();
                            //ticket_.Id = reader.GetInt32(0);
                            ticket_.Price=reader.GetDecimal(1);
                            ticket_.Date=reader.GetDateTime(2);
                            ticket_.Place_number=reader.GetInt32(3);
                            tickets.Add(ticket_);

                        }
                    }
                }
            }
            return tickets;
        }
        public void AddTicket(Ticket_ ticket_)
        {
            using(SqlConnection conn= new SqlConnection(_connectionString))
            {
                conn.Open();
                using(SqlCommand command= conn.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Ticket VALUES (@Price, @Date, @Place_number)";
                    var param1=new SqlParameter("@Price", SqlDbType.Int);
                   param1.Value = ticket_.Price;
                    var param2 = new SqlParameter("@Date", SqlDbType.DateTime);
                    param2.Value = ticket_.Date;
                    var param3 = new SqlParameter("@Place_number", SqlDbType.Int);
                    param3.Value = ticket_.Place_number;

                    command.Parameters.Add(param1);
                    command.Parameters.Add(param2);
                    command.Parameters.Add(param3);
                    var reader=command.ExecuteReader();

                }
            }
        }
    }
}
