using System.Collections;
using System.Collections.Generic;

public class MultiSet<T> : IEnumerable<T>
{
    private Dictionary<T, int> dict = new Dictionary<T, int>();

    public void Add(T item)
    {
        if (dict.ContainsKey(item))
        {
            dict[item]++;
        }
        else
        {
            dict.Add(item, 1);
        }
    }

    public bool Remove(T item)
    {
        if (dict.ContainsKey(item))
        {
            if (dict[item] > 1)
            {
                dict[item]--;
            }
            else
            {
                dict.Remove(item);
            }
            return true;
        }
        return false;
    }

    public int Count(T item)
    {
        if (dict.ContainsKey(item))
        {
            return dict[item];
        }
        return 0;
    }
    public bool Contains(T item) => dict.ContainsKey(item);
    public IEnumerator<T> GetEnumerator()
    {
        return dict.Keys.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}