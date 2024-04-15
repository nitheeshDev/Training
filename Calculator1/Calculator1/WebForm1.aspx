<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Calculator1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <p>First number</p>
                    </td>
                    <td>
                        <asp:TextBox ID="Text1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <p>Second number</p>
                    </td>
                    <td>
                        <asp:TextBox ID="Text2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <p>Operator</p>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Text="Addition" Value="Addition"></asp:ListItem>
                        <asp:ListItem Text="Subtraction" Value="Subtraction"></asp:ListItem>
                            <asp:ListItem Text="Muliplication" Value="Muliplication"></asp:ListItem>
                            <asp:ListItem Text="Division" Value="Division"></asp:ListItem>

                         </asp:DropDownList>                   

                    </td>
                </tr>
                 <tr>
                    <td>
                        <p>Result</p>
                    </td>
                    <td>
                        <asp:Label ID="Result" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Click" OnClick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
