using System;
using System.Collections.Generic;
using System.Text;

namespace OpenConstructionSet.IO
{
    public class DiscoveredFolders
    {
        public DiscoveredFolders(string mod, string data, string? content)
        {
            Mod = mod;
            Data = data;
            Content = content;
        }

        public string Mod { get; set; }

        public string Data { get; set; }

        public string? Content { get; set; }

        public string[] ToArray()
        {
            var list = new List<string>();

            list.Add(Data);

            list.Add(Mod);

            if (Content is not null)
            {
                list.Add(Content);
            }

            return list.ToArray();
        }
    }
}
