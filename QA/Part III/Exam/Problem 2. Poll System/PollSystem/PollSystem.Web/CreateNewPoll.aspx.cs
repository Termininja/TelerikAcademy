using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PollSystem.DAL;

namespace PollSystem.Web
{
	public partial class CreateNewPoll : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void ButtonCreateNewPoll_Click(object sender, EventArgs e)
		{
			string question = this.TextBoxQuestion.Text;
			string answer1 = this.TextBoxAnswer1.Text;
			string answer2 = this.TextBoxAnswer2.Text;
			string answer3 = this.TextBoxAnswer3.Text;
			string answer4 = this.TextBoxAnswer4.Text;
			string answer5 = this.TextBoxAnswer5.Text;
			string answer6 = this.TextBoxAnswer6.Text;
			PollsDAL.CreateNewPoll(question, answer1, answer2, answer3, answer4, answer5, answer6);
			Response.Redirect("~/Polls.aspx");
		}
	}
}