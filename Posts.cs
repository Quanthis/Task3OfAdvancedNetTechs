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
        private int index = 0;

        private List<string> postsID = new List<string>();

        public List <string> ToSend;

        public Posts(string postID)
        {
            if(postsID.Count == 0)
            {
                postsID.Add(postID);
                Interlocked.Increment(ref globalIndex);
                index = globalIndex;
            }
            else if (CheckForDuplicates(postID).Result)
            {
                postsID.Add(postID);
                Interlocked.Increment(ref globalIndex);
                index = globalIndex;
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

        public string GetElement()
        {
            if (postsID.Count == 0)
            {
                throw new InvalidOperationException("List has no elements, therefore it can not be copied.");
            }
            else
            {
                ToSend = postsID;
                return ToSend[index - 1];
            }
        }
    }
}
