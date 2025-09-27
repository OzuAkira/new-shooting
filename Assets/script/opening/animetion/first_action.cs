using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class first_action : MonoBehaviour
{
    public Vector2 golePos = new Vector2(-130, 160);
    public float movespeed = 0.1f;
    bool isPush , isCoroutine;
    RectTransform rt;
    private void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (Input.anyKey)isPush = true;
        if (isPush)
        {
            if (isCoroutine == false) StartCoroutine(opening());
        }
    }
    IEnumerator opening()
    {
        bool loop = false;
        isCoroutine = true;

        while (loop == false)
        {
            rt.anchoredPosition += golePos * movespeed;//オブジェクトが原点から始まるから、golePosがそのままベクトルになる
            if (rt.anchoredPosition.x < golePos.x)
            {
                rt.anchoredPosition = golePos;
                loop = true;
            }
            yield return null;
        }
    }
}
