Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator
Imports System.Drawing
Imports DevExpress.XtraEditors.Drawing

Namespace CustomRangeTrackBarControl
	<UserRepositoryItem("Register"), System.ComponentModel.DesignerCategory("None")> _
	Friend Class RepositoryItemMultipleRangeTrackBar
		Inherits RepositoryItemRangeTrackBar

		#Region "Register"
		Friend Const EditorName As String = "MultipleRangeTrackBar"

		Public Shared Sub Register()
            EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(EditorName, GetType(MultipleRangeTrackBar), GetType(RepositoryItemMultipleRangeTrackBar), GetType(MultiRangeViewInfo), New MultiRangePainter(), True))
		End Sub
		Shared Sub New()
			Register()
		End Sub
		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return EditorName
			End Get
		End Property
		#End Region

		Public Overrides Function ToString() As String
			Return "Ritem_" & EditorName
		End Function
	End Class
End Namespace
