Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.ViewInfo
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq

Namespace MultiRangeTrackBarControlExample
    Public Class MultiTrackBarViewInfo
        Inherits TrackBarViewInfo

        Private _Thumbs As MultiRangeTrackBarControlExample.CustomThumb()

        Public Sub New(ByVal item As RepositoryItem)
            MyBase.New(item)
            CreateThumbs()
        End Sub

        Public Overrides Function GetTrackPainter() As TrackBarObjectPainter
            Return New MultiTrackBarObjectPainter(LookAndFeel)
        End Function

        Public Overloads ReadOnly Property Item As RepositoryItemMultiTrackBar
            Get
                Return TryCast(MyBase.Item, RepositoryItemMultiTrackBar)
            End Get
        End Property

        Public Property Thumbs As CustomThumb()
            Get
                Return _Thumbs
            End Get
            Protected Set(ByVal value As CustomThumb())
                _Thumbs = value
            End Set
        End Property

        Public Overrides Sub CalcViewInfo(ByVal g As Graphics)
            MyBase.CalcViewInfo(g)
            CreateThumbs()
        End Sub

        Public Overrides Sub Offset(ByVal x As Integer, ByVal y As Integer)
            MyBase.Offset(x, y)

            For Each thumb In Thumbs
                Dim p = thumb.Position
                p.Offset(x, y)
                thumb.Position = p
                Dim b = thumb.Bounds
                b.Offset(x, y)
                thumb.Bounds = b
            Next
        End Sub

        Public Sub CreateThumbs()
            Dim list = TryCast(EditValue, IEnumerable(Of Integer))

            If list Is Nothing Then
                Thumbs = New CustomThumb(-1) {}
                Return
            End If

            Thumbs = list.Select(New Func(Of Integer, CustomThumb)(AddressOf CalcThumb)).ToArray()
        End Sub

        Public Sub SetThumbValue(ByVal index As Integer, ByVal newValue As Integer)
            Thumbs(index) = CalcThumb(newValue)
        End Sub

        Public Overrides Function CalcHitInfo(ByVal p As Point) As EditHitInfo
            Return CreateHitInfo(p)
        End Function

        Protected Overrides Function CalcObjectState() As ObjectState
            Dim edit = TryCast(OwnerEdit, MultiRangeTrackBar)
            If edit Is Nothing Then Return ObjectState.Normal
            If edit.ActiveThumbIndex <> -1 Then Return ObjectState.Hot
            Return ObjectState.Normal
        End Function

        Public Sub SetThumbPos(ByVal p As Point)
            ThumbPos = p
        End Sub

        Public Overloads ReadOnly Property TrackCalculator As MultiTrackBarInfoCalculator
            Get
                Return TryCast(MyBase.TrackCalculator, MultiTrackBarInfoCalculator)
            End Get
        End Property

        Private Function CalcThumb(ByVal value As Integer) As CustomThumb
            Dim thumbPos As Point = CalcThumbPosCore(value)
            Return New CustomThumb With {
                .Value = value,
                .Position = thumbPos,
                .Bounds = TrackCalculator.GetThumbBounds(thumbPos)
            }
        End Function
    End Class

    Public Class CustomThumb
        Public Property Value As Integer
        Public Property Position As Point
        Public Property Bounds As Rectangle
    End Class
End Namespace
