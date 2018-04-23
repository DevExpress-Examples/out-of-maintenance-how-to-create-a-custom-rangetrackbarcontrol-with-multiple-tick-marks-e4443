Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports System.ComponentModel
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.ViewInfo
Imports System.Drawing
Imports DevExpress.XtraEditors.Controls

Namespace CustomRangeTrackBarControl
	<System.ComponentModel.DesignerCategory("None")> _
	Friend Class MultipleRangeTrackBar
		Inherits RangeTrackBarControl
		#Region "Initialization"
		Shared Sub New()
			RepositoryItemMultipleRangeTrackBar.Register()
		End Sub

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemMultipleRangeTrackBar.EditorName
			End Get
		End Property
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemMultipleRangeTrackBar
			Get
				Return TryCast(MyBase.Properties, RepositoryItemMultipleRangeTrackBar)
			End Get
		End Property

		Friend Shadows ReadOnly Property ViewInfo() As MultiRangeViewInfo
			Get
				Return TryCast(MyBase.ViewInfo, MultiRangeViewInfo)
			End Get
		End Property
		#End Region

		Public Sub New()
			If innerRanges Is Nothing Then
				innerRanges = New List(Of TrackBarRange)()
			End If
		End Sub

		Private Sub RefreshInnerRanges()
			Dim list As RangeList = CType(EditValue, RangeList)
			innerRanges.Clear()
			For i As Integer = 0 To list.Count - 1
				innerRanges.Add(list.GetValue(i))
			Next i
		End Sub

		Private lockEditValueChanged As Boolean = False
		Protected Overrides Sub OnEditValueChanged()
			If (Not lockEditValueChanged) Then
				MyBase.OnEditValueChanged()
				If innerRanges Is Nothing Then
					innerRanges = New List(Of TrackBarRange)()
				End If
				Dim list As RangeList = TryCast(EditValue, RangeList)
				RefreshInnerRanges()
			End If
		End Sub

		Private Function IsEqualEditValue(ByVal list As RangeList) As Boolean
			Dim editVal As RangeList = TryCast(EditValue, RangeList)
			If editVal.Count <> list.Count Then
				Return False
			End If
			For i As Integer = 0 To list.Count - 1
				If editVal.GetValue(i).Minimum <> list.GetValue(i).Minimum OrElse editVal.GetValue(i).Maximum <> list.GetValue(i).Maximum Then
					Return False
				End If
			Next i
			Return True
		End Function

		Protected Overrides Sub OnEditValueChanging(ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs)
			lockEditValueChanged = True
			MyBase.OnEditValueChanging(e)
			lockEditValueChanged = False
			If e.Cancel = False AndAlso (Not IsEqualEditValue((TryCast(e.NewValue, RangeList)))) Then
				editVal = TryCast(e.NewValue, RangeList)
				RefreshInnerRanges()
				OnEditValueChanged()
			End If
		End Sub

		Private Sub OnEditValueChangingCore(ByVal oldVal As RangeList, ByVal newVal As RangeList)
			Dim e As New ChangingEventArgs(oldVal, newVal)
			OnEditValueChanging(e)
		End Sub

		Private Sub CreateEditValue()
			editVal = New RangeList()
			AddHandler editVal.ListChanged, AddressOf editVal_ListChanged
		End Sub

		Private Sub editVal_ListChanged(ByVal sender As Object, ByVal e As EventArgs)
			Refresh()
		End Sub

		Private editVal As RangeList
		Public Overrides Property EditValue() As Object
			Get
				Return editVal
			End Get
			Set(ByVal value As Object)
				If editVal Is Nothing Then
					CreateEditValue()
				End If
				If value.GetType() Is GetType(TrackBarRange) Then
					editVal.ChangeValue(0, CType(value, TrackBarRange))
					OnEditValueChanged()
				Else
					If value.GetType() Is GetType(RangeList) Then
						OnEditValueChangingCore(editVal, TryCast(value, RangeList))
						AddHandler editVal.ListChanged, AddressOf editVal_ListChanged
						Refresh()
					End If
				End If
			End Set
		End Property
		#Region "Add, Remove, Get, Change"

		Private Function CheckAdd(ByVal maximum As Integer) As Boolean
			For Each range As TrackBarRange In innerRanges
				If range.Minimum <= maximum Then
					Return False
				End If
			Next range
			Return True
		End Function

		Private Function ConvertItem(ByVal item As TrackBarRange) As TrackBarRange
			Dim range As TrackBarRange = item
			range.Minimum = Math.Max(item.Minimum, Properties.Minimum)
			range.Maximum = Math.Min(item.Maximum, Properties.Maximum)
			Return range
		End Function

		Private Sub AddItem(ByVal item As TrackBarRange)
			Dim range As TrackBarRange = ConvertItem(item)
			Dim oldVal As New RangeList(CType(EditValue, RangeList))
			Dim newVal As New RangeList(oldVal)
			newVal.Add(item)
			OnEditValueChangingCore(oldVal, newVal)
		End Sub

		Private Sub ChangeItem(ByVal index As Integer, ByVal item As TrackBarRange)
			Dim range As TrackBarRange = ConvertItem(item)
			If innerRanges(index).Maximum <> item.Maximum OrElse innerRanges(index).Minimum <> item.Minimum Then
				Dim oldVal As New RangeList(CType(EditValue, RangeList))
				Dim newVal As New RangeList(oldVal)
				newVal.ChangeValue(index,item)
				OnEditValueChangingCore(oldVal, newVal)
			End If
		End Sub

		Private Sub RemoveItem(ByVal index As Integer)
			Dim oldVal As New RangeList(CType(EditValue, RangeList))
			Dim newVal As New RangeList(oldVal)
			newVal.RemoveAt(index)
			OnEditValueChangingCore(oldVal, newVal)
		End Sub

		Public Sub AddNewRange()
			AddNewRange(0, 0)
		End Sub

		Public Sub AddNewRange(ByVal minimum As Integer, ByVal maximum As Integer)
			Dim item As New TrackBarRange(minimum, maximum)
			If CheckAdd(item.Maximum) Then
				AddItem(item)
			End If
		End Sub

		Public Sub RemoveRange(ByVal index As Integer)
			If index > 0 AndAlso innerRanges.Count > index Then
				RemoveItem(index)
			End If
		End Sub

		Public Function GetValue(ByVal index As Integer) As TrackBarRange
			Return innerRanges(index)
		End Function

		Public Sub ChangeValue(ByVal range As TrackBarRange, ByVal index As Integer)
			If innerRanges.Count > index Then
				ChangeItem(index, range)
			End If
		End Sub

		Public Sub ChangeValue(ByVal minimum As Integer, ByVal maximum As Integer, ByVal index As Integer)
			Dim range As New TrackBarRange(minimum, maximum)
			ChangeValue(range, index)
		End Sub
		#End Region

		#Region "Intersection algorithm"
		Public Delegate Sub IntersectEventHandler(ByVal e As IntersectEventArgs)
		Public Event Intersect As IntersectEventHandler

		Private Sub OnIntersect(ByVal thumbType_ As ThumbType, ByVal draggedThumb_ As Integer, ByVal value_ As Integer)
			If IntersectEvent IsNot Nothing Then
				Dim e As New IntersectEventArgs(thumbType_, draggedThumb_, value_)
				RaiseEvent Intersect(e)
			End If
		End Sub

		Private Function CheckMinChange(ByVal startIndex As Integer, ByVal newMinValue As Integer, ByVal [raiseEvent] As Boolean) As Boolean
			Dim check As Boolean = True
			Dim thumb As Integer = 0
			If newMinValue < Properties.Minimum Then
				check = False
				[raiseEvent] = False
			End If
			For i As Integer = startIndex To innerRanges.Count - 1
				If innerRanges(i).Maximum >= newMinValue Then
					check = False
					thumb = i
					Exit For
				End If
			Next i
			If (Not check) AndAlso [raiseEvent] Then
				OnIntersect(ThumbType.Minimum, thumb - 1, innerRanges(thumb).Maximum)
			End If
			Return check
		End Function

		Private Function CheckMaxChange(ByVal lastIndex As Integer, ByVal newMaxValue As Integer, ByVal [raiseEvent] As Boolean) As Boolean
			Dim check As Boolean = True
			Dim thumb As Integer = 0
			If newMaxValue > Properties.Maximum Then
				check = False
				[raiseEvent] = False
			End If
			For i As Integer = 0 To lastIndex - 1
				If innerRanges(i).Minimum <= newMaxValue Then
					check = False
					thumb = i
					Exit For
				End If
			Next i
			If (Not check) AndAlso [raiseEvent] Then
				OnIntersect(ThumbType.Maximum, thumb + 1, innerRanges(thumb).Minimum)
			End If
			Return check
		End Function
		#End Region

		Protected Overridable Function ChangeMinThumbPosition(ByVal dragThumb As Integer, ByVal newMinValue As Integer) As TrackBarRange
			Dim range As TrackBarRange = innerRanges(dragThumb)
			If CheckMinChange(ViewInfo.DraggedThumb + 1, newMinValue, True) Then
				range = New TrackBarRange(newMinValue, innerRanges(ViewInfo.DraggedThumb).Maximum)
			End If
			Return range
		End Function

		Protected Overridable Function ChangeMaxThumbPosition(ByVal dragThumb As Integer, ByVal newMaxValue As Integer) As TrackBarRange
			Dim range As TrackBarRange = innerRanges(dragThumb)
			If CheckMaxChange(ViewInfo.DraggedThumb, newMaxValue, True) Then
				range = New TrackBarRange(innerRanges(ViewInfo.DraggedThumb).Minimum, newMaxValue)
			End If
			Return range
		End Function

		Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
			Dim ee As DXMouseEventArgs = DXMouseEventArgs.GetMouseArgs(e)
			If ee.Handled Then
				Return
			End If
			If Properties.ReadOnly Then
				Return
			End If
			If ViewInfo.PressedInfo.HitTest = EditHitTest.Button Then
				ChangeItem(ViewInfo.DraggedThumb, ChangeMinThumbPosition(ViewInfo.DraggedThumb, Math.Min(ViewInfo.ValueFromPoint(ViewInfo.ControlToClient(New Point(e.X, e.Y))), innerRanges(ViewInfo.DraggedThumb).Maximum)))
				ShowMinValue()
			ElseIf ViewInfo.PressedInfo.HitTest = EditHitTest.Button2 Then
				ChangeItem(ViewInfo.DraggedThumb, ChangeMaxThumbPosition(ViewInfo.DraggedThumb, Math.Max(innerRanges(ViewInfo.DraggedThumb).Minimum, ViewInfo.ValueFromPoint(ViewInfo.ControlToClient(New Point(e.X, e.Y))))))
				ShowMaxValue()
			End If
		End Sub

		Protected Overrides Sub ShowMaxValue()
			ShowValue(innerRanges(ViewInfo.DraggedThumb).ToString(), ViewInfo.MaxThumbBoundses(ViewInfo.DraggedThumb))
		End Sub

		Protected Overrides Sub ShowMinValue()
			ShowValue(innerRanges(ViewInfo.DraggedThumb).ToString(), ViewInfo.MinThumbBoundses(ViewInfo.DraggedThumb))
		End Sub

		Private Function GetClosestThumb(ByVal val As Integer) As Integer
			Dim value As Integer = 0
			Dim diff As Integer = Int32.MaxValue
			For i As Integer = 0 To innerRanges.Count - 1
				If Math.Abs(val - innerRanges(i).Minimum) < diff Then
					value = i * 2
					diff = Math.Abs(val - innerRanges(i).Minimum)
				End If
				If Math.Abs(val - innerRanges(i).Maximum) <= diff Then
					value = i * 2 + 1
					diff = Math.Abs(val - innerRanges(i).Maximum)
				End If
			Next i
			Return value
		End Function

		Protected Overrides Sub UpdateValueFromPoint(ByVal pt As Point)
			If ViewInfo.DraggedThumb < 0 Then
				If (Not ShouldUpdateValueFromPoint(pt)) Then
					Return
				End If
				Dim value As Integer = ViewInfo.ValueFromPoint(ViewInfo.ControlToClient(pt))
				Dim val As Integer = GetClosestThumb(value)
				If val Mod 2 = 0 Then
					ChangeValue(New TrackBarRange(value, innerRanges(val \ 2).Maximum), val \ 2)
				Else
					ChangeValue(New TrackBarRange(innerRanges(val \ 2).Minimum, value), val \ 2)
				End If
			End If
		End Sub

		Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
			MyBase.OnMouseUp(e)
			ViewInfo.DraggedThumb = -1
		End Sub

		Private innerRanges As List(Of TrackBarRange)

		Public ReadOnly Property ThumbsCount() As Integer
			Get
				Return innerRanges.Count
			End Get
		End Property
	End Class
End Namespace
