using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entity;

namespace DAL
{
    public class DataLink
    {
        SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        string connect = "Server = DEL1-LHP-N82143\\MSSQLSERVER01;Database = Week5;Integrated Security = SSPI";

        public bool Insert(Book book)
        {
            try
            {
                if(GetNumberOfRecords() > 0)
                {
                    conn = new SqlConnection(connect);
                    cmd = new SqlCommand("AddBook", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", book.ID);
                    cmd.Parameters.AddWithValue("@Name", book.Name);
                    cmd.Parameters.AddWithValue("@Author", book.Author);
                    cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
                    cmd.Parameters.AddWithValue("@Price", book.Price);
                    conn.Open();
                    int n = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (n > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                if (GetNumberOfRecords() > 0)
                {
                    conn = new SqlConnection(connect);
                    cmd = new SqlCommand("DeleteBook", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    int n = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (n > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Book book)
        {
            try
            {
                if (GetNumberOfRecords() > 0)
                {
                    conn = new SqlConnection(connect);
                    cmd = new SqlCommand("UpdateBook", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", book.ID);
                    cmd.Parameters.AddWithValue("@Name", book.Name);
                    cmd.Parameters.AddWithValue("@Author", book.Author);
                    cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
                    cmd.Parameters.AddWithValue("@Price", book.Price);
                    conn.Open();
                    int n = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (n > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public object Show()
        {
            if (GetNumberOfRecords() > 0)
            {
                conn = new SqlConnection(connect);
                cmd = new SqlCommand("GetDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable DT = new DataTable();
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DT);
                return DT;
            }
            else
            {
                return null;
            }
        }

        private int GetNumberOfRecords()
        {
            int count = -1;
            try
            {
                conn = new SqlConnection(connect);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select count(*) from BookDetails", conn);

                count = (int)cmd.ExecuteScalar();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return count;
        }
    }
}
