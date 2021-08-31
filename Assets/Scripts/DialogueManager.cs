using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text DialougeText;
    public Text NameText;
    public Image Portrait;
    public GameObject Interaction_object;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interaction(GameObject obj)
    {
        Interaction_object = obj;
        NameText.text = obj.name;
        
    }
}
