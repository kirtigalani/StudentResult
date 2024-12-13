using Microsoft.Data.SqlClient;

namespace StudentResult.Models
{
    public class Studentresult
    {
        public string name { get; set; }
        public int sub1 { get; set; }
        public int sub2 { get; set; }
        public int sub3 { get; set; }
        public int sub4 { get; set; }
        public int sub5 { get; set; }

        SqlConnection sqlcon = new SqlConnection("Data Source=.\\SQLEXPRESS;Database=StudentResult;User Id=sa;pwd=123;Encrypt=False;TrustServerCertificate=False;");
        public int Insert(string name, int sub1, int sub2 , int sub3, int sub4, int sub5 , int total , int avg , string result)
        {
            SqlCommand Sqlcmd = new SqlCommand("insert into [dbo].[User](name,sub1,sub2,sub3,sub4,sub5,total,avg,result)values('" + name +"','"+ sub1 +"','"+ sub2 + "','"+ sub3 +"','"+ sub4 + "','"+ sub5 + "','"+ total +"','"+ avg +"','"+ result +"')", sqlcon);
            sqlcon.Open();
            return Sqlcmd.ExecuteNonQuery();
        }
    }
}
