using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Drawing;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using System.Drawing;

namespace CustomRangeTrackBarControl
{
    class MultiRangeViewInfo : RangeTrackBarViewInfo
    {
        public MultiRangeViewInfo(DevExpress.XtraEditors.Repository.RepositoryItem item)
            : base(item)
        {
            _ThumbsPos = new List<PointRange>();
            _ThumbsPos.Add(new PointRange());
            _MaxThumbBoundses = new List<Rectangle>();
            _MaxThumbBoundses.Add(this.MaxThumbBounds);
            _MinThumbBoundses = new List<Rectangle>();
            _MinThumbBoundses.Add(this.MinThumbBounds);
            CurrentIndex = 0;
            _DraggedThumb = -1;
        }
        private int _DraggedThumb;
        private int _CurrentIndex;
        private List<Rectangle> _MinThumbBoundses;
        private List<Rectangle> _MaxThumbBoundses;
        private List<PointRange> _ThumbsPos;
        TrackBarObjectInfoArgs trackInfo;
        public override void Reset()
        {
            base.Reset();
            this.trackInfo = new TrackBarObjectInfoArgs(PaintAppearance, this);
        }

        public new RepositoryItemMultipleRangeTrackBar Item { get { return base.Item as RepositoryItemMultipleRangeTrackBar; } }

        public List<PointRange> ThumbsPos
        {
            get { return _ThumbsPos; }
        }

        public List<Rectangle> MaxThumbBoundses
        {
            get { return _MaxThumbBoundses; }
            set { _MaxThumbBoundses = value; }
        }

        public List<Rectangle> MinThumbBoundses
        {
            get { return _MinThumbBoundses; }
            set { _MinThumbBoundses = value; }
        }

        protected override void CalcThumbPos()
        {
            RangeList ranges = EditValue as RangeList;
            if (ranges != null)
            for (int i = 0; i < ranges.Count; i++)
            {
                if (this.ThumbsPos.Count <= i) ThumbsPos.Add(new PointRange());
                this.ThumbsPos[i].Maximum = CalcThumbPosCore(ranges.GetValue(i).Maximum);
                this.ThumbsPos[i].Minimum = CalcThumbPosCore(ranges.GetValue(i).Minimum);
            }
        }

        public int DraggedThumb
        {
            get { return _DraggedThumb; }
            set { _DraggedThumb = value; }
        }

        void ClearBoundses()
        {
            if (MaxThumbBoundses.Count > (EditValue as RangeList).Count)
            {
                int b = MaxThumbBoundses.Count - (EditValue as RangeList).Count;
                for (int i = b; i < MaxThumbBoundses.Count; i++)
                {
                    MaxThumbBoundses.RemoveAt(i);
                    MinThumbBoundses.RemoveAt(i);
                    ThumbsPos.RemoveAt(i);
                }
            }
        }

        public override EditHitInfo CalcHitInfo(Point p)
        {
            Point p1 = p;
            int index = 0;
            if (Bounds.Contains(p))
            {
                for (int i = 0; i < MinThumbBoundses.Count; i++)
                {
                    if (MinThumbBoundses[i].Contains(p))
                    {
                        if (this.DraggedThumb == -1)
                            this.DraggedThumb = i;
                        if (Item.Orientation == System.Windows.Forms.Orientation.Horizontal)
                            p1.X = MinThumbBoundses[0].X + 1;
                        else
                            p1.Y = MinThumbBoundses[0].Y + 1;
                        index = i;
                        break;
                    }
                }
                for (int i = 0; i < MaxThumbBoundses.Count; i++)
                {
                    if (MaxThumbBoundses[i].Contains(p))
                    {
                        if (this.DraggedThumb == -1) // for intersection
                            this.DraggedThumb = i;
                        if (Item.Orientation == System.Windows.Forms.Orientation.Horizontal)
                            p1.X = MaxThumbBoundses[0].X + 1;
                        else
                            p1.Y = MaxThumbBoundses[0].Y + 1;
                        index = i;
                        break;
                    }
                }
            }
            CurrentIndex = 0;
            EditHitInfo hi = base.CalcHitInfo(p1);
            CurrentIndex = index;
            ClearBoundses();
            return hi;
        }

