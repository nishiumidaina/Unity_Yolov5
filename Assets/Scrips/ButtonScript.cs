using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using MySql.Data.MySqlClient;
using System.Diagnostics;

public class ButtonScript : MonoBehaviour
{
    //pythonがある場所
    private string pyExePath = @"C:\Users\nishi\AppData\Local\Programs\Python\Python310\python.exe";

    //実行したいスクリプトがある場所
    private string pyCodePath = @"C:\Users\nishi\Desktop\GameProject\Person_Simulator\Unity_YOLOv5\yolov5\start.py";
    // 開始時
    public void OnClickStart()
    {
        //外部プロセスの設定
        ProcessStartInfo processStartInfo = new ProcessStartInfo()
        {
            FileName = pyExePath, //実行するファイル(python)
            UseShellExecute = false,//シェルを使うかどうか
            CreateNoWindow = true, //ウィンドウを開くかどうか
            RedirectStandardOutput = true, //テキスト出力をStandardOutputストリームに書き込むかどうか
            Arguments = pyCodePath + " " + "Hello,python.", //実行するスクリプト 引数(複数可)
        };

        //開始
        Process process = Process.Start(processStartInfo);

        StreamReader streamReader = process.StandardOutput;
        string str = streamReader.ReadLine();

        //終了
        process.WaitForExit();
        process.Close();

        print(str);
    }

    // 停止時
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
        print("停止");
    }
}
