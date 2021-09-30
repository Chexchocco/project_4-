using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_platform : MonoBehaviour
{
    public event_stage eManager;
    public BoxCollider2D boxcoll;
    public Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(eManager.platform_switch == false)
        {
            boxcoll.enabled = false;
            anime.SetBool("on", false);
        }
        else
        {
            boxcoll.enabled = true;
            anime.SetBool("on", true);
            anime.SetTrigger("sw");
        }
    }
}
