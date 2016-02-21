using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class DacInsert
    {
        public static void InsertFichierZip(BO.FichiersZip fileZip)
        {
            SqlConnection con = null;
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["MachaineZipFile"].ConnectionString;
                con = new SqlConnection(cs);
                con.Open();

                SqlCommand com = new SqlCommand("INSERT INTO FichiersZip (NomZip) VALUES (@PNomZip)", con);
                com.Parameters.AddWithValue("@PNomZip", fileZip.NomZip);
                com.ExecuteNonQuery();


            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                con.Dispose();
            }
        }

        public static bool ExistZip(string zipname)
        {
            SqlConnection con = null;
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["MachaineZipFile"].ConnectionString;
                con = new SqlConnection(cs);
                con.Open();

                SqlCommand com = new SqlCommand(@"SELECT COUNT(*)
                                                    FROM FichiersZip
                                                    WHERE NomZip= @PName;", con);
                com.Parameters.AddWithValue("@PName", zipname);
                int temp = Convert.ToInt32(com.ExecuteScalar());
                
                if (temp > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Dispose();
            }
        }
    }
}
