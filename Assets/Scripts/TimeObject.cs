using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public bool mouse_over = false;
    public bool rewind = false;
    float rewind_durataion = 1.0f;
    float cool_down = 0.0f;
    
    public short time_flow;
    
    void Start()
    {
        time_flow = 1;
    }


    // Update is called once per frame
    void Update()
    {
        if ( ( mouse_over == true) && ( player.rewind_cooldown <= 0 ) ) 
        {
            if (Input.GetKey(KeyCode.R))
            {

                rewind = true;
                time_flow *= -1;
                rewind_durataion = 10.0f;
                player.Can_rewind = false;
            }
        }
        if (rewind == true)
        {
            rewind_durataion -= Time.deltaTime;

            if (rewind_durataion <= 0)
            {
                rewind = false;
                time_flow *= -1;
            }
        }
        
        


    }

    private void OnMouseEnter()
    {
        mouse_over = true;
}
    private void OnMouseExit()
    {
        mouse_over = false;
    }
  
}
