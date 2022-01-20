using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnpageOn : MonoBehaviour
{
    public List<GameObject> activateObjsWhenArrive;

    // Update is called once per frame
    void Update()
    {
        // activate all the objects in the  list if the page that it is on is centered on the screen, otherwise disactivate them
        if (gameObject.transform.position.x == 512)
        {
            for (int i = 0; i < activateObjsWhenArrive.Count; i++)
            {
                activateObjsWhenArrive[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < activateObjsWhenArrive.Count; i++)
            {
                activateObjsWhenArrive[i].SetActive(false);
            }
        }
    }


}
