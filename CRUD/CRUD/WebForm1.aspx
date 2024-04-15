<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CRUD.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
       <asp:Label ID="Label5" runat="server"></asp:Label><br />
       <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
       <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br /><br />
       <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
       <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br /><br />
       <asp:Label ID="Label3" runat="server" Text="Country"></asp:Label>
       <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br /><br />
       <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
       <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br /><br />
       <asp:Button ID="Button1" runat="server" Text="Insert" OnClick="Button1_Click1"/>
       <asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" />
       <asp:Button ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" /><br />
       <br />
    <div>
        <asp:GridView ID="GridView1" runat="server"  >
            <Columns>
                <asp:ButtonField CommandName="Edit" HeaderText="Edit" ShowHeader="True" Text="Edit" />
            </Columns>
        </asp:GridView>
    </div>
</form>

</body>
</html>
