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
            var post = new Posts("123");
            var profile = new Profiles("341");
            var otherPost = new Posts("1234");

            Posts[] linkedPosts = new Posts[1];
            linkedPosts[0] = otherPost;


            var sample = new Send(post, profile, "mail@dot.com", "Name", "http://somelink", "footer", "content", linkedPosts);

            var json = new BuildJSON(sample);
            json.SerializeToJson();
            Console.WriteLine(json);
            
            //await sample.SerializeToJson();
            /*var json = new JavaScriptSerializer();
            var serialized = json.Serialize(sample);
            Console.WriteLine(serialized);*/

            //Console.WriteLine(post.GetElement(10));

            Console.ReadKey();
        }
    }
}
