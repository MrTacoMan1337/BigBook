using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VocabularyWords : MonoBehaviour
{
    public GameObject nextButton;
    public GameObject prevButton;
    public GameObject vocabPanel;
    public GameObject glossary;
    private int index;
    public List<string> VocabWords;
    public List<GameObject> VocabWordsObj;
    public List<GameObject> VocabDefs;
    private AudioSource[] VocabNarrs1;
    private AudioSource[] VocabNarrs2;
    public GameObject audiosGO1;
    public GameObject audiosGO2;

    private void Start()
    {
        //get list of all vocabulary audio files
        VocabNarrs1 = audiosGO1.GetComponents<AudioSource>();
        VocabNarrs2 = audiosGO2.GetComponents<AudioSource>();
    }

    private void Update()
    {
        //Disactivate vocab audio when changing pages of opening glossay
        nextButton.GetComponent<Button>().onClick.AddListener(HidePannel);
        prevButton.GetComponent<Button>().onClick.AddListener(HidePannel);
        if (!glossary.activeInHierarchy)
        {
            DisableAllAudios1();
        }

        
    }
    //show the vocab panel and dispaly the correct vocab word and definiton
    public void Vocab(string vocab)
    {
        //compare the vocab string with the VocabWords to find the math and output its index
        for (int i = 0; i < VocabWords.Count; i++)
        {
            if (VocabWords[i].ToUpper() == vocab.ToUpper())
            {
                index = i;
            }
        }
        DisableAllVocabs();
        DisableAllAudios1();
        DisableAllAudios2();


        VocabWordsObj[index].SetActive(true);
        VocabDefs[index].SetActive(true);
        vocabPanel.GetComponent<Animator>().SetBool("On", true);
        
    }
    //Play vocab audio, This is for the vocab panel only
    public void PlayVocabDef()
    {
        VocabNarrs2[index].Play();
        Debug.Log("playing");
    }
    //Play vocab audio, This is for the glossary only
    public void PlayVocabDefGlossary(int indexnum)
    {
        DisableAllAudios1();
        VocabNarrs1[indexnum].Play();
    }
    //hide vocabulary panel
    public void HidePannel()
    {
        vocabPanel.GetComponent<Animator>().SetBool("On", false);
        DisableAllAudios2();
    }
    //hide all vocabulary words and definitions
    private void DisableAllVocabs()
    {
        for (int i = 0; i < VocabWords.Count; i++)
        {
            VocabWordsObj[i].SetActive(false);
            VocabDefs[i].SetActive(false);
        }
    }
    //disable all vocab audios on list #1
    public void DisableAllAudios1()
    {
        for (int i = 0; i < VocabWords.Count; i++)
        {
            VocabNarrs1[i].Stop();
        }
    }
    //disable all vocab audios on list #2
    public void DisableAllAudios2()
    {
        for (int i = 0; i < VocabWords.Count; i++)
        {
            VocabNarrs2[i].Stop();
        }
    }
}
