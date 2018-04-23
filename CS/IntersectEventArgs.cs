using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomRangeTrackBarControl
{
    class IntersectEventArgs : EventArgs
    {
        ThumbType _ThumbType;
        public ThumbType ThumbType
        {
            get { return _ThumbType; }
            set { _ThumbType = value; }
        }

        int _DraggedThumb;
        public int DraggedThumb
        {
            get { return _DraggedThumb; }
            set { _DraggedThumb = value; }
        }

        int _Value;
        public int Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        public IntersectEventArgs(ThumbType thumbType_, int draggedThumb_, int value_)
        {
            _ThumbType = thumbType_;
            _DraggedThumb = draggedThumb_;
            _Value = value_;
        }
    }

    public enum ThumbType { Minimum, Maximum };
}
