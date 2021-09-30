using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Event_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public DialogueManager dialogue;
    public Player player;
    public bool first_event;
    public GameObject ori;
    public GameObject ply;
    public GameObject scroll;
    
    void Start()
    {
        dialogue.On_action = false;
        dialogue.Board.SetActive(false);
        dialogue.Gen_data();
        if (first_event == false)
        {
            dialogue.First_event(ply, ori);
            player.on_event = true;
            scroll.SetActive(false);
            dialogue.On_action = true;
            dialogue.Board.SetActive(true);

        }

        if (first_event== true)
        {

        }
        

    }

    // Update is called once per frame
    void Update()
    {


        if ((first_event != true))
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                dialogue.First_event(ply, ori);
            }
            if (dialogue.index_for == 4)
            {
                scroll.SetActive(true);
            }
            if (dialogue.index_for == 6)
            {
                scroll.SetActive(false);
            }
            if (dialogue.index_for == 8)
            {
                first_event = true;
                player.on_event = false;
                ori.SetActive(false);
                dialogue.On_action = false;
                dialogue.Board.SetActive(false);
            }
        }
        


    }


}
