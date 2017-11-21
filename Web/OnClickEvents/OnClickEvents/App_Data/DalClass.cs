using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

public class DalClass{

    public static string constr = ConfigurationManager.ConnectionStrings["dbConStr"].ToString();
    static MySqlConnection con = new MySqlConnection(constr);

    public void OpenConnection() {
        try { con.Open(); }
        catch(Exception ex) { con.Close(); }
    }

    public bool CheckConnection() {
        bool check = true;
        try
        {
            if (con.State != System.Data.ConnectionState.Open)
            {
                OpenConnection();
                check = true;
            }
        }
        catch (Exception ex) {
            check = false;
            con.Close();
        }
        return check;
    }

    public object ExecuteScalar(string _sql)
    {
        object result = null;
        try
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = _sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                result = cmd.ExecuteScalar();
            }
        }
        catch (Exception ex)
        {
            result = ex.Message;
        }
        finally
        {
            con.Close();
        }
        return result;
    }

    public string ExecuteData(string _sql)
    {
        string result = string.Empty;
        try
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = _sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                if (con.State != ConnectionState.Open)
                {
                    OpenConnection();
                }
                result = cmd.ExecuteNonQuery().ToString();
            }
        }
        catch (Exception ex)
        {
            result = ex.Message;
        }
        finally
        {
            con.Close();
        }
        return result;
    }

    public DataSet GetDataSet(string _sql)
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = _sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.CommandTimeout = 0;
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(ds);
            adp.Dispose();
            return ds;
        }

    }

    public DataTable GetDataTable(string _sql)
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = _sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.CommandTimeout = 0;
            DataTable dt = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(dt);
            adp.Dispose();
            return dt;
        }

    }


}
