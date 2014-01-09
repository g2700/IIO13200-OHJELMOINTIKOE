<%@ Page Language="C#" AutoEventWireup="true" CodeFile="G2700_T4bLogin.aspx.cs" Inherits="G2700_T4bLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>PuolipilkunViilaajien virallinen kotisivu(TM)</h1>
      <asp:Image ID="Image1" runat="server" ImageUrl="~/Images.jpg" />
    <form id="form1" runat="server">
    <div>
      <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" FailureText="Incorrect username or password!"></asp:Login>
    </div>
    </form>
    <br />
    käyttäjä/salasana <br />
    Linus/linus <br />
    Richard/richard <br />
    Monty/monty <br />
    Bjarne/bjarne <br />
</body>
</html>
