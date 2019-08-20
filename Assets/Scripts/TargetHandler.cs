using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHandler : MonoBehaviour
{

    public Toggle changer;
    public GameObject item1, item2, item3, item4;
    int GroupID;
    // Start is called before the first frame update
    void Start()
    {
        changer.isOn = true;
        //item1 = GetComponent<Transform>().GetChild(0).gameObject;
        //item2 = GetComponent<Transform>().GetChild(1).gameObject;
        //item3 = GetComponent<Transform>().GetChild(2).gameObject;
        //item4 = GetComponent<Transform>().GetChild(3).gameObject;
        item1.SetActive(true);
        item2.SetActive(false);
        item3.SetActive(false);
        item4.SetActive(false);
        GroupID = PlayerPrefs.GetInt("Group ID");
    }

    // Update is called once per frame
    void Update()
    {
        /*if(changer.isOn == true)
        {
            Debug.Log("On");
            item1.SetActive(false);
            item2.SetActive(true);
        }
        else if(changer.isOn == false)
        {
            Debug.Log("off");
            item2.SetActive(false);
            item1.SetActive(true);
        }*/

        switch (GroupID)
        {
            case 1:
                Debug.Log(" 1 is On");
                item1.SetActive(true);
                item2.SetActive(false);
                item3.SetActive(false);
                item4.SetActive(false);
                break;
            case 2:
                Debug.Log(" 2 is On");
                item1.SetActive(false);
                item2.SetActive(true);
                item3.SetActive(false);
                item4.SetActive(false);
                break;
            case 3:
                Debug.Log(" 3 is On");
                item1.SetActive(false);
                item2.SetActive(false);
                item3.SetActive(true);
                item4.SetActive(false);
                break;
            case 4:
                Debug.Log(" 4 is On");
                item1.SetActive(false);
                item2.SetActive(false);
                item3.SetActive(false);
                item4.SetActive(true);
                break;

        }
    }
}
