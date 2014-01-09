<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/G2700_T3Master.master" CodeFile="G2700_T3.aspx.cs" Inherits="G2700_T3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div>
 

         <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label><br />
         <asp:DropDownList id="DDLMaat" runat="server" DataSourceID="MaatSQLDataSource" AutoPostBack="true" DataTextField="maa" Visible="true" OnSelectedIndexChanged="DDLMaat_SelectedIndexChanged"></asp:DropDownList>  <br />
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField DataField="asnimi" HeaderText="asnimi" SortExpression="asnimi" />
                <asp:BoundField DataField="yhteyshlo" HeaderText="yhteyshlo" SortExpression="yhteyshlo" />
                <asp:BoundField DataField="maa" HeaderText="maa" SortExpression="maa" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="AsiakkaatSQLDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Demox %>" SelectCommand="SELECT [asnimi], [yhteyshlo], [maa] FROM [asiakas] ORDER BY [asnimi]"></asp:SqlDataSource>
          <asp:SqlDataSource ID="MaatSQLDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Demox %>" SelectCommand="SELECT DISTINCT [maa] FROM [asiakas]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="AsFilteredByCountrySQLDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Demox %>" SelectCommand="SELECT [asnimi], [yhteyshlo], [maa] FROM [asiakas] WHERE [maa] = @Maa ORDER BY [asnimi]">
                <SelectParameters>
               <asp:ControlParameter Name="Maa" ControlID="DDLMaat" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
            </asp:SqlDataSource>

        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="astunnus" DataSourceID="OstotSQLDataSource">
            <Columns>
                <asp:BoundField DataField="astunnus" HeaderText="astunnus" ReadOnly="True" SortExpression="astunnus" />
                <asp:BoundField DataField="asnimi" HeaderText="asnimi" SortExpression="asnimi" />
                <asp:BoundField DataField="ostot" HeaderText="ostot" SortExpression="ostot" />
                
            </Columns>
         </asp:GridView>
        <br />
        <asp:Label ID="lblostot" runat="server" Text="Label"></asp:Label>

         <asp:SqlDataSource ID="OstotSQLDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Demox %>" SelectCommand="SELECT [astunnus], [asnimi], [ostot] FROM [asiakas] WHERE [ostot] IS NOT NULL ORDER BY [ostot] DESC"></asp:SqlDataSource>
          <asp:SqlDataSource ID="CountSQLDS" runat="server" ConnectionString="<%$ ConnectionStrings:Demox %>" SelectCommand="SELECT COUNT(*) FROM [asiakas]"></asp:SqlDataSource>
<br />
        <br />
    </div>

</asp:Content>