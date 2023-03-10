using Datapackager.src.resources.item;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datapackager.src.data
{
    internal class ProjectPack
    {
        private string projectName;

        private List<Dictionary<string, dynamic>> itemRegistry;
        private List<Dictionary<string, dynamic>> fileRegistry;
        
        public ProjectPack()
        {
            itemRegistry = new List<Dictionary<string, dynamic>>();
            fileRegistry = new List<Dictionary<string, dynamic>>();
        }

        public bool exportProject(string exportPath)
        {

            ResourcePack rp = new ResourcePack(exportPath + "\\" + projectName + "[RP]");
            Datapack dp = new Datapack(exportPath + "\\" + projectName + "[DP]", projectName, "");

            foreach (Dictionary<string, dynamic> itemRegister in itemRegistry)
            {
                BaseItem item;

                switch (itemRegister["type"])
                {
                    /*case 1:
                        item = new ComplexItem();
                        break;
                    case 2:
                        item = new FoodItem();
                        break;*/
                    default:
                        item = new SimpleItem(itemRegister["name"], itemRegister["texture"], rp.getNextModelID());
                        if (!string.IsNullOrEmpty(itemRegister["nbt"]))
                        {
                            item.mergeNewNbt(JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(itemRegister["nbt"]));
                        }
                        if (!string.IsNullOrEmpty(itemRegister["lore"]))
                        {
                            item.getDisplay().setLoreHelper(itemRegister["lore"], 16);
                        }
                        break;
                }

                dp.addItem(item);
                rp.addItem(item);
            }

            foreach (Dictionary<string, dynamic> fileRegister in fileRegistry)
            {
                PackFile packFile = new PackFile(fileRegister["namespace"] + "\\" + fileRegister["path"], fileRegister["contents"]);

                if (fileRegister["datapack"])
                {
                    dp.addPackFile(packFile);
                }
                else
                {
                    rp.addPackFile(packFile);
                }
            }

            rp.exportPack();
            dp.exportPack();
            return true;
        }

        public List<Dictionary<string, dynamic>> getItemRegistry() { return itemRegistry; }

        public List<Dictionary<string, dynamic>> getFileRegistry() { return fileRegistry; }

        public void addNewItem()
        {
            Dictionary<string, dynamic> newItem = new Dictionary<string, dynamic>()
            {
                { "name", "Unnamed Item" },
                { "lore", "" },
                { "type", 0 },
                { "texture", null },
                { "nbt", "" }
            };
            itemRegistry.Add(newItem);
        }

        public void removeItem(int index) 
        {
            itemRegistry.RemoveAt(index);
        }

        public void addNewFile()
        {
            Dictionary<string, dynamic> newFile = new Dictionary<string, dynamic>()
            {
                { "datapack", true },
                { "namespace", "minecraft" },
                { "path", "new_file.txt" },
                { "contents", "" }
            };
            fileRegistry.Add(newFile);
        }

        public void removeFile(int index)
        {
            fileRegistry.RemoveAt(index);
        }

        public void setName(string name)
        {
            projectName = name;
        }

        public bool saveProject(Stream file)
        {
            try
            {
                StreamWriter writer = new StreamWriter(file);

                Dictionary<string, dynamic> jsonDict = new Dictionary<string, dynamic>()
                {
                    { "items", itemRegistry },
                    { "files", fileRegistry }
                };

                writer.Write(JsonConvert.SerializeObject(jsonDict));

                writer.Close();
                return true;
            }
            catch(Exception e) 
            {
                return false;
            }
        }

        public bool loadProject(Stream file)
        {
            try
            {
                StreamReader reader = new StreamReader(file);
                string projectJson = reader.ReadToEnd();

                Dictionary<string, dynamic> jsonDict = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(projectJson);
                itemRegistry.Clear();
                foreach(JObject entry in jsonDict["items"])
                {
                    itemRegistry.Add(entry.ToObject<Dictionary<string, dynamic>>());
                    foreach(string key in itemRegistry.Last().Keys)
                    {
                        if (itemRegistry.Last()[key] is Int64)
                        {
                            itemRegistry.Last()[key] = Convert.ToInt32(itemRegistry.Last()[key]);
                        }
                    }
                }

                fileRegistry.Clear();
                foreach(JObject entry in jsonDict["files"])
                {
                    fileRegistry.Add(entry.ToObject<Dictionary<string, dynamic>>());
                    foreach (string key in fileRegistry.Last().Keys)
                    {
                        if (fileRegistry.Last()[key] is Int64)
                        {
                            fileRegistry.Last()[key] = Convert.ToInt32(fileRegistry.Last()[key]);
                        }
                    }
                }

                reader.Close();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
