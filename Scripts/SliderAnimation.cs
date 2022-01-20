using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAnimation : MonoBehaviour
{

    public List<Sprite> sprites;
    public Slider slider;
    private int sliderValue;
    

    // Update is called once per frame
    void Update()
    {
        //change the sprite of the image with a sprite in the sprites list. The value of the slide is the index of the list
        sliderValue = (int)slider.gameObject.GetComponent<Slider>().value;
        gameObject.GetComponent<Image>().sprite = sprites[sliderValue - 1];
    }
    
}
