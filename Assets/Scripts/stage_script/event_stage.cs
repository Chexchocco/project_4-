using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class event_stage : MonoBehaviour
{

    public bool platform_switch;
    public float switch_time;


    public Image fade;
    float time;
    float fades;
    bool fade_on;
    // Start is called before the first frame update
    void Start()
    {
        platform_switch = false;
        fade_on = false;
        fade.color = new Color(0, 0, 0, 255);
        fades = 1.0f;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (fade_on == false)
        {
            time += Time.deltaTime;
            if (fades > 0.0f && time >= 0.1f)
            {
                fades -= 0.1f;
                fade.color = new Color(0, 0, 0, fades);
                time = 0;
            }
            else if (fades <= 0.0f)
            {
                fade_on = true;
                time = 0;

            }
        }
        if (switch_time > 0)
        {
            switch_time -= Time.deltaTime;
            if (switch_time <= 0)
            {
                platform_switch = false;
            }
        }
    }
}
