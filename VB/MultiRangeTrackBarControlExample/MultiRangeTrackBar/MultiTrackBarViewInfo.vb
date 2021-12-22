Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.ViewInfo
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq

Namespace MultiRangeTrackBarControlExample

    Public Class MultiTrackBarViewInfo
        Inherits DevExpress.XtraEditors.ViewInfo.TrackBarViewInfo

        Private _Thumbs As MultiRangeTrackBarControlExample.CustomThumb()

        Public Sub New(ByVal item As DevExpress.XtraEditors.Repository.RepositoryItem)
            MyBase.New(item)
            Me.CreateThumbs()
        End Sub

        Public Overrides Function GetTrackPainter() As TrackBarObjectPainter
            Return New MultiRangeTrackBarControlExample.MultiTrackBarObjectPainter(Me.LookAndFeel)
        End Function

        Public Overloads ReadOnly Property Item As RepositoryItemMultiTrackBar
            Get
                Return TryCast(MyBase.Item, MultiRangeTrackBarControlExample.RepositoryItemMultiTrackBar)
            End Get
        End Property

        Public Property Thumbs As MultiRangeTrackBarControlExample.CustomThumb()
            Get
                Return _Thumbs
            End Get

            Protected Set(ByVal value As MultiRangeTrackBarControlExample.CustomThumb())
                _Thumbs = value
            End Set
        End Property

        Public Overrides Sub CalcViewInfo(ByVal g As System.Drawing.Graphics)
            MyBase.CalcViewInfo(g)
            Me.CreateThumbs()
        End Sub

        Public Overrides Sub Offset(ByVal x As Integer, ByVal y As Integer)
            MyBase.Offset(x, y)
            For Each thumb As MultiRangeTrackBarControlExample.CustomThumb In Me.Thumbs
                Dim p As System.Drawing.Point = thumb.Position
                p.Offset(x, y)
                thumb.Position = p
                Dim b As System.Drawing.Rectangle = thumb.Bounds
                b.Offset(x, y)
                thumb.Bounds = b
            Next
        End Sub

        Public Sub CreateThumbs(ByVal Optional editValue As Object = Nothing)
            Dim list = TryCast(Me.EditValue, System.Collections.Generic.IEnumerable(Of Integer))
            If list Is Nothing Then
                Me.Thumbs = New MultiRangeTrackBarControlExample.CustomThumb(-1) {}
                Return
            End If

            Me.Thumbs = list.[Select](New Global.System.Func(Of System.Int32, Global.MultiRangeTrackBarControlExample.CustomThumb)(AddressOf Me.CalcThumb)).ToArray()
        End Sub

        Public Sub SetThumbValue(ByVal index As Integer, ByVal newValue As Integer)
            Me.Thumbs(index) = Me.CalcThumb(newValue)
        End Sub

        Public Overrides Function CalcHitInfo(ByVal p As System.Drawing.Point) As EditHitInfo
            Return Me.CreateHitInfo(p)
        End Function

        Protected Overrides Function CalcObjectState() As ObjectState
            Dim edit = TryCast(Me.OwnerEdit, MultiRangeTrackBarControlExample.MultiRangeTrackBar)
            If edit Is Nothing Then Return DevExpress.Utils.Drawing.ObjectState.Normal
            If edit.ActiveThumbIndex <> -1 Then Return DevExpress.Utils.Drawing.ObjectState.Hot
            Return DevExpress.Utils.Drawing.ObjectState.Normal
        End Function

        Public Sub SetThumbPos(ByVal p As System.Drawing.Point)
            CSharpImpl.__Assign(Me.ThumbPos, p)
        End Sub

        Public Overloads ReadOnly Property TrackCalculator As MultiTrackBarInfoCalculator
            Get
                Return TryCast(MyBase.TrackCalculator, MultiRangeTrackBarControlExample.MultiTrackBarInfoCalculator)
            End Get
        End Property

        Private Function CalcThumb(ByVal value As Integer) As CustomThumb
            Dim thumbPos As System.Drawing.Point = Me.CalcThumbPosCore(value)
            Return New MultiRangeTrackBarControlExample.CustomThumb With {.Value = value, .Position = thumbPos, .Bounds = Me.TrackCalculator.GetThumbBounds(thumbPos)}
        End Function

        Private Class CSharpImpl

            <System.Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class

    Public Class CustomThumb

        Public Property Value As Integer

        Public Property Position As Point

        Public Property Bounds As Rectangle
    End Class
End Namespace
