using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollSystem.DAL
{
    public static class PollsDAL
    {
        public static List<Poll> GetThreeRandomPolls()
        { 
            using(PollSystemEntities context = new PollSystemEntities())
            {
                List<Poll> polls = context.Polls.Include("PollAnswers").ToList();

                List<Poll> pollsToReturn = new List<Poll>();

                Random rndGen = new Random();

                for (int i = 0; i < 3 && polls.Count != 0; i++)
                {
                    int index = rndGen.Next(0, polls.Count);
                    pollsToReturn.Add(polls[index]);
                    polls.RemoveAt(index);
                }

                return pollsToReturn;
            }
        }

        public static List<Poll> GetAllPolls()
        {
            using (PollSystemEntities context = new PollSystemEntities())
            {
                List<Poll> polls = context.Polls.Include("PollAnswers").OrderBy(p => p.Question).ToList();

                return polls;
            }
        }

        public static Poll GetAnswers(int pollID)
        { 
    
            using (PollSystemEntities context = new PollSystemEntities())
            {
                Poll poll = context.Polls.Include("PollAnswers").First(p => p.PollID == pollID);

                return poll;
            }
        }

        public static void VoteForPoll(int answerID)
        {
            using (PollSystemEntities context = new PollSystemEntities())
            {
                PollAnswer answer = context.PollAnswers.First(a => a.AnswerID == answerID);
                
                int votes = answer.Votes;
                answer.Votes = votes + 1;

                context.SaveChanges();
            }
        }

		public static void CreateNewPoll(string question, string answer1, 
			string answer2, string answer3, string answer4, string answer5, string answer6)
		{
			Poll newPoll = new Poll();
			newPoll.Question = question;
			PollSystemEntities context = new PollSystemEntities();
			context.Polls.AddObject(newPoll);
			context.SaveChanges();

			if (!string.IsNullOrWhiteSpace(answer1))
				CreateAnswer(answer1, newPoll);
			if (!string.IsNullOrWhiteSpace(answer2))
				CreateAnswer(answer2, newPoll);
			if (!string.IsNullOrWhiteSpace(answer3))
				CreateAnswer(answer3, newPoll);
			if (!string.IsNullOrWhiteSpace(answer4))
				CreateAnswer(answer4, newPoll);
			if (!string.IsNullOrWhiteSpace(answer5))
				CreateAnswer(answer5, newPoll);
			if (!string.IsNullOrWhiteSpace(answer6))
				CreateAnswer(answer6, newPoll);
		}

		private static void CreateAnswer(string answerText, Poll newPoll)
		{
			using (PollSystemEntities context = new PollSystemEntities())
			{
				if (answerText.Length > 255)
				{
					// Special case: long text should be inserted directly
					string cmd = String.Format("INSERT INTO PollAnswers(Answer, Votes, PollID) VALUES ('{0}', {1}, {2})", answerText, 0, newPoll.PollID);
					context.ExecuteStoreCommand(cmd);
				}
				else
				{
					PollAnswer answer = new PollAnswer();
					answer.Answer = answerText;
					answer.PollID = newPoll.PollID;
					answer.Votes = 0;
					context.PollAnswers.AddObject(answer);
				}
				context.SaveChanges();
			}
		}

		public static Poll GetPollsInfo(int pollID)
		{
			using (PollSystemEntities context = new PollSystemEntities())
			{
				Poll poll = context.Polls.Include("PollAnswers").First(p => p.PollID == pollID);

				return poll;
			}
		}

		public static int ShowVotesCount(int pollID)
		{
			using (PollSystemEntities context = new PollSystemEntities())
			{
				Poll poll = context.Polls.Include("PollAnswers").First(p => p.PollID == pollID);
				int votesCount = 0;
				foreach (PollAnswer answer in poll.PollAnswers)
				{
					votesCount += answer.Votes;
				}
				return votesCount;
			}
		}

		public static void DeletePoll(int pollID)
		{
			PollSystemEntities context = new PollSystemEntities();
			context.ExecuteStoreCommand("DELETE FROM PollAnswers WHERE PollID={0}", pollID);
			context.ExecuteStoreCommand("DELETE FROM Polls WHERE PollID={0}", pollID);
		}

		public static void ResetPoll(int pollID)
		{
			PollSystemEntities context = new PollSystemEntities();
			context.ExecuteStoreCommand("UPDATE PollAnswers SET Votes=0 WHERE PollID={0}", pollID);
		}
	}
}
