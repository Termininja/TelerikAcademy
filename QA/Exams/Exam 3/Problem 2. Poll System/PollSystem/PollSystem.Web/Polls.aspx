<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Polls.aspx.cs" Inherits="PollSystem.Web.Polls" %>
<%@ Import Namespace="PollSystem.DAL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>

<asp:Content ID="ContentTitle" 
  ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Literal runat="server" Mode="Encode"
      id="LiteralPageTitle">Poll System - Polls & Voting</asp:Literal>

    <asp:LoginStatus ID="LoginStatus" runat="server" CssClass="LogoutLink" />
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    
    <div class="great-wrapper">
    <asp:ListView runat="server" ID="ListViewShowThreePolls" OnItemCommand="ListViewShowThreePolls_ItemCommand">
        <ItemTemplate>
            <div class="single-wrapper question">
                <div class="radiobuttons-wrapper">
                <h3 class="question">
                    <%# SafeEval("Question")%>
                </h3>
                    <asp:RadioButtonList runat="server" ID="RadioButtonListShowingAnswers"
                        DataSource='<%#DataBinder.Eval(Container.DataItem, "PollAnswers")%>' 
                        OnDataBinding="RadioButtonListShowingAnswers_DataBinding"                
                        >
                    </asp:RadioButtonList> 
                </div>               
                <asp:Button ID="VoteButton" runat="server"
                    CommandArgument='<%# Eval("PollID") %>'
                    CommandName="Vote" CssClass="button" Text="Vote" />
                <!--
                <div class="AdminMenu">Admin menu</div>
                <asp:Button ID="ButtonReset" runat="server"
                    CommandArgument='<%# Eval("PollID") %>'
                    CommandName="Reset" CssClass="button" Text="Reset" />
                <asp:Button ID="ButtonDelete" runat="server"
                    CommandArgument='<%# Eval("PollID") %>'
                    CommandName="Delete" CssClass="button" Text="Delete" />
                -->
            </div>
        </ItemTemplate>    
    </asp:ListView>
        <div class="clear"></div>
    </div>
</asp:Content>
