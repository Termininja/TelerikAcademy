<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Voting.aspx.cs" Inherits="PollSystem.Web.Voting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>



<asp:Content ID="ContentTitle" 
  ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Literal runat="server" Mode="Encode"
      id="LiteralPageTitle">Poll System - Voting Result</asp:Literal>

    <asp:LoginStatus ID="LoginStatus" runat="server" CssClass="LogoutLink" />
</asp:Content>


<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <header class="great-wrapper">Thank you for your vote!</header>

    <section class="great-wrapper">
        <div class="single-wrapper">
            <h3 ID="TitleHeader" runat="server"></h3>
            <asp:Repeater ID="RepeaterPollAnswers" runat="server">
                <ItemTemplate>
                    <div class="answer-wrapper">
                        <span class="answer-text">
                            <%# SafeEval("Answer")%>
                        </span>
                        <progress id="progressBar" max="100" 
                            value='<%# GetPercents("Votes") %>'><%# GetPercents("Votes") %>
                        </progress>
                        (<%# GetPercents("Votes") %>%)
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <a href="Polls.aspx" id="BackButton" class="button">&larr; Back to Polls</a>
    </section>

</asp:Content>
