using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DevExpress.XtraEditors.Repository;

namespace CustomRangeTrackBarControl
{
    public class RangeList
    {
        List<TrackBarRange> list;

        public event EventHandler ListChanged;

        public RangeList()
        {
            list = new List<TrackBarRange>();
            list.Add(new TrackBarRange());
        }

        public RangeList(RangeList _list)
        {
            list = new List<TrackBarRange>();
            this.Assign(_list);
        }

        public TrackBarRange GetValue(int index)
        {
            return list[index];
        }

        public int Count { get { return list.Count; } }

        bool CheckAdd(TrackBarRange range)
        {
            foreach (TrackBarRange r in list)
                if (range.Maximum >= r.Minimum) return false;
            return true;
        }

        bool CheckChange(int index, TrackBarRange range)
        {
            bool res = true;
            for (int i = index + 1; i < list.Count; i++)
                if (range.Minimum <= list[i].Maximum) res = false;
            for (int i = 0; i < index; i++)
                if (range.Maximum >= list[i].Minimum) res = false;
            return res;
        }

        void OnListChanged()
        {
            if (ListChanged != null)
            {
                ListChanged(this, new EventArgs());
            }
        }

        public void Add(TrackBarRange range)
        {
            if (CheckAdd(range))
            {
                list.Add(range);
                OnListChanged();
            }
        }

        public void ChangeValue(int index, TrackBarRange range)
        {
            if (CheckChange(index, range))
            {
                list[index] = range;
                OnListChanged();
            }
        }

        public bool RemoveAt(int index)
        {
            if (index >= list.Count && index > 0)
                return false;
            list.RemoveAt(index);
            OnListChanged();
            return true;
        }

        public void Remove(TrackBarRange range)
        {
            int index = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == range) index = i;
            }
            list.Remove(range);
            OnListChanged();
        }

        internal void Assign(RangeList newList)
        {
            list.Clear();
            for (int i = 0; i < newList.Count; i++)
                list.Add(newList.GetValue(i));
        }

        public void Clear()
        {
            for (int i = 1; i < list.Count; i++)
            {
                list.RemoveAt(i);
            }
            OnListChanged();
        }
    }
}
