using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class TimeObject : MonoBehaviour
{
    // Start is called before the first frame update
    private bool mouse_over = false;
    private bool rewind = false;
    float rewind_durataion = 1.0f;
    float speed = 0.003f;
    float cool_down = 0.0f;
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (mouse_over == true)
        {
            if ((Input.GetKey(KeyCode.R)) &&(cool_down <= 0.0f) )
            {
                rewind = true;
                rewind_durataion = 10.0f;
                cool_down = 3.0f;
                Debug.Log("rewinded");
            }
        }
        if(rewind = true)
        {
            rewind_durataion -= Time.deltaTime;

            if(rewind_durataion <= 0)
            {
                rewind = false;
               
            }
        }
        if(cool_down > 0.0f)
        {
            cool_down -= Time.deltaTime;
        }

        if(rewind == true)
        {
            this.transform.Translate(new Vector3(speed, 0, 0));
        }
        else
        {
            this.transform.Translate(new Vector3(-1*speed, 0, 0));
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
