<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="LocalSite.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <br />
    <asp:Label ID="CreateUserHeading" runat="server" Font-Bold="True" 
        Font-Size="Large" Font-Underline="True" ForeColor="#000066" Text="CREATE USER" 
        Width="500px"></asp:Label>
    <br />
    <br />
    <asp:Label ID="ErrorMsg" runat="server" ForeColor="Red" Text="Label" 
        Visible="False"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Label ID="UserNameID" runat="server" Text=" USER NAME : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Label ID="PasswordID" runat="server" Text="PASSWORD : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="PasswordTextBoxID" runat="server" EnableTheming="True" 
    TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Label ID="ConfirmPasswordID" runat="server" Text="CONFIRM PASSWORD : "></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="ConfirmPasswordTextBoxID" runat="server" 
        TextMode="Password"></asp:TextBox>
    <asp:CompareValidator ID="CompareValidator2" runat="server" 
        ControlToCompare="PasswordTextBoxID" ErrorMessage="not equal" 
    ControlToValidate="ConfirmPasswordTextBoxID"></asp:CompareValidator>
    <br />
    <br />
    <br />
    <asp:Button ID="CancelRegisterID" runat="server" Text="CANCEL" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="SubmitButtonID" runat="server" Text="SUBMIT" 
    onclick="SubmitButtonID_Click" />
    <br />
    <br />
</asp:Content>
