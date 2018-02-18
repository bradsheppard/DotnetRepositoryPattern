using System;
using System.Linq;

namespace IntegrationTests.FakeGenerators {
    
    public static class RandomizationHelper {
        
        private const int Length = 10;
        private const int MaxInt = 1000;
        
        public static string GenerateString() {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, Length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int GenerateInt() {
            Random random = new Random();
            return random.Next(MaxInt);
        }
    }
}