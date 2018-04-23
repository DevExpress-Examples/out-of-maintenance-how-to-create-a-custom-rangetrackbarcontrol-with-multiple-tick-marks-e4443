Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.Skins
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.Utils.Drawing
Imports System.Drawing

Namespace CustomRangeTrackBarControl
	Friend Class MultiRangePainter
		Inherits RangeTrackBarPainter
		Public Sub New()
		End Sub
	End Class

	Friend Class MultipleTrackBarObjectPainter
		Inherits SkinRangeTrackBarObjectPainter
		Public Sub New(ByVal provider As DevExpress.Skins.ISkinProvider)
			MyBase.New(provider)
		End Sub

		Protected Overridable Sub DrawThumbs(ByVal e As TrackBarObjectInfoArgs)
			Dim vi As MultiRangeViewInfo = (TryCast(e.ViewInfo, MultiRangeViewInfo))
			Dim p As Point = vi.MaxThumbPos
			Dim list As RangeList = (TryCast(vi.EditValue, RangeList))
			For i As Integer = 0 To list.Count - 1
				Dim args As New TrackBarObjectInfoArgs(vi.TrackInfo.Appearance, vi)
				args.Cache = e.ViewInfo.TrackInfo.Cache
				vi.CurrentIndex += 1
				DrawRangeHighlight(args, e.ViewInfo.TrackBarHelper.Rotate(e.ViewInfo.TrackLineRect))
				DrawThumb(args)
			Next i
			vi.CurrentIndex = 0
		End Sub

		Public Overrides Sub DrawMaxThumb(ByVal e As TrackBarObjectInfoArgs, ByVal bMirror As Boolean)
			Dim ri As MultiRangeViewInfo = TryCast(e.ViewInfo, MultiRangeViewInfo)
			Dim maxInfo As SkinElementInfo = GetMaxThumbInfo(ri, e.State)
			If maxInfo Is Nothing Then
				Return
			End If
			maxInfo.Bounds = GetVerticalThumbRectangle(e.ViewInfo, ri.MaxThumbBounds)
			If ri.CurrentIndex = ri.DraggedThumb AndAlso ri.PressedInfo.HitTest = EditHitTest.Button2 Then
				maxInfo.State = ObjectState.Pressed
			End If
			CType(New RotateObjectPaintHelper(), RotateObjectPaintHelper).DrawRotated(e.Cache, maxInfo, SkinElementPainter.Default, GetRotateAngle(e.ViewInfo), True)
		End Sub

		Public Overrides Sub DrawMinThumb(ByVal e As TrackBarObjectInfoArgs, ByVal bMirror As Boolean)
			Dim ri As MultiRangeViewInfo = TryCast(e.ViewInfo, MultiRangeViewInfo)
			Dim minInfo As SkinElementInfo = GetMinThumbInfo(ri, e.State)
			If minInfo Is Nothing Then
				Return
			End If
			If ri.CurrentIndex = ri.DraggedThumb AndAlso ri.PressedInfo.HitTest = EditHitTest.Button Then
				minInfo.State = ObjectState.Pressed
			End If
			minInfo.Bounds = GetMinVerticalThumbRectangle(ri, ri.MinThumbBounds)
			CType(New RotateObjectPaintHelper(), RotateObjectPaintHelper).DrawRotated(e.Cache, minInfo, SkinElementPainter.Default, GetRotateAngle(e.ViewInfo), True)
		End Sub

		Public Overrides Overloads Sub DrawObject(ByVal e As DevExpress.Utils.Drawing.ObjectInfoArgs)
			Dim tbe As TrackBarObjectInfoArgs = TryCast(e, TrackBarObjectInfoArgs)
			DrawBackground(tbe)
			DrawTrackLine(tbe)
			If Me.AllowTick(tbe.ViewInfo) Then
				DrawPoints(tbe)
			End If
			TryCast(tbe.ViewInfo, MultiRangeViewInfo).CurrentIndex = -1
			DrawThumbs(tbe)
			If tbe.ViewInfo.Item.ShowLabels Then
				DrawLabels(tbe)
			End If
		End Sub

		Protected Overridable Sub DrawRangeHighlight(ByVal e As TrackBarObjectInfoArgs, ByVal bounds As Rectangle)
			Dim info As New SkinElementInfo(GetTrack(e.ViewInfo), bounds)
			Dim filled As Rectangle = GetFilledRect(e)
			Dim clipState As GraphicsClipState = e.Cache.ClipInfo.SaveAndSetClip(filled)
			If e.ViewInfo.Item.HighlightSelectedRange Then
				info.ImageIndex += 1
			End If
			CType(New RotateObjectPaintHelper(), RotateObjectPaintHelper).DrawRotated(e.Cache, info, SkinElementPainter.Default, GetTrackLineRotateAngle(e.ViewInfo))
			e.Cache.ClipInfo.RestoreClipRelease(clipState)
		End Sub

		Protected Overrides Sub DrawSkinTrackLineCore(ByVal e As TrackBarObjectInfoArgs, ByVal bounds As Rectangle)
			Dim info As New SkinElementInfo(GetTrack(e.ViewInfo), bounds)
			info.ImageIndex = If(e.State = ObjectState.Disabled, 2, 0)
			CType(New RotateObjectPaintHelper(), RotateObjectPaintHelper).DrawRotated(e.Cache, info, SkinElementPainter.Default, GetTrackLineRotateAngle(e.ViewInfo))
		End Sub

		Public Overrides Function GetFilledRect(ByVal e As TrackBarObjectInfoArgs) As Rectangle
			Dim ri As MultiRangeViewInfo = TryCast(e.ViewInfo, MultiRangeViewInfo)
			Dim rect As Rectangle = ri.TrackLineRect
			rect.X = ri.ThumbsPos(ri.CurrentIndex).Minimum.X
			rect.Width = ri.ThumbsPos(ri.CurrentIndex).Maximum.X - ri.ThumbsPos(ri.CurrentIndex).Minimum.X
			Return e.ViewInfo.TrackBarHelper.Rotate(rect)
		End Function

		Protected Overrides Function GetCalculator(ByVal viewInfo As TrackBarViewInfo) As TrackBarInfoCalculator
			Return New CustomCalculator(TryCast(viewInfo, RangeTrackBarViewInfo), Me)
		End Function
	End Class
End Namespace
