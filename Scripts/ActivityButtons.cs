using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityButtons : MonoBehaviour
{
    //Hide disactivateObj
    public void DisactivateObjOnPress(GameObject disactivateObj)
    {
        disactivateObj.SetActive(false);
    }
    //activate(reveal) activateObj
    public void ActivateObjOnPress(GameObject activateObj)
    {
        activateObj.SetActive(true);
    }
    //Play audio from the audio soruce located in the gameobject
    public void PlaySound(GameObject gameObject)
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.Play();
    }
    //stop playing audio
    public void PauseAudioSource(AudioSource audio)
    {
        audio.Stop();
    }
}
