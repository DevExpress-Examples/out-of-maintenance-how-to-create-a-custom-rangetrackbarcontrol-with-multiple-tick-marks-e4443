<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128619637/20.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4443)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MultiRangeTrackBar.cs](./CS/MultiRangeTrackBarControlExample/MultiRangeTrackBar/MultiRangeTrackBar.cs) (VB: [MultiRangeTrackBar.vb](./VB/MultiRangeTrackBarControlExample/MultiRangeTrackBar/MultiRangeTrackBar.vb))
* [RepositoryItemMultiTrackBar.cs](./CS/MultiRangeTrackBarControlExample/MultiRangeTrackBar/RepositoryItemMultiTrackBar.cs) (VB: [RepositoryItemMultiTrackBar.vb](./VB/MultiRangeTrackBarControlExample/MultiRangeTrackBar/RepositoryItemMultiTrackBar.vb))
* [MultiTrackBarViewInfo.cs](./CS/MultiRangeTrackBarControlExample/MultiRangeTrackBar/MultiTrackBarViewInfo.cs) (VB: [MultiTrackBarViewInfo.vb](./VB/MultiRangeTrackBarControlExample/MultiRangeTrackBar/MultiTrackBarViewInfo.vb))
* [MultiTrackBarObjectPainter.cs](./CS/MultiRangeTrackBarControlExample/MultiRangeTrackBar/MultiTrackBarObjectPainter.cs) (VB: [MultiTrackBarObjectPainter.vb](./VB/MultiRangeTrackBarControlExample/MultiRangeTrackBar/MultiTrackBarObjectPainter.vb))
* [MainForm.cs](./CS/MultiRangeTrackBarControlExample/MainForm.cs) (VB: [MainForm.vb](./VB/MultiRangeTrackBarControlExample/MainForm.vb))
<!-- default file list end -->
# How to create a custom RangeTrackBarControl with multiple tick marks.

This example illustrates how to draw and handle multiple tick marks in a custom `TrackBarControl`.

* Tick marks are stored in the **MultiRangeTrackBar.Value** property (of the [ObservableCollection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1) type). Each element represents a tick mark, and its value represents its position. New tick marks can be created by adding their positions to the collection. Elements must be ordered by their values.
* Each tick mark's position is limited by its neighboring tick marks' positions. This behavior is defined in the **MultiRangeTrackBar.OnMouseMove** button, and it can be changed depending on the usage scenario.
* The ranges in this example are purely visual, and are drawn between each pair of tick marks. This can be disabled using the **RepositoryItemMultiTrackBar.DrawRanges** property.
* Due to the use of the **ObservableCollection** type for the editor's value, it may work incorrectly in in-place mode.

