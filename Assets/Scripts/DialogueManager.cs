using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Board;
    public Text DialougeText;
    public Text NameText;
    public Image Portrait;
    public GameObject Interaction_object;
    public bool On_action;

    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;


    void Start()
    {
        Board.SetActive(false);
        portraitData = new Dictionary<int, Sprite>();

        portraitData.Add(1000 + 0, portraitArr[0]); //0번 인덱스에 저장된 초상화를 id = 1000과 mapping
        portraitData.Add(1000 + 1, portraitArr[1]); //1번 인덱스에 저장된 초상화를 id = 1001과 mapping
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interaction(GameObject obj)
    {
        if (On_action)
        {
            On_action = false;
            Board.SetActive(false);
        }
        else
        {
            On_action = true;
            Board.SetActive(true);
            Interaction_object = obj;
            NameText.text = obj.name;

            if (obj.name == "ori")
            {
                Portrait.sprite = portraitArr[1];
                DialougeText.text = "안녕, 오랜만이야!";
            }
        }
    }
}
