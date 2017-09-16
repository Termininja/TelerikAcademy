<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PollSystem.Web.Register" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderStyles" runat="server">
    <link href="Styles/Membership.css" rel="stylesheet" type="text/css" />
    </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>


<asp:Content ID="ContentTitle" 
  ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Literal runat="server" Mode="Encode"
      id="LiteralPageTitle">Poll System - Register</asp:Literal>

    <asp:LoginStatus ID="LoginStatus" runat="server" CssClass="LogoutLink" />
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="great-wrapper">
        <div class="single-wrapper membership-box">
    <div _designerregion="0">
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" RequireEmail="False" CreateUserButtonText="Register" FinishDestinationPageUrl="~/ViewAllPolls.aspx">
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td align="center" colspan="2">Register</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep runat="server" >
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td align="center">Complete</td>
                            </tr>
                            <tr>
                                <td>Your account has been successfully created.</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue" Text="Continue" ValidationGroup="CreateUserWizard1" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
    </div>
        <a href="Login.aspx" class="hrefButton">Login</a>
        </div>
    </div>
</asp:Content>
