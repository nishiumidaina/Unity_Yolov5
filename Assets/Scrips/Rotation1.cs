using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Threading;

public class Rotation1 : MonoBehaviour
{
    Vector3 Y;
    float N;
    float M;
    // Update is called once per frame
    void Update()
    {
        //�ϓ��̃A�j���[�V����
        if(Y.y > N)
        {
            Y.y = Y.y + 50;
            gameObject.transform.localScale = Y;
            Debug.Log("�X�V");
        }
        else if(Y.y < N)
        {
            if(Y.y > 0)
            {
                Y.y = Y.y - 50;
                gameObject.transform.localScale = Y;
                Debug.Log("�X�V");
            }
            else
            {
                gameObject.transform.localScale = Y;
                Debug.Log("�X�V");
            }

        }
        else if(Y.y == N)
        {
            gameObject.transform.localScale = Y;
            Debug.Log("�X�V");
        }

    }
    private void Start()
    {
        Y = gameObject.transform.localScale;
        //DelayMethod��5�b��ɌĂяo��5�b���Ɏ��s
        InvokeRepeating(nameof(DelayMethod), 2.0f, 10.0f);
    }

    void DelayMethod()
    {
        MySqlConnection con = new MySqlConnection("server=localhost;uid=0000;pwd=0000;database=unityproject");

        try
        {
            N = M; 
            string prefab_id = name;
            con.Open();
            string sql = $"SELECT * FROM spots WHERE spots_id={prefab_id}";
            MySqlCommand com = new MySqlCommand(sql, con);
            MySqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                float count = Y.y;
                object Spot = reader[3];
                //�����̒���
                int Spot_i = (int)Spot * 5000;
                float Spot_f = (float)Spot_i;
                Y.y = Spot_f + 1;
                gameObject.transform.localScale = Y;
                M = Y.y;
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