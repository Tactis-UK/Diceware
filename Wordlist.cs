using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Diceware
{
    public static class Wordlist
    {
        private static readonly Lazy<Dictionary<string,string>> _words = new(() => {
            var asm = Assembly.GetExecutingAssembly();
            var res = asm.GetManifestResourceNames().FirstOrDefault(n => n.EndsWith("eff_large_wordlist.txt", StringComparison.OrdinalIgnoreCase))
                      ?? throw new InvalidOperationException("Embedded eff_large_wordlist.txt not found.");
            using var s = asm.GetManifestResourceStream(res)!;
            using var r = new StreamReader(s);
            var dict = new Dictionary<string,string>(7776, StringComparer.Ordinal);
            foreach (var line in r.ReadLines())
            {
                if (string.IsNullOrWhiteSpace(line) || line[0] == '#') continue;
                var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2) dict[parts[0]] = parts[1];
            }
            return dict;
        });

        public static bool TryGet(string key, out string? word) => _words.Value.TryGetValue(key, out word);
        public static string Get(string key) => _words.Value[key];
        public static IReadOnlyDictionary<string,string> All => _words.Value;
    }

    static class StreamReaderExt
    {
        public static IEnumerable<string> ReadLines(this StreamReader reader)
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
                yield return line;
        }
    }
}