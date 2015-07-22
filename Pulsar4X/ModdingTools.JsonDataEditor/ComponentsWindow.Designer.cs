﻿namespace ModdingTools.JsonDataEditor
{
    partial class ComponentsWindow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_saveUpdate = new System.Windows.Forms.Button();
            this.button_mainMenu = new System.Windows.Forms.Button();
            this.button_saveNew = new System.Windows.Forms.Button();
            this.listBox_allComponents = new System.Windows.Forms.ListBox();
            this.genericDataUC1 = new ModdingTools.JsonDataEditor.GenericDataUC();
            this.listBox_Abilities = new System.Windows.Forms.ListBox();
            this.listBox_allAbilities = new System.Windows.Forms.ListBox();
            this.propertyGrid_PropertyEditor = new System.Windows.Forms.PropertyGrid();
            this.itemGridUC1 = new ModdingTools.JsonDataEditor.UserControls.ItemGridUC();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 246F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.listBox_allComponents, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.genericDataUC1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBox_Abilities, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBox_allAbilities, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(727, 508);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button_clear, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_saveUpdate, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_mainMenu, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.button_saveNew, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 444);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(240, 61);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // button_clear
            // 
            this.button_clear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_clear.Location = new System.Drawing.Point(3, 3);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(114, 24);
            this.button_clear.TabIndex = 0;
            this.button_clear.Text = "Clear Selection";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clearSelection_Click);
            // 
            // button_saveUpdate
            // 
            this.button_saveUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_saveUpdate.Location = new System.Drawing.Point(123, 3);
            this.button_saveUpdate.Name = "button_saveUpdate";
            this.button_saveUpdate.Size = new System.Drawing.Size(114, 24);
            this.button_saveUpdate.TabIndex = 1;
            this.button_saveUpdate.Text = "Save (Update)";
            this.button_saveUpdate.UseVisualStyleBackColor = true;
            this.button_saveUpdate.Click += new System.EventHandler(this.button_updateExisting_Click);
            // 
            // button_mainMenu
            // 
            this.button_mainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_mainMenu.Location = new System.Drawing.Point(3, 33);
            this.button_mainMenu.Name = "button_mainMenu";
            this.button_mainMenu.Size = new System.Drawing.Size(114, 25);
            this.button_mainMenu.TabIndex = 2;
            this.button_mainMenu.Text = "Main Menu";
            this.button_mainMenu.UseVisualStyleBackColor = true;
            this.button_mainMenu.Click += new System.EventHandler(this.button_mainMenu_Click);
            // 
            // button_saveNew
            // 
            this.button_saveNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_saveNew.Location = new System.Drawing.Point(123, 33);
            this.button_saveNew.Name = "button_saveNew";
            this.button_saveNew.Size = new System.Drawing.Size(114, 25);
            this.button_saveNew.TabIndex = 3;
            this.button_saveNew.Text = "Save (New)";
            this.button_saveNew.UseVisualStyleBackColor = true;
            this.button_saveNew.Click += new System.EventHandler(this.button_saveNew_Click);
            // 
            // listBox_allComponents
            // 
            this.listBox_allComponents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_allComponents.FormattingEnabled = true;
            this.listBox_allComponents.Location = new System.Drawing.Point(3, 155);
            this.listBox_allComponents.Name = "listBox_allComponents";
            this.listBox_allComponents.Size = new System.Drawing.Size(240, 283);
            this.listBox_allComponents.TabIndex = 0;
            this.listBox_allComponents.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_AllComponents_MouseDoubleClick);
            // 
            // genericDataUC1
            // 
            this.genericDataUC1.Description = "";
            this.genericDataUC1.Location = new System.Drawing.Point(3, 3);
            this.genericDataUC1.MinimumSize = new System.Drawing.Size(240, 0);
            this.genericDataUC1.Name = "genericDataUC1";
            this.genericDataUC1.Size = new System.Drawing.Size(240, 146);
            this.genericDataUC1.TabIndex = 2;
            // 
            // listBox_Abilities
            // 
            this.listBox_Abilities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Abilities.FormattingEnabled = true;
            this.listBox_Abilities.Location = new System.Drawing.Point(249, 3);
            this.listBox_Abilities.Name = "listBox_Abilities";
            this.listBox_Abilities.Size = new System.Drawing.Size(234, 146);
            this.listBox_Abilities.TabIndex = 4;
            this.listBox_Abilities.DoubleClick += new System.EventHandler(this.listBox_Abilities_DoubleClick);
            // 
            // listBox_allAbilities
            // 
            this.listBox_allAbilities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_allAbilities.FormattingEnabled = true;
            this.listBox_allAbilities.Location = new System.Drawing.Point(489, 3);
            this.listBox_allAbilities.Name = "listBox_allAbilities";
            this.listBox_allAbilities.Size = new System.Drawing.Size(235, 146);
            this.listBox_allAbilities.TabIndex = 8;
            this.listBox_allAbilities.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_allAbilities_MouseDoubleClick);
            // 
            // propertyGrid_PropertyEditor
            // 
            this.propertyGrid_PropertyEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid_PropertyEditor.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid_PropertyEditor.Name = "propertyGrid_PropertyEditor";
            this.propertyGrid_PropertyEditor.Size = new System.Drawing.Size(461, 251);
            this.propertyGrid_PropertyEditor.TabIndex = 7;
            // 
            // itemGridUC1
            // 
            this.itemGridUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemGridUC1.Location = new System.Drawing.Point(3, 3);
            this.itemGridUC1.Name = "itemGridUC1";
            this.itemGridUC1.Size = new System.Drawing.Size(461, 318);
            this.itemGridUC1.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tabControl1, 2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(249, 155);
            this.tabControl1.Name = "tabControl1";
            this.tableLayoutPanel1.SetRowSpan(this.tabControl1, 2);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(475, 350);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.itemGridUC1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(467, 324);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.propertyGrid_PropertyEditor);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(467, 257);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ComponentsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ComponentsWindow";
            this.Size = new System.Drawing.Size(727, 508);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listBox_allComponents;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private GenericDataUC genericDataUC1;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_saveUpdate;
        private System.Windows.Forms.Button button_mainMenu;
        private System.Windows.Forms.Button button_saveNew;
        private System.Windows.Forms.ListBox listBox_Abilities;
        private System.Windows.Forms.PropertyGrid propertyGrid_PropertyEditor;
        private System.Windows.Forms.ListBox listBox_allAbilities;
        private UserControls.ItemGridUC itemGridUC1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}
