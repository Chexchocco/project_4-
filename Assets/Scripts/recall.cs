using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recall : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 direction;
    private Vector3 initPos;
    public float timer;
    Player ply;
    public GameObject recallPoint;
    void Start()
    {
        timer = 300;
        if (!(GameObject.FindWithTag("recall_point")))
        {
            GameObject point = GameObject.Instantiate(recallPoint);
            point.GetComponent<Recall_point>().init(this);
        }
    }
    public void init(Player player)
    {
        initPos = player.gameObject.transform.position;
        gameObject.transform.position = player.gameObject.transform.position;
        direction = player.gameObject.transform.forward;
        ply = player;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1;
        if (timer <= 0)
        {
            if (ply.can_move == true)
            {
                if ((GameObject.FindWithTag("recall_point")))
                {
                    Destroy(GameObject.FindWithTag("recall_point"));
                }
                GameObject point = GameObject.Instantiate(recallPoint);
                point.GetComponent<Recall_point>().init(this);
            }
            Destroy(gameObject);
        }
    }
}
