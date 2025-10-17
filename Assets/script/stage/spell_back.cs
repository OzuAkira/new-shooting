using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class spell_back : MonoBehaviour
{
    [SerializeField] GameObject _canvas, image;
    [SerializeField] float delpos = 700;
    RectTransform Rect;
    Image _image;
    Vector2 _vector = new Vector2(0, -10);
    float add = 0.1f ,i=0;
    bool ins = false;
    private void Start()
    {
        _canvas = transform.parent.gameObject;
        Rect = gameObject.GetComponent<RectTransform>();
        _image = GetComponent<Image>();
    }

    void Update()
    {
        if (_image.color.a < 1)
        {
            UnityEngine.Color c = _image.color;
            c.a = i;
            i += add;
            _image.color = c;
        }
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
