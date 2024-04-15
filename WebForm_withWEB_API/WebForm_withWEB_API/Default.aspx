<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm_withWEB_API._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">User Details</h5>
                        <div class="form-group">
                            <label for="TextBox5">UserID</label>
                            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="TextBox1">Username</label>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="TextBox2">Password</label>
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="TextBox4">Country</label>
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="TextBox3">Email</label>
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:Button ID="Button1" runat="server" Text="Insert" OnClick="Button1_Click" CssClass="btn btn-primary btn-block" />
                        <asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click1" CssClass="btn btn-success btn-block mt-2" />
                        <asp:Button ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" CssClass="btn btn-danger btn-block mt-2" />
                        <asp:Label ID="Label1" runat="server" CssClass="mt-3" Text=""></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">User List</h5>
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover"></asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
