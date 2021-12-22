namespace MultiRangeTrackBarControlExample {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.Form1layoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.removeButton = new DevExpress.XtraEditors.SimpleButton();
            this.addButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.multiRangeTrackBar = new MultiRangeTrackBarControlExample.MultiRangeTrackBar();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.Form1layoutControl1ConvertedLayout)).BeginInit();
            this.Form1layoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiRangeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiRangeTrackBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // Form1layoutControl1ConvertedLayout
            // 
            this.Form1layoutControl1ConvertedLayout.Controls.Add(this.multiRangeTrackBar);
            this.Form1layoutControl1ConvertedLayout.Controls.Add(this.removeButton);
            this.Form1layoutControl1ConvertedLayout.Controls.Add(this.addButton);
            this.Form1layoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Form1layoutControl1ConvertedLayout.Location = new System.Drawing.Point(0, 0);
            this.Form1layoutControl1ConvertedLayout.Name = "Form1layoutControl1ConvertedLayout";
            this.Form1layoutControl1ConvertedLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(628, 138, 650, 400);
            this.Form1layoutControl1ConvertedLayout.Root = this.layoutControlGroup1;
            this.Form1layoutControl1ConvertedLayout.Size = new System.Drawing.Size(580, 399);
            this.Form1layoutControl1ConvertedLayout.TabIndex = 2;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(291, 61);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(277, 22);
            this.removeButton.StyleController = this.Form1layoutControl1ConvertedLayout;
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "Remove";
            this.removeButton.Click += new System.EventHandler(this.OnRemoveButtonClick);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 61);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(275, 22);
            this.addButton.StyleController = this.Form1layoutControl1ConvertedLayout;
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add";
            this.addButton.Click += new System.EventHandler(this.OnAddButtonClick);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(580, 399);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.addButton;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 49);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(279, 330);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.removeButton;
            this.layoutControlItem2.Location = new System.Drawing.Point(279, 49);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(281, 330);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // multiRangeTrackBar
            // 
            this.multiRangeTrackBar.Location = new System.Drawing.Point(12, 12);
            this.multiRangeTrackBar.Name = "multiRangeTrackBar";
            this.multiRangeTrackBar.Properties.DrawRanges = true;
            this.multiRangeTrackBar.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.multiRangeTrackBar.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.multiRangeTrackBar.Size = new System.Drawing.Size(556, 45);
            this.multiRangeTrackBar.StyleController = this.Form1layoutControl1ConvertedLayout;
            this.multiRangeTrackBar.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.multiRangeTrackBar;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(560, 49);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 399);
            this.Controls.Add(this.Form1layoutControl1ConvertedLayout);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.Form1layoutControl1ConvertedLayout)).EndInit();
            this.Form1layoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiRangeTrackBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiRangeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl Form1layoutControl1ConvertedLayout;
        private DevExpress.XtraEditors.SimpleButton removeButton;
        private DevExpress.XtraEditors.SimpleButton addButton;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private MultiRangeTrackBar multiRangeTrackBar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}

