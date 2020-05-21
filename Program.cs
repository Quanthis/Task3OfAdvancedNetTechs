using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task3OfAdvancedNetTechs
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0 || args == null)
            {
                Console.WriteLine("Using built-in sample data...");

                var profile = new Profiles("341");

                string[] answers = { "answer1", "answer2" };

                var sample = new Send("postID", profile, "mail@dot.com", "Name", "http://somelink", "footer", "content", answers);

                var json = new BuildJSON(sample);

                await json.SerializeToJson();

                Console.ReadKey();
            }
            else
            {
                try
                {
                    string postID = args[0];
                    var profile = new Profiles(args[1]);
                    string mail = args[2];
                    string name = args[3];
                    string link = args[4];
                    string footer = args[5];
                    string content = args[6];
                    List<string> answers = new List<string>();
                    
                    for(int i = 7; i < args.Length; ++i)
                    {
                        answers.Add(args[i]);
                    }

                    string[] sendableAnswers = new string[answers.Count];
                    for(int i = 0; i < answers.Count; ++i)
                    {
                        sendableAnswers[i] = answers[i + 7];
                    }

                    var toSend = new Send(postID, profile, mail, name, link, footer, content, sendableAnswers);
                    var json = new BuildJSON(toSend);
                    await json.SerializeToJson();
                }
                catch(Exception)
                {
                    Console.WriteLine("Please specify args as below: ");
                    Console.WriteLine("postID, profileID, mail, name, avatarLink, footer, content, anwers (may be more than one answer to a post");
                    Console.WriteLine("Please restart application.");
                }
                finally
                {
                    Console.ReadKey();
                }
            }
        }
    }
}
