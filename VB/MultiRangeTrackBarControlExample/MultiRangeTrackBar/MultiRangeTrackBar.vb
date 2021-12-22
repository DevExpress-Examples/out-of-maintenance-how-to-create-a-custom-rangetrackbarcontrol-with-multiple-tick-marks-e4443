Imports DevExpress.XtraEditors
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Linq
Imports System.Windows.Forms

Namespace MultiRangeTrackBarControlExample
    <ToolboxItem(True)>
    Public Class MultiRangeTrackBar
        Inherits TrackBarControl

        Shared Sub New()
            RepositoryItemMultiTrackBar.RegisterCustomTrackBar()
        End Sub

        Public Sub New()
            fEditValue = CreateValues()
        End Sub

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Overloads ReadOnly Property Properties As RepositoryItemMultiTrackBar
            Get
                Return TryCast(MyBase.Properties, RepositoryItemMultiTrackBar)
            End Get
        End Property

        Public Overrides ReadOnly Property EditorTypeName As String
            Get
                Return RepositoryItemMultiTrackBar.CustomEditName
            End Get
        End Property

        Protected Overrides Function ConvertCheckValue(ByVal val As Object) As Object
            If TypeOf val Is IEnumerable(Of Integer) Then
                Return val
            Else
                Return fEditValue
            End If
        End Function

        Public ReadOnly Property Values As ObservableCollection(Of Integer)
            Get
                Dim lValues = TryCast(fEditValue, ObservableCollection(Of Integer))
                If lValues Is Nothing Then fEditValue = CreateValues()
                Return TryCast(fEditValue, ObservableCollection(Of Integer))
            End Get
        End Property

        Private Function CreateValues() As ObservableCollection(Of Integer)
            Dim valuesCollection = New ObservableCollection(Of Integer)()
            AddHandler valuesCollection.CollectionChanged, Sub(sender, e)
                                                               If AllowFireEditValueChanged Then
                                                                   RaiseEditValueChanged()
                                                                   RefreshValues()
                                                               End If
                                                           End Sub

            Return valuesCollection
        End Function

        Private Sub RefreshValues()
            ViewInfo.CalcViewInfo()
            Invalidate()
        End Sub

        Private Function ValuesValid(ByVal values As IEnumerable(Of Integer)) As Boolean
            Return values.All(Function(x) x >= Properties.Minimum AndAlso x <= Properties.Maximum)
        End Function

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Overrides Property EditValue As Object
            Get
                Return Values.ToList()
            End Get
            Set(ByVal value As Object)
                Dim values = TryCast(value, IEnumerable(Of Integer))

                If values IsNot Nothing AndAlso ValuesValid(values) Then
                    LockEditValueChanged()
                    Me.Values.Clear()

                    For Each item In values
                        Me.Values.Add(item)
                    Next

                    UnLockEditValueChanged()
                    RefreshValues()
                End If
            End Set
        End Property

        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            Dim value As Integer = ViewInfo.ValueFromPoint(e.Location)
            ActiveThumbIndex = Values.IndexOf(value)
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            MyBase.OnMouseMove(e)

            If ActiveThumbIndex <> -1 Then
                Dim valueFromPoint As Integer = ViewInfo.ValueFromPoint(e.Location)
                Dim minBound = If(ActiveThumbIndex > 0, Values(ActiveThumbIndex - 1), Properties.Minimum)
                Dim maxBound = If(ActiveThumbIndex < Values.Count - 1, Values(ActiveThumbIndex + 1), Properties.Maximum)
                Dim newValue = Math.Max(minBound, Math.Min(maxBound, valueFromPoint))
                Dim oldValue = Values(ActiveThumbIndex)

                If oldValue <> newValue Then
                    '
                    Values(ActiveThumbIndex) = newValue
                    TryCast(ViewInfo, MultiTrackBarViewInfo).SetThumbValue(ActiveThumbIndex, newValue)
                    Invalidate()
                End If
            End If
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            ActiveThumbIndex = -1
            MyBase.OnMouseUp(e)
        End Sub

        Public Property ActiveThumbIndex As Integer = -1
    End Class
End Namespace
