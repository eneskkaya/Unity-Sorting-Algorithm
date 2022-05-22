using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// min binary heap kullanarak priority queue
public class PriorityQueue<T> where T : IComparable<T>
{
    // queeu deki item list
    List<T> data;

    // queue'deki item sayısı
    public int Count { get { return data.Count; }}

    // constructor
    public PriorityQueue()
    {
        this.data = new List<T>();
    }

    // queue item ekle min binary heap kullanarak sırala
    public void Enqueue(T item)
    {
        // liste sonuna item ekle
        data.Add(item);

        // heap'teki son konumdan başla
        int childindex = data.Count - 1;

        // min binary heap kullanarak sırala
        while (childindex > 0)
        {
            // heap'teki parent pozisyonunu bul
            int parentindex = (childindex - 1) / 2;

            // parent ve child sıralandıysa,durdur
            if (data[childindex].CompareTo(data[parentindex]) >= 0)
            {
                break;
            }

            // ... değilse,parent ve child değiştir
            T tmp = data[childindex];
            data[childindex] = data[parentindex];
            data[parentindex] = tmp;

            // heap'te bir üste geç sıralanana kadar tekrarla
            childindex = parentindex;

        }
    }

    // item'i queue den çıkar, min binary heap kullanarak sırala
    public T Dequeue()
    {
        // son itemin indexini al
        int lastindex = data.Count - 1;

        // Listteki ilk itemi değişkene ata
        T frontItem = data[0];

        // ilk itemle son itemi yer değiştir
        data[0] = data[lastindex];

        // queue yi kısalt ve son position kaldır
        data.RemoveAt(lastindex);

        // item count azalt
        lastindex--;

        // binary heap sıralamak için queue başına gel
        int parentindex = 0;

        // min binary heap ile sırala
        while (true)
        {
            // left child seç
            int childindex = parentindex * 2 + 1;

            // left child yoksa dur
            if (childindex > lastindex)
            {
                break;
            }

            // right child
            int rightchild = childindex + 1;

            // right child < left child ise heap right branch geç
            if (rightchild <= lastindex && data[rightchild].CompareTo(data[childindex]) < 0)
            {
                childindex = rightchild;
            }

            // parent ve child sıralandı ise durdur
            if (data[parentindex].CompareTo(data[childindex]) <= 0)
            {
                break;
            }

            // değilse, parent child değiştir
            T tmp = data[parentindex];
            data[parentindex] = data[childindex];
            data[childindex] = tmp;

            // heap child levela gelsin,sıralanana kadar tekrar
            parentindex = childindex;

        }

        // return orjinal firs item
        return frontItem;
    }

   
    public T Peek()
    {
        T frontItem = data[0];
        return frontItem;
    }

   
    public bool Contains(T item)
    {
        return data.Contains(item);
    }

    
    public List<T> ToList()
    {
        return data;
    }

}
