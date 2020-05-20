using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3OfAdvancedNetTechs
{
    public class Posts
    {
        private static int globalIndex = 0;

        public static List<string> postsID = new List<string>();


        public Posts(string postID)
        {
            if(postsID.Count == 0)
            {
                postsID.Add(postID);
                Interlocked.Increment(ref globalIndex);
            }
            else if (CheckForDuplicates(postID).Result)
            {
                postsID.Add(postID);
                Interlocked.Increment(ref globalIndex);
            }
        }

        private async Task<bool> CheckForDuplicates(string postID)
        {
            return await Task.Run(() =>
            {
                for (int i = 0; i < postsID.Count; ++i)
                {
                    if (postID == postsID[i])
                    {
                        throw new InvalidOperationException("This string is already bound to other post!");
                        return false;
                    }
                }
                return true;
            });
        }

        public string GetElement(int index)
        {
            return postsID[index];
        }
    }
}
