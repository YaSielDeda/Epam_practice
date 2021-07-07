using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FileStorage.Entitiess
{
    public class SearchResult
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public SearchResult (string name, string type, string path)
        {
            Name = name;
            Type = type;
            Path = path;
        }
    }
}
