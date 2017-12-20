namespace WordOfTheDay
{
    partial class FromMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FromMain));
            this.lblId = new System.Windows.Forms.Label();
            this.txtWord = new System.Windows.Forms.RichTextBox();
            this.ntfyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.itmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.itmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.itmNext = new System.Windows.Forms.ToolStripMenuItem();
            this.itmAutorun = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.btnRead = new System.Windows.Forms.Button();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(0, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(17, 13);
            this.lblId.TabIndex = 4;
            this.lblId.Text = "Id";
            this.lblId.Visible = false;
            // 
            // txtWord
            // 
            this.txtWord.BackColor = System.Drawing.Color.Snow;
            this.txtWord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWord.Location = new System.Drawing.Point(0, 0);
            this.txtWord.Name = "txtWord";
            this.txtWord.ReadOnly = true;
            this.txtWord.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtWord.Size = new System.Drawing.Size(319, 167);
            this.txtWord.TabIndex = 5;
            this.txtWord.TabStop = false;
            this.txtWord.Text = "";
            this.txtWord.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.txtWord_ContentsResized);
            // 
            // ntfyIcon
            // 
            this.ntfyIcon.ContextMenuStrip = this.mainMenu;
            this.ntfyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfyIcon.Icon")));
            this.ntfyIcon.Text = "Word of The Day";
            this.ntfyIcon.Visible = true;
            this.ntfyIcon.DoubleClick += new System.EventHandler(this.ntfyIcon_DoubleClick);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmAdd,
            this.itmEdit,
            this.itmDelete,
            this.itmNext,
            this.itmAutorun,
            this.itmExit});
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(119, 136);
            // 
            // itmAdd
            // 
            this.itmAdd.Image = global::WordOfTheDay.Properties.Resources.add_icon;
            this.itmAdd.Name = "itmAdd";
            this.itmAdd.Size = new System.Drawing.Size(118, 22);
            this.itmAdd.Text = "Add";
            this.itmAdd.Click += new System.EventHandler(this.itmAdd_Click);
            // 
            // itmEdit
            // 
            this.itmEdit.Image = global::WordOfTheDay.Properties.Resources.options_icon;
            this.itmEdit.Name = "itmEdit";
            this.itmEdit.Size = new System.Drawing.Size(118, 22);
            this.itmEdit.Text = "Edit";
            this.itmEdit.Click += new System.EventHandler(this.itmEdit_Click);
            // 
            // itmDelete
            // 
            this.itmDelete.Image = global::WordOfTheDay.Properties.Resources.cancel_icon;
            this.itmDelete.Name = "itmDelete";
            this.itmDelete.Size = new System.Drawing.Size(118, 22);
            this.itmDelete.Text = "Delete";
            this.itmDelete.Click += new System.EventHandler(this.itmDelete_Click);
            // 
            // itmNext
            // 
            this.itmNext.Image = global::WordOfTheDay.Properties.Resources.refresh_icon;
            this.itmNext.Name = "itmNext";
            this.itmNext.Size = new System.Drawing.Size(118, 22);
            this.itmNext.Text = "Next";
            this.itmNext.Click += new System.EventHandler(this.itmNext_Click);
            // 
            // itmAutorun
            // 
            this.itmAutorun.Checked = true;
            this.itmAutorun.CheckState = System.Windows.Forms.CheckState.Checked;
            this.itmAutorun.Name = "itmAutorun";
            this.itmAutorun.Size = new System.Drawing.Size(118, 22);
            this.itmAutorun.Text = "Autorun";
            this.itmAutorun.Click += new System.EventHandler(this.itmAutorun_Click);
            // 
            // itmExit
            // 
            this.itmExit.Image = global::WordOfTheDay.Properties.Resources.Button_Close_icon;
            this.itmExit.Name = "itmExit";
            this.itmExit.Size = new System.Drawing.Size(118, 22);
            this.itmExit.Text = "Exit";
            this.itmExit.Click += new System.EventHandler(this.itmExit_Click);
            // 
            // tmrMain
            // 
            this.tmrMain.Interval = 3600000;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(0, 0);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 7;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // FromMain
            // 
            this.AcceptButton = this.btnRead;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 167);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnRead);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FromMain";
            this.Text = "Word Of The Day";
            this.Activated += new System.EventHandler(this.FromMain_Activated);
            this.Deactivate += new System.EventHandler(this.FromMain_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FromMain_FormClosing);
            this.mainMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.RichTextBox txtWord;
        private System.Windows.Forms.NotifyIcon ntfyIcon;
        private System.Windows.Forms.ContextMenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem itmAdd;
        private System.Windows.Forms.ToolStripMenuItem itmEdit;
        private System.Windows.Forms.ToolStripMenuItem itmDelete;
        private System.Windows.Forms.ToolStripMenuItem itmNext;
        private System.Windows.Forms.ToolStripMenuItem itmAutorun;
        private System.Windows.Forms.ToolStripMenuItem itmExit;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Button btnRead;
    }
}

