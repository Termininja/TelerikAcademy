using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PollSystem.DAL;

namespace PollSystem.Web
{
    public partial class Voting : System.Web.UI.Page
    {
        protected int voteCounts;

        protected string SafeEval(string expression)
        {
            string result = Eval(expression).ToString();
            string encodedResult = Server.HtmlEncode(result);
            return encodedResult;
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
			var queryStringPollID = Request.QueryString["pollId"];

			if (queryStringPollID == null || queryStringPollID == string.Empty)
			{
				Response.Redirect("Polls.aspx");
			}

			int pollId = int.Parse(queryStringPollID);

			var queryStringReset = Request.QueryString["reset"];
			if (queryStringReset != null)
			{
				PollsDAL.ResetPoll(pollId);
			}
            
			Poll poll = PollsDAL.GetAnswers(pollId);
			this.TitleHeader.InnerText = poll.Question;

			voteCounts = PollsDAL.ShowVotesCount(poll.PollID);

			this.RepeaterPollAnswers.DataSource = poll.PollAnswers;
			this.RepeaterPollAnswers.DataBind();
        }

        protected int GetPercents(string expression)
        {
            string result = Eval(expression).ToString();
            int votes = int.Parse(result);

			double percents = 0;
			if (voteCounts != 0)
			{
				percents = ((double)votes) / voteCounts * 100;
			}

            return (int)percents;
        }             
    }
}