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
        private int selectedFileIndex = -1;

        public EditorView()
        {
            InitializeComponent();
            pack = new ProjectPack();

            // Start on Items since blocks don't have a use rn
            tabWindow.SelectedIndex = 1;
            windowControl.SelectedIndex = 1;

            windowControl.Visible = false;
        }

        private void tabWindow_Selecting(object sender, EventArgs e)
        {
            windowControl.SelectedIndex = tabWindow.SelectedIndex;

            switch(tabWindow.SelectedIndex)
            {
                case 0:
                    //refreshBlockList();
                    //verifyWindowVisibility(selectedBlockIndex);
                    break;
                case 1:
                    refreshItemList();
                    verifyWindowVisibility(selectedItemIndex);
                    break;
                case 2:
                    refreshFileList();
                    verifyWindowVisibility(selectedFileIndex);
                    break;
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

            itemList.SelectedIndex = itemList.Items.Count - 1;
        }

        private void removeItemButton_Click(object sender, EventArgs e)
        {
            pack.removeItem(itemList.SelectedIndex);

            refreshItemList();

            int newIndex = Math.Min(selectedItemIndex, itemList.Items.Count - 1);
            selectedItemIndex = -1;
            itemList.SelectedIndex = newIndex;

            verifyWindowVisibility(selectedItemIndex);
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
            
            verifyWindowVisibility(selectedItemIndex);
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
            verifyWindowVisibility(selectedItemIndex);
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

                Bitmap itemImage = new Bitmap(Image.FromFile(filePath));
                Bitmap result = new Bitmap(itemTextureDisplay.Size.Width, itemTextureDisplay.Size.Height);
                using (Graphics g = Graphics.FromImage(result))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    g.DrawImage(itemImage, 0, 0, itemTextureDisplay.Size.Width, itemTextureDisplay.Size.Height);
                }
                itemTextureDisplay.Image = result;

                itemTextureDisplay.Tag = filePath;
            }
            catch(Exception e)
            {
                Bitmap itemImage = new Bitmap(Resources.default_item);
                Bitmap result = new Bitmap(itemTextureDisplay.Size.Width, itemTextureDisplay.Size.Height);
                using (Graphics g = Graphics.FromImage(result))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    g.DrawImage(itemImage, 0, 0, itemTextureDisplay.Size.Width, itemTextureDisplay.Size.Height);
                }
                itemTextureDisplay.Image = result;

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
            // TODO: save blocks
            saveItem();
            saveFile();
            pack.saveProject(saveProjectDialog.OpenFile());
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            loadProjectDialog.ShowDialog();
            pack.loadProject(loadProjectDialog.OpenFile());
            refreshItemList();
            refreshFileList();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            saveItem();
            saveFile();
            exportProjectDialog.ShowDialog();
            pack.exportProject(exportProjectDialog.SelectedPath);
        }

        private void exportProjectDialog_HelpRequest(object sender, EventArgs e)
        {

        }

        private void fileList_SelectedItemChange(object sender, EventArgs e)
        {
            saveFile();

            selectedFileIndex = fileList.SelectedIndex;
            if(selectedFileIndex >= 0)
            {
                Dictionary<string, dynamic> selectedFile = pack.getFileRegistry()[selectedFileIndex];
                fileNamespace.Text = selectedFile["namespace"];
                filePath.Text = selectedFile["path"];
                if (selectedFile["datapack"]) { filePackDatapack.Checked = true; }
                else { filePackResource.Checked = true; }
                fileContents.Text = selectedFile["contents"];
            }

            verifyWindowVisibility(selectedFileIndex);
        }

        private void addFileButton_Click(object sender, EventArgs e)
        {
            pack.addNewFile();
            selectedFileIndex = -1;

            refreshFileList();

            fileList.SelectedIndex = fileList.Items.Count - 1;
        }

        private void removeFileButton_Click(object sender, EventArgs e)
        {
            pack.removeFile(fileList.SelectedIndex);

            refreshFileList();

            int newIndex = Math.Min(selectedFileIndex, fileList.Items.Count - 1);
            selectedFileIndex = -1;
            fileList.SelectedIndex = newIndex;
            selectedFileIndex = fileList.SelectedIndex;

            verifyWindowVisibility(selectedFileIndex);
        }

        private void updateFileName_LeaveControlFocus(object sender, EventArgs e)
        {
            saveFile();
            refreshFileList();
        }

        private void saveFile()
        {
            if (selectedFileIndex >= 0)
            {
                Dictionary<string, dynamic> selectedFile = pack.getFileRegistry()[selectedFileIndex];
                selectedFile["namespace"] = fileNamespace.Text;
                selectedFile["path"] = filePath.Text;
                selectedFile["contents"] = fileContents.Text;
                selectedFile["datapack"] = filePackDatapack.Checked;
            }
        }

        private void refreshFileList()
        {
            fileList.Items.Clear();
            foreach(Dictionary<string, dynamic> file in pack.getFileRegistry())
            {
                fileList.Items.Add("(" + file["namespace"] + ") " + Path.GetFileName(file["path"]));
            }
            verifyWindowVisibility(selectedFileIndex);
        }

        private void verifyWindowVisibility(int selectedIndex)
        {
            windowControl.Visible = selectedIndex >= 0;
        }
    }
}
