using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputAddress : MonoBehaviour
{
    public Text text;

    public void TextAppare()
    {
        //InputFieldに入力された文字を取得
        Text FieldText = GameObject.Find("InputAddress/Text").GetComponent<Text>();

        //InputFieldに入力された文字をテキストエリアに表示
        text.text = FieldText.text;

        //InputFieldに表示された文字を消す
        InputField column = GameObject.Find("InputAddress").GetComponent<InputField>();
        column.text = "";
    }

}