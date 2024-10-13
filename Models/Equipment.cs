using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OST_Inventory.Models
{
    public class Equipment:Member
    {
          public int EquipmentId { get; set; }
          public string Name { get; set; }
          public int Quantity {  get; set; }

          public int Stock { get; set; }
          
          
          public string EntryDate { get; set; }

          public Member Member { get; set; }

        public Equipment() { 
        Member = new Member();
        }

        public static List<Equipment> LSTEquipment1()
        {
            List<Equipment> list = new List<Equipment>();

            for (int i = 0; i < 10; i++)
            {
                Equipment equipment = new Equipment();
                equipment.EquipmentId = i;
                equipment.Name = "Raian";
                equipment.Quantity = i * 6;
                equipment.EntryDate = "";


                list.Add(equipment);





            }


            return list;

        }


        public static List<Equipment> LSTEquipment()
        {
            List<Equipment> list = new List<Equipment>();

            string connstring = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connstring);
            sqlConnection.Open();

            SqlCommand sql = new SqlCommand();
            sql.Connection = sqlConnection;
            sql.CommandText = "dbo.GetList_InsEquipment";
            sql.CommandType= System.Data.CommandType.StoredProcedure;
            sql.CommandTimeout = 0;

            SqlDataReader sqlDataReader = sql.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Equipment equipment = new Equipment();
                    equipment.Name = Convert.ToString(sqlDataReader["EquipmentName"].ToString());
                    equipment.EquipmentId = Convert.ToInt32(sqlDataReader["EquipmentId"].ToString());
                    equipment.Quantity = Convert.ToInt32(sqlDataReader["Quantity"].ToString());
                    equipment.Stock = Convert.ToInt32(sqlDataReader["Stock"].ToString());
                    equipment.EntryDate = Convert.ToString(sqlDataReader["EntryDate"].ToString());
                    list.Add(equipment);

                }

            }


            return list;

        }



        public static int SaveEquipmrnt(string Name,int Quantitty,int Stock)
        {
            int result = 0;
            string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(ConnString);
            sqlConnection.Open();
            SqlCommand sql = new SqlCommand();
            sql.Connection = sqlConnection;
            sql.CommandText = "dbo.SpOst_InsEquipment";
            sql.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@Name", Name));
            sql.Parameters.Add(new SqlParameter("@Name", Name));
            sql.Parameters.Add(new SqlParameter("@Quantity", Quantitty));
            sql.Parameters.Add(new SqlParameter("@Stock", Stock));
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