namespace Datapackager.forms
{
    partial class EditorView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabWindow = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.itemList = new System.Windows.Forms.ListBox();
            this.addItemButton = new System.Windows.Forms.Button();
            this.removeItemButton = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.blockTextureDisplay = new System.Windows.Forms.PictureBox();
            this.windowControl = new System.Windows.Forms.TabControl();
            this.blocksPage = new System.Windows.Forms.TabPage();
            this.itemsPage = new System.Windows.Forms.TabPage();
            this.itemWindow = new System.Windows.Forms.TabControl();
            this.itemSimpleWindow = new System.Windows.Forms.TabPage();
            this.simpleItemNbt = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.itemComplexWindow = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.itemFoodWindow = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.itemFood = new System.Windows.Forms.RadioButton();
            this.itemSimple = new System.Windows.Forms.RadioButton();
            this.itemComplex = new System.Windows.Forms.RadioButton();
            this.itemLore = new System.Windows.Forms.RichTextBox();
            this.itemName = new System.Windows.Forms.TextBox();
            this.itemTextureDisplay = new System.Windows.Forms.PictureBox();
            this.filesPage = new System.Windows.Forms.TabPage();
            this.openItemTexture = new System.Windows.Forms.OpenFileDialog();
            this.saveProjectDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.loadProjectDialog = new System.Windows.Forms.OpenFileDialog();
            this.exportButton = new System.Windows.Forms.Button();
            this.exportProjectDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tabWindow.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blockTextureDisplay)).BeginInit();
            this.windowControl.SuspendLayout();
            this.blocksPage.SuspendLayout();
            this.itemsPage.SuspendLayout();
            this.itemWindow.SuspendLayout();
            this.itemSimpleWindow.SuspendLayout();
            this.itemComplexWindow.SuspendLayout();
            this.itemFoodWindow.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemTextureDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // tabWindow
            // 
            this.tabWindow.Controls.Add(this.tabPage1);
            this.tabWindow.Controls.Add(this.tabPage2);
            this.tabWindow.Controls.Add(this.tabPage3);
            this.tabWindow.Location = new System.Drawing.Point(10, 10);
            this.tabWindow.Name = "tabWindow";
            this.tabWindow.SelectedIndex = 0;
            this.tabWindow.Size = new System.Drawing.Size(400, 985);
            this.tabWindow.TabIndex = 0;
            this.tabWindow.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabWindow_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(8, 46);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(384, 931);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Blocks";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.itemList);
            this.tabPage2.Controls.Add(this.addItemButton);
            this.tabPage2.Controls.Add(this.removeItemButton);
            this.tabPage2.Location = new System.Drawing.Point(8, 46);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(384, 931);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Items";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // itemList
            // 
            this.itemList.FormattingEnabled = true;
            this.itemList.ItemHeight = 32;
            this.itemList.Location = new System.Drawing.Point(6, 6);
            this.itemList.Name = "itemList";
            this.itemList.Size = new System.Drawing.Size(372, 868);
            this.itemList.TabIndex = 5;
            this.itemList.SelectedIndexChanged += new System.EventHandler(this.itemList_SelectedIndexChange);
            // 
            // addItemButton
            // 
            this.addItemButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addItemButton.Location = new System.Drawing.Point(332, 879);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(46, 46);
            this.addItemButton.TabIndex = 3;
            this.addItemButton.Text = "+";
            this.addItemButton.UseVisualStyleBackColor = true;
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
            // 
            // removeItemButton
            // 
            this.removeItemButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeItemButton.Location = new System.Drawing.Point(280, 879);
            this.removeItemButton.Name = "removeItemButton";
            this.removeItemButton.Size = new System.Drawing.Size(46, 46);
            this.removeItemButton.TabIndex = 4;
            this.removeItemButton.Text = "-";
            this.removeItemButton.UseVisualStyleBackColor = true;
            this.removeItemButton.Click += new System.EventHandler(this.removeItemButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(8, 46);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(384, 931);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Raw Files";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // blockTextureDisplay
            // 
            this.blockTextureDisplay.Location = new System.Drawing.Point(6, 6);
            this.blockTextureDisplay.Name = "blockTextureDisplay";
            this.blockTextureDisplay.Size = new System.Drawing.Size(200, 200);
            this.blockTextureDisplay.TabIndex = 1;
            this.blockTextureDisplay.TabStop = false;
            // 
            // windowControl
            // 
            this.windowControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.windowControl.Controls.Add(this.blocksPage);
            this.windowControl.Controls.Add(this.itemsPage);
            this.windowControl.Controls.Add(this.filesPage);
            this.windowControl.ItemSize = new System.Drawing.Size(0, 1);
            this.windowControl.Location = new System.Drawing.Point(416, 48);
            this.windowControl.Name = "windowControl";
            this.windowControl.SelectedIndex = 0;
            this.windowControl.Size = new System.Drawing.Size(1597, 1200);
            this.windowControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.windowControl.TabIndex = 2;
            this.windowControl.TabStop = false;
            // 
            // blocksPage
            // 
            this.blocksPage.BackColor = System.Drawing.Color.Transparent;
            this.blocksPage.Controls.Add(this.blockTextureDisplay);
            this.blocksPage.ForeColor = System.Drawing.Color.Transparent;
            this.blocksPage.Location = new System.Drawing.Point(4, 5);
            this.blocksPage.Name = "blocksPage";
            this.blocksPage.Padding = new System.Windows.Forms.Padding(3);
            this.blocksPage.Size = new System.Drawing.Size(1589, 1191);
            this.blocksPage.TabIndex = 0;
            // 
            // itemsPage
            // 
            this.itemsPage.BackColor = System.Drawing.Color.Transparent;
            this.itemsPage.Controls.Add(this.itemWindow);
            this.itemsPage.Controls.Add(this.panel1);
            this.itemsPage.Controls.Add(this.itemLore);
            this.itemsPage.Controls.Add(this.itemName);
            this.itemsPage.Controls.Add(this.itemTextureDisplay);
            this.itemsPage.ForeColor = System.Drawing.Color.Transparent;
            this.itemsPage.Location = new System.Drawing.Point(4, 5);
            this.itemsPage.Name = "itemsPage";
            this.itemsPage.Padding = new System.Windows.Forms.Padding(3);
            this.itemsPage.Size = new System.Drawing.Size(1589, 1191);
            this.itemsPage.TabIndex = 1;
            // 
            // itemWindow
            // 
            this.itemWindow.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.itemWindow.Controls.Add(this.itemSimpleWindow);
            this.itemWindow.Controls.Add(this.itemComplexWindow);
            this.itemWindow.Controls.Add(this.itemFoodWindow);
            this.itemWindow.ItemSize = new System.Drawing.Size(0, 1);
            this.itemWindow.Location = new System.Drawing.Point(9, 265);
            this.itemWindow.Name = "itemWindow";
            this.itemWindow.SelectedIndex = 0;
            this.itemWindow.Size = new System.Drawing.Size(1200, 920);
            this.itemWindow.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.itemWindow.TabIndex = 8;
            // 
            // itemSimpleWindow
            // 
            this.itemSimpleWindow.Controls.Add(this.simpleItemNbt);
            this.itemSimpleWindow.Controls.Add(this.label1);
            this.itemSimpleWindow.Location = new System.Drawing.Point(4, 5);
            this.itemSimpleWindow.Name = "itemSimpleWindow";
            this.itemSimpleWindow.Padding = new System.Windows.Forms.Padding(3);
            this.itemSimpleWindow.Size = new System.Drawing.Size(1192, 911);
            this.itemSimpleWindow.TabIndex = 0;
            this.itemSimpleWindow.UseVisualStyleBackColor = true;
            // 
            // simpleItemNbt
            // 
            this.simpleItemNbt.Location = new System.Drawing.Point(6, 38);
            this.simpleItemNbt.Multiline = false;
            this.simpleItemNbt.Name = "simpleItemNbt";
            this.simpleItemNbt.Size = new System.Drawing.Size(1180, 192);
            this.simpleItemNbt.TabIndex = 1;
            this.simpleItemNbt.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "NBT";
            // 
            // itemComplexWindow
            // 
            this.itemComplexWindow.Controls.Add(this.label2);
            this.itemComplexWindow.Location = new System.Drawing.Point(4, 5);
            this.itemComplexWindow.Name = "itemComplexWindow";
            this.itemComplexWindow.Padding = new System.Windows.Forms.Padding(3);
            this.itemComplexWindow.Size = new System.Drawing.Size(1192, 911);
            this.itemComplexWindow.TabIndex = 1;
            this.itemComplexWindow.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(311, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Complex Item";
            // 
            // itemFoodWindow
            // 
            this.itemFoodWindow.Controls.Add(this.label3);
            this.itemFoodWindow.Location = new System.Drawing.Point(4, 5);
            this.itemFoodWindow.Name = "itemFoodWindow";
            this.itemFoodWindow.Size = new System.Drawing.Size(1192, 911);
            this.itemFoodWindow.TabIndex = 2;
            this.itemFoodWindow.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(632, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "Food Item";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.itemFood);
            this.panel1.Controls.Add(this.itemSimple);
            this.panel1.Controls.Add(this.itemComplex);
            this.panel1.Location = new System.Drawing.Point(6, 212);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 47);
            this.panel1.TabIndex = 7;
            // 
            // itemFood
            // 
            this.itemFood.AutoSize = true;
            this.itemFood.ForeColor = System.Drawing.SystemColors.ControlText;
            this.itemFood.Location = new System.Drawing.Point(272, 3);
            this.itemFood.Name = "itemFood";
            this.itemFood.Size = new System.Drawing.Size(99, 36);
            this.itemFood.TabIndex = 7;
            this.itemFood.Tag = "2";
            this.itemFood.Text = "Food";
            this.itemFood.UseVisualStyleBackColor = true;
            this.itemFood.CheckedChanged += new System.EventHandler(this.itemType_CheckedChanged);
            // 
            // itemSimple
            // 
            this.itemSimple.AutoSize = true;
            this.itemSimple.Checked = true;
            this.itemSimple.ForeColor = System.Drawing.SystemColors.ControlText;
            this.itemSimple.Location = new System.Drawing.Point(3, 3);
            this.itemSimple.Name = "itemSimple";
            this.itemSimple.Size = new System.Drawing.Size(118, 36);
            this.itemSimple.TabIndex = 5;
            this.itemSimple.TabStop = true;
            this.itemSimple.Tag = "0";
            this.itemSimple.Text = "Simple";
            this.itemSimple.UseVisualStyleBackColor = true;
            this.itemSimple.CheckedChanged += new System.EventHandler(this.itemType_CheckedChanged);
            // 
            // itemComplex
            // 
            this.itemComplex.AutoSize = true;
            this.itemComplex.ForeColor = System.Drawing.SystemColors.ControlText;
            this.itemComplex.Location = new System.Drawing.Point(127, 3);
            this.itemComplex.Name = "itemComplex";
            this.itemComplex.Size = new System.Drawing.Size(139, 36);
            this.itemComplex.TabIndex = 6;
            this.itemComplex.Tag = "1";
            this.itemComplex.Text = "Complex";
            this.itemComplex.UseVisualStyleBackColor = true;
            this.itemComplex.CheckedChanged += new System.EventHandler(this.itemType_CheckedChanged);
            // 
            // itemLore
            // 
            this.itemLore.Location = new System.Drawing.Point(220, 65);
            this.itemLore.Name = "itemLore";
            this.itemLore.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.itemLore.Size = new System.Drawing.Size(400, 125);
            this.itemLore.TabIndex = 4;
            this.itemLore.Text = "";
            // 
            // itemName
            // 
            this.itemName.Location = new System.Drawing.Point(220, 20);
            this.itemName.Name = "itemName";
            this.itemName.PlaceholderText = "Item Name";
            this.itemName.Size = new System.Drawing.Size(400, 39);
            this.itemName.TabIndex = 3;
            this.itemName.Leave += new System.EventHandler(this.itemEditor_LeaveControlFocus);
            // 
            // itemTextureDisplay
            // 
            this.itemTextureDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.itemTextureDisplay.Location = new System.Drawing.Point(6, 6);
            this.itemTextureDisplay.Name = "itemTextureDisplay";
            this.itemTextureDisplay.Size = new System.Drawing.Size(200, 200);
            this.itemTextureDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.itemTextureDisplay.TabIndex = 0;
            this.itemTextureDisplay.TabStop = false;
            this.itemTextureDisplay.Click += new System.EventHandler(this.itemTexture_Click);
            // 
            // filesPage
            // 
            this.filesPage.BackColor = System.Drawing.Color.Transparent;
            this.filesPage.Location = new System.Drawing.Point(4, 5);
            this.filesPage.Name = "filesPage";
            this.filesPage.Size = new System.Drawing.Size(1589, 1191);
            this.filesPage.TabIndex = 2;
            // 
            // openItemTexture
            // 
            this.openItemTexture.FileOk += new System.ComponentModel.CancelEventHandler(this.openItemTexture_FileOk);
            // 
            // saveProjectDialog
            // 
            this.saveProjectDialog.DefaultExt = "dpg";
            this.saveProjectDialog.Filter = "Datapackager Project File|*.dpg";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(18, 1001);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(150, 46);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(18, 1053);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(150, 46);
            this.loadButton.TabIndex = 4;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(18, 1156);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(150, 46);
            this.exportButton.TabIndex = 5;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // exportProjectDialog
            // 
            this.exportProjectDialog.HelpRequest += new System.EventHandler(this.exportProjectDialog_HelpRequest);
            // 
            // EditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2025, 1300);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.windowControl);
            this.Controls.Add(this.tabWindow);
            this.Name = "EditorView";
            this.Text = "EditorView";
            this.tabWindow.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.blockTextureDisplay)).EndInit();
            this.windowControl.ResumeLayout(false);
            this.blocksPage.ResumeLayout(false);
            this.itemsPage.ResumeLayout(false);
            this.itemsPage.PerformLayout();
            this.itemWindow.ResumeLayout(false);
            this.itemSimpleWindow.ResumeLayout(false);
            this.itemSimpleWindow.PerformLayout();
            this.itemComplexWindow.ResumeLayout(false);
            this.itemComplexWindow.PerformLayout();
            this.itemFoodWindow.ResumeLayout(false);
            this.itemFoodWindow.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemTextureDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabWindow;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private PictureBox blockTextureDisplay;
        private TabControl windowControl;
        private TabPage blocksPage;
        private TabPage itemsPage;
        private TabPage filesPage;
        private RichTextBox itemLore;
        private TextBox itemName;
        private PictureBox itemTextureDisplay;
        private RadioButton itemComplex;
        private RadioButton itemSimple;
        private Panel panel1;
        private RadioButton itemFood;
        private TabControl itemWindow;
        private TabPage itemSimpleWindow;
        private TabPage itemComplexWindow;
        private TabPage itemFoodWindow;
        private Label label2;
        private Label label3;
        private RichTextBox simpleItemNbt;
        private Label label1;
        private ListBox itemList;
        private Button addItemButton;
        private Button removeItemButton;
        private OpenFileDialog openItemTexture;
        private SaveFileDialog saveProjectDialog;
        private Button saveButton;
        private Button loadButton;
        private OpenFileDialog loadProjectDialog;
        private Button exportButton;
        private FolderBrowserDialog exportProjectDialog;
    }
}