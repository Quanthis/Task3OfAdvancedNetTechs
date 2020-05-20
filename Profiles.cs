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

        public static List<string> profileIDs = new List<string>();


        public Profiles(string postID)
        {
            if(profileIDs.Count == 0)
            {
                profileIDs.Add(postID);
                Interlocked.Increment(ref globalIndex);
            }
            else if (CheckForDuplicates(postID).Result)
            {
                profileIDs.Add(postID);
                Interlocked.Increment(ref globalIndex);
            }
        }

        private async Task<bool> CheckForDuplicates(string postID)
        {
            return await Task.Run(() =>
            {
                for (int i = 0; i < profileIDs.Count; ++i)
                {
                    if (postID == profileIDs[i])
                    {
                        throw new InvalidOperationException("This string is already bound to other profile!");
                        return false;
                    }
                }
                return true;
            });
        }
    }
}
