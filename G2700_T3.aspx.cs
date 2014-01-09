using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*) 
5) 
6) asiakkaan haku, haku kohdistuu sekä asnimi että yhteyshlo -kenttiin, esitä taulukossa asiakkaista astunnus, asnimi, yhteyshlo ja maa
7) asiakkaiden listaus maittain, eli esitä raportinomaisesti kukin maa, ja sen alla listattuna asiakas (asnimi)
 * */
public partial class G2700_T3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {


            GridView1.DataSourceID = "AsiakkaatSQLDataSource";
            lblError.Text = "Taulussa on "+ GridView1.Rows.Count.ToString() + " asiakasta";

            lblError.Visible = true;
            //lblError.Text = "Kaikki Toimii taulussa on ";
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.ToString();
            throw;
        }


        SqlConnection s = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Demox"].ToString());
        s.Open();
        SqlCommand cmd = new SqlCommand("SELECT SUM(ostot) FROM asiakas", s);
        SqlCommand cmd1 = new SqlCommand("SELECT COUNT(ostot) FROM asiakas WHERE ostot IS NOT NULL", s);
        //cmd.CommandText = ;
        lblostot.Text = cmd1.ExecuteScalar().ToString() + " asiakasta joilla ostoja joiden yhteissumma: " + cmd.ExecuteScalar().ToString() ;

        List<string> asiakkaat = new List<string>();

        SqlCommand cmd2 = new SqlCommand("SELECT DISTINCT asnimi, maa FROM asiakas ORDER BY maa", s);
        SqlDataAdapter da = new SqlDataAdapter(cmd2);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string maa = "";
        foreach (DataRow item in dt.Rows)
        {
            if (maa == item["maa"].ToString())
            {

            }
            else
            {

            }

        }




    }
   /* protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        Label1.Text = e.AffectedRows.ToString();
    }*/
    protected void DDLMaat_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
          //  lblError.Visible = false;
            GridView1.DataSourceID = "AsFilteredByCountrySQLDataSource";
            GridView1.Visible = false;
        }
        catch (Exception ex)
        {
         //   lblError.Visible = true;
           // lblError.Text = ex.ToString();
            throw;
        }
    }

  
}