using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
    protected GameObject player;
    protected Slider slide;
    protected int feedCount;
    // Start is called before the first frame update
    void Start()
    {
        feedCount = 3;
        player = GameObject.Find("Player");
        slide = gameObject.GetComponentInChildren<Slider>();
        Debug.Log(slide);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void  OnTriggerEnter(Collider other)
    {
        if (slide.value < feedCount )
        {
            slide.value++;
            Destroy(other.gameObject);
        }
        else
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            player.GetComponent<PlayerController>().points = player.GetComponent<PlayerController>().points + 1;
        }
        

    }
}
