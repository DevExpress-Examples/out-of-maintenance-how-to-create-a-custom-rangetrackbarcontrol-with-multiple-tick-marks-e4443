using DevExpress.Skins;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using System.Drawing;
using System.Windows.Forms;

namespace MultiRangeTrackBarControlExample {
    public class MultiTrackBarObjectPainter : SkinTrackBarObjectPainter {
        public MultiTrackBarObjectPainter(ISkinProvider provider) : base(provider) {
        }

        public override void DrawTrackLine(TrackBarObjectInfoArgs e) {
            MultiTrackBarViewInfo viewInfo = e.ViewInfo as MultiTrackBarViewInfo;
            viewInfo.SetThumbPos(Point.Empty);
            base.DrawTrackLine(e);
        }

        public override void DrawThumb(TrackBarObjectInfoArgs e) {
            MultiTrackBarViewInfo viewInfo = e.ViewInfo as MultiTrackBarViewInfo;
            foreach (var thumb in viewInfo.Thumbs) {
                viewInfo.SetThumbPos(thumb.Position);
                base.DrawThumb(e);
            }
        }

        const int trackLineRadius = 8;

        protected override void DrawSkinTrackLineCore(TrackBarObjectInfoArgs e, Rectangle bounds) {
            MultiTrackBarViewInfo viewInfo = e.ViewInfo as MultiTrackBarViewInfo;
            var trackElement = GetTrack(viewInfo);
            if (trackElement == null)
                return;
            var trackElementInfo = new SkinElementInfo(trackElement, bounds);
            DrawObject(e.Cache, SkinElementPainter.Default, trackElementInfo);
            if (viewInfo.Item.DrawRanges) {
                bounds.Y -= trackLineRadius;
                bounds.Height += trackLineRadius * 2;
                trackElementInfo.ImageIndex = 1;
                for (int i = 0; i < viewInfo.Thumbs.Length - 1; i += 2) {
                    int start = viewInfo.Thumbs[i].Position.X;
                    int end = viewInfo.Thumbs[i + 1].Position.X;
                    trackElementInfo.Bounds = new Rectangle(start, bounds.Y, end - start, bounds.Height);
                    DrawObject(e.Cache, SkinElementPainter.Default, trackElementInfo);
                }
            }
        }

        protected override TrackBarInfoCalculator GetCalculator(TrackBarViewInfo viewInfo) {
            return new MultiTrackBarInfoCalculator(viewInfo, this);
        }
    }

    public class MultiTrackBarInfoCalculator : TrackBarSkinInfoCalculator {
        public MultiTrackBarInfoCalculator(TrackBarViewInfo viewInfo, SkinTrackBarObjectPainter trackPainter) : base(viewInfo, trackPainter) {
        }

        public Rectangle GetThumbBounds(Point thumbPos) {
            Point pt = GetSkinThumbElementOffset();
            Rectangle rect = Rectangle.Empty;
            if (ViewInfo.TickStyle == TickStyle.TopLeft)
                rect = new Rectangle(new Point(thumbPos.X - pt.X, GetThumbY()), GetSkinThumbElementSize());
            else
                rect = new Rectangle(new Point(thumbPos.X - pt.X, GetThumbY()), GetSkinThumbElementSize());
            return ViewInfo.TrackBarHelper.Rotate(rect);
        }
    }
}
