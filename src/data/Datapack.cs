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

        private List<Function> functions;

        public Datapack(string exportPath, string name, string desc) : this(exportPath, name, desc, CURRENT_DATAPACK_VERSION) { }

        public Datapack(string exportPath, string name, string desc, int version)
        {
            this.directory = exportPath;
            this.name = name;
            this.items = new List<BaseItem>();
            this.packFiles = new List<PackFile>();
            this.functions = new List<Function>();
            this.packMCMETA = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(DEFAULT_MCMETA.Replace("%PACK_FORMAT%", version.ToString()).Replace("%PACK_DESCRIPTION%", desc));
        }

        public void exportPack()
        {
            if (Directory.Exists(directory)) { Directory.Delete(directory, true); }
            Directory.CreateDirectory(directory);

            createFile(directory + "\\pack.mcmeta", JsonConvert.SerializeObject(packMCMETA));
            Directory.CreateDirectory(directory + "\\data");

            // Create load and tick function, as well as the functon tags to set them up to work properly
            Function load = new Function("z\\load", name);
            Function tick = new Function("z\\tick", name);

            Dictionary<string, dynamic> loadTag = new Dictionary<string, dynamic>() { { "values", new List<string>() { load.getFunctionPath() } } };
            Dictionary<string, dynamic> tickTag = new Dictionary<string, dynamic>() { { "values", new List<string>() { tick.getFunctionPath() } } };

            functions.Add(load);
            functions.Add(tick);

            Function convertTo = new Function("z\\process_convert_to", name);
            functions.Add(convertTo);

            foreach(BaseItem item in items)
            {
                Function giveFunction = new Function("give\\" + item.getName(), name, item.giveCommand());
                createFile(directory + "\\data\\" + giveFunction.getFilePath(), giveFunction.getCommandsString());

                // Handle ConvertTo convenience NBT tag
                convertTo.addCommand("execute if entity @s[nbt={Item:{tag:{ConvertTo:\"" + item.getInternalName() + "\"}}}] run data merge entity @s {Item:{id:\"minecraft:" + item.getBaseItem() + "\",tag:" + item.getNbtString() +"}}");
            }
            tick.addCommand("execute as @e[type=item] if data entity @s Item.tag.ConvertTo run function " + convertTo.getFunctionPath());

            foreach(PackFile packFile in packFiles)
            {
                createFile(directory + "\\data\\" + packFile.getPath(), packFile.getContents());
            }

            // Process adding functions into datapack
            foreach(Function function in functions)
            {
                if (function.getCommands().Any())
                {
                    createFile(directory + "\\data\\" + function.getFilePath(), function.getCommandsString());
                }
            }

            // Create load.mcfunction file if any commands are in the function, as well as assigning it the proper tag.
            if (load.getCommands().Any())
            {
                createFile(directory + "\\data\\minecraft\\tags\\functions\\load.json", JsonConvert.SerializeObject(loadTag));
            }

            // Create tick.mcfunction file if any commands are in the function, as well as assigning it the proper tag.
            if (tick.getCommands().Any())
            {
                createFile(directory + "\\data\\minecraft\\tags\\functions\\tick.json", JsonConvert.SerializeObject(tickTag));
            }

        }

        public bool createFile(string path, string contents)
        {
            try
            {
                string location = Path.GetDirectoryName(path);
                if (!Directory.Exists(location)) { Directory.CreateDirectory(location); }

                using (FileStream fs = File.Create(path))
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
