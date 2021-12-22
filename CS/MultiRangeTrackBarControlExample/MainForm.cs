using System;
using System.Linq;

namespace MultiRangeTrackBarControlExample {
    public partial class MainForm : DevExpress.XtraEditors.XtraForm {
        public MainForm() {
            InitializeComponent();

            // Uncomment this line to disable drawing track lines.
            // multiRangeTrackBar.Properties.DrawRanges = false;
        }

        private void OnAddButtonClick(object sender, EventArgs e) {
            var values = multiRangeTrackBar.Values;
            int startingIndex = values.Count == 0 ? multiRangeTrackBar.Properties.Minimum : values.Last() + 1;
            int limitIndex = multiRangeTrackBar.Properties.Maximum;
            if (limitIndex - startingIndex > 0) {
                values.Add(startingIndex);
                values.Add(startingIndex + 1);
            }
        }

        private void OnRemoveButtonClick(object sender, EventArgs e) {
            if (multiRangeTrackBar.Values.Count >= 2) {
                multiRangeTrackBar.Values.RemoveAt(multiRangeTrackBar.Values.Count - 1);
                multiRangeTrackBar.Values.RemoveAt(multiRangeTrackBar.Values.Count - 1);
            }
        }
    }
}
