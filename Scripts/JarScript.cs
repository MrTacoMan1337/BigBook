using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JarScript : MonoBehaviour
{
    public Slider slider;
    private Animator anim;
    public int frame;
    public float frameState;
    private bool reset;
    public bool resetOnPageLeave;
    public GameObject textBubble;

    public Color[] colors;
    private Outline outline;
    private float outlineTimer;

    //public GameObject reseetFrames;
    private void Start()
    {
        anim = GetComponent<Animator>();
        frame = 0;
        outline = gameObject.GetComponent<Outline>();
    }

    private void Update()
    {
        

        //Reset animation and position when activity is not on screen
        if (resetOnPageLeave)
        {
            //if page that this object is on is off-screen
            if (gameObject.GetComponentInParent<Transform>().position.x <= -512 || gameObject.GetComponentInParent<Transform>().position.x >= 1536)
            {
                if (reset)
                {
                    slider.value = 5;
                    anim.Play("JarAnim", 0, 0);
                    slider.interactable = true;
                    reset = false;
                    
                }
            }
            //only alternates outline color if the textbubble is on
            else
            {
                reset = true;

                if (textBubble.activeInHierarchy)
                {
                    OutlineAlpha();
                }
                else
                {
                    outline.effectColor = Color.Lerp(colors[1], colors[0], 1);
                }
                
            }
        }
    }
    
    //This Function will perform everytime the jar (slider value) moves
    public void PlayOneFrame(GameObject obj)
    {
        
        Slider slider1 = obj.GetComponent<Slider>();
        Animator anim1 = gameObject.GetComponent<Animator>();
        
        //get how far the animation has played as a float from 0-1, 0 being the begining of the animation and 1 being the end
        frameState = (float)anim1.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (frameState == 0)
        {
            frame = 0;
        }

        //Play 1 frame of the animation
        frame += 1;
        anim1.Play("JarAnim", 0, (float)frame/100);
        textBubble.SetActive(false);
        
        // when it reaches the last frame (100) make the jar not interactable.
        if (frame >= 100)
        {
            frame = 99;
            slider1.interactable = false;
        }
        
    }

    //create an outline that will alternate between colors[0] and colors [1]
    private void OutlineAlpha()
    {
        outlineTimer += Time.deltaTime;
        if (outlineTimer >= 2)
        {
            outline.effectColor = Color.Lerp(colors[1], colors[0], 1);
            outlineTimer = 0;
        }
        else if (outlineTimer >= 1)
        {
            outline.effectColor = Color.Lerp(colors[0], colors[1], 1);
        }
    }
    
    
}
