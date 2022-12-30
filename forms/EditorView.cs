using Datapackager.src.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using Datapackager.src.resources.item;
using Datapackager.Properties;

namespace Datapackager.forms
{
    public partial class EditorView : Form
    {
        private ProjectPack pack;

        private int selectedItemIndex = -1;

        public EditorView()
        {
            InitializeComponent();
            pack = new ProjectPack();
        }

        private void tabWindow_Selecting(object sender, EventArgs e)
        {
            windowControl.SelectedIndex = tabWindow.SelectedIndex;

            if(tabWindow.SelectedIndex == 1) /* Items Tab */
            {
                refreshItemList();
            }
        }

        private void itemType_CheckedChanged(object sender, EventArgs e)
        {
            saveItem();
            if(((RadioButton)sender).Checked)
            {
                itemWindow.SelectedIndex = Int32.Parse((string)((RadioButton)sender).Tag);
            }
        }

        private void itemEditor_LeaveControlFocus(object sender, EventArgs e)
        {
            saveItem();
            refreshItemList();
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            pack.addNewItem();
            refreshItemList();
        }

        private void removeItemButton_Click(object sender, EventArgs e)
        {
            pack.removeItem(itemList.SelectedIndex);
            selectedItemIndex = -1;
            refreshItemList();
            clearItemEditor();
        }

        private void itemList_SelectedIndexChange(object sender, EventArgs e)
        {
            // Store current values in last selected item
            saveItem();

            // Populate control values from newly selected item
            selectedItemIndex = itemList.SelectedIndex;
            if (selectedItemIndex >= 0)
            {
                Dictionary<string, dynamic> selectedItem = pack.getItemRegistry()[selectedItemIndex];
                itemName.Text = selectedItem["name"];
                itemLore.Text = selectedItem["lore"];
                itemSimple.Checked = selectedItem["type"] == 0;
                itemComplex.Checked = selectedItem["type"] == 1;
                itemFood.Checked = selectedItem["type"] == 2;
                itemWindow.SelectedIndex = selectedItem["type"];
                itemTextureSet(selectedItem["texture"]);

                switch(selectedItem["type"])
                {
                    case 0:
                        simpleItemNbt.Text = selectedItem["nbt"];
                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                }
            }
        }

        private void itemTexture_Click(object senter, EventArgs e)
        {
            openItemTexture.ShowDialog();
        }

        private void refreshItemList()
        {
            itemList.Items.Clear();
            foreach(Dictionary<string, dynamic> item in pack.getItemRegistry())
            {
                itemList.Items.Add(item["name"]);
            }
        }

        private void clearItemEditor()
        {
            itemName.Text = "";
            itemLore.Text = "";
            itemSimple.Checked = true;
            simpleItemNbt.Text = "";
            itemTextureDisplay.Image = null;
        }

        private void saveItem()
        {
            if (selectedItemIndex >= 0)
            {
                Dictionary<string, dynamic> selectedItem = pack.getItemRegistry()[selectedItemIndex];
                selectedItem["name"] = itemName.Text;
                selectedItem["lore"] = itemLore.Text;
                selectedItem["type"] = itemWindow.SelectedIndex;
                selectedItem["texture"] = itemTextureDisplay.Tag;
                switch(selectedItem["type"])
                {
                    case 0:
                        selectedItem["nbt"] = simpleItemNbt.Text;
                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                }
            }
        }

        private void itemTextureSet(string filePath)
        {
            if (itemTextureDisplay.Image is not null) { itemTextureDisplay.Image.Dispose(); }
            try
            {
                if(filePath is null) { throw new Exception(); }
                itemTextureDisplay.Image = Image.FromFile(filePath);
                itemTextureDisplay.Tag = filePath;
            }
            catch(Exception e)
            {
                itemTextureDisplay.Image = Resources.default_item;
                itemTextureDisplay.Tag = null;
            }
        }

        private void openItemTexture_FileOk(object sender, CancelEventArgs e)
        {
            itemTextureSet(openItemTexture.FileName);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveProjectDialog.ShowDialog();
            //TODO: handle cancel
            // TODO: save block
            // TODO: save files
            saveItem();
            pack.saveProject(saveProjectDialog.OpenFile());
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            loadProjectDialog.ShowDialog();
            pack.loadProject(loadProjectDialog.OpenFile());
            refreshItemList();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            saveItem();
            exportProjectDialog.ShowDialog();
            pack.exportProject(exportProjectDialog.SelectedPath);
        }

        private void exportProjectDialog_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
