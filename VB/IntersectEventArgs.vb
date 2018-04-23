Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace CustomRangeTrackBarControl
	Friend Class IntersectEventArgs
		Inherits EventArgs
		Private _ThumbType As ThumbType
		Public Property ThumbType() As ThumbType
			Get
				Return _ThumbType
			End Get
			Set(ByVal value As ThumbType)
				_ThumbType = value
			End Set
		End Property

		Private _DraggedThumb As Integer
		Public Property DraggedThumb() As Integer
			Get
				Return _DraggedThumb
			End Get
			Set(ByVal value As Integer)
				_DraggedThumb = value
			End Set
		End Property

		Private _Value As Integer
		Public Property Value() As Integer
			Get
				Return _Value
			End Get
			Set(ByVal value As Integer)
				_Value = value
			End Set
		End Property

		Public Sub New(ByVal thumbType_ As ThumbType, ByVal draggedThumb_ As Integer, ByVal value_ As Integer)
			_ThumbType = thumbType_
			_DraggedThumb = draggedThumb_
			_Value = value_
		End Sub
	End Class

	Public Enum ThumbType
		Minimum
		Maximum
	End Enum
End Namespace
