using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class InputName : MonoBehaviour
{
    public Text text; //�e�L�X�g�G���A

    public void TextAppare()
    {
        //InputField�ɓ��͂��ꂽ�������擾
        Text FieldText = GameObject.Find("InputName/Text").GetComponent<Text>();

        //InputField�ɓ��͂��ꂽ�������e�L�X�g�G���A�ɕ\��
        text.text = FieldText.text;

        //InputField�ɕ\�����ꂽ����������
        InputField column = GameObject.Find("InputName").GetComponent<InputField>();
        column.text = "";
    }

}