using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public float  maxTime;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time=maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        time = time - Time.deltaTime*1;
        int minutes=(int)time/60;
        int seconds=(int)time%60;
        if(seconds<10){
             timeText.text=minutes.ToString()+":0"+seconds.ToString(); 
        }
        else{
             timeText.text=minutes.ToString()+":"+seconds.ToString(); 
        }
        
    }
}
