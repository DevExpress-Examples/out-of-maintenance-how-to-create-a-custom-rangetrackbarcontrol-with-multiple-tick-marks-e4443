Imports DevExpress.Accessibility
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports System.Drawing

Namespace MultiRangeTrackBarControlExample

    <UserRepositoryItem("RegisterCustomTrackBar")>
    Public Class RepositoryItemMultiTrackBar
        Inherits RepositoryItemTrackBar

        Shared Sub New()
            Call RegisterCustomTrackBar()
        End Sub

        Public Const CustomEditName As String = "MultiRangeTrackBar"

        Public Sub New()
        End Sub

        Public Overrides ReadOnly Property EditorTypeName As String
            Get
                Return CustomEditName
            End Get
        End Property

        Public Shared Sub RegisterCustomTrackBar()
            Dim img As Image = Nothing
            Call EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(CustomEditName, GetType(MultiRangeTrackBar), GetType(RepositoryItemMultiTrackBar), GetType(MultiTrackBarViewInfo), New TrackBarPainter(), True, img, GetType(TrackBarAccessible)))
        End Sub

        Public Overrides Sub Assign(ByVal item As RepositoryItem)
            BeginUpdate()
            Try
                MyBase.Assign(item)
                Dim source As RepositoryItemMultiTrackBar = TryCast(item, RepositoryItemMultiTrackBar)
                If source Is Nothing Then Return
                DrawRanges = source.DrawRanges
            Finally
                EndUpdate()
            End Try
        End Sub

        Public Property DrawRanges As Boolean = True
    End Class
End Namespace
