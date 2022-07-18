using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Threading;

public class Rotation2 : MonoBehaviour
{
    Vector3 Y;
    // Update is called once per frame
    void Update()
    {
        Debug.Log(Y);
        gameObject.transform.localScale = Y;
        Debug.Log("更新2");
    }
    private void Start()
    {
        Y = gameObject.transform.localScale;
        //DelayMethodを5秒後に呼び出し5秒毎に実行
        InvokeRepeating(nameof(DelayMethod), 2.0f, 10.0f);
    }

    void DelayMethod()
    {
        MySqlConnection con = new MySqlConnection("server=localhost;uid=0000;pwd=0000;database=unityproject");

        try
        {
            string prefab_id = name;
            con.Open();
            string sql = $"SELECT * FROM spots WHERE spots_id={prefab_id}";
            MySqlCommand com = new MySqlCommand(sql, con);
            MySqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                float count = Y.y;
                object Spot = reader[3];
                //長さの調整
                int Spot_i = (int)Spot * 3000;
                float Spot_f = (float)Spot_i;
                Y.y = Spot_f + 1;
                gameObject.transform.localScale = Y;


            }
            reader.Close();
        }
        catch (MySqlException e)
        {
            Debug.Log(e.ToString());
        }

        Debug.Log("");
    }

    private void OnDestroy()
    {
        CancelInvoke();
    }


}