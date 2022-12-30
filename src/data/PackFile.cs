using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datapackager.src.data
{
    internal class PackFile
    {
        private string path;
        private string contents;

        public PackFile(string path, string contents)
        {
            this.path = path;
            this.contents = contents;
        }

        public string getPath()
        {
            return path;
        }

        public string getContents()
        {
            return contents;
        }
    }
}
