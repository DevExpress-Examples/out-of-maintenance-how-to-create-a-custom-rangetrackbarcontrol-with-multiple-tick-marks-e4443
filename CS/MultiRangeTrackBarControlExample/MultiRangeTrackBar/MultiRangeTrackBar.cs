using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace MultiRangeTrackBarControlExample {

    [ToolboxItem(true)]
    public class MultiRangeTrackBar : TrackBarControl {
        static MultiRangeTrackBar() {
            RepositoryItemMultiTrackBar.RegisterCustomTrackBar();
        }

        public MultiRangeTrackBar() {
            fEditValue = CreateValues();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemMultiTrackBar Properties => base.Properties as RepositoryItemMultiTrackBar;

        public override string EditorTypeName => RepositoryItemMultiTrackBar.CustomEditName;

        protected override object ConvertCheckValue(object val) {
            if (val is IEnumerable<int>)
                return val;
            else
                return fEditValue;
        }

        public ObservableCollection<int> Values {
            get {
                var values = fEditValue as ObservableCollection<int>;
                if (values == null)
                    fEditValue = CreateValues();
                return fEditValue as ObservableCollection<int>;
            }
        }

        private ObservableCollection<int> CreateValues() {
            var valuesCollection = new ObservableCollection<int>();
            valuesCollection.CollectionChanged += (sender, e) => {
                if (AllowFireEditValueChanged) {
                    RaiseEditValueChanged();
                    RefreshValues();
                }
            };
            return valuesCollection;
        }

        private void RefreshValues() {
            ViewInfo.CalcViewInfo();
            Invalidate();
        }

        private bool ValuesValid(IEnumerable<int> values) {
            return values.All(x => x >= Properties.Minimum && x <= Properties.Maximum);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object EditValue {
            get => Values.ToList();
            set {
                var values = value as IEnumerable<int>;
                if (values != null && ValuesValid(values)) {
                    LockEditValueChanged();
                    Values.Clear();
                    foreach (int item in values) {
                        Values.Add(item);
                    }
                    UnLockEditValueChanged();
                    RefreshValues();
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseDown(e);
            int value = ViewInfo.ValueFromPoint(e.Location);
            ActiveThumbIndex = Values.IndexOf(value);
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);
            if (ActiveThumbIndex != -1) {
                int valueFromPoint = ViewInfo.ValueFromPoint(e.Location);

                int minBound = ActiveThumbIndex > 0 ? Values[ActiveThumbIndex - 1] : Properties.Minimum;
                int maxBound = ActiveThumbIndex < Values.Count - 1 ? Values[ActiveThumbIndex + 1] : Properties.Maximum;

                int newValue = Math.Max(minBound, Math.Min(maxBound, valueFromPoint));

                int oldValue = Values[ActiveThumbIndex];
                if (oldValue != newValue) {
                    //
                    Values[ActiveThumbIndex] = newValue;
                    (ViewInfo as MultiTrackBarViewInfo).SetThumbValue(ActiveThumbIndex, newValue);
                    Invalidate();
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e) {

            ActiveThumbIndex = -1;
            base.OnMouseUp(e);
        }

        public int ActiveThumbIndex { get; protected set; } = -1;
    }
}
