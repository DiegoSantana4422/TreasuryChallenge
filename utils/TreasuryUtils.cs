using System;
using System.Collections.Generic;
using System.Linq;

namespace TreasuryChallenge.utils
{
    public static class TreasuryUtils
    {
        public static List<T> RemoveDuplicates<T>(List<T> list)
        {
            return new HashSet<T>(list).ToList();
        }

        public static string GenerateCode()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var generatedCode = new string(chars.OrderBy(x => random.Next()).Distinct().Take(7).ToArray());
            return generatedCode;
        }
    }
}