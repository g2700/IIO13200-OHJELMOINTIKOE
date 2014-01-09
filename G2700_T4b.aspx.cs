using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class G2700_T4b : System.Web.UI.Page
{
    private DataSet ds;
    private DataTable dt;
    private DataView dataViewAll;
    private List<string> columns;

    protected void Page_Load(object sender, EventArgs e)
    {

            if (MySession.Current.Property1 == "default value")
                Response.Redirect("~/G2700_T4bLogin.aspx");

            columns = new List<string>();
            columns.Add("kayttaja");
            columns.Add("paiva");
            columns.Add("tunnit");
            columns.Add("minuutit");

            ds = new DataSet();
            ds.ReadXml(ConfigurationManager.AppSettings["tunnit"]);

            dt = ds.Tables[0];
            //  var productNames = from products in dt.AsEnumerable()
            //                   select products.Field<string>("ProductName");
            //var query = dt.AsEnumerable().Where(dr => dr.Field<string>("LastName") == "Smith").Select(dr => dr.Field<string>("FirstName
            // var query = dt.AsEnumerable().Where(dr => dr.Field<string>("kayttaja") == "Linusss").Select(dr => dr.Field<string>("kayttaja").Count());
            // Label1.Text = query.First().ToString();

            dataViewAll = dt.DefaultView;

            tunnit.DataSource = dataViewAll.ToTable(false, columns.ToArray());

            tunnit.DataBind();
            txtboxKayttaja.Text = MySession.Current.Property1;
            txtboxDate.Text = DateTime.Now.ToShortDateString();

            int tunnitcnt = 0;
            int minuutitcnt = 0;
            foreach (DataRowView row in dt.DefaultView)
            {
                tunnitcnt += int.Parse(row["tunnit"].ToString());
                minuutitcnt += int.Parse(row["minuutit"].ToString());
            }
            tunnitcnt += minuutitcnt / 60;
            int minuutit = minuutitcnt % 60;
            Label2.Text = "kirjausten kokonaislukumäärä " + dt.Rows.Count.ToString() +" ja kesto " + tunnitcnt.ToString() + ":"+ minuutit.ToString();

            if (!IsPostBack)
            {
                DataTable ddt;
            ddt = dt.DefaultView.ToTable(true, "kayttaja");
            drpjoukkueet.DataSource = ddt.DefaultView;
            drpjoukkueet.DataTextField = "kayttaja";
            drpjoukkueet.DataBind();

        }
    }
    protected void btnLisaa_Click(object sender, EventArgs e)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(ConfigurationManager.AppSettings["tunnit"]);


        XmlNode node = doc.CreateElement("tunti");
        XmlElement kayttaja = doc.CreateElement("kayttaja");
        kayttaja.InnerText = txtboxKayttaja.Text;
        XmlElement date = doc.CreateElement("paiva");
        date.InnerText = txtboxDate.Text;
        XmlElement tunnit = doc.CreateElement("tunnit");
        tunnit.InnerText = txtboxTunnit.Text;
        XmlElement minuutit = doc.CreateElement("minuutit");
        minuutit.InnerText = txtbotMinuutit.Text;
        node.AppendChild(kayttaja);
        node.AppendChild(date);
        node.AppendChild(tunnit);
        node.AppendChild(minuutit);


        doc.DocumentElement.AppendChild(node);
        doc.Save(ConfigurationManager.AppSettings["tunnit"]);
    }
    protected void drpjoukkueet_SelectedIndexChanged(object sender, EventArgs e)
    {
        string filter = string.Format("kayttaja like '%{0}%'", drpjoukkueet.SelectedValue);
        DataView dv = dt.DefaultView;
        dv.RowFilter = filter;
        int tunnitcnt = 0;
        int minuutitcnt = 0;
        foreach (DataRowView row in dv)
        {
            tunnitcnt += int.Parse(row["tunnit"].ToString());
            minuutitcnt += int.Parse(row["minuutit"].ToString());
        }
        tunnitcnt += minuutitcnt / 60;
        int minuutit = minuutitcnt % 60;
        tunnit.DataSource = dv;
        tunnit.DataBind();
        Label2.Text = drpjoukkueet.SelectedValue + " tuntikirjaukset : " + dv.Count.ToString() + "kpl. tunnit yhteensä: " + tunnitcnt.ToString()+ ":"+minuutit.ToString();
    }
}