using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PageManager : MonoBehaviour
{
    public List<GameObject> Pages;
    private AudioSource[] narrationAudio;

    private GameObject activityAnswer;

    private int listLength;
    private int index;
    private int pageNum = 1;
    public Text pageNumText;

    public GameObject nextButton;
    public GameObject prevButton;
    
    public GameObject tutorialPanel;
    public GameObject homePanel;
    public Text pagenum;
    public GameObject glossaryPanel;
    public GameObject navigationPanel;
    public GameObject navigationTryAgainText;
    public GameObject navigationInputField;


    // Start is called before the first frame update
    void Start()
    {
        CheckPageNum();
        listLength = Pages.Count;

    }

    // Update is called once per frame
    void Update()
    {
        //on mousepress, hide help panel
        if (tutorialPanel && Input.GetMouseButtonDown(0))
        {
            tutorialPanel.SetActive(false);
        }
        //if on the first page, diable the back button, if on the last page, disable the next button
        if (pageNum == 1)
        {
            prevButton.GetComponent<Button>().interactable = false;
        }
        if (pageNum == listLength)
        {
            nextButton.GetComponent<Button>().interactable = false;
        }
        //if page has the activity script, but only one audio source, only play that one audio sourse.
        //This is because normally it is set up to have two audio sources, one for the normal textbubble, and one for the answer textbubble
        if (Pages[index].GetComponent<ActivityPage>() != null)
        {
            if (activityAnswer.activeInHierarchy == true)
            {
                if (narrationAudio.Length > 1)
                {
                    narrationAudio[0].Stop();
                }
            }
        }
    }
    //set index, change the home panel text page number, get activity answer if page has one, and get page narration audio
    void CheckPageNum()
    {

        index = pageNum - 1;
        pageNumText.text = pageNum.ToString();
        prevButton.GetComponent<Button>().interactable = true;
        nextButton.GetComponent<Button>().interactable = true;

        if (Pages[index].GetComponent<ActivityPage>() != null)
        {
            activityAnswer = Pages[index].GetComponent<ActivityPage>().answer;
        }
        narrationAudio = Pages[index].GetComponents<AudioSource>();
        
        

    }
    //Play Page Narration
    public void PlayNarration()
    {
        
        if (Pages[index].GetComponent<ActivityPage>() == null)
        {
            //Debug.Log("Playing 1 " + narrationAudio[0]);
            narrationAudio[0].Play();
        }
        else if (activityAnswer.activeInHierarchy == false)
        {
            //Debug.Log("Playing 2 " + narrationAudio[0]);
            narrationAudio[0].Play();
        }
        else if (activityAnswer.activeInHierarchy == true)
        {
            //Debug.Log("Playing 3 " + narrationAudio[0]);
            narrationAudio[narrationAudio.Length - 1].Play();
        }
    }
    //display home panel
    public void HomePanelButton()
    {
        homePanel.SetActive(true);
        pagenum.text = pageNumText.text;
    }
    //if press yes on the home panel, go to startscreen
    public void GoHomeYesButton()
    {
        SceneManager.LoadScene("StartScreen");
    }
    //if press no on the home panel, hide the HomePanel
    public void GoHomeNoButton()
    {
        homePanel.SetActive(false);
    }

    //Display the help panel
    public void TutrialButton()
    {
        tutorialPanel.SetActive(true);
    }
    //When the next arrow is pressed, go to next page
    public void NextPage()
    {
        if (Pages[index].transform.position.x == 512)
        {
            pageNum += 1;

            DisablePageAudios();


            CheckPageNum();
            Pages[index - 1].GetComponent<Animator>().Play("NextPageOut");
            Pages[index].GetComponent<Animator>().Play("NextPageIn");
        }
    }
    //When the back arrow is pressed, go to previous page
    public void PreviousePage()
    {
        if (Pages[index].transform.position.x == 512)
        {
            pageNum -= 1;

            DisablePageAudios();

            CheckPageNum();
            Pages[index + 1].GetComponent<Animator>().Play("BackPageOut");
            Pages[index].GetComponent<Animator>().Play("BackPageIn");
        }
    }
    
    //Display the Glossary
    public void DisplayGlossary()
    {
        glossaryPanel.SetActive(true);

    }
    //Hide the Glossary
    public void DisplayGlossaryHide()
    {
        glossaryPanel.SetActive(false);
    }
    //Display the navigation panel
    public void DisplayNavigation()
    {
        navigationPanel.SetActive(true);
        navigationTryAgainText.SetActive(false);
    }

    //This is used for the navigation panel, to skip to another page that is available.
    public void SkipToPage()
    {
        //this bool checks if the input text is a number and returns a bool
        bool success = Int32.TryParse(navigationInputField.GetComponent<InputField>().text, out int inputInt);
        //if what entered is a number
        if (success)
        {
            navigationTryAgainText.SetActive(false);
            //if the numer is a page that is available, go to that page
            if (inputInt > 0 && inputInt < Pages.Count + 1 && inputInt != pageNum)
            {
                int currentIndex = index;
                int currentPageNum = pageNum;
                pageNum = inputInt;
                CheckPageNum();

                if (inputInt > currentPageNum)
                {
                    Pages[currentIndex].GetComponent<Animator>().Play("NextPageOut");
                    Pages[index].GetComponent<Animator>().Play("NextPageIn");
                }
                if (inputInt < currentPageNum)
                {
                    Pages[currentIndex].GetComponent<Animator>().Play("BackPageOut");
                    Pages[index].GetComponent<Animator>().Play("BackPageIn");
                }
                DisablePageAudios();
            }
            else if (inputInt == pageNum)
            {
                return;
            }
            //if page is not available, give a warning.
            else
            {
                Debug.Log("not success");
                navigationTryAgainText.GetComponent<Text>().text = "Page not found. Please try again.";
                navigationTryAgainText.SetActive(true);
            }
            
        }
        //if what was entered was not a number, give a warning
        else
        {
            navigationTryAgainText.GetComponent<Text>().text = "Incorrect format. Please try again.";
            navigationTryAgainText.SetActive(true);
        }
        navigationInputField.GetComponent<InputField>().text = "";
    }
    //disable page narrations
    public void DisablePageAudios()
    {
        foreach (AudioSource sound in narrationAudio)
        {
            sound.Stop();
        }
    }
}
