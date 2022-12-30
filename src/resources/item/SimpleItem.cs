using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datapackager.src.resources.item
{
    internal class SimpleItem : BaseItem
    {

        public SimpleItem(string name, string texturePath, int modelID, Dictionary<string, dynamic> nbt)
            : base(name, texturePath, "command_block", modelID, nbt)
        {

        }

        public SimpleItem(string name, string texturePath, int modelID)
            : base(name, texturePath, "command_block", modelID)
        {

        }
    }
}
