<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PollSystem.Web.Login" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderStyles" runat="server">
    <link href="Styles/Membership.css" rel="stylesheet" type="text/css" />
    </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>

<asp:Content ID="ContentTitle" 
  ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Literal runat="server" Mode="Encode"
      id="LiteralPageTitle">Poll System - Login</asp:Literal>

    <asp:LoginStatus ID="LoginStatus" runat="server" CssClass="LogoutLink" />
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    
    <div class="great-wrapper">
        <div class="single-wrapper membership-box">
            <asp:Login ID="Login1" runat="server" Font-Bold="True" Font-Names="Ebrima" Font-Size="Large" ForeColor="White" LoginButtonText="Login" TitleText="Login" UserNameLabelText="Username:">
            </asp:Login>
            <a href="Register.aspx" class="hrefButton">Register</a>
        </div>
    </div>
    

</asp:Content>
