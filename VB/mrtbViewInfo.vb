Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.LookAndFeel
Imports DevExpress.Utils
Imports System.Drawing

Namespace CustomRangeTrackBarControl
	Friend Class MultiRangeViewInfo
		Inherits RangeTrackBarViewInfo
		Public Sub New(ByVal item As DevExpress.XtraEditors.Repository.RepositoryItem)
			MyBase.New(item)
			_ThumbsPos = New List(Of PointRange)()
			_ThumbsPos.Add(New PointRange())
			_MaxThumbBoundses = New List(Of Rectangle)()
			_MaxThumbBoundses.Add(Me.MaxThumbBounds)
			_MinThumbBoundses = New List(Of Rectangle)()
			_MinThumbBoundses.Add(Me.MinThumbBounds)
			CurrentIndex = 0
			_DraggedThumb = -1
		End Sub
		Private _DraggedThumb As Integer
		Private _CurrentIndex As Integer
		Private _MinThumbBoundses As List(Of Rectangle)
		Private _MaxThumbBoundses As List(Of Rectangle)
		Private _ThumbsPos As List(Of PointRange)
		Private trackInfo_Renamed As TrackBarObjectInfoArgs
		Public Overrides Sub Reset()
			MyBase.Reset()
			Me.trackInfo_Renamed = New TrackBarObjectInfoArgs(PaintAppearance, Me)
		End Sub

		Public Shadows ReadOnly Property Item() As RepositoryItemMultipleRangeTrackBar
			Get
				Return TryCast(MyBase.Item, RepositoryItemMultipleRangeTrackBar)
			End Get
		End Property

		Public ReadOnly Property ThumbsPos() As List(Of PointRange)
			Get
				Return _ThumbsPos
			End Get
		End Property

		Public Property MaxThumbBoundses() As List(Of Rectangle)
			Get
				Return _MaxThumbBoundses
			End Get
			Set(ByVal value As List(Of Rectangle))
				_MaxThumbBoundses = value
			End Set
		End Property

		Public Property MinThumbBoundses() As List(Of Rectangle)
			Get
				Return _MinThumbBoundses
			End Get
			Set(ByVal value As List(Of Rectangle))
				_MinThumbBoundses = value
			End Set
		End Property

		Protected Overrides Sub CalcThumbPos()
			Dim ranges As RangeList = TryCast(EditValue, RangeList)
			If ranges IsNot Nothing Then
			For i As Integer = 0 To ranges.Count - 1
				If Me.ThumbsPos.Count <= i Then
					ThumbsPos.Add(New PointRange())
				End If
				Me.ThumbsPos(i).Maximum = CalcThumbPosCore(ranges.GetValue(i).Maximum)
				Me.ThumbsPos(i).Minimum = CalcThumbPosCore(ranges.GetValue(i).Minimum)
			Next i
			End If
		End Sub

		Public Property DraggedThumb() As Integer
			Get
				Return _DraggedThumb
			End Get
			Set(ByVal value As Integer)
				_DraggedThumb = value
			End Set
		End Property

		Private Sub ClearBoundses()
			If MaxThumbBoundses.Count > (TryCast(EditValue, RangeList)).Count Then
				Dim b As Integer = MaxThumbBoundses.Count - (TryCast(EditValue, RangeList)).Count
				Dim i As Integer = b
				Do While i < MaxThumbBoundses.Count
					MaxThumbBoundses.RemoveAt(i)
					MinThumbBoundses.RemoveAt(i)
					ThumbsPos.RemoveAt(i)
					i += 1
				Loop
			End If
		End Sub

		Public Overrides Function CalcHitInfo(ByVal p As Point) As EditHitInfo
			Dim p1 As Point = p
			Dim index As Integer = 0
			If Bounds.Contains(p) Then
				For i As Integer = 0 To MinThumbBoundses.Count - 1
					If MinThumbBoundses(i).Contains(p) Then
						If Me.DraggedThumb = -1 Then
							Me.DraggedThumb = i
						End If
						If Item.Orientation = System.Windows.Forms.Orientation.Horizontal Then
							p1.X = MinThumbBoundses(0).X + 1
						Else
							p1.Y = MinThumbBoundses(0).Y + 1
						End If
						index = i
						Exit For
					End If
				Next i
				For i As Integer = 0 To MaxThumbBoundses.Count - 1
					If MaxThumbBoundses(i).Contains(p) Then
						If Me.DraggedThumb = -1 Then ' for intersection
							Me.DraggedThumb = i
						End If
						If Item.Orientation = System.Windows.Forms.Orientation.Horizontal Then
							p1.X = MaxThumbBoundses(0).X + 1
						Else
							p1.Y = MaxThumbBoundses(0).Y + 1
						End If
						index = i
						Exit For
					End If
				Next i
			End If
			CurrentIndex = 0
			Dim hi As EditHitInfo = MyBase.CalcHitInfo(p1)
			CurrentIndex = index
			ClearBoundses()
			Return hi
		End Function

		Public Overrides ReadOnly Property TrackInfo() As TrackBarObjectInfoArgs
			Get
				Return TryCast(trackInfo_Renamed, TrackBarObjectInfoArgs)
			End Get
		End Property

		Public Property CurrentIndex() As Integer
			Get
				Return _CurrentIndex
			End Get
			Set(ByVal value As Integer)
				_CurrentIndex = value
			End Set
		End Property

		Public Overrides ReadOnly Property MaxThumbBounds() As Rectangle
			Get
				If Me.MaxThumbBoundses.Count > 0 Then
					If MaxThumbBoundses.Count <= CurrentIndex Then
						MaxThumbBoundses.Add(New Rectangle())
					End If
					Me.MaxThumbBoundses(Me.CurrentIndex) = (MyBase.TrackCalculator).GetMaxThumbBounds()
				End If
				Return (TrackCalculator).GetMaxThumbBounds()
			End Get
		End Property

		Public Overrides ReadOnly Property MinThumbBounds() As Rectangle
			Get
				If Me.MinThumbBoundses.Count > 0 Then
					If MinThumbBoundses.Count <= CurrentIndex Then
						MinThumbBoundses.Add(New Rectangle())
					End If
					Me.MinThumbBoundses(Me.CurrentIndex) = (MyBase.TrackCalculator).GetMinThumbBounds()
				End If
				Return (TrackCalculator).GetMinThumbBounds()
			End Get
		End Property

		Public Overrides Overloads Sub Offset(ByVal x As Integer, ByVal y As Integer)
			MyBase.Offset(x, y)
			For i As Integer = 0 To ThumbsPos.Count - 1
				ThumbsPos(i).Offset(x, y)
			Next i
		End Sub

		Public Overrides Function GetTrackPainter() As TrackBarObjectPainter
			If IsPrinting Then
				Return New RangeTrackBarObjectPainter()
			End If
			If Me.LookAndFeel.ActiveStyle = ActiveLookAndFeelStyle.WindowsXP Then
				Return New RangeTrackBarObjectPainter()
			End If
			If Me.LookAndFeel.ActiveStyle = ActiveLookAndFeelStyle.Skin Then
				Return New MultipleTrackBarObjectPainter(LookAndFeel.ActiveLookAndFeel)
			End If
			If Me.LookAndFeel.ActiveStyle = ActiveLookAndFeelStyle.Office2003 Then
				Return New Office2003RangeTrackBarObjectPainter()
			End If
			Return New RangeTrackBarObjectPainter()
		End Function
	End Class

	'*********************************************************************************************
	Friend Class CustomCalculator
		Inherits SkinRangeTrackBarInfoCalculator
		Public Sub New(ByVal viewInfo As RangeTrackBarViewInfo, ByVal painter As RangeTrackBarObjectPainter)
			MyBase.New(viewInfo, painter)
		End Sub

		Public Overrides Function GetMaxThumbBounds() As Rectangle
			Dim view As MultiRangeViewInfo = TryCast(Me.ViewInfo, MultiRangeViewInfo)
			Dim rect As New Rectangle(New Point(view.ThumbsPos(view.CurrentIndex).Maximum.X, GetThumbY()), GetThumbElementSize())
			Return ViewInfo.TrackBarHelper.Rotate(rect)
		End Function

		Public Overrides Function GetMinThumbBounds() As Rectangle
			Dim view As MultiRangeViewInfo = TryCast(Me.ViewInfo, MultiRangeViewInfo)
			Dim rect As New Rectangle(New Point(view.ThumbsPos(view.CurrentIndex).Minimum.X - GetThumbElementSize().Width, GetThumbY()), GetThumbElementSize())
			Return ViewInfo.TrackBarHelper.Rotate(rect)
		End Function
	End Class

	'*********************************************************************************************
	Public Class PointRange
		' Fields...
		Private _Maximum As Point
		Private _Minimum As Point

		Public Property Minimum() As Point
			Get
				Return _Minimum
			End Get
			Set(ByVal value As Point)
				_Minimum = value
			End Set
		End Property

		Public Sub Offset(ByVal x As Integer, ByVal y As Integer)
			_Minimum.Offset(x, y)
			_Maximum.Offset(x, y)
		End Sub

		Public Property Maximum() As Point
			Get
				Return _Maximum
			End Get
			Set(ByVal value As Point)
				_Maximum = value
			End Set
		End Property
		Public Overrides Function ToString() As String
			Return String.Format("Minimum = {0}; Maximum = {1}", Minimum, Maximum)
		End Function
	End Class
End Namespace