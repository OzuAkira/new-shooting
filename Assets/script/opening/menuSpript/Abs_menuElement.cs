using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Abs_menuElement : MonoBehaviour
{
    public Sprite OnImage , OffImage;
    Image image;

    public abstract void select();

    public void On()
    {
        image = gameObject.GetComponent<Image>();
        image.sprite = OnImage;
    }
    public void Off()
    {
        image = gameObject.GetComponent<Image>();
        image.sprite = OffImage;
    }
}
