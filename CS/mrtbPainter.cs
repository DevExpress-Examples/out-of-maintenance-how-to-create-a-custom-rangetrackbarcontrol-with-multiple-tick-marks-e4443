using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Drawing;
using DevExpress.Skins;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Drawing;
using System.Drawing;

namespace CustomRangeTrackBarControl
{
    class MultiRangePainter : RangeTrackBarPainter
    {
        public MultiRangePainter()
        {
        }
    }

    class MultipleTrackBarObjectPainter : SkinRangeTrackBarObjectPainter
    {
        public MultipleTrackBarObjectPainter(DevExpress.Skins.ISkinProvider provider)
            : base(provider)
        { }

        protected virtual void DrawThumbs(TrackBarObjectInfoArgs e)
        {
            MultiRangeViewInfo vi = (e.ViewInfo as MultiRangeViewInfo);
            Point p = vi.MaxThumbPos;
            RangeList list = (vi.EditValue as RangeList);
            for (int i = 0; i < list.Count; i++ )
            {
                TrackBarObjectInfoArgs args = new TrackBarObjectInfoArgs(vi.TrackInfo.Appearance, vi);
                args.Cache = e.ViewInfo.TrackInfo.Cache;
                vi.CurrentIndex++;
                DrawRangeHighlight(args, e.ViewInfo.TrackBarHelper.Rotate(e.ViewInfo.TrackLineRect));
                DrawThumb(args);
            }
            vi.CurrentIndex = 0;
        }
        
        public override void DrawMaxThumb(TrackBarObjectInfoArgs e, bool bMirror)
        {
            MultiRangeViewInfo ri = e.ViewInfo as MultiRangeViewInfo;
            SkinElementInfo maxInfo = GetMaxThumbInfo(ri, e.State);
            if (maxInfo == null) return;
            maxInfo.Bounds = GetVerticalThumbRectangle(e.ViewInfo, ri.MaxThumbBounds);
            if (ri.CurrentIndex == ri.DraggedThumb && ri.PressedInfo.HitTest == EditHitTest.Button2)
                maxInfo.State = ObjectState.Pressed;
            new RotateObjectPaintHelper().DrawRotated(e.Cache, maxInfo, SkinElementPainter.Default, GetRotateAngle(e.ViewInfo), true);
        }

        public override void DrawMinThumb(TrackBarObjectInfoArgs e, bool bMirror)
        {
            MultiRangeViewInfo ri = e.ViewInfo as MultiRangeViewInfo;
            SkinElementInfo minInfo = GetMinThumbInfo(ri, e.State);
            if (minInfo == null) return;
            if (ri.CurrentIndex == ri.DraggedThumb && ri.PressedInfo.HitTest == EditHitTest.Button)
                minInfo.State = ObjectState.Pressed;
            minInfo.Bounds = GetMinVerticalThumbRectangle(ri, ri.MinThumbBounds);
            new RotateObjectPaintHelper().DrawRotated(e.Cache, minInfo, SkinElementPainter.Default, GetRotateAngle(e.ViewInfo), true);
        }

        public override void DrawObject(DevExpress.Utils.Drawing.ObjectInfoArgs e)
        {
            TrackBarObjectInfoArgs tbe = e as TrackBarObjectInfoArgs;
            DrawBackground(tbe);
            DrawTrackLine(tbe);
            if (this.AllowTick(tbe.ViewInfo))
                DrawPoints(tbe);
            (tbe.ViewInfo as MultiRangeViewInfo).CurrentIndex = -1;
            DrawThumbs(tbe);
            if (tbe.ViewInfo.Item.ShowLabels) DrawLabels(tbe);
        }

        protected virtual void DrawRangeHighlight(TrackBarObjectInfoArgs e, Rectangle bounds)
        {
            SkinElementInfo info = new SkinElementInfo(GetTrack(e.ViewInfo), bounds);
            Rectangle filled = GetFilledRect(e);
            GraphicsClipState clipState = e.Cache.ClipInfo.SaveAndSetClip(filled);
            if (e.ViewInfo.Item.HighlightSelectedRange)
                info.ImageIndex += 1;
            new RotateObjectPaintHelper().DrawRotated(e.Cache, info, SkinElementPainter.Default, GetTrackLineRotateAngle(e.ViewInfo));
            e.Cache.ClipInfo.RestoreClipRelease(clipState);
        }

        protected override void DrawSkinTrackLineCore(TrackBarObjectInfoArgs e, Rectangle bounds)
        {
            SkinElementInfo info = new SkinElementInfo(GetTrack(e.ViewInfo), bounds);
            info.ImageIndex = e.State == ObjectState.Disabled ? 2 : 0;
            new RotateObjectPaintHelper().DrawRotated(e.Cache, info, SkinElementPainter.Default, GetTrackLineRotateAngle(e.ViewInfo));
        }

        public override Rectangle GetFilledRect(TrackBarObjectInfoArgs e)
        {
            MultiRangeViewInfo ri = e.ViewInfo as MultiRangeViewInfo;
            Rectangle rect = ri.TrackLineRect;
            rect.X = ri.ThumbsPos[ri.CurrentIndex].Minimum.X;
            rect.Width = ri.ThumbsPos[ri.CurrentIndex].Maximum.X - ri.ThumbsPos[ri.CurrentIndex].Minimum.X;
            return e.ViewInfo.TrackBarHelper.Rotate(rect);
        }

        protected override TrackBarInfoCalculator GetCalculator(TrackBarViewInfo viewInfo)
        {
            return new CustomCalculator(viewInfo as RangeTrackBarViewInfo, this);
        }
    }
}
