using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputAddress : MonoBehaviour
{
    public Text text;

    public void TextAppare()
    {
        //InputField�ɓ��͂��ꂽ�������擾
        Text FieldText = GameObject.Find("InputAddress/Text").GetComponent<Text>();

        //InputField�ɓ��͂��ꂽ�������e�L�X�g�G���A�ɕ\��
        text.text = FieldText.text;

        //InputField�ɕ\�����ꂽ����������
        InputField column = GameObject.Find("InputAddress").GetComponent<InputField>();
        column.text = "";
    }

}