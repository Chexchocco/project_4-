using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recall_point : MonoBehaviour
{
    Vector3 direction;
    private Vector3 initPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void init(recall Recall)
    {
        initPos = Recall.gameObject.transform.position;
        gameObject.transform.position = Recall.gameObject.transform.position;
        direction = Recall.gameObject.transform.forward;

    }
}
