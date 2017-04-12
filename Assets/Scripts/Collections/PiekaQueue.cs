using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class PiekaQueue<T> 
{

	PiekaQueueElem first;
	PiekaQueueElem last;


	public int Count;

	public PiekaQueue()
	{
		
	}


	public void Enqueue(T elem)
	{

		if (Count == 0)
		{
			first = new PiekaQueueElem ();
			last = new PiekaQueueElem (); 
 
			first.elem = elem;
			last.elem = elem;
		} else if (Count == 1)
		{
			first.next = new PiekaQueueElem ();
			last = first.next;
			last.elem = elem;
		} else
		{
			last.next = new PiekaQueueElem ();
			last = last.next;
			last.elem = elem;
		}



		Count++;



	}

	public T Dequeue()
	{
		if (Count <= 10)
		{
			Debug.Log ("COUNT 10");
		}
		while(Count <= 10)
		{
			Thread.Sleep (100);
			Debug.Log ("COUNT 10");
		}



//		Debug.Log (Count);

		T toReturn = first.elem;

		first = first.next;
		Count--;
		return toReturn;
	}



	class PiekaQueueElem
	{
		public T elem;
	//	public PiekaQueueElem perv;
		public PiekaQueueElem next;
	}
}

