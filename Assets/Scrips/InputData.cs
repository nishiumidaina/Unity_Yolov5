using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Web;
using System.Net;
using System.Text;

using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

public class InputData : MonoBehaviour
{
    public Text text;

    public void TextAppare()
    {


        //InputFieldに入力された文字を取得&型の変換
        Text TextName = GameObject.Find("InputName/Text").GetComponent<Text>();
        Text TextAddress = GameObject.Find("InputAddress/Text").GetComponent<Text>();
        Text TextURL = GameObject.Find("InputURL/Text").GetComponent<Text>();

        string Name = TextName.text;
        string Address = TextAddress.text;
        string URL = TextURL.text;
        int Count = 0;
        string Status = "None";

        var url = string.Format("https://www.geocoding.jp/api/?q={0}",
            HttpUtility.UrlEncode(Address));

        byte[] results;
        using (var wc = new WebClient())
        {
            results = wc.DownloadData(url);
        }

        string String_XML = Encoding.UTF8.GetString(results);
        var xml = XDocument.Parse(String_XML);
        Debug.Log(xml);
        var lat = xml.XPathSelectElement(@"./result/coordinate/lat");
        var lng = xml.XPathSelectElement(@"./result/coordinate/lng");
        string lat_st = lat.Value;
        string long_st = lng.Value;


        var connectionString = "server=localhost;uid=0000;pwd=0000;database=unityproject";
        var sql = "INSERT INTO spots (spots_name, spots_status, spots_count, spots_url, spots_latitude, spots_longitude) VALUES (@name, @status, @count, @url, @latitude ,@longitude)";

        // インスタンスを生成
        using (var connection = new MySqlConnection(connectionString))

        using (var command = new MySqlCommand(sql, connection))
        {
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = sql;
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@status", Status);
                command.Parameters.AddWithValue("@count", Count);
                command.Parameters.AddWithValue("@url", URL);
                command.Parameters.AddWithValue("@latitude", lat_st);
                command.Parameters.AddWithValue("@longitude", long_st) ;
               
                var result = command.ExecuteNonQuery();

                // 挿入されなかった場合
                if (result != 1)
                {
                    Debug.Log("insert ERROR");
                }
                connection.Close();
            }
            catch (MySqlException me)
            {
                Debug.Log("ERROR: " + me.Message);
            }

        }

        //InputFieldに表示された文字を消す
        InputField NameColumn = GameObject.Find("InputName").GetComponent<InputField>();
        InputField AddressColumn = GameObject.Find("InputAddress").GetComponent<InputField>();
        InputField URLColumn = GameObject.Find("InputURL").GetComponent<InputField>();
        NameColumn.text = "";
        AddressColumn.text = "";
        URLColumn.text = "";
    }

}