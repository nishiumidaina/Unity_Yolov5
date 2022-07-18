using System.Diagnostics;
using System.IO;
using UnityEngine;

public class CsPy : MonoBehaviour
{
    //python������ꏊ
    private string pyExePath = @"C:\Users\nishi\AppData\Local\Programs\Python\Python310\python.exe";

    //���s�������X�N���v�g������ꏊ
    private string pyCodePath = @"C:\Unity_YOLOv5\yolov5\start.py";

    private void Start()
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

        //�O���v���Z�X�̊J�n
        Process process = Process.Start(processStartInfo);

        //�X�g���[������o�͂𓾂�
        StreamReader streamReader = process.StandardOutput;
        string str = streamReader.ReadLine();

        //�O���v���Z�X�̏I��
        process.WaitForExit();
        process.Close();

        //���s
        print(str);
    }
}
