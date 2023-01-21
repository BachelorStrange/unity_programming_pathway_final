using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fox:DetectCollisions    //Inheritance
{

    // Start is called before the first frame update
    void Start()
    {
        feedCount = 1;
        player = GameObject.Find("Player");
        slide = gameObject.GetComponentInChildren<Slider>();
        slide.maxValue = feedCount;
        Debug.Log(slide);


    }

    public override void OnTriggerEnter(Collider other)
    {
        if (slide.value < feedCount)
        {
            slide.value++;
            Destroy(other.gameObject);
            slide.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color(0, 255, 0); ;
          
        }
        else
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            player.GetComponent<PlayerController>().points = player.GetComponent<PlayerController>().points + 1;
        }


    }




}
