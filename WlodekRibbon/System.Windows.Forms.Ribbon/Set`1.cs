// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.Set`1
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections;
using System.Collections.Generic;

namespace System.Windows.Forms
{
  [Serializable]
  public class Set<T> : ICollection<T>, IEnumerable<T>, IEnumerable
  {
    private readonly Dictionary<T, object> _items = new Dictionary<T, object>();

    public void Add(T item)
    {
      if ((object) item == null)
        return;
      this._items[item] = (object) null;
    }

    public void Clear() => this._items.Clear();

    public bool Contains(T item) => (object) item != null && this._items.ContainsKey(item);

    public void CopyTo(T[] array, int arrayIndex) => this._items.Keys.CopyTo(array, arrayIndex);

    public int Count => this._items.Count;

    public bool IsReadOnly => false;

    public bool Remove(T item) => (object) item != null && this._items.Remove(item);

    public IEnumerator<T> GetEnumerator() => (IEnumerator<T>) this._items.Keys.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this._items.Keys.GetEnumerator();

    public void AddRange(IEnumerable<T> items)
    {
      if (items == null)
        return;
      foreach (T obj in items)
        this.Add(obj);
    }

    public T[] ToArray()
    {
      T[] array = new T[this._items.Count];
      this.CopyTo(array, 0);
      return array;
    }
  }
}
