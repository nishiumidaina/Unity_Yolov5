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
        Vector3 kero;  //�@仮の変数宣言


        kero = gameObject.transform.localScale; //◆現在の大きさを代入
        kero.x = kero.x + 1;  //�A変数keroのx座標を1増やして代入
        gameObject.transform.localScale = kero; //�B大きさに変数keroを代入
    }
}
