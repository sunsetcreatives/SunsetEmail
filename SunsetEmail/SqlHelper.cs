using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

class SqlHelper
{
    private static string GetString()
    {
        return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }

    public static DataTable Load(string query)
    {
        SqlConnection con = null;
        SqlDataAdapter adp = null;
        DataTable dtLoad = new DataTable();

        try
        {
            con = new SqlConnection(GetString());

            adp = new SqlDataAdapter(query, con);
            adp.Fill(dtLoad);   

            return (dtLoad);
        }
        catch (Exception ea)
        {
            throw ea;
        }
        finally
        {
            dtLoad.Dispose();
            adp.Dispose();
            con.Close();
            con.Dispose();
        }
    }

    public static bool Opertions(string query)
    {
        SqlConnection con = null;
        SqlCommand com = null;

        try
        {
            con = new SqlConnection(GetString());
            con.Open();

            com = new SqlCommand(query, con);

            if (com.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }
        catch (Exception eb)
        {
            throw eb;
        }
        finally
        {
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }

    public static bool OpertionsArray(ArrayList arr)
    {
        SqlConnection con = null;
        SqlCommand com = null;
        SqlTransaction myTrans = null;

        try
        {
            con = new SqlConnection(GetString());
            con.Open();

            myTrans = con.BeginTransaction();

            for (int i = 0; i < arr.Count; i++)
            {
                com = new SqlCommand(arr[i].ToString(), con, myTrans);
                com.ExecuteNonQuery();
            }

            myTrans.Commit();

            return true;
        }
        catch
        {
            myTrans.Rollback();

            return false;
        }
        finally
        {
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }

    public static bool CheckHasRows(string strQuery)
    {
        SqlConnection con = null;
        SqlCommand com = null;
        SqlDataReader sqlRd = null;

        try
        {
            con = new SqlConnection(GetString());
            con.Open();

            com = new SqlCommand(strQuery, con);
            sqlRd = com.ExecuteReader();

            return (sqlRd.HasRows);
        }
        catch (Exception ec)
        {
            throw ec;
        }
        finally
        {
            sqlRd.Dispose();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }

    public static int NextId(string tableName, string columnName)
    {
        SqlConnection con = null;
        SqlCommand com = null;

        try
        {
            int id;

            con = new SqlConnection(GetString());
            con.Open();

            string query = "SELECT COALESCE(MAX(" + columnName + "),0) FROM " + tableName + "";
            com = new SqlCommand(query, con);

            id = Convert.ToInt32(com.ExecuteScalar().ToString());

            return (id + 1);
        }
        catch (Exception ed)
        {
            throw ed;
        }
        finally
        {
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }

    public static int IntValue(string query)
    {
        SqlConnection con = null;
        SqlCommand com = null;

        try
        {
            int id;
            object obj = new object();

            con = new SqlConnection(GetString());
            con.Open();

            com = new SqlCommand(query, con);
            obj = com.ExecuteScalar();

            if (obj is DBNull || obj == null)
                id = -1;
            else
                id = Convert.ToInt32(obj.ToString());

            return (id);
        }
        catch (Exception ef)
        {
            throw ef;
        }
        finally
        {
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }

    public static string stringValue(string query)
    {
        SqlConnection con = null;
        SqlCommand com = null;

        try
        {
            con = new SqlConnection(GetString());
            con.Open();
            object obj = new object();
            string abc;

            com = new SqlCommand(query, con);
            obj = com.ExecuteScalar();

            if (obj is DBNull || obj == null)
                abc = null;
            else
                abc = obj.ToString();

            return (abc);
        }
        catch (Exception eg)
        {
            throw eg;
        }
        finally
        {
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }

    public static decimal DecimalValue(string query)
    {
        SqlConnection con = null;
        SqlCommand com = null;

        try
        {
            con = new SqlConnection(GetString());
            con.Open();

            com = new SqlCommand(query, con);
            string abc = com.ExecuteScalar().ToString();

            abc = abc == string.Empty ? "0.00" : abc;

            return (decimal.Parse(abc));
        }
        catch (Exception eg)
        {
            throw eg;
        }
        finally
        {
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
}