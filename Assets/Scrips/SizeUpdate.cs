using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 kero;  //�@���̕ϐ��錾


        kero = gameObject.transform.localScale; //�����݂̑傫������
        kero.x = kero.x + 1;  //�A�ϐ�kero��x���W��1���₵�đ��
        gameObject.transform.localScale = kero; //�B�傫���ɕϐ�kero����
    }
}
