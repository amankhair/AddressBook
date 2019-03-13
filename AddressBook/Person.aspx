<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Person.aspx.cs" Inherits="AddressBook.Person" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="width=300">
            <asp:HiddenField ID="hfId" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Full Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                    </td>
               </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Birth Date"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtBirthDate" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                 </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txteMAIL" runat="server"></asp:TextBox>
                    </td>
                 </tr>
                <tr>
                    <td>
                        
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblSuccessMessage" runat="server" Text="Success" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblErrorMessage" runat="server" Text="Error" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
                </div>
            <div>
            <asp:GridView ID="gvPerson" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="fullName" HeaderText="Full Name" />
                    <asp:BoundField DataField="birthDate" HeaderText="Birth Date" />
                    <asp:BoundField DataField="description" HeaderText="Description" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="lnk_OnClick"> Edit </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                </div>
        </div>
    </form>
</body>
</html>
