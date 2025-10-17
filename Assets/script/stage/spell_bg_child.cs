using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell_bg_child : MonoBehaviour
{
    [SerializeField] GameObject _canvas, image;
    
    RectTransform Rect;
    private void Start()
    {
        _canvas = transform.parent.gameObject;
        Rect = gameObject.GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (Rect.anchoredPosition.y == 0)
        {
            RectTransform r = Instantiate(image, _canvas.transform).GetComponent<RectTransform>();
            r.anchoredPosition = new Vector2(0, -890);
        }
        else if (Rect.anchoredPosition.y > 700) Destroy(gameObject);
            Rect.anchoredPosition += Vector2.up * 10;
    }
}
