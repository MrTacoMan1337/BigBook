using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDropObj : MonoBehaviour
{
    public string destinationTag;
    private bool isDragging;
    private bool isInDestination;
    private GameObject startingPosObj;
    public GameObject destination;
    public GameObject parentOfStartPos;
    
    public bool switchSpriteAfterPlaced;
    public GameObject newSprite;

    public bool turnoffCollider;
    public Collider2D collider;
    


    // Start is called before the first frame update
    void Start()
    {
        //instantiate an empty object that will be the starting reference point to the gameobject
        startingPosObj = Instantiate(Resources.Load("EmptyGameObj")) as GameObject;
        startingPosObj.transform.position = new Vector2(transform.localPosition.x, transform.localPosition.y);
        startingPosObj.transform.SetParent(parentOfStartPos.transform , false);
    }

    // Update is called once per frame
    void Update()
    {
        //when dragging, scale gameobject 1.25 on both the x and y axis; make the position of the gameobject equal the position of the mouse, 
        if (isDragging)
        {
            Debug.Log("change pos");
            transform.localScale = new Vector2(1.25f, 1.25f);
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
        
        // when not dragging or letting go of the object the game object turns back to its original size
        if (!isDragging)
        {
            transform.localScale = new Vector2(1, 1);
            // if it reaches its destination
            if (isInDestination)
            {
                //if bool is on, turn on the new sprite; turn of the render of the gameobject.
                if (switchSpriteAfterPlaced)
                {
                    newSprite.SetActive(true);
                    gameObject.SetActive(false);
                    //turn off colliders so that they dont interfere with raycast. Just used in ch 4 pg 23
                    if (turnoffCollider)
                    {
                        collider.enabled = false;
                    }
                }
                // any other time, the starting position will now be the position of the set destination
                else
                {
                    startingPosObj.transform.position = destination.transform.position;
                }
            }

            //move object to the position of startingPosObj
            transform.position = startingPosObj.transform.position;
            
            
        }
        
        
    }

    
    //if mouse is over gameobject and it is pressed down or pressed up (released)
    private void OnMouseDown()
    {
        Debug.Log("is dragging is true");
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    //if gameoject enters or exits its desired destination.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == destinationTag)
        {
            isInDestination = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag ==  destinationTag)
        {
            isInDestination = false;
        }
    }

}