<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAllPolls.aspx.cs" Inherits="PollSystem.Web.ViewAllPolls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>

<asp:Content ID="ContentTitle" 
  ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Literal runat="server" Mode="Encode"
      id="LiteralPageTitle">Poll System - View All Results</asp:Literal>

    <asp:LoginStatus ID="LoginStatus" runat="server" CssClass="LogoutLink" />
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <div class="great-wrapper">              
        <asp:ListView ID="ListViewQuestions" runat="server" OnPagePropertiesChanged="ListViewQuestions_PagePropertiesChanged">
            <ItemTemplate>
                <div class="single-wrapper title">
                <asp:Button ID="QuestionButton" runat="server" 
                    CommandArgument='<%# Eval("PollID") %>' OnCommand="QuestionButton_Command"   
                    CommandName="ShowQuestion" Text='<%# SafeEval("Question") %>'
                    CssClass="question-button"/><br />
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div class="paging">
        <asp:DataPager ID="DataPagerPolls" runat="server"
            PagedControlID="ListViewQuestions" PageSize="3">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Link" 
                    ShowFirstPageButton="True" 
                    ShowNextPageButton="False" 
                    ShowPreviousPageButton="False" />
                <asp:NumericPagerField CurrentPageLabelCssClass="aspNetCurrentPage" />
                <asp:NextPreviousPagerField 
                    ButtonType="Link" ShowLastPageButton="True" 
                    ShowNextPageButton="False" ShowPreviousPageButton="False" />
            </Fields>
        </asp:DataPager>
    </div>

    <section class="great-wrapper" runat="server" ID="GreatWrapper">
        <div class="single-wrapper">
            <h3 ID="TitleHeader" runat="server"></h3>
            <asp:Repeater ID="RepeaterPollAnswers" runat="server">
                <ItemTemplate>
                    <div class="answer-wrapper">
                        <span class="answer-text">
                            <%# SafeEval("Answer")%>
                        </span>
                        <progress id="progressBar" max="100" 
                            value='<%# GetPercents("Votes") %>'><%# GetPercents("Votes") %></progress>
                        (<%# GetPercents("Votes") %>%)
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </section>


</asp:Content>

