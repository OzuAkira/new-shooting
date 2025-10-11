using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class back_ground : MonoBehaviour
{
    [SerializeField] GameObject _canvas,image;
    RectTransform Rect;
    private void Start()
    {
        _canvas = GameObject.Find("Canvas_0");
        Rect = gameObject.GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (Rect.anchoredPosition.y == 0)
        {
            RectTransform r = Instantiate(image, _canvas.transform).GetComponent<RectTransform>();
            r.anchoredPosition = new Vector2(0,890);
        }
        Rect.anchoredPosition += Vector2.down*10;
    }
}
