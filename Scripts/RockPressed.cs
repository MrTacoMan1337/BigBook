using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPressed : MonoBehaviour
{
    public bool rockPressed;
    //when hovering over the gameobject's  collider, make rockPressed = true
    private void OnMouseEnter()
    {
        rockPressed = true;
    }
    //when hovering not over the gameobject's  collider, make rockPressed = false
    private void OnMouseExit()
    {
        rockPressed = false;
    }
}
