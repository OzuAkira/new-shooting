using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class player_shot : MonoBehaviour
{
    private PlayerInput _playerInput;// ���͂��󂯎��PlayerInput
    [SerializeField] private string _slowActionName = "Shot";// �A�N�V������
    private InputAction _shotAction;// �A�N�V�����̃R���|�[�l���g

    bool isShot = false;
    int i;
    [SerializeField] int interval = 5;

    private float instant_Ypos = 0.5f;

    [SerializeField] GameObject player_bullet;

    public int my_power = 0 , power_level = 12;
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        // �U���A�N�V������PlayerInput����擾
        _shotAction = _playerInput.actions[_slowActionName];
    }


    
    
    private void Update()
    {
        //�Ԋu�Ńt���O���Ǘ�
        if (isShot)
        {
            if (i >= interval)
            {
                i = 0;
                isShot = false;
            }
            else i++;
        }

        //�U������
        if (_shotAction != null && isShot == false)
        {
            // �U���{�^���̉�����Ԏ擾
            var isPressed = _shotAction.IsPressed();

            if (isPressed)
            {
                if(my_power > power_level*2)
                {
                    Instantiate(player_bullet, gameObject.transform.position + new Vector3(0, instant_Ypos), Quaternion.Euler(0, 0, 1));
                    Instantiate(player_bullet, gameObject.transform.position + new Vector3(0, instant_Ypos), Quaternion.identity);
                    Instantiate(player_bullet, gameObject.transform.position + new Vector3(0, instant_Ypos), Quaternion.Euler(0, 0, -1));
                }
                
                else if(my_power > power_level)
                {
                    Instantiate(player_bullet, gameObject.transform.position + new Vector3(0, instant_Ypos), Quaternion.Euler(0,0,1));
                    Instantiate(player_bullet, gameObject.transform.position + new Vector3(0, instant_Ypos), Quaternion.Euler(0, 0, -1));
                }

                else Instantiate(player_bullet, gameObject.transform.position + new Vector3(0, instant_Ypos), Quaternion.identity);//�e�𐶐�

                isShot = true;


            }
        }
        else if(_shotAction == null)
        {
            Debug.Log("_shotAction ��Null�ł��I");
            return;
        }
    }
    

}
