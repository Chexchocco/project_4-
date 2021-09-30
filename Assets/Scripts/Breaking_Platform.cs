using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaking_Platform : MonoBehaviour
{
    public Player player;
    public bool broken;
    public Animator anime;
    public float time;
    public bool mouse_over = false;

    public Collider2D Boxcoll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(broken== true)
        {
            anime.SetBool("breaking", true);
            if (time > 0)
            {
                time -= Time.deltaTime;
                if(time<= 0)
                {
                    Boxcoll.enabled = false;
                }
            }
            if ((mouse_over == true) && /*(player.rewind_cooldown <= 0)*/ (player.Can_rewind==true) && (Input.GetKey(KeyCode.R)))
            {
                player.Can_rewind = false;
                anime.SetBool("breaking", false);
                broken = false;
                Boxcoll.enabled = true;
                time = 0.5f;
               
            }
        }
        
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        broken = true;
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


