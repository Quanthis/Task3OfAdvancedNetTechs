using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Task3OfAdvancedNetTechs
{
    public class BuildJSON
    {
        public string postID;
        public string profileID;
        public string mail;
        public string name;
        public string avatar;
        public string footer;
        public string content;
        public List<string> answers;

        public BuildJSON(Send valueToConvert)
        {
            this.postID = valueToConvert.GetPost();
            this.profileID = valueToConvert.GetProfile();
            this.mail = valueToConvert.GetMail();
            this.name = valueToConvert.GetName();
            this.avatar = valueToConvert.GetAvatar();
            this.footer = valueToConvert.GetFooter();
            this.content = valueToConvert.GetContent();
            this.answers = valueToConvert.GetAnswers();
        }

        public async Task<string> SerializeToJson()
        {
            return await Task.Run(() =>
            {
                string cont = this.content;
                var json = new JavaScriptSerializer().Serialize(this);
                Console.WriteLine("Serialized object: " + json);
                return json;
            });
        }
    }
}
