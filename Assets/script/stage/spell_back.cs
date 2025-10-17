using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spell_back : MonoBehaviour
{
    [SerializeField] GameObject _canvas, image;
    [SerializeField] float delpos = 700;
    RectTransform Rect;
    Vector2 _vector = new Vector2(0, -10);
    float add = 0.1f;
    bool ins = false;
    private void Start()
    {
        _canvas = GameObject.Find("Canvas_spell");
        Rect = gameObject.GetComponent<RectTransform>();
    }

    void Update()
    {
        
        if (Rect.anchoredPosition.y >= 0 && _vector.y >= 10 && ins == false)
        {
            ins = true;
            if (image == null) return;
            RectTransform r = Instantiate(image, _canvas.transform).GetComponent<RectTransform>();
            r.anchoredPosition = new Vector2(0, -890);
        }
        else if (Rect.anchoredPosition.y > delpos) Destroy(gameObject);
        Rect.anchoredPosition += _vector;
        if (_vector.y < 10) _vector.y += add;
    }
}
