using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datapackager.src.data
{
    internal class TextComponent
    {
        private string text;
        private string color;

        /* Bitwise Format - ABCDE
         *  A - Bold
         *  B - Italics
         *  C - Underlined
         *  D - Strikethrough
         *  E - Obfuscated
         */
        private int formatting;

        public TextComponent(string text, string color, int formatting)
        {
            this.text = text;
            this.color = color;
            this.formatting = formatting;
        }

        public TextComponent(string text) : this(text, "white", 0) { }
        public TextComponent(string text, string color) : this(text, color, 0) { }
        public TextComponent(string text, int formatting) : this(text, "white", formatting) { }

        public Dictionary<string, dynamic> getNBT()
        {
            return new Dictionary<string, dynamic>() { 
                { "text", this.text },
                { "color", this.color },
                { "bold", getBold() },
                { "italic", getItalics() }, 
                { "underlined", getUnderlined() },
                { "obfuscated", getObfuscated() }
            };
        }

        public bool getBold() { return (formatting & 0b10000) > 0; }
        public bool getItalics() { return (formatting & 0b01000) > 0; }
        public bool getUnderlined() { return (formatting & 0b00100) > 0; }
        public bool getStrikethrough() { return (formatting & 0b00010) > 0; }
        public bool getObfuscated() { return (formatting & 0b00001) > 0; }
        public void setBold(bool value) { formatting = setBit(formatting, 4, value); }
        public void setItalics(bool value) { formatting = setBit(formatting, 3, value); }
        public void setUnderline(bool value) { formatting = setBit(formatting, 2, value); }
        public void setStrikethrough(bool value) { formatting = setBit(formatting, 1, value); }
        public void setObfuscated(bool value) { formatting = setBit(formatting, 0, value); }

        private int setBit(int value, int index, bool bit)
        {
            return value & ~(1 << index) | (Convert.ToByte(bit) << index);
        }
    }
}
