using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System.ComponentModel;
using DevExpress.XtraEditors.Drawing;
using DevExpress.Utils;
using DevExpress.XtraEditors.ViewInfo;
using System.Drawing;
using DevExpress.XtraEditors.Controls;

namespace CustomRangeTrackBarControl
{
    [System.ComponentModel.DesignerCategory("None")]
    class MultipleRangeTrackBar : RangeTrackBarControl
    {
        #region Initialization
        static MultipleRangeTrackBar()
        {
            RepositoryItemMultipleRangeTrackBar.Register();
        }
        
        public override string EditorTypeName
        {
            get { return RepositoryItemMultipleRangeTrackBar.EditorName; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemMultipleRangeTrackBar Properties
        {
            get { return base.Properties as RepositoryItemMultipleRangeTrackBar; }
        }

        internal new MultiRangeViewInfo ViewInfo
        {
            get { return base.ViewInfo as MultiRangeViewInfo; }
        }
        #endregion

        public MultipleRangeTrackBar()
        {
            if (innerRanges == null)  innerRanges = new List<TrackBarRange>();
        }

        void RefreshInnerRanges()
        {
            RangeList list = (RangeList)EditValue;
            innerRanges.Clear();
            for (int i = 0; i < list.Count; i++)
                innerRanges.Add(list.GetValue(i));
        }

        bool lockEditValueChanged = false;
        protected override void OnEditValueChanged()
        {
            if (!lockEditValueChanged)
            {
                base.OnEditValueChanged();
                if (innerRanges == null) innerRanges = new List<TrackBarRange>();
                RangeList list = EditValue as RangeList;
                RefreshInnerRanges();
            }
        }

        bool IsEqualEditValue(RangeList list)
        {
            RangeList editVal = EditValue as RangeList;
            if (editVal.Count != list.Count) return false;
            for (int i = 0; i < list.Count; i++)
                if (editVal.GetValue(i).Minimum != list.GetValue(i).Minimum || editVal.GetValue(i).Maximum != list.GetValue(i).Maximum)
                    return false;
            return true;
        }

        protected override void OnEditValueChanging(DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            lockEditValueChanged = true;
            base.OnEditValueChanging(e);
            lockEditValueChanged = false;
            if (e.Cancel == false && !IsEqualEditValue((e.NewValue as RangeList)))
            {
                editVal = e.NewValue as RangeList;
                RefreshInnerRanges();
                OnEditValueChanged();
            }
        }

        void OnEditValueChangingCore(RangeList oldVal, RangeList newVal)
        {
            ChangingEventArgs e = new ChangingEventArgs(oldVal, newVal);
            OnEditValueChanging(e);
        }

        void CreateEditValue()
        {
            editVal = new RangeList();
            editVal.ListChanged += new EventHandler(editVal_ListChanged);
        }

        void editVal_ListChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        RangeList editVal;
        public override object EditValue
        {
            get
            {
                return editVal;
            }
            set
            {
                if (editVal == null) CreateEditValue();
                if (value.GetType() == typeof(TrackBarRange))
                {
                    editVal.ChangeValue(0, (TrackBarRange)value);
                    OnEditValueChanged();
                } else
                    if (value.GetType() == typeof(RangeList))
                    {
                        OnEditValueChangingCore(editVal, value as RangeList);
                        editVal.ListChanged += new EventHandler(editVal_ListChanged);
                        Refresh();
                    }
            }
        }
        #region Add, Remove, Get, Change

        bool CheckAdd(int maximum)
        {
            foreach (TrackBarRange range in innerRanges)
                if (range.Minimum <= maximum) return false;
            return true;
        }

        TrackBarRange ConvertItem(TrackBarRange item)
        {
            TrackBarRange range = item;
            range.Minimum = Math.Max(item.Minimum, Properties.Minimum);
            range.Maximum = Math.Min(item.Maximum, Properties.Maximum);
            return range;
        }

        void AddItem(TrackBarRange item)
        {
            TrackBarRange range = ConvertItem(item);
            RangeList oldVal = new RangeList((RangeList)EditValue);
            RangeList newVal = new RangeList(oldVal); 
            newVal.Add(item);
            OnEditValueChangingCore(oldVal, newVal);
        }

        void ChangeItem(int index, TrackBarRange item)
        {
            TrackBarRange range = ConvertItem(item);
            if (innerRanges[index].Maximum != item.Maximum || innerRanges[index].Minimum != item.Minimum)
            {
                RangeList oldVal = new RangeList((RangeList)EditValue);
                RangeList newVal = new RangeList(oldVal); 
                newVal.ChangeValue(index ,item);
                OnEditValueChangingCore(oldVal, newVal);
            }
        }

        void RemoveItem(int index)
        {
            RangeList oldVal = new RangeList((RangeList)EditValue);
            RangeList newVal = new RangeList(oldVal); 
            newVal.RemoveAt(index);
            OnEditValueChangingCore(oldVal, newVal);
        }

        public void AddNewRange()
        {
            AddNewRange(0, 0);
        }

        public void AddNewRange(int minimum, int maximum)
        {
            TrackBarRange item = new TrackBarRange(minimum, maximum);
            if (CheckAdd(item.Maximum))
                AddItem(item);
        }

        public void RemoveRange(int index)
        {
            if (index > 0 && innerRanges.Count > index)
                RemoveItem(index);
        }

        public TrackBarRange GetValue(int index)
        {
            return innerRanges[index];
        }

        public void ChangeValue(TrackBarRange range, int index)
        {
            if (innerRanges.Count > index)
                ChangeItem(index, range);
        }

        public void ChangeValue(int minimum, int maximum, int index)
        {
            TrackBarRange range = new TrackBarRange(minimum, maximum);
            ChangeValue(range, index);
        }
        #endregion

        #region Intersection algorithm
        public delegate void IntersectEventHandler(IntersectEventArgs e );
        public event IntersectEventHandler Intersect;

        void OnIntersect(ThumbType thumbType_, int draggedThumb_, int value_)
        {
            if (Intersect != null)
            {
                IntersectEventArgs e = new IntersectEventArgs(thumbType_, draggedThumb_, value_);
                Intersect(e);
            }
        }

        bool CheckMinChange(int startIndex ,int newMinValue, bool raiseEvent)
        {
            bool check = true;
            int thumb = 0;
            if (newMinValue < Properties.Minimum) { check = false; raiseEvent = false; }
            for (int i = startIndex; i < innerRanges.Count; i++)
            {
                if (innerRanges[i].Maximum >= newMinValue)
                {
                    check = false;
                    thumb = i;
                    break;
                }
            }
            if (!check && raiseEvent)
                OnIntersect(ThumbType.Minimum, thumb - 1, innerRanges[thumb].Maximum);
            return check;
        }

        bool CheckMaxChange(int lastIndex, int newMaxValue, bool raiseEvent)
        {
            bool check = true;
            int thumb = 0;
            if (newMaxValue > Properties.Maximum) { check = false; raiseEvent = false; }
            for (int i = 0; i < lastIndex; i++)
            {
                if (innerRanges[i].Minimum <= newMaxValue)
                {
                    check = false;
                    thumb = i;
                    break;
                }
            }
            if (!check && raiseEvent)
                OnIntersect(ThumbType.Maximum, thumb + 1, innerRanges[thumb].Minimum);
            return check;
        }
        #endregion

        protected virtual TrackBarRange ChangeMinThumbPosition(int dragThumb, int newMinValue)
        {
            TrackBarRange range = innerRanges[dragThumb];
            if (CheckMinChange(ViewInfo.DraggedThumb + 1, newMinValue, true))
                range = new TrackBarRange(newMinValue, innerRanges[ViewInfo.DraggedThumb].Maximum);
            return range;
        }

        protected virtual TrackBarRange ChangeMaxThumbPosition(int dragThumb, int newMaxValue)
        {
            TrackBarRange range = innerRanges[dragThumb];
            if (CheckMaxChange(ViewInfo.DraggedThumb, newMaxValue, true))
                range = new TrackBarRange(innerRanges[ViewInfo.DraggedThumb].Minimum, newMaxValue);
            return range;
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            DXMouseEventArgs ee = DXMouseEventArgs.GetMouseArgs(e);
            if (ee.Handled) return;
            if (Properties.ReadOnly) return;
            if (ViewInfo.PressedInfo.HitTest == EditHitTest.Button)
            {
                ChangeItem(ViewInfo.DraggedThumb, ChangeMinThumbPosition(ViewInfo.DraggedThumb, Math.Min(ViewInfo.ValueFromPoint(ViewInfo.ControlToClient(new Point(e.X, e.Y))),
                    innerRanges[ViewInfo.DraggedThumb].Maximum)));
                ShowMinValue();
            }
            else if (ViewInfo.PressedInfo.HitTest == EditHitTest.Button2)
            {
                ChangeItem(ViewInfo.DraggedThumb, ChangeMaxThumbPosition(ViewInfo.DraggedThumb, Math.Max(innerRanges[ViewInfo.DraggedThumb].Minimum,
                    ViewInfo.ValueFromPoint(ViewInfo.ControlToClient(new Point(e.X, e.Y))))));
                ShowMaxValue();
            }
        }

        protected override void ShowMaxValue()
        {
            ShowValue(innerRanges[ViewInfo.DraggedThumb].ToString(), ViewInfo.MaxThumbBoundses[ViewInfo.DraggedThumb]);
        }

        protected override void ShowMinValue()
        {
            ShowValue(innerRanges[ViewInfo.DraggedThumb].ToString(), ViewInfo.MinThumbBoundses[ViewInfo.DraggedThumb]);
        }

        int GetClosestThumb(int val)
        {
            int value = 0;
            int diff = Int32.MaxValue;
            for (int i = 0; i < innerRanges.Count; i++)
            {
                if (Math.Abs(val - innerRanges[i].Minimum) < diff)
                {
                    value = i * 2;
                    diff = Math.Abs(val - innerRanges[i].Minimum);
                }
                if (Math.Abs(val - innerRanges[i].Maximum) <= diff)
                {
                    value = i * 2 + 1;
                    diff = Math.Abs(val - innerRanges[i].Maximum);
                }
            }
            return value;
        }

        protected override void UpdateValueFromPoint(Point pt)
        {
            if (ViewInfo.DraggedThumb < 0)
            {
                if (!ShouldUpdateValueFromPoint(pt)) return;
                int value = ViewInfo.ValueFromPoint(ViewInfo.ControlToClient(pt));
                int val = GetClosestThumb(value);
                if (val % 2 == 0) ChangeValue(new TrackBarRange(value, innerRanges[val / 2].Maximum), val / 2);
                else ChangeValue(new TrackBarRange(innerRanges[val / 2].Minimum, value), val / 2);
            }
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            ViewInfo.DraggedThumb = -1;
        }
                
        private List<TrackBarRange> innerRanges;

        public int ThumbsCount { get { return innerRanges.Count; } }
    }
}