        public override TrackBarObjectInfoArgs TrackInfo
        {
            get { return trackInfo as TrackBarObjectInfoArgs; }
        }

        public int CurrentIndex
        {
            get { return _CurrentIndex; }
            set { _CurrentIndex = value; }
        }

        public override Rectangle MaxThumbBounds
        { 
            get 
            {
                if (this.MaxThumbBoundses.Count > 0)
                {
                    if (MaxThumbBoundses.Count <= CurrentIndex)
                        MaxThumbBoundses.Add(new Rectangle());
                    this.MaxThumbBoundses[this.CurrentIndex] = (base.TrackCalculator).GetMaxThumbBounds();
                }
                return (TrackCalculator).GetMaxThumbBounds();
            }
        }

        public override Rectangle MinThumbBounds
        {
            get
            {
                if (this.MinThumbBoundses.Count > 0)
                {
                    if (MinThumbBoundses.Count <= CurrentIndex)
                        MinThumbBoundses.Add(new Rectangle());
                    this.MinThumbBoundses[this.CurrentIndex] = (base.TrackCalculator).GetMinThumbBounds();
                }
                return (TrackCalculator).GetMinThumbBounds();
            }
        }

        public override void Offset(int x, int y)
        {
            base.Offset(x, y);
            for (int i = 0; i < ThumbsPos.Count; i++)
                ThumbsPos[i].Offset(x, y);
        }

        public override TrackBarObjectPainter GetTrackPainter()
        {
            if (IsPrinting)
                return new RangeTrackBarObjectPainter();
            if (this.LookAndFeel.ActiveStyle == ActiveLookAndFeelStyle.WindowsXP)
                return new RangeTrackBarObjectPainter();
            if (this.LookAndFeel.ActiveStyle == ActiveLookAndFeelStyle.Skin)
                return new MultipleTrackBarObjectPainter(LookAndFeel.ActiveLookAndFeel);
            if (this.LookAndFeel.ActiveStyle == ActiveLookAndFeelStyle.Office2003)
                return new Office2003RangeTrackBarObjectPainter();
            return new RangeTrackBarObjectPainter();
        }
    }
    
    //*********************************************************************************************
    class CustomCalculator : SkinRangeTrackBarInfoCalculator
    {
        public CustomCalculator(RangeTrackBarViewInfo viewInfo, RangeTrackBarObjectPainter painter)
            : base(viewInfo, painter)
        { }

        public override Rectangle GetMaxThumbBounds()
        {
            MultiRangeViewInfo view = this.ViewInfo as MultiRangeViewInfo;
            Rectangle rect = new Rectangle(new Point(view.ThumbsPos[view.CurrentIndex].Maximum.X, GetThumbY()), GetThumbElementSize());
            return ViewInfo.TrackBarHelper.Rotate(rect);
        }

        public override Rectangle GetMinThumbBounds()
        {
            MultiRangeViewInfo view = this.ViewInfo as MultiRangeViewInfo;
            Rectangle rect = new Rectangle(new Point(view.ThumbsPos[view.CurrentIndex].Minimum.X - GetThumbElementSize().Width, GetThumbY()), GetThumbElementSize());
            return ViewInfo.TrackBarHelper.Rotate(rect);
        }
    }

    //*********************************************************************************************
    public class PointRange
    {
        // Fields...
        private Point _Maximum;
        private Point _Minimum;

        public Point Minimum
        {
            get { return _Minimum; }
            set { _Minimum = value; }
        }

        public void Offset(int x, int y)
        {
            _Minimum.Offset(x, y);
            _Maximum.Offset(x, y);
        }

        public Point Maximum
        {
            get { return _Maximum; }
            set { _Maximum = value; }
        }
        public override string ToString()
        {
            return String.Format("Minimum = {0}; Maximum = {1}", Minimum, Maximum);
        }
    }
}