using Datapackager.Properties;
using Datapackager.src.resources.item;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Datapackager.src.data
{
    internal class ResourcePack
    {
        private const int CURRENT_RESOURCE_PACK_VERSION = 12; /* Updated for version 1.19 */
        private const string DEFAULT_MCMETA = "{'pack':{'pack_format':%PACK_FORMAT%,'description':'%PACK_DESCRIPTION%'}}";

        private string directory;

        private int nextModelID;
        private Dictionary<string, List<BaseItem>> items;

        private List<PackFile> packFiles;

        private Dictionary<string, dynamic> packMCMETA;

        public ResourcePack(string exportPath, string desc, int initialModelID, int version)
        {
            this.directory = exportPath;
            this.nextModelID = initialModelID - 1;
            this.items = new Dictionary<string, List<BaseItem>>();
            this.packFiles = new List<PackFile>();

            this.packMCMETA = this.packMCMETA = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(DEFAULT_MCMETA.Replace("%PACK_FORMAT%", version.ToString()).Replace("%PACK_DESCRIPTION%", desc));
        }

        public ResourcePack(string exportPath) : this(exportPath, "", 1000, CURRENT_RESOURCE_PACK_VERSION) { }
        public ResourcePack(string exportPath, string description) : this(exportPath, description, 1000, CURRENT_RESOURCE_PACK_VERSION) { }
        public ResourcePack(string exportPath, string description, int initialModelID) : this(exportPath, description, initialModelID, CURRENT_RESOURCE_PACK_VERSION) { }

        public void exportPack()
        {
            if (Directory.Exists(directory)) { Directory.Delete(directory, true); }
            Directory.CreateDirectory(directory);

            createFile(directory, "pack.mcmeta", JsonConvert.SerializeObject(packMCMETA));
            Directory.CreateDirectory(directory + "\\assets");

            foreach (string baseModel in items.Keys)
            {
                List<Dictionary<string, dynamic>> overrides = new List<Dictionary<string, dynamic>>();
                if (!Directory.Exists(directory + "\\assets\\minecraft\\textures\\item")) { Directory.CreateDirectory(directory + "\\assets\\minecraft\\textures\\item"); }
                foreach (BaseItem item in items[baseModel])
                {
                    // Copy texture of item into resource pack, using default item texture if none specified
                    string texture = item.getTexture();
                    if (string.IsNullOrEmpty(texture))
                    {
                        texture = "default_item";
                        if(!File.Exists(directory + "\\assets\\minecraft\\textures\\item\\default_item.png"))
                        {
                            Image textureImage = Resources.default_item;
                            textureImage.Save(directory + "\\assets\\minecraft\\textures\\item\\default_item.png", ImageFormat.Png);

                            // Create item model for default texture
                            createFile(directory + "\\assets\\minecraft\\models\\item", texture + ".json", createItemModel(texture));
                        }
                    }
                    else
                    {
                        File.Copy(item.getTextureSourcePath(), directory + "\\assets\\minecraft\\textures\\item\\" + item.getTexture() + ".png");

                        // Create item model
                        createFile(directory + "\\assets\\minecraft\\models\\item", texture + ".json", createItemModel(texture));
                    }

                    // Add item override to base model overrides JSON
                    Dictionary<string, dynamic> itemOverride = new Dictionary<string, dynamic>()
                    {
                        { "predicate", new Dictionary<string, dynamic>(){ { "custom_model_data", item.getModeID() } } },
                        { "model", "item/" + texture }
                    };
                    overrides.Add(itemOverride);

                }

                Dictionary<string, dynamic> baseModelItem = getBaseModel("item", baseModel);
                baseModelItem["overrides"] = overrides;

                createFile(directory + "\\assets\\minecraft\\models\\item", baseModel, JsonConvert.SerializeObject(baseModelItem));
            }

            foreach (PackFile packFile in packFiles)
            {
                createFile(directory + "\\assets\\" + Path.GetDirectoryName(packFile.getPath()), Path.GetFileName(packFile.getPath()), packFile.getContents());
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
        public void addItem(BaseItem item)
        {
            // Add item to model override list for item's base model if list exists, create model override list containing item if not.
            if (items.ContainsKey(item.getBaseModel())) { items[item.getBaseModel()].Add(item); }
            else { items[item.getBaseModel()] = new List<BaseItem>() { item }; }
        }

        public void test()
        {
            Dictionary<string, dynamic> d = getBaseModel("block", "command_block.json");
            foreach (var item in d.Keys) { Debug.WriteLine(item); }
        }

        public string createItemModel(string texture)
        {
            Dictionary<string, dynamic> model = new Dictionary<string, dynamic>()
            {
                { "parent", "item/generated" },
                { "textures", new Dictionary<string, dynamic>(){ { "layer0", "minecraft:item/" + texture } } }
            };
            return JsonConvert.SerializeObject(model);
        }

        public int getNextModelID()
        {
            nextModelID++;
            return nextModelID;
        }

        private Dictionary<string, dynamic> getBaseModel(string type, string fileName)
        {
            string result = "<ERROR>";
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Datapackager.resources.models." + type + "." + fileName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(result);
        }

        public void addPackFile(PackFile file)
        {
            packFiles.Add(file);
        }
    }
}
