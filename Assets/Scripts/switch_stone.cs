using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_stone : MonoBehaviour
{
    public event_stage eManager;
    public Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(eManager.platform_switch==true)
        {
            anime.SetTrigger("switch");
            anime.SetBool("on", true);
        }
        if(eManager.platform_switch == false)
        {
            
            anime.SetBool("on", false);
        }
    }
}
