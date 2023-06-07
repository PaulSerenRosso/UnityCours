using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class ReturnAsyncExemple : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] values = new[] { 1, 3, 5, 6, 8 };
      
     //   Foo();
        //ReturnAsyncValue();
    }

    async Task<int> ReturnAsyncValue()
    {
        int delayInMiliSecond = Random.Range(3000, 5001);
        await Task.Delay(delayInMiliSecond);
        return delayInMiliSecond;
    }

    
    void Foo()
    {
        StartCoroutine(Bar((intReturn ) =>  {
            Debug.Log("bonsoir"+intReturn);
        }));
    }
 
    IEnumerator Bar(System.Action<int> callback)
    {
        yield return new WaitForSeconds(5);
        callback( 10);
    }
  
}
