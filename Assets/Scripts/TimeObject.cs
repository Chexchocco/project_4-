using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeObject : MonoBehaviour
{
    // Start is called before the first frame update
    private bool mouse_over = false;
    private bool rewind = false;
    int rewind_durataion = 300;
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (mouse_over == true)
        {
                    }
    }

    void OnMouseOver()
    {
        mouse_over = true;
    }
    void OnMouseExit()
    {
        mouse_over = false;
    }

}
