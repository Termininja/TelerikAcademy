using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PollSystem.DAL;

namespace PollSystem.Web
{
    public partial class ViewAllPolls : System.Web.UI.Page
    {
        protected int voteCounts;

        protected string SafeEval(string expression)
        {
            string result = Eval(expression).ToString();
            string encodedResult = Server.HtmlEncode(result);
            return encodedResult;
        }

        protected int ShowVotesCount(string expression)
        {
            string result = Eval(expression).ToString();
            int pollID = int.Parse(result);
            return PollsDAL.ShowVotesCount(pollID);
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            var polls = PollsDAL.GetAllPolls();

            this.ListViewQuestions.DataSource = polls;
            this.ListViewQuestions.DataBind();
			if (!this.Page.IsPostBack)
			{
				if (polls.Count > 0)
				{
					ShowQuestion(polls[0].PollID);
				}
			}
        }

        protected void QuestionButton_Command(object sender, CommandEventArgs e)
        {
            var commandArg = e.CommandArgument.ToString();
            int pollId = int.Parse(commandArg);
			ShowQuestion(pollId);
        }

		private void ShowQuestion(int pollId)
		{
			Poll poll = PollsDAL.GetPollsInfo(pollId);
			voteCounts = PollsDAL.ShowVotesCount(poll.PollID);
			this.TitleHeader.InnerHtml = poll.Question;
			this.RepeaterPollAnswers.DataSource = poll.PollAnswers;
			this.DataBind();
		}

        protected int GetPercents(string expression)
        {
            string result = Eval(expression).ToString();
            int votes = int.Parse(result);

            double percents = ((double)votes) / voteCounts * 100;

            return (int)percents;
        }

		protected void ListViewQuestions_PagePropertiesChanged(object sender, EventArgs e)
		{
		}   
    }
}