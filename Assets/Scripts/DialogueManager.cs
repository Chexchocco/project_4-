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
    Dictionary<int, string[]> talkData;
    public Sprite[] portraitArr;
    public int Index;
    public int Event_index;
    public int index_for;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        return talkData[id][talkIndex];
    }
    
    public void Gen_data()
    {
        portraitData = new Dictionary<int, Sprite>
        {
            { 0, portraitArr[0] },
            { 1, portraitArr[1] },
            { 2, portraitArr[2] },
            { 3, portraitArr[3] }


        };

        talkData = new Dictionary<int, string[]>
        {
            {
                1,
                new string[]{"안녕? , 부탁이 있어서 왔어 너구리야."  , "혹시 지금 시간 좀 될까?" , "우리 우체국에 편지가 하나 왔는데, 주소가 어딘지 잘 모르겠어."
            , "듣자하니 이런 편지는 너가 처리해준다고 했던데 맞아?" ,"고마워! 잘 부탁해."}
            },
            { 0, new string[] { "잘 자고 있던 중이었어. 무슨일인데 그래.", "흠. 내가 이 편지를 처리해줄게." } },
            {
                2,
                new string[]{"잠자던 너구리는 사실은 엘리트 우체부였습니다." , "너구리는 사실 선계에 들어가 신선으로 부터 여러 도술을 배웠고, 이 편지는 그 신선에게 배달해야할 편지입니다." ,
        "너구리는 AD 로 좌우이동이 가능하며, space로 점프할 수 있습니다.", "그외에도 E을 누를 경우 몇 초 전으로 돌아갈 수 있습니다. 대부분의 스테이지에서 한 번만 사용 가능 합니다. ", "몇몇 물체에 마우스를 올리고 R을 누를 경우 물체의 상태를 원상태로 돌릴 수 있습니다. 대부분의 스테이지에서 한 번만 사용 가능합니다." ,
         "마지막으로 F를 누를 경우 몇몇 물체와 상호작용 할 수 있습니다." , "옆에 있는 돌에 가까이가서 F를 누르는 것으로 게임이 시작됩니다."}
            },
            {
                3,
                new string[]{"너구리구나! 편지 배달을 와줘서 정말 고맙네."}

            }
        };



    }
    public void Interaction(GameObject obj)
    {
        obj_data odata= obj.GetComponent<obj_data>();

        string Tdata = GetTalk(odata.id, Index);
        if (Tdata == null)
        {
            Index = 0;
            On_action = false;
            Board.SetActive(false);
            return;
        }

        On_action = true;
        Board.SetActive(true);
        Portrait.sprite = portraitData[odata.id];
        Interaction_object = obj;
        DialougeText.text = Tdata;

        Index++;
    }
    public void First_event(GameObject nugul, GameObject ori)
    {
        obj_data nugul_data = nugul.GetComponent<obj_data>();
        obj_data ori_data = ori.GetComponent<obj_data>();
        switch (index_for)
        {
            case 0:
                Portrait.sprite = portraitData[ori_data.id];
                DialougeText.text = GetTalk(ori_data.id, 0); ;
                index_for++;
                break;
            case 1:
                DialougeText.text = GetTalk(ori_data.id, 1); ;
                index_for++;
                break;
            case 2:
                Portrait.sprite = portraitData[nugul_data.id];
                DialougeText.text = GetTalk(nugul_data.id, 0); ;
                index_for++;
                break;
            case 3:
                Portrait.sprite = portraitData[ori_data.id];
                DialougeText.text = GetTalk(ori_data.id, 2);
                index_for++;
                break;
            case 4:
                DialougeText.text = GetTalk(ori_data.id, 3); 
                index_for++;
                break;
            case 5:
                Portrait.sprite = portraitData[nugul_data.id];
                DialougeText.text = GetTalk(nugul_data.id, 1); ;
                index_for++;
                break;
            case 6:
                Portrait.sprite = portraitData[ori_data.id];
                DialougeText.text = GetTalk(ori_data.id, 4); ;
                index_for++;
                break;
            case 7:
                index_for++;
                break;
        }
        if (index_for == 8)
        {
            On_action = false;
            Board.SetActive(false);
            return;
        }




    }
}
