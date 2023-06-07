using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPurchasable <T>
{
    void purchase(T t);
}

