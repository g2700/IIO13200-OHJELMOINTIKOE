using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class G2700_T2 : System.Web.UI.Page
{
    List<Country> maa;
    class popula
    {
        public string Maa { get; set; }
        public int Pop { get; set; }
        string maa;
        int pop;
        public popula() { }
    }
    class le
    {
        public string Maa { get; set; }
        public string LE { get; set; }
        string maa;
        string lE;
        public le() { }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string path = ConfigurationManager.AppSettings["Countries"];

            Countries maat = new Countries();
            maa = new List<Country>();

            BL.DeSerialisoiXml(path, ref maat);

            foreach (Country item in maat.countries)
            {
                maa.Add(item);
            }

            List<Country> SortedListByPop = maa.OrderByDescending(o => o.Population).ToList();          
            List<popula> top10=  new List<popula>();
            for(int i = 0; i < 10; i++) {
                popula p = new popula();
                p.Maa = SortedListByPop.ElementAt(i).Name;
                p.Pop = SortedListByPop.ElementAt(i).Population;
                top10.Add(p);
            }

           // List<Country> haetut = maa.FindAll(o => o.Name.Contains(TextBox1.Text));


            List<Country> SortedListByLE = maa.OrderBy(o => o.LifeExpectancy).ToList();
            List<le> letop10 = new List<le>();
            for (int i = 0; i <5; i++)
            {
                le p = new le();
                p.Maa = SortedListByLE.ElementAt(i).Name;
                p.LE = SortedListByLE.ElementAt(i).LifeExpectancy;
                letop10.Add(p);
            }


            GridView3.DataSource = letop10;
            GridView3.DataBind();

            GridView2.DataSource = top10;
            GridView2.DataBind();
            maalkm.Text = maa.Count.ToString();
            GridView1.DataSource = maa;
            GridView1.DataBind();

        }

        


    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
             {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType==DataControlRowType.Header)
            {

                e.Row.Cells[0].Visible =false;
                e.Row.Cells[3].Visible =false;
                e.Row.Cells[4].Visible =false;
                e.Row.Cells[5].Visible =false;

                //e.Row.Cells[6].Visible =false;
                e.Row.Cells[7].Visible =false;
                e.Row.Cells[8].Visible =false;
                e.Row.Cells[9].Visible =false;
                e.Row.Cells[9].Visible = false;
                //e.Row.Cells[10].Visible = false;
                e.Row.Cells[11].Visible = false;
                //e.Row.Cells[12].Visible = false;
                e.Row.Cells[13].Visible = false;
                e.Row.Cells[14].Visible = false;
               /*- name (nimi)
- continent (maanosa)
- population (asukasluku)
- paikallinen nimi (local name)
- headofstate (maan johtaja)*/

            }
        }
    }
protected void Button1_Click(object sender, EventArgs e)
{
         string path = ConfigurationManager.AppSettings["Countries"];

            Countries maat = new Countries();
            maa = new List<Country>();

            BL.DeSerialisoiXml(path, ref maat);

            foreach (Country item in maat.countries)
            {
                maa.Add(item);
            }
    
        List<Country> haetut = maa.FindAll(o => o.Name.Contains(TextBox1.Text));





        GridView1.DataSource = haetut;
        GridView1.DataBind();
    }

}