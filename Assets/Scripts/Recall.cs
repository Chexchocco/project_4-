using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recall : MonoBehaviour
{
    private Vector3 initPos;
    private float speed;
    private float range;

    private float count = 0.0f;
    public GameObject real_Recall;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void init(Player player)
    {
        initPos = player.gameObject.transform.position;
        gameObject.transform.position = player.gameObject.transform.position; // 생성위치 변경
       
        
    }
    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if(Time.deltaTime >= 3)
        {


            GameObject Rec = GameObject.Instantiate(real_Recall);
            Rec.GetComponent<Real_recall>().init(this);
        }
    }
}
