using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {

            string connectString = "Server=(localdb)\\mssqllocaldb;Database=CSWebAppContext-91e67821-630c-4958-a9cc-29f9825a8850;Trusted_Connection=True;MultipleActiveResultSets=true";
            SqlConnection connection = null;
            SqlTransaction tran = null;
            try
            {
                connection = new SqlConnection(connectString);
                connection.Open();
                tran = connection.BeginTransaction();

                this.select(connection,tran);
                this.insert(connection, tran);
                this.delete(connection, tran);

                tran.Commit();

            }
            catch (Exception e)
            {
                if ( tran != null )
                {
                    tran.Rollback();
                }
                throw;
            }
            finally
            {
                try
                {
                    if ( connection != null )
                    {
                        connection.Close();
                    }
                }
                catch (Exception e) { }
            }
            
            return View();
        }

        private void select(SqlConnection connection, SqlTransaction tran)
        {

            SqlCommand command = new SqlCommand("select * from dbo_Table_3", connection);
            command.Transaction = tran;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string aaaa = reader.GetString(0);
                Trace.WriteLine("Aaaa:" + aaaa);
            }

        }

        private void insert(SqlConnection connection, SqlTransaction tran)
        {

            Trace.WriteLine("before insert:");
            this.select(connection, tran);

            // updateÇ‡SQLï∂Ç™à·Ç§ÇæÇØÇ≈ÅAèàóùÇÕìØÇ∂
            SqlCommand command = new SqlCommand("insert into dbo_Table_3 values(@Aaaa)", connection);
            command.Transaction = tran;
            command.Parameters.AddWithValue("@Aaaa", "99999");
            int rows = command.ExecuteNonQuery();

            //throw new Exception("exception occured");

            Trace.WriteLine("after insert:");
            this.select(connection, tran);

        }

        private void delete(SqlConnection connection, SqlTransaction tran)
        {

            Trace.WriteLine("before delete:");
            this.select(connection, tran);

            // updateÇ‡SQLï∂Ç™à·Ç§ÇæÇØÇ≈ÅAèàóùÇÕìØÇ∂
            SqlCommand command = new SqlCommand("delete from dbo_Table_3 where Aaaa=@Aaaa", connection);
            command.Transaction = tran;
            command.Parameters.AddWithValue("@Aaaa", "99999");
            int rows = command.ExecuteNonQuery();

            Trace.WriteLine("after delete:");
            this.select(connection, tran);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
