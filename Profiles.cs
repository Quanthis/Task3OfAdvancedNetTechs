using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task3OfAdvancedNetTechs
{
    public class Profiles
    {
        private static int globalIndex = 0;

        private readonly string[] profileIDs;


        public Profiles(string postID)
        {
            if (CheckForDuplicates(postID).Result)
            {
                profileIDs[globalIndex] = postID;
                Interlocked.Increment(ref globalIndex);
            }
        }

        private async Task<bool> CheckForDuplicates(string postID)
        {
            return await Task.Run(() =>
            {
                for (int i = 0; i < profileIDs.Length; ++i)
                {
                    if (postID == profileIDs[i])
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
