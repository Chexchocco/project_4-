using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class start : MonoBehaviour
{
    public Image fade;
    public GameObject room;
    public Animator anime;
    public Animator anime_start;
    float time;
    float fade_time;
    float fades;
    // Start is called before the first frame update
    void Start()
    {
        anime = room.GetComponent<Animator>();
       
        fades = 1.0f;
        time = 0;
        fade_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (fade_time == 0)
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
                fade_time = 1;
                time = 0;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                anime.SetTrigger("start");
                time = 2.0f;
            }
            if (time > 0)
            {
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }

    }
    private void OnMouseEnter()
    {
        anime_start.SetBool("New Bool", true);
    }

    private void OnMouseExit()
    {
        anime_start.SetBool("New Bool", false);
    }
}
