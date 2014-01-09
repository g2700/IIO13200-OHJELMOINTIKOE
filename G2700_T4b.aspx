<%@ Page Language="C#" AutoEventWireup="true" CodeFile="G2700_T4b.aspx.cs" Inherits="G2700_T4b" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="drpjoukkueet" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="drpjoukkueet_SelectedIndexChanged"></asp:DropDownList>

            <asp:GridView ID="tunnit" runat="server" AutoGenerateColumns="true"></asp:GridView>
<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        Käyttäjänimi: <asp:TextBox ID="txtboxKayttaja" runat="server"></asp:TextBox><br />
        Päiväys: <asp:TextBox ID="txtboxDate" runat="server" ></asp:TextBox> <br />

        Tunnit: <asp:TextBox ID="txtboxTunnit" runat="server"></asp:TextBox><br />
        Minuutit: <asp:TextBox ID="txtbotMinuutit" runat="server"></asp:TextBox>
        <asp:Button runat="server" ID="btnLisaa" Text="Kirjaa merkinta" OnClick="btnLisaa_Click"/>

        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
