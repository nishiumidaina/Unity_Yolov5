using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController2 : MonoBehaviour
{
    public void OnClickButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
