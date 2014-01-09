<%@ Page Language="C#" AutoEventWireup="true" CodeFile="G2700_T2.aspx.cs" Inherits="G2700_T2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Haku(case sensitive) <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /> <br />
        Maita:<asp:Label ID="maalkm" runat="server" Text="Label"></asp:Label> <br />
        Top10 väkeä
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="true"></asp:GridView>
        Life Expentancy
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="true"></asp:GridView>
        <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="true"></asp:GridView>
    </div>
    </form>
</body>
</html>
