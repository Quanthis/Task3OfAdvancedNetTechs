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

        private readonly string[] postsID;


        public Posts(string postID)
        {
            if (CheckForDuplicates(postID).Result)
            {
                postsID[globalIndex] = postID;
                Interlocked.Increment(ref globalIndex);
            }
        }

        private async Task<bool> CheckForDuplicates(string postID)
        {
            return await Task.Run(() =>
            {
                for (int i = 0; i < postsID.Length; ++i)
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
    }
}
