<%@ Page Title="Create New Poll" Language="C#"
    MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CreateNewPoll.aspx.cs" Inherits="PollSystem.Web.CreateNewPoll" %>

<asp:Content ID="ContentStyles" ContentPlaceHolderID="ContentPlaceHolderStyles" runat="server">
    <link href="Styles/Membership.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="ContentTitle" 
  ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Literal runat="server" Mode="Encode"
      id="LiteralPageTitle">Poll System - Create New Poll</asp:Literal>
    <asp:LoginStatus ID="LoginStatus" runat="server" CssClass="LogoutLink" />
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    
    <div class="great-wrapper">
        <div class="single-wrapper form">
            Question: <asp:TextBox runat="server" id="TextBoxQuestion" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorQuestion" runat="server"
                ControlToValidate="TextBoxQuestion" ErrorMessage="*" />
            Answer 1: <asp:TextBox runat="server" id="TextBoxAnswer1" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAnswer1" runat="server" 
                ControlToValidate="TextBoxAnswer1" ErrorMessage="*" />
            Answer 2: <asp:TextBox runat="server" id="TextBoxAnswer2" />
            Answer 3: <asp:TextBox runat="server" id="TextBoxAnswer3" />
            Answer 4: <asp:TextBox runat="server" id="TextBoxAnswer4" />
            Answer 5: <asp:TextBox runat="server" id="TextBoxAnswer5" />
            Answer 6: <asp:TextBox runat="server" id="TextBoxAnswer6" />
            <asp:Button Text="Create" runat="server" ID="ButtonCreateNewPoll"
                CssClass="button" OnClick="ButtonCreateNewPoll_Click" />
        </div>
    </div>
    

</asp:Content>
