Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Collections
Imports DevExpress.XtraEditors.Repository

Namespace CustomRangeTrackBarControl
	Public Class RangeList
		Private list As List(Of TrackBarRange)

		Public Event ListChanged As EventHandler

		Public Sub New()
			list = New List(Of TrackBarRange)()
			list.Add(New TrackBarRange())
		End Sub

		Public Sub New(ByVal _list As RangeList)
			list = New List(Of TrackBarRange)()
			Me.Assign(_list)
		End Sub

		Public Function GetValue(ByVal index As Integer) As TrackBarRange
			Return list(index)
		End Function

		Public ReadOnly Property Count() As Integer
			Get
				Return list.Count
			End Get
		End Property

		Private Function CheckAdd(ByVal range As TrackBarRange) As Boolean
			For Each r As TrackBarRange In list
				If range.Maximum >= r.Minimum Then
					Return False
				End If
			Next r
			Return True
		End Function

		Private Function CheckChange(ByVal index As Integer, ByVal range As TrackBarRange) As Boolean
			Dim res As Boolean = True
			For i As Integer = index + 1 To list.Count - 1
				If range.Minimum <= list(i).Maximum Then
					res = False
				End If
			Next i
			For i As Integer = 0 To index - 1
				If range.Maximum >= list(i).Minimum Then
					res = False
				End If
			Next i
			Return res
		End Function

		Private Sub OnListChanged()
			RaiseEvent ListChanged(Me, New EventArgs())
		End Sub

		Public Sub Add(ByVal range As TrackBarRange)
			If CheckAdd(range) Then
				list.Add(range)
				OnListChanged()
			End If
		End Sub

		Public Sub ChangeValue(ByVal index As Integer, ByVal range As TrackBarRange)
			If CheckChange(index, range) Then
				list(index) = range
				OnListChanged()
			End If
		End Sub

		Public Function RemoveAt(ByVal index As Integer) As Boolean
			If index >= list.Count AndAlso index > 0 Then
				Return False
			End If
			list.RemoveAt(index)
			OnListChanged()
			Return True
		End Function

		Public Sub Remove(ByVal range As TrackBarRange)
			Dim index As Integer = -1
			For i As Integer = 0 To list.Count - 1
				If list(i) = range Then
					index = i
				End If
			Next i
			list.Remove(range)
			OnListChanged()
		End Sub

		Friend Sub Assign(ByVal newList As RangeList)
			list.Clear()
			For i As Integer = 0 To newList.Count - 1
				list.Add(newList.GetValue(i))
			Next i
		End Sub

		Public Sub Clear()
			Dim i As Integer = 1
			Do While i < list.Count
				list.RemoveAt(i)
				i += 1
			Loop
			OnListChanged()
		End Sub
	End Class
End Namespace
