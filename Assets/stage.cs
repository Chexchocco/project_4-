using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class stage : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anime;
    public Stage_manager Stage;
    float time;
    bool qqq;
    void Start()
    {
        qqq = false;
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if( ( qqq == false && Stage.next_Stage == true)) 
        {
            anime.SetTrigger("Activated");
            time = 1.0f;
            qqq = true;
        }
        if(time > 0)
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                SceneManager.LoadScene("Stage" + (Stage.number+1));
            }
        }
    }
}
