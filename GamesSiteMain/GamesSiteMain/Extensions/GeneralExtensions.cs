using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSiteMain
{
    public static class GeneralExtensions
    {
        public static string GetShortened(this string self,int lines=5)
        {
            string[] split = self.Split(Environment.NewLine);
            if (split.Length < lines)
                return self;

            return string.Join(Environment.NewLine, split.Take(lines)) + ".....";
        }
    }
}
