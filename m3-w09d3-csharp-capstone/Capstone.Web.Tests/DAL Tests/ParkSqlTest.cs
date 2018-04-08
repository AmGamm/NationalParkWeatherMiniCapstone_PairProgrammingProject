using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capstone.Web.DALs;
using Capstone.Web.Models;
using System.Transactions;

namespace Capstone.Web.Tests.DAL_Tests
{
    [TestClass]
    public class ParkSqlTest
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=ParkWeather;Integrated Security=True";
        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;

                conn.Open();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void ParkSqlDalTests()
        {
            ParkSqlDAL parkDal = new ParkSqlDAL(connectionString);

            List<Park> parks = parkDal.GetParks();
            Assert.IsNotNull(parks);
        }
    }
}
