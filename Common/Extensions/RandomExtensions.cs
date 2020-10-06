using System;
using System.Linq;

namespace Common.Extensions {
    public static class RandomExtensions {
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string RandomString(this Random random, int leng) {
            return new string(Enumerable.Repeat(_chars, leng)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
