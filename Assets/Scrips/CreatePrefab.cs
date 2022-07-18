using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using MySql.Data.MySqlClient;

public class CreatePrefab : MonoBehaviour
{
    public GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        MySqlConnection con = new MySqlConnection("server=localhost;uid=0000;pwd=0000;database=unityproject");

        try
        {
            string prefab_id = name;
            con.Open();
            string sql = $"SELECT * FROM spots";
            MySqlCommand com = new MySqlCommand(sql, con);
            MySqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                //Unity内での原点(0,0)の緯度と経度
                double lat_un = 35.68484615220562; 
                double long_un = 139.68082581140052;
                double max_lat_un = -2451;
                double max_long_un = -4292.5;

                object spot_id = reader[0];
                object spot_lat = reader[5];
                object spot_long = reader[6];
                

                string prefab_name = spot_id.ToString();
                string prefab_lat_st = spot_lat.ToString();
                string prefab_long_st = spot_long.ToString();


                //固定小数点
                double prefab_lat_d = double.Parse(prefab_lat_st);
                double prefab_long_d = double.Parse(prefab_long_st);


                //緯度と経度の増加値
                double new_lat_d = prefab_lat_d - lat_un;
                double new_long_d = prefab_long_d - long_un;

                double an_lat = new_lat_d * max_lat_un / 0.01745698671;
                double an_long = new_long_d * max_long_un / 0.03847317242;


                //floatに変換
                float prefab_lat_f = (float)an_lat;
                float prefab_long_f = (float)an_long;
                
                var obj = Instantiate(point, new Vector3(prefab_long_f, 72.2f, prefab_lat_f), Quaternion.identity) as GameObject;
                obj.name = prefab_name;
                Debug.Log(obj.name);
                Debug.Log(prefab_long_f);
                Debug.Log(prefab_lat_f);

            }
            reader.Close();
        }
        catch (MySqlException e)
        {
            Debug.Log(e.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
