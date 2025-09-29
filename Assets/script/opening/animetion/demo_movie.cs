using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class demo_movie : MonoBehaviour
{
    //okura
    public GameObject rawImage;
    VideoPlayer v_player;
    int i = 0;
    private void Start()
    {
        v_player = rawImage.GetComponent<VideoPlayer>();
    }
    void Update()
    {
        i++;
    }
}
