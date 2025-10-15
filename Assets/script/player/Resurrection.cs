using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resurrection : MonoBehaviour
{
    public GameObject playerObj,stage_M,ending;

    [SerializeField] Text player;
    [SerializeField] Text bom;

    public int _player = 3, _bom = 2;
    public bool isResurrection;

    private bool _do;
    private SpriteRenderer sr;
    private void Start()
    {
        sr = playerObj.GetComponent<SpriteRenderer>();
    }
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
        
        
        textChange("Player : ",_player,player);
        

        var Pmove = playerObj.GetComponent<player_move>();
        Pmove.axis = Vector2.zero;//復活時に移動方向をニュートラル直す

        playerObj.transform.position = new Vector3(0,-4,0);

        yield return new WaitForSeconds(3.5f);
        if (_player < 0)
        {
            Debug.Log("gemeover");
            stage_M.SetActive(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;//敵弾と敵のObjectを削除

            StartCoroutine(end(false));

        }
        else
        {
            _bom = 2;

            textChange(" Bom   : ", _bom, bom);
            playerObj.SetActive(true);

            isResurrection = true;

            

            sr.color = Color.red;
            yield return new WaitForSeconds(3.5f);//無敵時間
            sr.color = Color.white;

            isResurrection = false;

            _do = false;
        }
    }
    //残機とボムのUIを更新
    public void textChange(string baseText ,int _n, Text textObj)
    {
        if (_n < 0) return;

        List<string> TextList = new List<string> { baseText };
        for (int i = 0; i < _n; i++)TextList.Add("♦");

        textObj.text = string.Join("", TextList);
    }
    public IEnumerator end(bool clear)
    {
        yield return new WaitForSeconds(1);
        GameObject child_ending = Instantiate(ending, new Vector3(0, 0, 0), Quaternion.identity);
        Image _image = child_ending.transform.GetChild(0).GetComponent<Image>();
        push_score ps = child_ending.transform.GetChild(1).GetComponent<push_score>();

        float add=0.02f;
        UnityEngine.Color c = _image.color;//alphaを調整
        c.a = 0;
        _image.color = c;
        while (_image.color.a < 1)
        {
            c.a += add;
            _image.color = c;
            yield return null;
        }
        
        yield return new WaitForSeconds(1);
        if (clear) StartCoroutine(ps.first_move(true));
        else StartCoroutine(ps.first_move(false));//”GameOrver”の文字を出す演出
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy_bullet") || collision.CompareTag("enemy")) Destroy(collision.gameObject);
    }
}
