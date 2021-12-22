<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128619637/20.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4443)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [CustomRangeTrackBar.cs](./CS/CustomRangeTrackBar.cs) (VB: [CustomRangeTrackBar.vb](./VB/CustomRangeTrackBar.vb))
* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [IntersectEventArgs.cs](./CS/IntersectEventArgs.cs) (VB: [IntersectEventArgs.vb](./VB/IntersectEventArgs.vb))
* [mrtbPainter.cs](./CS/mrtbPainter.cs) (VB: [mrtbPainter.vb](./VB/mrtbPainter.vb))
* [mrtbViewInfo.cs](./CS/mrtbViewInfo.cs) (VB: [mrtbViewInfo.vb](./VB/mrtbViewInfo.vb))
* [RangeList.cs](./CS/RangeList.cs) (VB: [RangeList.vb](./VB/RangeList.vb))
* [ritem.cs](./CS/ritem.cs) (VB: [ritem.vb](./VB/ritem.vb))
<!-- default file list end -->
# How to create a custom RangeTrackBarControl with multiple tick marks.


<p>Sometimes it is useful to have the capability to edit multiple ranges using a single control. This can be introduced with a custom control – <strong>MultipleRangeTrackBar</strong>.</p><p>In this example we have implemented the following features and functionality:</p><p>    1) The capability to have multiple tick marks within this control.</p><p>    2) The <strong>EditValue </strong>property of this control is a special <strong>RangeList</strong><strong> </strong>class which contains a list of <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraEditorsRepositoryTrackBarRangeMembersTopicAll"><u>TrackBarRange</u></a> instances.</p><p>    3) A couple of methods are intended for  adding, changing and removing ticks:</p><p>        - <strong>AddNewRange</strong>(int minimum, int maximum) – add a new range at a specific position. If it intersects with one of the existing ranges it will not be created.</p><p>        - <strong>AddNewRange</strong>() – add a new range at the (0, 0) position. It has the same behavior as the previous method. </p><p>        - <strong>ChangeValue</strong>(int minimum, int maximum, int index) – changes the value of the thumb by a particular index in the EditValue’s list. The new value will be set to a new TracKBarRange object with a special minimum and maximum. If it intersects with one of the existing ranges it will not be changed.</p><p>        - <strong>ChangeValue</strong>(TrackBarRange range, int index) – The new value will be set to the range parameter. It has the same behavior as the previous method.</p><p>        - <strong>RemoveRange</strong>(int index) – removes the thumb, by a particular index in the EditValue’s list. The first range cannot be deleted. Calling this method with the 0 parameter will do nothing. </p><p>    4) The new <strong>EditValueChanged </strong>and the <strong>EditValueChanging </strong>events fire  after successful completion of any of the above methods. They also fire after changing the EditValue with a new RangeList instance.</p><p>    5) The <strong>Intersect </strong>event with the <strong>IntersectEventArgs </strong>argument. Thumbs cannot be intersected in this control. When an end-user tries to intersect thumbs, this event is raised. This event allows you to specify whether or not a dragged thumb is about to be intersected. The event handler receives an argument of type <strong>IntersectEventArgs </strong>containing data related to this event:</p><p>        - <strong>DraggedThumb </strong>– gets the index of the pair of ticks.</p><p>        - <strong>ThumbType </strong>– gets the value of the ThubmType type that specifies the type of the dragged thumb (ThumbType .Maximum or ThumbType .Minimum).</p><p>        - <strong>Value </strong>– gets the value where this intersection occurs.</p><p>    6) The <strong>ThumbsCount  </strong>property returns the number of thumbs.</p><p>    7) A new method also was added: </p><p> <strong>GetValue</strong>(int index) – returns a TrackBarRange instance, which has a particular index in the EditValue list. </p><p>     The current example shows how we implemented MultipleRangeTrackBar and how to use it.</p>

<br/>


