Imports System
Imports System.Linq

Namespace MultiRangeTrackBarControlExample
    Public Partial Class MainForm
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()

            ' Uncomment this line to disable drawing track lines.
            ' multiRangeTrackBar.Properties.DrawRanges = false;
        End Sub

        Private Sub OnAddButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles addButton.Click
            Dim values = multiRangeTrackBar.Values
            Dim startingIndex As Integer = If(values.Count = 0, multiRangeTrackBar.Properties.Minimum, values.Last() + 1)
            Dim limitIndex As Integer = multiRangeTrackBar.Properties.Maximum

            If limitIndex - startingIndex > 0 Then
                values.Add(startingIndex)
                values.Add(startingIndex + 1)
            End If
        End Sub

        Private Sub OnRemoveButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles removeButton.Click
            If multiRangeTrackBar.Values.Count >= 2 Then
                multiRangeTrackBar.Values.RemoveAt(multiRangeTrackBar.Values.Count - 1)
                multiRangeTrackBar.Values.RemoveAt(multiRangeTrackBar.Values.Count - 1)
            End If
        End Sub
    End Class
End Namespace
