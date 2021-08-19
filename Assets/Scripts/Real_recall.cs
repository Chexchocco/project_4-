using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Real_recall : MonoBehaviour
{
    private Vector3 initPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void init(Recall recall)
    {
        initPos = recall.gameObject.transform.position;
        gameObject.transform.position = recall.gameObject.transform.position; // 생성위치 변경


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
