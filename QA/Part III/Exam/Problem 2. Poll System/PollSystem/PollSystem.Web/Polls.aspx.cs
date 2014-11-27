using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PollSystem.DAL;

namespace PollSystem.Web
{
    public partial class Polls : System.Web.UI.Page
    {
        protected string SafeEval(string expression)
        {
            string result = Eval(expression).ToString();
            string encodedResult = Server.HtmlEncode(result);
            return encodedResult;
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            var polls = PollsDAL.GetThreeRandomPolls();

            this.ListViewShowThreePolls.DataSource = polls;
            this.ListViewShowThreePolls.DataBind();
        }

        protected void RadioButtonListShowingAnswers_DataBinding(object sender, EventArgs e)
        {
            RadioButtonList rdl = (RadioButtonList)sender;
            rdl.DataTextField = "Answer";
            rdl.DataValueField = "AnswerID";
        }

        protected void ListViewShowThreePolls_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
			ListViewItem lvi = e.Item;
			Button btn = (Button)lvi.FindControl("VoteButton");
			var commandArg = btn.CommandArgument.ToString();
			int pollID = int.Parse(commandArg);

			if (e.CommandName == "Vote")
			{
				RadioButtonList rbl = (RadioButtonList)lvi.FindControl("RadioButtonListShowingAnswers");
				var answerIDStr = rbl.SelectedValue;
				if (answerIDStr != "")
				{
					int answerID = int.Parse(answerIDStr);
					PollsDAL.VoteForPoll(answerID);
					Response.Redirect("Voting.aspx?pollId=" + pollID);
				}
			}
			else if (e.CommandName == "Reset")
			{
				Response.Redirect("Voting.aspx?reset=true&pollId=" + pollID);
			}
			else if (e.CommandName == "Delete")
			{
				PollsDAL.DeletePoll(pollID);
				Response.Redirect("Polls.aspx");
			}
		}
    }
}