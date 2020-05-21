using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Task3OfAdvancedNetTechs
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var profile = new Profiles("341"); 

            string[] anwers = { "answer1", "answer2" };

            var sample = new Send("postID", profile, "mail@dot.com", "Name", "http://somelink", "footer", "content", anwers);

            var json = new BuildJSON(sample);
            await json.SerializeToJson();

            Console.ReadKey();
        }
    }
}
