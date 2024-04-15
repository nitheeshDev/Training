<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebAPI_Empty.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CRUD Application</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
</head>
<body>
    <form id="form1" runat="server" class="container mt-4">
        <h1>CRUD Application</h1>
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="TextBox1">Username:</label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="TextBox2">Password:</label>
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="TextBox3">Country:</label>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="TextBox4">Email:</label>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="TextBox5">User ID:</label>
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="btn-group" role="group" aria-label="CRUD buttons">
                    <asp:Button ID="Button1" runat="server" Text="Insert" OnClick="Button1_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" CssClass="btn btn-success" />
                    <asp:Button ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" CssClass="btn btn-danger" />
                </div>
            </div>
            <div class="col-md-6">
                <asp:Label ID="Label1" runat="server" CssClass="font-weight-bold"></asp:Label>
                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" CssClass="table table-bordered"
      DataKeyNames="Id"  AutoGenerateEditButton="true">
             <Columns>
             <asp:CommandField ShowDeleteButton="true" />
             </Columns>
             </asp:GridView>
                <%--<asp:GridView ID="GridView1" runat="server" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" CssClass="table table-bordered" AutoGenerateEditButton="true">
    <Columns>
        <asp:CommandField ShowDeleteButton="true" />
    </Columns>
</asp:GridView>--%>


            </div>
        </div>
    </form>
</body>
</html>
