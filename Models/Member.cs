using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OST_Inventory.Models
{
    public class Member
    {
        public string MemberName { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string Role { get; set; }

        public string MemberDesignation { get; set; }

        public string MobileNumber { get; set; }


        public static List<Member> LSTMember()
        {
            List<Member> list = new List<Member>();

            string connstring = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connstring);
            sqlConnection.Open();

            SqlCommand sql = new SqlCommand();
            sql.Connection = sqlConnection;
            sql.CommandText = "dbo.LstMember";
            sql.CommandType = System.Data.CommandType.StoredProcedure;
            sql.CommandTimeout = 0;

            SqlDataReader sqlDataReader = sql.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Member member = new Member();
                    member.UserName = Convert.ToString(sqlDataReader["UserName"].ToString());
                    member.PassWord = Convert.ToString(sqlDataReader["PassWord"].ToString());
                    member.Role = Convert.ToString(sqlDataReader["Role"].ToString());
                    list.Add(member);

                }

            }


            return list;

        }

        public static int SaveMember(string UserName,string password, string Role)
        {
            int result = 1;
            string connstring = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection( connstring);
            sqlConnection.Open();
            SqlCommand sql = new SqlCommand();
            sql.Connection = sqlConnection;
            sql.CommandText = "dbo.CreateMember";
            sql.CommandType = System.Data.CommandType.StoredProcedure;
            sql.CommandTimeout = 0;
            sql.Parameters.Add(new SqlParameter("@UserName", UserName));
            sql.Parameters.Add(new SqlParameter("@PassWord", password));
            sql.Parameters.Add(new SqlParameter("@Role", Role));
            sql.CommandTimeout = 0;

            try
            {
                result = sql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string sds = ex.Message;
            }

            sql.Dispose();
            sqlConnection.Close();

            return result;


        }

    }
}