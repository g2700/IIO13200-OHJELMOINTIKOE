using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class G2700_T4bLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string username;
        string pwd;
        string CurrentUser = "";
        string CurrentPwd = "";
        bool LoginStatus = false;
        username = Login1.UserName;
        pwd = Login1.Password;
        
        XmlDocument xmxdoc = new XmlDocument();
        xmxdoc.Load(ConfigurationManager.AppSettings["kayttajat"]);
        XmlNodeList xmlnodelist = xmxdoc.GetElementsByTagName("User");
        foreach (XmlNode xn in xmlnodelist)
        {
            XmlNodeList xmlnl = xn.ChildNodes;
            foreach (XmlNode xmln in xmlnl)
            {
                if (xmln.Name == "username")
                {
                    if (xmln.InnerText == username)
                    {
                        CurrentUser = username;
                    }
                }
                if (xmln.Name == "password")
                {
                    if (xmln.InnerText == pwd)
                    {
                        CurrentPwd = pwd;
                    }
                }
            }
            if ((CurrentUser != "") & (CurrentPwd != ""))
            {
                LoginStatus = true;
            }
        }
        if (LoginStatus == true)
        {
            MySession.Current.Property1 = username;
            Session.Timeout = 1;
            Response.Redirect("G2700_T4b.aspx");
        }
        else
        {
            Session["UserAuthentication"] = "";
        }
    }
}