Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Utils.Controls
Imports DevExpress.XtraEditors

Namespace CustomRangeTrackBarControl
	Partial Public Class Form1
		Inherits Form
		Private ritem As RepositoryItemMultipleRangeTrackBar

		Public Sub New()
			InitializeComponent()
			SubscribeEvents()
			CustomizeButtons()
			SetGrid()
		End Sub

		Private Sub SetGrid()
			gridControl1.DataSource = GetData(1)
			ritem = New RepositoryItemMultipleRangeTrackBar()
			Dim ritem1 As New RepositoryItemRangeTrackBar()
			ritem.ShowValueToolTip = True
			Dim list As New RangeList()
			list.ChangeValue(0, New TrackBarRange(5, 7))
			gridView1.SetRowCellValue(0, "MyRitem", list)
			gridView1.Columns(0).ColumnEdit = ritem
			gridView1.Columns(1).ColumnEdit = ritem1
		End Sub

		Private Sub AddClick(ByVal sender As Object, ByVal e As EventArgs)
			Dim editor As MultipleRangeTrackBar = (TryCast((TryCast(sender, SimpleButton)).Tag, MultipleRangeTrackBar))
			If editor IsNot Nothing Then
				editor.AddNewRange(0, 0)
			End If
		End Sub

		Private Sub SetEditValueClick(ByVal sender As Object, ByVal e As EventArgs)
			Dim list As New RangeList()
			list.ChangeValue(0, New TrackBarRange(1, 4))
			list.Add(New TrackBarRange())
			gridView1.SetRowCellValue(0, gridView1.Columns(0), list)
		End Sub

		Private Sub RemoveClick(ByVal sender As Object, ByVal e As EventArgs)
			Dim editor As MultipleRangeTrackBar = (TryCast((TryCast(sender, SimpleButton)).Tag, MultipleRangeTrackBar))
			If editor IsNot Nothing Then
				editor.RemoveRange(1)
			End If
		End Sub

		Private Sub SubscribeEvents()
			AddHandler multiRangeForEvent.Intersect, AddressOf multiRangeForEvent_Intersect
			' buttons
			For Each ctrl As Control In Me.Controls
				If ctrl.Text = "Add a new range" Then
					AddHandler TryCast(ctrl, SimpleButton).Click, AddressOf AddClick
				End If
				If ctrl.Text = "Remove 1" Then
					AddHandler TryCast(ctrl, SimpleButton).Click, AddressOf RemoveClick
				End If
				If ctrl.Text = "Set edit value" Then
					AddHandler TryCast(ctrl, SimpleButton).Click, AddressOf SetEditValueClick
				End If
			Next ctrl
		End Sub

		Private Sub CustomizeMultiRanges()
			multiRangeForEvent.Properties.Maximum = 30
		End Sub

		Private Sub CustomizeButtons()
			simpleButton4.Tag = multiRangeForEvent
			btnMultiRangeEvent.Tag = multiRangeForEvent
			simpleButton2.Tag = multiRange1
			simpleButton5.Tag = multiRange1
			simpleButton7.Tag = multiRange2
			simpleButton6.Tag = multiRange2
			simpleButton9.Tag = multiRangeVertical
			simpleButton8.Tag = multiRangeVertical
			simpleButton1.Tag = gridView1
		End Sub

		Private Sub simpleButton3_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton3.Click
			Dim edit As MultipleRangeTrackBar = TryCast(gridView1.ActiveEditor, MultipleRangeTrackBar)
			If edit IsNot Nothing Then
				edit.AddNewRange()
			End If
		End Sub

		Private Sub multiRangeForEvent_Intersect(ByVal e As IntersectEventArgs)
			labelControl1.Text = String.Format("Intersect event: DraggedThumb = {0}; ThumbType = {1}; Value = {2}", e.DraggedThumb, e.ThumbType, e.Value)
		End Sub

		Private Function GetData(ByVal rows As Integer) As DataTable
			Dim dt As New DataTable()
			dt.Columns.Add("MyRitem", GetType(RangeList))
			dt.Columns.Add("Standard ritem", GetType(TrackBarRange))
			dt.Columns.Add("Info", GetType(String))
			For i As Integer = 0 To rows - 1
				dt.Rows.Add(New RangeList(), New TrackBarRange(0, i), "Info" & i.ToString())
			Next i
			Return dt
		End Function
	End Class
End Namespace
