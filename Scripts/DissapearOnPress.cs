using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearOnPress : MonoBehaviour
{
    public GameObject disappearObj;

    //when the gameobject is pressed, hide disappearObj
    private void OnMouseDown()
    {
        disappearObj.SetActive(false);
    }
}
