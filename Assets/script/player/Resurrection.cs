using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resurrection : MonoBehaviour
{
    public GameObject playerObj;

    [SerializeField] Text player;
    [SerializeField] Text bom;

    public int _player = 3, _bom = 2;
    public bool isResurrection;

    private bool _do;

    private void Update()
    {
        if(playerObj.activeSelf == false && _do == false)
        {
           StartCoroutine( resurrection_time());
        }
    }
    IEnumerator resurrection_time()
    {
        _do = true;//連続で呼ばれるのを阻止
        _player--;
        _bom = 2;

        if (_player < 0)
        {
            Debug.Log("gemeover");//後で書く
        }
        else
        {
            textChange("Player : ",_player,player);
            textChange(" Bom   : ",_bom, bom);

            var Pmove = playerObj.GetComponent<player_move>();
            Pmove.axis = Vector2.zero;//復活時に移動方向をニュートラル直す

            playerObj.transform.position = Vector3.zero;

            yield return new WaitForSeconds(3.5f);
            playerObj.SetActive(true);
            isResurrection = true;

            yield return new WaitForSeconds(3.5f);//無敵時間
            isResurrection = false;

            _do = false;
        }
    }
    //残機とボムのUIを更新
    void textChange(string baseText ,int _n, Text textObj)
    {
        
        List<string> TextList = new List<string> { baseText };
        for (int i = 0; i < _n; i++)TextList.Add("♦");

        textObj.text = string.Join("", TextList);
    }
}
