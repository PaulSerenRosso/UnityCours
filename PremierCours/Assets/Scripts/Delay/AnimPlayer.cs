using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class AnimPlayer : MonoBehaviour
{
   public Button button;
   public Animation animation;
   public async void PlayDansDisableButton()
   {
       animation.Play();
       button.interactable = false;
       while (animation.isPlaying)
       {
           await Task.Yield();
       }

       button.interactable = true;
   }
}
