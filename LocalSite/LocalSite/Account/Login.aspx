<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="LocalSite.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
        <asp:HyperLink ID="ChangePwdHyperLinkID" runat="server" EnableViewState="false"  NavigateUrl="Register.aspx"> Change Password</asp:HyperLink>
       <a href="ChangePassword.aspx">Change Password</a>
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Change Pswd</asp:LinkButton>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
    </p>
    
    </asp:Content>
