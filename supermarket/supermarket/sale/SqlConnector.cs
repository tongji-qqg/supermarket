using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Suppermarket_POS
{
    enum ConnectionType { Express, Other };
    class SqlConnector
    {
        public DataTable DataTable { get; set; }
        public SqlDataAdapter SqlDataAdapter { get; set; }
        //private string ConnectionString =  "localhost;Initial Catalog=Market;Integrated Security=True";
        private string ConnectionString = supermarket.Properties.Settings.Default.SupermarketConnectionString;
        public SqlConnector(string selectSqlString)
        {
            try
            {                
                SqlDataAdapter = new SqlDataAdapter(selectSqlString, ConnectionString);                
                DataTable = new DataTable();
                SqlDataAdapter.FillSchema(DataTable, SchemaType.Mapped);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(SqlDataAdapter);
                SqlDataAdapter.Fill(DataTable);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "创建适配器出错");
            }
        }
        public void Update()
        {
            SqlDataAdapter.Update(DataTable);
        }
    }
}
