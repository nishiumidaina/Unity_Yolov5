using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 kero;  //‡@‰¼‚Ì•Ï”éŒ¾


        kero = gameObject.transform.localScale; //ŸŒ»İ‚Ì‘å‚«‚³‚ğ‘ã“ü
        kero.x = kero.x + 1;  //‡A•Ï”kero‚ÌxÀ•W‚ğ1‘‚â‚µ‚Ä‘ã“ü
        gameObject.transform.localScale = kero; //‡B‘å‚«‚³‚É•Ï”kero‚ğ‘ã“ü
    }
}
