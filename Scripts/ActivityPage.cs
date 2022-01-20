using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityPage : MonoBehaviour
{
    public GameObject nextButton;
    public GameObject answer;
    public bool multipleAnswers;
    public List<GameObject> multiAnswers;
    public List<GameObject> activateOnPageLeave;
    public List<GameObject> disactivateOnPageLeave;
    private bool pageActive;
    private bool activityCompleted;
    private bool buttonActive;
    Vector3 pagePos;
    public List<Collider2D> colliders;
    public bool setPageOnAnswer;
    

    // Start is called before the first frame update
    void Start()
    {
        //checks if there are any answers, if there isn't then activity is completed
        if(disactivateOnPageLeave.Count == 0)
        {
            activityCompleted = true;
        }
        buttonActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        pagePos = gameObject.transform.position;

        //if the page is on the screen
        if (pagePos.x > -512 && pagePos.x < 1536)
        {
            //Debug.Log(pagePos.x);
            pageActive = true;
            ChecForCompletion();

            //if activity is completed, then the nextButton will become active again
            if (!activityCompleted)
            {
                nextButton.GetComponent<Button>().interactable = false;
            }
            else if (activityCompleted && buttonActive)
            {
                nextButton.GetComponent<Button>().interactable = true;
                buttonActive = false;

                if (setPageOnAnswer)
                {
                    SetPage();
                }
            }
        }

        //if page is not on the screen
        if (pagePos.x <= -512 || pagePos.x >= 1536)
        {
            // reset the page and activity
            if (pageActive)
            {
                ResetPage();
                pageActive = false;
                buttonActive = true;
                nextButton.GetComponent<Button>().interactable = true;
            }
        }
    }

    //check if page activity has been completed
    public void ChecForCompletion()
    {

        if (multipleAnswers)
        {
            for (int i = 0; i < multiAnswers.Count; i++)
            {
                if (!multiAnswers[i].activeSelf)
                {
                    activityCompleted = false;
                    answer.SetActive(false);
                    return;
                }
                else
                {
                    activityCompleted = true;
                    answer.SetActive(true);
                }
            }
        }
        else if (!answer.activeInHierarchy)
        {
            activityCompleted = false;
        }
        else
        {
            activityCompleted = true;
        }
    }

    //Set page, so that it reveals all disactivateOnPageLeave objects and hides all activateOnPageLeave objects
    public void SetPage()
    {
        for (int i = 0; i < activateOnPageLeave.Count; i++)
        {
            activateOnPageLeave[i].SetActive(false);
        }
        for (int i = 0; i < disactivateOnPageLeave.Count; i++)
        {
            disactivateOnPageLeave[i].SetActive(true);
        }
    }

    // resets the page
    public void ResetPage()
    {
        for (int i = 0; i < activateOnPageLeave.Count; i++)
        {
            activateOnPageLeave[i].SetActive(true);
        }
        for (int i = 0; i < disactivateOnPageLeave.Count; i++)
        {
            disactivateOnPageLeave[i].SetActive(false);
        }
        for (int i = 0; i < colliders.Count; i++)
        {
            colliders[i].enabled = true;
        }
    }

    
}
