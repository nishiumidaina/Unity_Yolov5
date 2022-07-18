using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using MySql.Data.MySqlClient;
using System.Diagnostics;

public class ButtonScript : MonoBehaviour
{
    //python������ꏊ
    private string pyExePath = @"C:\Users\nishi\AppData\Local\Programs\Python\Python310\python.exe";

    //���s�������X�N���v�g������ꏊ
    private string pyCodePath = @"C:\Users\nishi\Desktop\GameProject\Person_Simulator\Unity_YOLOv5\yolov5\start.py";
    // �J�n��
    public void OnClickStart()
    {
        //�O���v���Z�X�̐ݒ�
        ProcessStartInfo processStartInfo = new ProcessStartInfo()
        {
            FileName = pyExePath, //���s����t�@�C��(python)
            UseShellExecute = false,//�V�F�����g�����ǂ���
            CreateNoWindow = true, //�E�B���h�E���J�����ǂ���
            RedirectStandardOutput = true, //�e�L�X�g�o�͂�StandardOutput�X�g���[���ɏ������ނ��ǂ���
            Arguments = pyCodePath + " " + "Hello,python.", //���s����X�N���v�g ����(������)
        };

        //�J�n
        Process process = Process.Start(processStartInfo);

        StreamReader streamReader = process.StandardOutput;
        string str = streamReader.ReadLine();

        //�I��
        process.WaitForExit();
        process.Close();

        print(str);
    }

    // ��~��
    public void OnClickStop()
    {
        MySqlConnection con = new MySqlConnection("server=localhost;uid=0000;pwd=0000;database=unityproject");

        try
        {
            con.Open();
            string sql = "UPDATE spots SET spots_status='Stop'";
            MySqlCommand com = new MySqlCommand(sql, con);
            MySqlDataReader reader = com.ExecuteReader();
            reader.Close();
        }
        catch (MySqlException e)
        {
            print(e.ToString());
        }
        print("��~");
    }
}
