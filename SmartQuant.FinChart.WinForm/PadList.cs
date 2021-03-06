﻿// Licensed under the Apache License, Version 2.0. 
// Copyright (c) Alex Lee. All rights reserved.

using System;
using System.Collections;

namespace SmartQuant.FinChart
{
    [Serializable]
    public class PadList : IList
    {
        private ArrayList list = new ArrayList();

        public bool IsReadOnly
        {
            get
            {
                return this.list.IsReadOnly;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return this.list.IsFixedSize;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return this.list.IsSynchronized;
            }
        }

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this.list.SyncRoot;
            }
        }

        public Pad this [int index]
        {
            get
            {
                return this.list[index] as Pad;
            }
        }

        public void RemoveAt(int index)
        {
            this.list.RemoveAt(index);
        }

        void IList.Insert(int index, object value)
        {
            throw new NotSupportedException();
        }

        void IList.Remove(object value)
        {
            Remove(value as Pad);
        }

        bool IList.Contains(object value)
        {
            return this.list.Contains(value);
        }

        public void Clear()
        {
            this.list.Clear();
        }

        int IList.IndexOf(object value)
        {
            return IndexOf(value as Pad);
        }

        int IList.Add(object value)
        {
            return Add(value as Pad);
        }

        public void CopyTo(Array array, int index)
        {
            this.list.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        public int Add(Pad pad)
        {
            return this.list.Add(pad);
        }

        public void Remove(Pad pad)
        {
            this.list.Remove(pad);
        }

        public void Insert(int index, Pad pad)
        {
            this.list.Insert(index, pad);
        }

        public int IndexOf(Pad pad)
        {
            return this.list.IndexOf(pad);
        }
    }
}