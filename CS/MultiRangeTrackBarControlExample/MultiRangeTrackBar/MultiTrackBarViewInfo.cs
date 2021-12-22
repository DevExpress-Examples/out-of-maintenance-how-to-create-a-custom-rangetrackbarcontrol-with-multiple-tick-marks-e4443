using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MultiRangeTrackBarControlExample {
    public class MultiTrackBarViewInfo : TrackBarViewInfo {
        public MultiTrackBarViewInfo(RepositoryItem item) : base(item) {
            CreateThumbs();
        }

        public override TrackBarObjectPainter GetTrackPainter() {
            return new MultiTrackBarObjectPainter(LookAndFeel);
        }

        public new RepositoryItemMultiTrackBar Item => base.Item as RepositoryItemMultiTrackBar;

        public CustomThumb[] Thumbs { get; protected set; }

        public override void CalcViewInfo(Graphics g) {
            base.CalcViewInfo(g);
            CreateThumbs();
        }

        public override void Offset(int x, int y) {
            base.Offset(x, y);
            foreach (CustomThumb thumb in Thumbs) {
                Point p = thumb.Position;
                p.Offset(x, y);
                thumb.Position = p;

                Rectangle b = thumb.Bounds;
                b.Offset(x, y);
                thumb.Bounds = b;
            }
        }

        public void CreateThumbs(object editValue = null) {
            var list = EditValue as IEnumerable<int>;
            if (list == null) {
                Thumbs = new CustomThumb[0];
                return;
            }

            Thumbs = list.Select(CalcThumb).ToArray();
        }

        public void SetThumbValue(int index, int newValue) {
            Thumbs[index] = CalcThumb(newValue);
        }

        public override EditHitInfo CalcHitInfo(Point p) {
            return CreateHitInfo(p);
        }

        protected override ObjectState CalcObjectState() {
            var edit = OwnerEdit as MultiRangeTrackBar;
            if (edit == null)
                return ObjectState.Normal;
            if (edit.ActiveThumbIndex != -1)
                return ObjectState.Hot;
            return ObjectState.Normal;
        }

        public void SetThumbPos(Point p) => ThumbPos = p;

        public new MultiTrackBarInfoCalculator TrackCalculator => base.TrackCalculator as MultiTrackBarInfoCalculator;

        private CustomThumb CalcThumb(int value) {
            Point thumbPos = CalcThumbPosCore(value);
            return new CustomThumb {
                Value = value,
                Position = thumbPos,
                Bounds = TrackCalculator.GetThumbBounds(thumbPos)
            };
        }
    }

    public class CustomThumb {
        public int Value { get; set; }
        public Point Position { get; set; }
        public Rectangle Bounds { get; set; }
    }
}
