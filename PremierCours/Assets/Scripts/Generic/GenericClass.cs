using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GenericClass<T>
{
   public T item { get; }
   public void UpdateItem(T newItem);
}
