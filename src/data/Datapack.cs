using Datapackager.src.resources.item;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datapackager.src.data
{
    internal class Datapack
    {
        private const int CURRENT_DATAPACK_VERSION = 10; /* Updated for version 1.19 */
        private const string DEFAULT_MCMETA = "{'pack':{'pack_format':%PACK_FORMAT%,'description':'%PACK_DESCRIPTION%'}}";


        private string directory;
        private string name;
        private Dictionary<string, dynamic> packMCMETA;

        private List<BaseItem> items;
        private List<PackFile> packFiles;

        public Datapack(string exportPath, string name, string desc) : this(exportPath, name, desc, CURRENT_DATAPACK_VERSION) { }

        public Datapack(string exportPath, string name, string desc, int version)
        {
            this.directory = exportPath;
            this.name = name;
            this.items = new List<BaseItem>();
            this.packFiles = new List<PackFile>();
            this.packMCMETA = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(DEFAULT_MCMETA.Replace("%PACK_FORMAT%", version.ToString()).Replace("%PACK_DESCRIPTION%", desc));
        }

        public void exportPack()
        {
            if (Directory.Exists(directory)) { Directory.Delete(directory, true); }
            Directory.CreateDirectory(directory);

            createFile(directory, "pack.mcmeta", JsonConvert.SerializeObject(packMCMETA));
            Directory.CreateDirectory(directory + "\\data");

            foreach(BaseItem item in items)
            {
                createFile(directory + "\\data\\" + name + "\\functions\\give", item.getInternalName() + ".mcfunction", item.giveFunction().getCommandsString());
            }

            foreach(PackFile packFile in packFiles)
            {
                createFile(directory + "\\data\\" + Path.GetDirectoryName(packFile.getPath()), Path.GetFileName(packFile.getPath()), packFile.getContents());
            }
        }

        public bool createFile(string location, string name, string contents)
        {
            try
            {
                if (!Directory.Exists(location)) { Directory.CreateDirectory(location); }

                using (FileStream fs = File.Create(location + "\\" + name))
                {
                    StreamWriter writer = new StreamWriter(fs);
                    writer.Write(contents);
                    writer.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Dictionary<string, dynamic> getPackMCMETA()
        {
            return packMCMETA;
        }

        public void addItem(BaseItem item)
        {
            items.Add(item);
        }

        public void addPackFile(PackFile file)
        {
            packFiles.Add(file);
        }
    }
}
