using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;
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
                MessageBox.Show(ex.Message, "创建适配器出错,请检查网络或服务器配置！");
            }
        }
        public void Update()
        {
            try
            {
                SqlDataAdapter.Update(DataTable);
            }
            catch (Exception ex) { MessageBox.Show("连接数据库失败，详细原因："+ex.Message); }
        }
    }
}
