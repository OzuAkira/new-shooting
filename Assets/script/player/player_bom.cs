using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_bom : MonoBehaviour
{
    public GameObject bom , GM;
    Resurrection res;
    [SerializeField] Text bomText;
    CircleCollider2D cc;
    bool _do = false;
    private void Start()
    {
        res = GM.GetComponent<Resurrection>();
        cc = gameObject.GetComponent<CircleCollider2D>();
    }
    void OnBom()
    {
        if (_do == false && res._bom > 0) StartCoroutine(bom_animetion());
    }
    IEnumerator bom_animetion()
    {
        _do = true;//�A�˖h�~�p

        res._bom--;
        res.textChange(" Bom   : ", res._bom, bomText);//UI�̍X�V��resurection�̊֐����g�p

        res = GM.GetComponent<Resurrection>();//resurection�̍X�V

        bom.SetActive(true);
        cc.enabled = false;

        yield return new WaitForSeconds(3);//�{����������

        bom.SetActive(false);
        cc.enabled = true;

        _do = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bom"))
        {
            res._bom++;
            res.textChange(" Bom   : ", res._bom, bomText);//UI�̍X�V��resurection�̊֐����g�p

            res = GM.GetComponent<Resurrection>();//resurection�̍X�V

            Destroy(collision.gameObject);
        }
    }
}
