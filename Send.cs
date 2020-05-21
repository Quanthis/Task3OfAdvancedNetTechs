using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task3OfAdvancedNetTechs
{
    public class Send
    {
        private HashSet<string> postID =  new HashSet<string>();
        private Profiles profileID;
        private string mail;
        private string name;
        private string avatar;
        private string footer;
        private string content;
        private HashSet<string> answers = new HashSet<string>();

        public Send(string postID, Profiles profileID, string mail, string name, string avatar, string footer, string content, string[] answers)
        {
            try
            {
                this.postID.Add(postID);
                this.profileID = profileID;
                this.mail = mail;
                this.name = name;
                this.avatar = avatar;
                this.footer = footer;
                this.content = content;

                for(int i = 0; i < answers.Length; ++i)
                {
                    this.answers.Add(answers[i]);
                }
            }
            catch(Exception)
            {
                Console.WriteLine("One of unique string is not unique");
            }
        }

        public void AddAnswer(string answer)
        {
            answers.Add(answer);
        }

        #region Getters
        public string GetPost()
        {
            List<string> sent = postID.ToList<string>();
            return sent[0];
        }
        public string GetProfile()
        {
            return profileID.GetElement();
        }

        public string GetMail()
        {
            return mail;
        }

        public string GetName()
        {

            return name;
        }
        public string GetAvatar()
        {
            return avatar;
        }

        public string GetFooter()
        {
            return footer;
        }

        public string GetContent()
        {
            return content;
        }

        public List<string> GetAnswers()
        {
            List<string> result = answers.ToList<string>();
            return result;
        }
        #endregion
    }
}
