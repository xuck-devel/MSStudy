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

            string ConnectString = "Server=(localdb)\\mssqllocaldb;Database=CSWebAppContext-91e67821-630c-4958-a9cc-29f9825a8850;Trusted_Connection=True;MultipleActiveResultSets=true";
            SqlConnection Connection = null;
            SqlTransaction Tran = null;
            try
            {
                Connection = new SqlConnection(ConnectString);
                Connection.Open();
                Tran = Connection.BeginTransaction();

                this.Select(Connection, Tran);
                this.Insert(Connection, Tran);
                this.Delete(Connection, Tran);

                Tran.Commit();

            }
            catch (Exception e)
            {
                if (Tran != null )
                {
                    Tran.Rollback();
                }
                throw;
            }
            finally
            {
                try
                {
                    if ( Connection != null )
                    {
                        Connection.Close();
                    }
                }
                catch (Exception e) { }
            }
            
            return View();
        }

        private void Select(SqlConnection Connection, SqlTransaction Tran)
        {

            SqlDataReader Reader = null;

            try
            {

                SqlCommand Command = new SqlCommand("select * from dbo_Table_3", Connection);
                Command.Transaction = Tran;
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    string Aaaa = Reader.GetString(0);
                    Trace.WriteLine("Aaaa:" + Aaaa);
                }

            }
            finally
            {
                if ( Reader != null )
                {
                    Reader.Close();
                }
            }

        }

        private void Insert(SqlConnection Connection, SqlTransaction Tran)
        {

            Trace.WriteLine("before insert:");
            this.Select(Connection, Tran);

            // updateÇ‡SQLï∂Ç™à·Ç§ÇæÇØÇ≈ÅAèàóùÇÕìØÇ∂
            SqlCommand Command = new SqlCommand("insert into dbo_Table_3 values(@Aaaa)", Connection);
            Command.Transaction = Tran;
            Command.Parameters.AddWithValue("@Aaaa", "99999");
            int Rows = Command.ExecuteNonQuery();

            //throw new Exception("exception occured");

            Trace.WriteLine("after insert:");
            this.Select(Connection, Tran);

        }

        private void Delete(SqlConnection Connection, SqlTransaction Tran)
        {

            Trace.WriteLine("before delete:");
            this.Select(Connection, Tran);

            // updateÇ‡SQLï∂Ç™à·Ç§ÇæÇØÇ≈ÅAèàóùÇÕìØÇ∂
            SqlCommand Command = new SqlCommand("delete from dbo_Table_3 where Aaaa=@Aaaa", Connection);
            Command.Transaction = Tran;
            Command.Parameters.AddWithValue("@Aaaa", "99999");
            int Rows = Command.ExecuteNonQuery();

            Trace.WriteLine("after delete:");
            this.Select(Connection, Tran);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
