﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Task3OfAdvancedNetTechs
{
    public class Send
    {
        private Posts postID;
        private Profiles profileID;
        private string mail;
        private string name;
        private string avatar;
        private string footer;
        private string content;
        private Posts[] answers;

        public Send(Posts postID, Profiles profileID, string mail, string name, string avatar, string footer, string content, Posts[] answers)
        {
            this.postID = postID;
            this.profileID = profileID;
            this.mail = mail;
            this.name = name;
            this.avatar = avatar;
            this.footer = footer;
            this.content = content;
            this.answers = answers;
        }

        #region Getters
        public string GetPost()
        {
            return postID.GetElement();
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

        /*public List<string> GetAnswers()
        {
            Console.WriteLine(answers.Length);
            List<string> result = new List<string>();

            for(int i = 0; i < answers.Length; ++i)
            {
                Console.WriteLine(i);
                result.Add(answers[i].GetElement());
            }

            return result;
        }*/
        #endregion

        public async Task SerializeToJson()
        {
            await Task.Run(() =>
            {
                string cont = this.content;
                var json = new JavaScriptSerializer().Serialize(cont);
                Console.WriteLine("Serialized object: " + json);
                //return json;
            });
        }
    }
}
