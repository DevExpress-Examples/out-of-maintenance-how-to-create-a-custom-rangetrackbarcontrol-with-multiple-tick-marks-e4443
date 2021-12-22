Namespace MultiRangeTrackBarControlExample

    Partial Class MainForm

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.Form1layoutControl1ConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
            Me.removeButton = New DevExpress.XtraEditors.SimpleButton()
            Me.addButton = New DevExpress.XtraEditors.SimpleButton()
            Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
            Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
            Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
            Me.multiRangeTrackBar = New MultiRangeTrackBarControlExample.MultiRangeTrackBar()
            Me.layoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
            CType((Me.Form1layoutControl1ConvertedLayout), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Form1layoutControl1ConvertedLayout.SuspendLayout()
            CType((Me.layoutControlGroup1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.layoutControlItem1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.layoutControlItem2), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.multiRangeTrackBar), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.multiRangeTrackBar.Properties), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.layoutControlItem3), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' Form1layoutControl1ConvertedLayout
            ' 
            Me.Form1layoutControl1ConvertedLayout.Controls.Add(Me.multiRangeTrackBar)
            Me.Form1layoutControl1ConvertedLayout.Controls.Add(Me.removeButton)
            Me.Form1layoutControl1ConvertedLayout.Controls.Add(Me.addButton)
            Me.Form1layoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Form1layoutControl1ConvertedLayout.Location = New System.Drawing.Point(0, 0)
            Me.Form1layoutControl1ConvertedLayout.Name = "Form1layoutControl1ConvertedLayout"
            Me.Form1layoutControl1ConvertedLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(628, 138, 650, 400)
            Me.Form1layoutControl1ConvertedLayout.Root = Me.layoutControlGroup1
            Me.Form1layoutControl1ConvertedLayout.Size = New System.Drawing.Size(580, 399)
            Me.Form1layoutControl1ConvertedLayout.TabIndex = 2
            ' 
            ' removeButton
            ' 
            Me.removeButton.Location = New System.Drawing.Point(291, 61)
            Me.removeButton.Name = "removeButton"
            Me.removeButton.Size = New System.Drawing.Size(277, 22)
            Me.removeButton.StyleController = Me.Form1layoutControl1ConvertedLayout
            Me.removeButton.TabIndex = 5
            Me.removeButton.Text = "Remove"
            AddHandler Me.removeButton.Click, New System.EventHandler(AddressOf Me.OnRemoveButtonClick)
            ' 
            ' addButton
            ' 
            Me.addButton.Location = New System.Drawing.Point(12, 61)
            Me.addButton.Name = "addButton"
            Me.addButton.Size = New System.Drawing.Size(275, 22)
            Me.addButton.StyleController = Me.Form1layoutControl1ConvertedLayout
            Me.addButton.TabIndex = 4
            Me.addButton.Text = "Add"
            AddHandler Me.addButton.Click, New System.EventHandler(AddressOf Me.OnAddButtonClick)
            ' 
            ' layoutControlGroup1
            ' 
            Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
            Me.layoutControlGroup1.GroupBordersVisible = False
            Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutControlItem1, Me.layoutControlItem2, Me.layoutControlItem3})
            Me.layoutControlGroup1.Name = "Root"
            Me.layoutControlGroup1.Size = New System.Drawing.Size(580, 399)
            Me.layoutControlGroup1.TextVisible = False
            ' 
            ' layoutControlItem1
            ' 
            Me.layoutControlItem1.Control = Me.addButton
            Me.layoutControlItem1.Location = New System.Drawing.Point(0, 49)
            Me.layoutControlItem1.Name = "layoutControlItem1"
            Me.layoutControlItem1.Size = New System.Drawing.Size(279, 330)
            Me.layoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
            Me.layoutControlItem1.TextVisible = False
            ' 
            ' layoutControlItem2
            ' 
            Me.layoutControlItem2.Control = Me.removeButton
            Me.layoutControlItem2.Location = New System.Drawing.Point(279, 49)
            Me.layoutControlItem2.Name = "layoutControlItem2"
            Me.layoutControlItem2.Size = New System.Drawing.Size(281, 330)
            Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
            Me.layoutControlItem2.TextVisible = False
            ' 
            ' multiRangeTrackBar
            ' 
            Me.multiRangeTrackBar.Location = New System.Drawing.Point(12, 12)
            Me.multiRangeTrackBar.Name = "multiRangeTrackBar"
            Me.multiRangeTrackBar.Properties.DrawRanges = True
            Me.multiRangeTrackBar.Properties.LabelAppearance.Options.UseTextOptions = True
            Me.multiRangeTrackBar.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.multiRangeTrackBar.Size = New System.Drawing.Size(556, 45)
            Me.multiRangeTrackBar.StyleController = Me.Form1layoutControl1ConvertedLayout
            Me.multiRangeTrackBar.TabIndex = 6
            ' 
            ' layoutControlItem3
            ' 
            Me.layoutControlItem3.Control = Me.multiRangeTrackBar
            Me.layoutControlItem3.Location = New System.Drawing.Point(0, 0)
            Me.layoutControlItem3.Name = "layoutControlItem3"
            Me.layoutControlItem3.Size = New System.Drawing.Size(560, 49)
            Me.layoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
            Me.layoutControlItem3.TextVisible = False
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(580, 399)
            Me.Controls.Add(Me.Form1layoutControl1ConvertedLayout)
            Me.Name = "MainForm"
            Me.Text = "MainForm"
            CType((Me.Form1layoutControl1ConvertedLayout), System.ComponentModel.ISupportInitialize).EndInit()
            Me.Form1layoutControl1ConvertedLayout.ResumeLayout(False)
            CType((Me.layoutControlGroup1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.layoutControlItem1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.layoutControlItem2), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.multiRangeTrackBar.Properties), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.multiRangeTrackBar), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.layoutControlItem3), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

#End Region
        Private Form1layoutControl1ConvertedLayout As DevExpress.XtraLayout.LayoutControl

        Private removeButton As DevExpress.XtraEditors.SimpleButton

        Private addButton As DevExpress.XtraEditors.SimpleButton

        Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup

        Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem

        Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem

        Private multiRangeTrackBar As MultiRangeTrackBarControlExample.MultiRangeTrackBar

        Private layoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    End Class
End Namespace
