// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.Classes.Collections.RibbonCollectionBase`1
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace System.Windows.Forms.Classes.Collections
{
  public abstract class RibbonCollectionBase<T> : List<T>, IList, ICollection, IEnumerable
    where T : IRibbonElement
  {
    private Ribbon _owner;

    protected RibbonCollectionBase(Ribbon owner) => this._owner = owner;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual Ribbon Owner => this._owner;

    internal virtual void SetOwner(Ribbon owner) => this._owner = owner;

    internal void SetOwner(IEnumerable<T> items)
    {
      if (items == null)
        return;
      foreach (T obj in items)
        this.SetOwner(obj);
    }

    internal abstract void SetOwner(T item);

    internal void ClearOwner(IEnumerable<T> items)
    {
      if (items == null)
        return;
      foreach (T obj in items)
        this.ClearOwner(obj);
    }

    internal abstract void ClearOwner(T item);

    internal abstract void UpdateRegions();

    public new virtual T this[int index]
    {
      get => base[index];
      set
      {
        this.SetOwner(value);
        base[index] = value;
        this.UpdateRegions();
      }
    }

    public new virtual void Add(T item)
    {
      this.SetOwner(item);
      base.Add(item);
      this.UpdateRegions();
    }

    public new virtual void AddRange(IEnumerable<T> items)
    {
      this.SetOwner(items);
      base.AddRange(items);
      this.UpdateRegions();
    }

    public new virtual void Insert(int index, T item)
    {
      this.SetOwner(item);
      base.Insert(index, item);
      this.UpdateRegions();
    }

    public new virtual bool Remove(T item)
    {
      if (!base.Remove(item))
        return false;
      this.ClearOwner(item);
      this.UpdateRegions();
      return true;
    }

    public new virtual int RemoveAll(Predicate<T> predicate)
    {
      List<T> all = this.FindAll(predicate);
      int num = base.RemoveAll(predicate);
      if (all.Count <= 0)
        return num;
      this.ClearOwner((IEnumerable<T>) all);
      this.UpdateRegions();
      return num;
    }

    public new virtual void RemoveAt(int index)
    {
      T obj = this[index];
      base.RemoveAt(index);
      this.ClearOwner(obj);
      this.UpdateRegions();
    }

    public new virtual void RemoveRange(int index, int count)
    {
      List<T> range = this.GetRange(index, count);
      base.RemoveRange(index, count);
      if (range.Count <= 0)
        return;
      this.ClearOwner((IEnumerable<T>) range);
      this.UpdateRegions();
    }

    public new virtual void Clear()
    {
      List<T> objList = new List<T>((IEnumerable<T>) this);
      base.Clear();
      if (objList.Count <= 0)
        return;
      this.ClearOwner((IEnumerable<T>) objList);
      this.UpdateRegions();
    }

    object IList.this[int index]
    {
      get => (object) this[index];
      set => this[index] = (T) value;
    }

    int IList.Add(object item)
    {
      this.Add((T) item);
      return this.Count - 1;
    }

    void IList.Insert(int index, object item) => this.Insert(index, (T) item);

    void IList.Remove(object value) => this.Remove((T) value);

    void IList.RemoveAt(int index) => this.RemoveAt(index);

    void IList.Clear() => this.Clear();
  }
}
