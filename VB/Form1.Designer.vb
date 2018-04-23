Imports Microsoft.VisualBasic
Imports System
Namespace CustomRangeTrackBarControl
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim rangeList1 As New CustomRangeTrackBarControl.RangeList()
			Dim rangeList2 As New CustomRangeTrackBarControl.RangeList()
			Dim rangeList3 As New CustomRangeTrackBarControl.RangeList()
			Dim trackBarLabel1 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel2 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel3 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel4 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel5 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel6 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel7 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel8 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel9 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel10 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel11 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel12 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel13 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel14 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel15 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel16 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel17 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel18 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel19 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel20 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel21 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel22 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel23 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel24 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel25 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel26 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel27 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel28 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel29 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel30 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim trackBarLabel31 As New DevExpress.XtraEditors.Repository.TrackBarLabel()
			Dim rangeList4 As New CustomRangeTrackBarControl.RangeList()
			Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
			Me.btnMultiRangeEvent = New DevExpress.XtraEditors.SimpleButton()
			Me.simpleButton4 = New DevExpress.XtraEditors.SimpleButton()
			Me.multiRangeVertical = New CustomRangeTrackBarControl.MultipleRangeTrackBar()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.multiRange2 = New CustomRangeTrackBarControl.MultipleRangeTrackBar()
			Me.multiRangeForEvent = New CustomRangeTrackBarControl.MultipleRangeTrackBar()
			Me.multiRange1 = New CustomRangeTrackBarControl.MultipleRangeTrackBar()
			Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
			Me.simpleButton2 = New DevExpress.XtraEditors.SimpleButton()
			Me.simpleButton5 = New DevExpress.XtraEditors.SimpleButton()
			Me.simpleButton6 = New DevExpress.XtraEditors.SimpleButton()
			Me.simpleButton7 = New DevExpress.XtraEditors.SimpleButton()
			Me.simpleButton8 = New DevExpress.XtraEditors.SimpleButton()
			Me.simpleButton9 = New DevExpress.XtraEditors.SimpleButton()
			Me.simpleButton3 = New DevExpress.XtraEditors.SimpleButton()
			Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
			CType(Me.multiRangeVertical, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.multiRangeVertical.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.multiRange2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.multiRange2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.multiRangeForEvent, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.multiRangeForEvent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.multiRange1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.multiRange1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' simpleButton1
			' 
			Me.simpleButton1.Location = New System.Drawing.Point(207, 417)
			Me.simpleButton1.Name = "simpleButton1"
			Me.simpleButton1.Size = New System.Drawing.Size(297, 45)
			Me.simpleButton1.TabIndex = 1
			Me.simpleButton1.Text = "Set edit value"
			' 
			' btnMultiRangeEvent
			' 
			Me.btnMultiRangeEvent.Location = New System.Drawing.Point(844, 12)
			Me.btnMultiRangeEvent.Name = "btnMultiRangeEvent"
			Me.btnMultiRangeEvent.Size = New System.Drawing.Size(100, 45)
			Me.btnMultiRangeEvent.TabIndex = 2
			Me.btnMultiRangeEvent.Text = "Add a new range"
			' 
			' simpleButton4
			' 
			Me.simpleButton4.Location = New System.Drawing.Point(950, 12)
			Me.simpleButton4.Name = "simpleButton4"
			Me.simpleButton4.Size = New System.Drawing.Size(100, 45)
			Me.simpleButton4.TabIndex = 5
			Me.simpleButton4.Text = "Remove 1"
			' 
			' multiRangeVertical
			' 
			Me.multiRangeVertical.EditValue = rangeList1
			Me.multiRangeVertical.Location = New System.Drawing.Point(24, 207)
			Me.multiRangeVertical.Name = "multiRangeVertical"
			Me.multiRangeVertical.Properties.Orientation = System.Windows.Forms.Orientation.Vertical
			Me.multiRangeVertical.Properties.ShowValueToolTip = True
			Me.multiRangeVertical.Size = New System.Drawing.Size(45, 339)
			Me.multiRangeVertical.TabIndex = 6
			' 
			' gridControl1
			' 
			Me.gridControl1.Location = New System.Drawing.Point(207, 207)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(636, 204)
			Me.gridControl1.TabIndex = 7
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
			' 
			' multiRange2
			' 
			Me.multiRange2.EditValue = rangeList2
			Me.multiRange2.Location = New System.Drawing.Point(23, 156)
			Me.multiRange2.Name = "multiRange2"
			Me.multiRange2.Properties.LookAndFeel.SkinName = "Metropolis"
			Me.multiRange2.Properties.LookAndFeel.UseDefaultLookAndFeel = False
			Me.multiRange2.Properties.ShowValueToolTip = True
			Me.multiRange2.Size = New System.Drawing.Size(819, 45)
			Me.multiRange2.TabIndex = 10
			' 
			' multiRangeForEvent
			' 
			Me.multiRangeForEvent.EditValue = rangeList3
			Me.multiRangeForEvent.Location = New System.Drawing.Point(23, 12)
			Me.multiRangeForEvent.Name = "multiRangeForEvent"
			trackBarLabel1.Label = "0"
			trackBarLabel2.Label = "1"
			trackBarLabel2.Value = 1
			trackBarLabel3.Label = "2"
			trackBarLabel3.Value = 2
			trackBarLabel4.Label = "3"
			trackBarLabel4.Value = 3
			trackBarLabel5.Label = "4"
			trackBarLabel5.Value = 4
			trackBarLabel6.Label = "5"
			trackBarLabel6.Value = 5
			trackBarLabel7.Label = "6"
			trackBarLabel7.Value = 6
			trackBarLabel8.Label = "7"
			trackBarLabel8.Value = 7
			trackBarLabel9.Label = "8"
			trackBarLabel9.Value = 8
			trackBarLabel10.Label = "9"
			trackBarLabel10.Value = 9
			trackBarLabel11.Label = "10"
			trackBarLabel11.Value = 10
			trackBarLabel12.Label = "11"
			trackBarLabel12.Value = 11
			trackBarLabel13.Label = "12"
			trackBarLabel13.Value = 12
			trackBarLabel14.Label = "13"
			trackBarLabel14.Value = 13
			trackBarLabel15.Label = "14"
			trackBarLabel15.Value = 14
			trackBarLabel16.Label = "15"
			trackBarLabel16.Value = 15
			trackBarLabel17.Label = "16"
			trackBarLabel17.Value = 16
			trackBarLabel18.Label = "17"
			trackBarLabel18.Value = 17
			trackBarLabel19.Label = "18"
			trackBarLabel19.Value = 18
			trackBarLabel20.Label = "19"
			trackBarLabel20.Value = 19
			trackBarLabel21.Label = "20"
			trackBarLabel21.Value = 20
			trackBarLabel22.Label = "21"
			trackBarLabel22.Value = 21
			trackBarLabel23.Label = "22"
			trackBarLabel23.Value = 22
			trackBarLabel24.Label = "23"
			trackBarLabel24.Value = 23
			trackBarLabel25.Label = "24"
			trackBarLabel25.Value = 24
			trackBarLabel26.Label = "25"
			trackBarLabel26.Value = 25
			trackBarLabel27.Label = "26"
			trackBarLabel27.Value = 26
			trackBarLabel28.Label = "27"
			trackBarLabel28.Value = 27
			trackBarLabel29.Label = "28"
			trackBarLabel29.Value = 28
			trackBarLabel30.Label = "29"
			trackBarLabel30.Value = 29
			trackBarLabel31.Label = "30"
			trackBarLabel31.Value = 30
			Me.multiRangeForEvent.Properties.Labels.AddRange(New DevExpress.XtraEditors.Repository.TrackBarLabel() { trackBarLabel1, trackBarLabel2, trackBarLabel3, trackBarLabel4, trackBarLabel5, trackBarLabel6, trackBarLabel7, trackBarLabel8, trackBarLabel9, trackBarLabel10, trackBarLabel11, trackBarLabel12, trackBarLabel13, trackBarLabel14, trackBarLabel15, trackBarLabel16, trackBarLabel17, trackBarLabel18, trackBarLabel19, trackBarLabel20, trackBarLabel21, trackBarLabel22, trackBarLabel23, trackBarLabel24, trackBarLabel25, trackBarLabel26, trackBarLabel27, trackBarLabel28, trackBarLabel29, trackBarLabel30, trackBarLabel31})
			Me.multiRangeForEvent.Properties.LookAndFeel.SkinName = "Office 2010 Blue"
			Me.multiRangeForEvent.Properties.LookAndFeel.UseDefaultLookAndFeel = False
			Me.multiRangeForEvent.Properties.Maximum = 30
			Me.multiRangeForEvent.Properties.ShowLabels = True
			Me.multiRangeForEvent.Size = New System.Drawing.Size(820, 72)
			Me.multiRangeForEvent.TabIndex = 11
			' 
			' multiRange1
			' 
			Me.multiRange1.EditValue = rangeList4
			Me.multiRange1.Location = New System.Drawing.Point(23, 96)
			Me.multiRange1.Name = "multiRange1"
			Me.multiRange1.Properties.LookAndFeel.SkinName = "DevExpress Dark Style"
			Me.multiRange1.Properties.LookAndFeel.UseDefaultLookAndFeel = False
			Me.multiRange1.Properties.TickStyle = System.Windows.Forms.TickStyle.Both
			Me.multiRange1.Size = New System.Drawing.Size(819, 45)
			Me.multiRange1.TabIndex = 12
			' 
			' labelControl1
			' 
			Me.labelControl1.Location = New System.Drawing.Point(24, 63)
			Me.labelControl1.Name = "labelControl1"
			Me.labelControl1.Size = New System.Drawing.Size(79, 13)
			Me.labelControl1.TabIndex = 13
			Me.labelControl1.Text = "Intersect event:"
			' 
			' simpleButton2
			' 
			Me.simpleButton2.Location = New System.Drawing.Point(950, 96)
			Me.simpleButton2.Name = "simpleButton2"
			Me.simpleButton2.Size = New System.Drawing.Size(100, 45)
			Me.simpleButton2.TabIndex = 15
			Me.simpleButton2.Text = "Remove 1"
			' 
			' simpleButton5
			' 
			Me.simpleButton5.Location = New System.Drawing.Point(844, 96)
			Me.simpleButton5.Name = "simpleButton5"
			Me.simpleButton5.Size = New System.Drawing.Size(100, 45)
			Me.simpleButton5.TabIndex = 14
			Me.simpleButton5.Text = "Add a new range"
			' 
			' simpleButton6
			' 
			Me.simpleButton6.Location = New System.Drawing.Point(950, 156)
			Me.simpleButton6.Name = "simpleButton6"
			Me.simpleButton6.Size = New System.Drawing.Size(100, 45)
			Me.simpleButton6.TabIndex = 17
			Me.simpleButton6.Text = "Remove 1"
			' 
			' simpleButton7
			' 
			Me.simpleButton7.Location = New System.Drawing.Point(844, 156)
			Me.simpleButton7.Name = "simpleButton7"
			Me.simpleButton7.Size = New System.Drawing.Size(100, 45)
			Me.simpleButton7.TabIndex = 16
			Me.simpleButton7.Text = "Add a new range"
			' 
			' simpleButton8
			' 
			Me.simpleButton8.Location = New System.Drawing.Point(75, 449)
			Me.simpleButton8.Name = "simpleButton8"
			Me.simpleButton8.Size = New System.Drawing.Size(100, 45)
			Me.simpleButton8.TabIndex = 19
			Me.simpleButton8.Text = "Remove 1"
			' 
			' simpleButton9
			' 
			Me.simpleButton9.Location = New System.Drawing.Point(75, 398)
			Me.simpleButton9.Name = "simpleButton9"
			Me.simpleButton9.Size = New System.Drawing.Size(100, 45)
			Me.simpleButton9.TabIndex = 18
			Me.simpleButton9.Text = "Add a new range"
			' 
			' simpleButton3
			' 
			Me.simpleButton3.AllowFocus = False
			Me.simpleButton3.Location = New System.Drawing.Point(545, 417)
			Me.simpleButton3.Name = "simpleButton3"
			Me.simpleButton3.Size = New System.Drawing.Size(297, 45)
			Me.simpleButton3.TabIndex = 20
			Me.simpleButton3.Text = "Add a new range"
'			Me.simpleButton3.Click += New System.EventHandler(Me.simpleButton3_Click_1);
			' 
			' labelControl2
			' 
			Me.labelControl2.Location = New System.Drawing.Point(550, 474)
			Me.labelControl2.Name = "labelControl2"
			Me.labelControl2.Size = New System.Drawing.Size(150, 13)
			Me.labelControl2.TabIndex = 21
			Me.labelControl2.Text = "choose the first cell before click"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1141, 558)
			Me.Controls.Add(Me.labelControl2)
			Me.Controls.Add(Me.simpleButton3)
			Me.Controls.Add(Me.simpleButton8)
			Me.Controls.Add(Me.simpleButton9)
			Me.Controls.Add(Me.simpleButton6)
			Me.Controls.Add(Me.simpleButton7)
			Me.Controls.Add(Me.simpleButton2)
			Me.Controls.Add(Me.simpleButton5)
			Me.Controls.Add(Me.labelControl1)
			Me.Controls.Add(Me.multiRange1)
			Me.Controls.Add(Me.multiRangeForEvent)
			Me.Controls.Add(Me.multiRange2)
			Me.Controls.Add(Me.gridControl1)
			Me.Controls.Add(Me.multiRangeVertical)
			Me.Controls.Add(Me.simpleButton4)
			Me.Controls.Add(Me.btnMultiRangeEvent)
			Me.Controls.Add(Me.simpleButton1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.multiRangeVertical.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.multiRangeVertical, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.multiRange2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.multiRange2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.multiRangeForEvent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.multiRangeForEvent, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.multiRange1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.multiRange1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private simpleButton1 As DevExpress.XtraEditors.SimpleButton
		Private btnMultiRangeEvent As DevExpress.XtraEditors.SimpleButton
		Private simpleButton4 As DevExpress.XtraEditors.SimpleButton
		Private multiRangeVertical As MultipleRangeTrackBar
		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private multiRange2 As MultipleRangeTrackBar
		Private multiRangeForEvent As MultipleRangeTrackBar
		Private multiRange1 As MultipleRangeTrackBar
		Private labelControl1 As DevExpress.XtraEditors.LabelControl
		Private simpleButton2 As DevExpress.XtraEditors.SimpleButton
		Private simpleButton5 As DevExpress.XtraEditors.SimpleButton
		Private simpleButton6 As DevExpress.XtraEditors.SimpleButton
		Private simpleButton7 As DevExpress.XtraEditors.SimpleButton
		Private simpleButton8 As DevExpress.XtraEditors.SimpleButton
		Private simpleButton9 As DevExpress.XtraEditors.SimpleButton
		Private WithEvents simpleButton3 As DevExpress.XtraEditors.SimpleButton
		Private labelControl2 As DevExpress.XtraEditors.LabelControl


	End Class
End Namespace

