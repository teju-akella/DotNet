<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="LocalSite.Account.ChangePassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <br />
    <br />
        <table style="width:100%;">
            <tr>
                <td align="right">
                    <asp:Label ID="OldPwdLblID" runat="server" Text="Old Password: "></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="OldPwdTxtBoxID" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="NewPwdLblID" runat="server" Text="New Password: "></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="ForgetNewPwdtxtbxID" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                
                <td align="right">
                    <asp:Label ID="CnfrmNewPwdID" runat="server" Text="Confirm New Password: "></asp:Label>
                </td>
                 <td align="left">
                    
                     <asp:TextBox ID="ForgetCnfrmPwdTextboxID" runat="server" TextMode="Password"></asp:TextBox>
                    
                     <asp:CompareValidator ID="CompareValidatorinForgetPwdID" runat="server" 
                         ControlToCompare="ForgetNewPwdtxtbxID" 
                         ControlToValidate="ForgetCnfrmPwdTextboxID" ErrorMessage="password Mismatch"></asp:CompareValidator>
                    
                </td>
                
            </tr>
            <tr>
                
                <td align="right">
    <asp:Button ID="ForgetCancelBtnID" runat="server" Text="Cancel" />
                </td>
                 <td align="left">
                    
    <asp:Button ID="ChangePwdBtnID" runat="server" Text="Change Password" />
                    
                </td>
                
            </tr>
        </table>
    <br />
    <asp:Label ID="ChangePwdLabelID" runat="server" Enabled="False"></asp:Label>
    <br />
    <br />
</asp:Content>
