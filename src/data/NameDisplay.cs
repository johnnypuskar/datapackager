using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datapackager.src.data
{
    internal class NameDisplay
    {
        private List<TextComponent> name;
        private List<List<TextComponent>> lore;

        public NameDisplay(string name)
        {
            this.name = new List<TextComponent>() { new TextComponent(name) };
            this.lore = new List<List<TextComponent>>();
        }

        public void setName(string name)
        {
            this.name.Clear();
            this.name.Add(new TextComponent(name));
        }

        public void setLore(List<string> lines)
        {
            this.lore.Clear();
            foreach(string line in lines)
            {
                this.lore.Add(new List<TextComponent>() { new TextComponent(line, "gray") });
            }
        }

        public void setLoreHelper(string lore, int characterLimit)
        {
            List<string> lines = new List<string>();
            List<string> currentLine = new List<string>();
            int lineLength = -1;
            foreach(string word in lore.Split(" "))
            {
                if(!string.IsNullOrEmpty(word))
                {
                    currentLine.Add(word);
                    lineLength += 1 + word.Length;
                    if (lineLength >= characterLimit)
                    {
                        lines.Add(String.Join(" ", currentLine));
                        currentLine.Clear();
                        lineLength = -1;
                    }
                }
            }
            if(currentLine.Any())
            {
                lines.Add(String.Join(" ", currentLine));
            }
            setLore(lines);
        }

        public void addComponentToName(TextComponent textComponent)
        {
            this.name.Add(textComponent);
        }

        public void addComponentToLore(TextComponent textComponent, bool newLine)
        {
            if(newLine || this.lore.Count <= 0)
            {
                this.lore.Add(new List<TextComponent>());
            }
            this.lore.Last().Add(textComponent);
        }

        public string getNameJsonString()
        {
            List<string> nameJson = new List<string>();
            foreach (TextComponent textComponent in this.name) { nameJson.Add(JsonConvert.SerializeObject(textComponent.getNBT())); }
            return "'[" + String.Join(",", nameJson) + "]'";
        }

        public string getLoreJsonString()
        {
            string toReturn = "";
            List<string> loreJson = new List<string>();
            foreach (List<TextComponent> line in this.lore)
            {
                List<string> lineJson = new List<string>();
                line.ForEach(textComponent => lineJson.Add(JsonConvert.SerializeObject(textComponent.getNBT())));
                loreJson.Add("'[" + String.Join(",", lineJson) + "]'");
            }
            return "[" + String.Join(",", loreJson) + "]";
        }
    }
}
