Imports DevExpress.Skins
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports System.Drawing
Imports System.Windows.Forms

Namespace MultiRangeTrackBarControlExample

    Public Class MultiTrackBarObjectPainter
        Inherits SkinTrackBarObjectPainter

        Public Sub New(ByVal provider As ISkinProvider)
            MyBase.New(provider)
        End Sub

        Public Overrides Sub DrawTrackLine(ByVal e As TrackBarObjectInfoArgs)
            Dim viewInfo As MultiTrackBarViewInfo = TryCast(e.ViewInfo, MultiTrackBarViewInfo)
            viewInfo.SetThumbPos(Point.Empty)
            MyBase.DrawTrackLine(e)
        End Sub

        Public Overrides Sub DrawThumb(ByVal e As TrackBarObjectInfoArgs)
            Dim viewInfo As MultiTrackBarViewInfo = TryCast(e.ViewInfo, MultiTrackBarViewInfo)
            For Each thumb In viewInfo.Thumbs
                viewInfo.SetThumbPos(thumb.Position)
                MyBase.DrawThumb(e)
            Next
        End Sub

        Const trackLineRadius As Integer = 8

        Protected Overrides Sub DrawSkinTrackLineCore(ByVal e As TrackBarObjectInfoArgs, ByVal bounds As Rectangle)
            Dim viewInfo As MultiTrackBarViewInfo = TryCast(e.ViewInfo, MultiTrackBarViewInfo)
            Dim trackElement = GetTrack(viewInfo)
            If trackElement Is Nothing Then Return
            Dim trackElementInfo = New SkinElementInfo(trackElement, bounds)
            Call DrawObject(e.Cache, SkinElementPainter.Default, trackElementInfo)
            If viewInfo.Item.DrawRanges Then
                bounds.Y -= trackLineRadius
                bounds.Height += trackLineRadius * 2
                trackElementInfo.ImageIndex = 1
                For i As Integer = 0 To viewInfo.Thumbs.Length - 1 - 1 Step 2
                    Dim start As Integer = viewInfo.Thumbs(i).Position.X
                    Dim [end] As Integer = viewInfo.Thumbs(i + 1).Position.X
                    trackElementInfo.Bounds = New Rectangle(start, bounds.Y, [end] - start, bounds.Height)
                    Call DrawObject(e.Cache, SkinElementPainter.Default, trackElementInfo)
                Next
            End If
        End Sub

        Protected Overrides Function GetCalculator(ByVal viewInfo As TrackBarViewInfo) As TrackBarInfoCalculator
            Return New MultiTrackBarInfoCalculator(viewInfo, Me)
        End Function
    End Class

    Public Class MultiTrackBarInfoCalculator
        Inherits TrackBarSkinInfoCalculator

        Public Sub New(ByVal viewInfo As TrackBarViewInfo, ByVal trackPainter As SkinTrackBarObjectPainter)
            MyBase.New(viewInfo, trackPainter)
        End Sub

        Public Overloads Function GetThumbBounds(ByVal thumbPos As Point) As Rectangle
            Dim pt As Point = GetSkinThumbElementOffset()
            Dim rect As Rectangle = Rectangle.Empty
            If ViewInfo.TickStyle = TickStyle.TopLeft Then
                rect = New Rectangle(New Point(thumbPos.X - pt.X, GetThumbY()), GetSkinThumbElementSize())
            Else
                rect = New Rectangle(New Point(thumbPos.X - pt.X, GetThumbY()), GetSkinThumbElementSize())
            End If

            Return ViewInfo.TrackBarHelper.Rotate(rect)
        End Function
    End Class
End Namespace
