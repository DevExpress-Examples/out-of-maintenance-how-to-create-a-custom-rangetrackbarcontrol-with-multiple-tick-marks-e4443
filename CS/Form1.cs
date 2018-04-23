using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils.Controls;
using DevExpress.XtraEditors;

namespace CustomRangeTrackBarControl
{
    public partial class Form1 : Form
    {
        RepositoryItemMultipleRangeTrackBar ritem;

        public Form1()
        {
            InitializeComponent();
            SubscribeEvents();
            CustomizeButtons();
            SetGrid();
        }

        void SetGrid()
        {
            gridControl1.DataSource = GetData(1);
            ritem = new RepositoryItemMultipleRangeTrackBar();
            RepositoryItemRangeTrackBar ritem1 = new RepositoryItemRangeTrackBar();
            ritem.ShowValueToolTip = true;
            RangeList list = new RangeList();
            list.ChangeValue(0, new TrackBarRange(5, 7));
            gridView1.SetRowCellValue(0, "MyRitem", list); 
            gridView1.Columns[0].ColumnEdit = ritem;
            gridView1.Columns[1].ColumnEdit = ritem1;
        }

        void AddClick(object sender, EventArgs e)
        {
            MultipleRangeTrackBar editor = ((sender as SimpleButton).Tag as MultipleRangeTrackBar);
            if (editor != null)
                editor.AddNewRange(0, 0);
        }

        void SetEditValueClick(object sender, EventArgs e)
        {
            RangeList list = new RangeList();
            list.ChangeValue(0, new TrackBarRange(1, 4));
            list.Add(new TrackBarRange());
            gridView1.SetRowCellValue(0, gridView1.Columns[0], list);
        }

        private void RemoveClick(object sender, EventArgs e)
        {
            MultipleRangeTrackBar editor = ((sender as SimpleButton).Tag as MultipleRangeTrackBar);
            if (editor != null)
                editor.RemoveRange(1);
        }

        void SubscribeEvents()
        {
            multiRangeForEvent.Intersect += new MultipleRangeTrackBar.IntersectEventHandler(multiRangeForEvent_Intersect);
            // buttons
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Text == "Add a new range")
                    (ctrl as SimpleButton).Click += new EventHandler(AddClick);
                if (ctrl.Text == "Remove 1")
                    (ctrl as SimpleButton).Click += new EventHandler(RemoveClick);
                if (ctrl.Text == "Set edit value")
                    (ctrl as SimpleButton).Click += new EventHandler(SetEditValueClick);
            }
        }

        void CustomizeMultiRanges()
        {
            multiRangeForEvent.Properties.Maximum = 30;
        }

        void CustomizeButtons()
        {
            simpleButton4.Tag = multiRangeForEvent;
            btnMultiRangeEvent.Tag = multiRangeForEvent;
            simpleButton2.Tag = multiRange1;
            simpleButton5.Tag = multiRange1;
            simpleButton7.Tag = multiRange2;
            simpleButton6.Tag = multiRange2;
            simpleButton9.Tag = multiRangeVertical;
            simpleButton8.Tag = multiRangeVertical;
            simpleButton1.Tag = gridView1;
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            MultipleRangeTrackBar edit = gridView1.ActiveEditor as MultipleRangeTrackBar;
            if (edit != null)
                edit.AddNewRange();
        }

        void multiRangeForEvent_Intersect(IntersectEventArgs e)
        {
            labelControl1.Text = String.Format("Intersect event: DraggedThumb = {0}; ThumbType = {1}; Value = {2}", e.DraggedThumb, e.ThumbType, e.Value);
        }

        DataTable GetData(int rows)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MyRitem", typeof(RangeList));
            dt.Columns.Add("Standard ritem", typeof(TrackBarRange));
            dt.Columns.Add("Info", typeof(string));
            for (int i = 0; i < rows; i++)
            {
                dt.Rows.Add(new RangeList(), new TrackBarRange(0, i), "Info" + i.ToString());
            }
            return dt;
        }
    }
}
