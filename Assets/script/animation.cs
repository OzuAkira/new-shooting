using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite[] image;

    int index = 0, i = 0;
    [SerializeField] int frame = 5;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        i++;
        if (i % frame == 0)
        {
            index++;
            if (index > image.Length - 1) index = 0;
            sr.sprite = image[index];
        }
    }
}
