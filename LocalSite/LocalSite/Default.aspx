<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="LocalSite._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Log In
    </h2>
   
    <p>
        Please enter your username and password.
        <asp:HyperLink ID="RegisterHyperLink" runat="server" NavigateURL="/Account/Register.aspx" EnableViewState="false">Register</asp:HyperLink> if you don't have an account.
    </p>
    <p>
        <table style="width:100%;">
            <tr>
                <td align="right">
                    <asp:Label ID="LoginUserNameLabelID" runat="server" Text="User Name:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="LoginTextBoxID" runat="server"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="LoginPasswordlabelID" runat="server" Text="Password:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="PasswordTextBoxID" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                
                <td align="right">
                    <asp:Button ID="LoginBtnID" runat="server" Text="Log In" 
                        onclick="LoginBtnID_Click" />
                </td>
                 <td align="left">
                    
                     <asp:HyperLink ID="ForgetPassword" runat="server">OMG! I Forgot My Password</asp:HyperLink>
                    
                </td>
                
            </tr>
        </table>
    </p>
    <p>
        <asp:Label ID="result" runat="server" Visible="False"></asp:Label>
    </p>
    </asp:Content>
