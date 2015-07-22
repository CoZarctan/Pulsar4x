﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using Pulsar4X.ECSLib;

namespace ModdingTools.JsonDataEditor.UserControls
{
    public partial class ItemGridCell : UserControl
    {
        public dynamic Data { get; set; }
        protected dynamic _editControl_ { get; set; }
        private dynamic _activeControl { get; set; }
        public ItemGridCell() 
        {
            InitializeComponent();
            _activeControl = displayLabel;
            displayLabel.Text = Text;
            displayLabel.MouseClick += new MouseEventHandler(OnMouseClick);

        }

        public ItemGridCell(dynamic data) : this()
        {
            Data = data;
        }

        /// <summary>
        /// The display text for this control
        /// </summary>
        public new string Text {
            get
            {
                string returnstring = "";
                if (_editControl_ != null)
                    returnstring = _getText_;
                return returnstring;
            } 
        }

        /// <summary>
        /// a virtual method to return the wanted text
        /// this will be dependant on the type of _editControl_
        /// and therefor should be overriden.
        /// </summary>
        protected virtual string _getText_
        {
            get { return Data.Text; }
        }

        public override void Refresh()
        {
            displayLabel.Text = Text;
            Size = displayLabel.Size;
            base.Refresh();
        }

        /// <summary>
        /// detects a click on this control and causes the control to enter editing mode.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        protected void OnMouseClick(object o, MouseEventArgs e)
        {
            if(_editControl_ != null)
                StartEditing(this, e);         
        }

        /// <summary>
        /// Starts Editing Mode causing the control to use the _editControl_
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        protected void StartEditing(object o, EventArgs e)
        {
            _activeControl = _editControl_;
            Controls.Remove(displayLabel);
            Controls.Add(_editControl_);            
        }

        /// <summary>
        /// Stops Editing Mode, causing the control to use displayLabel
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        protected void StopEditing(object o, EventArgs e)
        {
            ValadateInput();
            _activeControl = displayLabel;
            Controls.Remove(_editControl_);
            Controls.Add(displayLabel);
        }

        /// <summary>
        /// translates the _editControl_ into Data
        /// since this is going to depend on what the Data Type is
        /// and what the _editControl Type is it should be overridden.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ValadateInput()
        {
            Data = _editControl_.Text;
            displayLabel.Text = Text;
            return true;
        }
    }

    /// <summary>
    /// String Entry version of ItemGridCell
    /// This version uses TextBox as editing mode.
    /// </summary>
    public class ItemGridCell_String : ItemGridCell
    {
        public ItemGridCell_String(string str) : base(str)
        {
            TextBox textbox = new TextBox();

            textbox.Text = str;

            _editControl_ = textbox; //set the _editControl
            textbox.Leave += new EventHandler(StopEditing); //subscribe to the correct event handler (textbox.Leave) to stop editing.

            Refresh();
        }

        protected override string _getText_
        {
            get { return Data; }
        }
    }


    /// <summary>
    /// AbilityType version of ItemGridCell
    /// This version uses Listbox to display a list of possible enum AbilityType during Editing Mode
    /// </summary>
    public class ItemGridCell_AbilityType : ItemGridCell
    {      
        public ItemGridCell_AbilityType(AbilityType ability) : base(ability)
        {
            ListBox listBox = new ListBox();

            foreach (object abilitytype in Enum.GetValues(typeof(AbilityType)))
            {
                listBox.Items.Add(abilitytype);
            }
            
            Data = ability;
            listBox.SelectedItem = Data;
            _editControl_ = listBox;
  
            listBox.SelectedIndexChanged += new EventHandler(StartEditing);
            Refresh();
        }


        protected override string _getText_
        {
            get
            {            
                return Enum.GetName(typeof(AbilityType), (AbilityType)Data);
            } 
        }

        protected override bool ValadateInput()
        {
            bool success = false;

            ListBox listBox = _editControl_;
            if (listBox.SelectedItem != null)
            {
                Data = (AbilityType)listBox.SelectedItem;
                success = true;
            }
            return success;
        }
    }

    /// <summary>
    /// float version of the ItemGridCell
    /// this version uses a textbox as the edit control and checks wheather casting the textbox.text is valid.
    /// </summary>
    public class ItemGridCell_FloatType : ItemGridCell
    {
        public ItemGridCell_FloatType(float num) : base(num)
        {
            TextBox textbox = new TextBox();

            textbox.Text = num.ToString();

            _editControl_ = textbox; //set the _editControl
            textbox.Leave += new EventHandler(StopEditing); //subscribe to the correct event handler (textbox.Leave) to stop editing.

            Refresh();
        }

        protected override string _getText_
        {
            get
            {              
                return Data.ToString();
            }
        }

 
        protected override bool ValadateInput()
        {
            bool success = false;
            float newdata;
            if (float.TryParse(_editControl_.Text, out newdata))
            {
                Data = newdata;
                success = true;
            }
            return success;
        }
    }
}
