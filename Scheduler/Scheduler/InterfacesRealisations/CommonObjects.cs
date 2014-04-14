﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Scheduler_InterfacesRealisations
{
    public abstract class CommonObjectWithNotify : Scheduler_Controls_Interfaces.IDummy
    {
        event System.ComponentModel.PropertyChangedEventHandler innerPropertyChanged;
        event System.ComponentModel.PropertyChangedEventHandler System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        {
            add { innerPropertyChanged = value; }
            remove { innerPropertyChanged = null; }
        }

        public void RaisePropertyChanged(string caller)
        {
            if (innerPropertyChanged == null)
                return;

            innerPropertyChanged(this, new PropertyChangedEventArgs(caller));
        }
    }

    public abstract class CommonList<T> : Scheduler_Forms_Interfaces.IEntityList<T> where T : Scheduler_Controls_Interfaces.IDummy
    {
        private List<T> list;

        public event Scheduler_Forms_Interfaces.ItemAddedHandler OnItemAdded;
        public event Scheduler_Forms_Interfaces.ItemRemovedHandler OnItemRemoved;
        public event Scheduler_Forms_Interfaces.ItemChangedHandler OnItemChange;

        public CommonList()
        {
            list = new List<T>();
        }

        public CommonList(CommonList<T> oldlist)
        {
            list = new List<T>(oldlist.List);
            OnItemAdded += oldlist.OnItemAdded;
            OnItemRemoved += oldlist.OnItemRemoved;
            OnItemChange += oldlist.OnItemChange;
        }

        public List<T> List
        {
            get { return list; }
        }

        public void Add(T item)
        {
            if (!list.Contains(item))
            {
                list.Add(item);
                if (OnItemAdded != null)
                    OnItemAdded(item);
            }
        }

        public void Remove(T item)
        {
            if (list.Contains(item))
            {
                list.Remove(item);
                if (OnItemRemoved != null)
                    OnItemRemoved(item);
            }
        }

        public abstract Scheduler_Forms_Interfaces.IEntityList<T> Copy();
    }
}
