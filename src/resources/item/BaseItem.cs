using Datapackager.src.data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datapackager.src.resources.item
{
    internal class BaseItem
    {
        protected string name;
        protected string internalName;
        protected string texture;
        protected string textureSourcePath;
        protected NameDisplay display;
        protected Dictionary<string, dynamic> nbt;
        protected string baseItem;
        protected string baseModel;
        protected int modelID;

        public BaseItem(string name, string textureSourcePath, string baseItem, int modelID, Dictionary<string, dynamic> nbt, string baseModel)
        {
            this.name = name.ToLower().Replace(" ", "_");
            this.internalName = name.ToLower().Replace(" ", "_");
            this.display = new NameDisplay(name);
            this.baseItem = baseItem;
            this.modelID = modelID;
            this.textureSourcePath = textureSourcePath;
            this.texture = Path.GetFileNameWithoutExtension(textureSourcePath);
            this.baseModel = baseModel;

            this.nbt = nbt;
            this.nbt["CustomModelData"] = modelID;
        }

        public BaseItem(string name, string texturePath, string baseItem, int modelID, Dictionary<string, dynamic> nbt) : this(name, texturePath, baseItem, modelID, nbt, baseItem + ".json") { }

        public BaseItem(string name, string texturePath, string baseItem, int modelID) : this(name, texturePath, baseItem, modelID, new Dictionary<string, dynamic>(), baseItem + ".json") { }

        public string giveCommand()
        {
            
            return "give @s " + baseItem + getNbtString();
        }

        public void mergeNewNbt(Dictionary<string, dynamic> newNbt)
        {
            foreach(string key in newNbt.Keys)
            {
                nbt[key] = newNbt[key];
            }
        }

        public string getName()
        {
            return name;
        }

        public string getInternalName()
        {
            return internalName;
        }

        public string getTexture()
        {
            return texture;
        }

        public string getTextureSourcePath()
        {
            return textureSourcePath;
        }

        public NameDisplay getDisplay()
        {
            return display;
        }

        public string getNbtString()
        {
            Dictionary<string, dynamic> mergedNBT = this.nbt.ToDictionary(entry => entry.Key, entry => entry.Value);
            mergedNBT["display"] = new Dictionary<string, dynamic>() { { "Name", "%NAME_JSON%" }, { "Lore", "%LORE_JSON%" } };

            StringBuilder sb = new StringBuilder();
            JsonSerializer serializer = new JsonSerializer();
            using (StringWriter sw = new StringWriter(sb))
            using (JsonTextWriter writer = new JsonTextWriter(sw))
            {
                writer.QuoteName = false;
                serializer.Serialize(writer, mergedNBT);
            }

            return sb.ToString().Replace("\"%NAME_JSON%\"", display.getNameJsonString()).Replace("\"%LORE_JSON%\"", display.getLoreJsonString());
        }

        public string getModelJson(string texture)
        {
            Dictionary<string, dynamic> model = new Dictionary<string, dynamic>()
            {
                { "parent", "item/generated" },
                { "textures", new Dictionary<string, dynamic>(){ { "layer0", "minecraft:item/" + texture } } }
            };
            return JsonConvert.SerializeObject(model);
        }
        public string getBaseItem()
        {
            return baseItem;
        }

        public string getBaseModel()
        {
            return baseModel;
        }

        public int getModeID()
        {
            return modelID;
        }
    }
}
