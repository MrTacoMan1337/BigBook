using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MedalActivity : MonoBehaviour
{
    private Animator rockAnim;
    private int rocknum;
    private AudioSource rockaudio;
    private float rockTimer;
    public GameObject medal;
    private Animator medalAnim;
    private bool playMedalAnim;

    public GameObject rockCollider;
    private bool mouseOverRock;

    // Start is called before the first frame update
    void Start()
    {
        //set up all the variables
        rockAnim = gameObject.GetComponent<Animator>();
        rocknum = 0;
        rockaudio = gameObject.GetComponent<AudioSource>();
        rockTimer = 0;
        medalAnim = medal.GetComponent<Animator>();
        playMedalAnim = false;
    }

    // Update is called once per frame
    void Update()
    {
        //keep cheking for the bool "rockPressed" in the RockPressed Scripted
        mouseOverRock = rockCollider.GetComponent<RockPressed>().rockPressed;
        TimerRock();

        //play next rock animation, play audio, and reset rockTimer.
        if (Input.GetMouseButtonDown(0) && rocknum <= 4 && rockTimer >= 0.5f && mouseOverRock)
        {
            rocknum += 1;
            rockaudio.Play();
            rockAnim.SetInteger("Rock", rocknum);
            rockTimer = 0;
        }

        //After last Rock animation played, play the medal animation. Depending on the chapter, a different medal will appear
        if (rocknum == 4)
        {
            playMedalAnim = true;
            //The bool makes it play once only
            if (playMedalAnim)
            {
                playMedalAnim = false;
                if (SceneManager.GetActiveScene().name == "Ch1")
                {
                    medalAnim.Play("Medal1", 0, 0);
                }
                else if (SceneManager.GetActiveScene().name == "Ch2")
                {
                    medalAnim.Play("Medal2", 0, 0);
                }
                else if (SceneManager.GetActiveScene().name == "Ch3")
                {
                    medalAnim.Play("Medal3", 0, 0);
                }
                else if (SceneManager.GetActiveScene().name == "Ch4")
                {
                    medalAnim.Play("Medal4", 0, 0);
                }
                else if (SceneManager.GetActiveScene().name == "Ch5")
                {
                    medalAnim.Play("Medal5", 0, 0);
                }
                
            }
        }


    }
    //Start rockTimer and stop it at .5 sec
    private void TimerRock()
    {
        rockTimer += Time.deltaTime;
        if(rockTimer >= 0.5f)
        {
            rockTimer = 0.5f;
        }
    }
    
}
