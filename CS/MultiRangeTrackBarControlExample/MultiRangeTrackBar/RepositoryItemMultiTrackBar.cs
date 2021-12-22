using DevExpress.Accessibility;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using System.Drawing;

namespace MultiRangeTrackBarControlExample {
    [UserRepositoryItem("RegisterCustomTrackBar")]
    public class RepositoryItemMultiTrackBar : RepositoryItemTrackBar {
        static RepositoryItemMultiTrackBar() {
            RegisterCustomTrackBar();
        }

        public const string CustomEditName = "MultiRangeTrackBar";

        public RepositoryItemMultiTrackBar() {
        }

        public override string EditorTypeName => CustomEditName;

        public static void RegisterCustomTrackBar() {
            Image img = null;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(MultiRangeTrackBar), typeof(RepositoryItemMultiTrackBar), typeof(MultiTrackBarViewInfo), new TrackBarPainter(), true, img, typeof(TrackBarAccessible)));
        }

        public override void Assign(RepositoryItem item) {
            BeginUpdate();
            try {
                base.Assign(item);
                RepositoryItemMultiTrackBar source = item as RepositoryItemMultiTrackBar;
                if (source == null) return;
                DrawRanges = source.DrawRanges;
            } finally {
                EndUpdate();
            }
        }

        public bool DrawRanges { get; set; } = true;
    }
}
