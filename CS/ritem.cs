using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using System.Drawing;
using DevExpress.XtraEditors.Drawing;

namespace CustomRangeTrackBarControl
{
    [UserRepositoryItem("Register")]
    [System.ComponentModel.DesignerCategory("None")]
    class RepositoryItemMultipleRangeTrackBar : RepositoryItemRangeTrackBar
    {

        #region Register
        internal const string EditorName = "MultipleRangeTrackBar";

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(MultipleRangeTrackBar),
                typeof(RepositoryItemMultipleRangeTrackBar), typeof(MultiRangeViewInfo),
                new MultiRangePainter(), true, null));
        }
        static RepositoryItemMultipleRangeTrackBar()
        {
            Register();
        }
        public override string EditorTypeName
        {
            get { return EditorName; }
        }
        #endregion

        public override string ToString()
        {
            return "Ritem_" + EditorName;
        }
    }
}
