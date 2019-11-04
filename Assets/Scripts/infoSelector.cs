using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using System;

public class infoSelector : MonoBehaviour
{
    public Sprite Anubis, Osiris, Bastet, Horus;
    Sprite godSprite;
    Image panel;
    public GameObject revealPanel;
    public TextMeshProUGUI godName, godDesciption, godParagraph1, godParagraph2;
    public Text venueText;
    int GroupID;
    God myGod;

    private void Start()
    {
        //PlayerPrefs.SetInt("Group ID", Mathf.RoundToInt(Random.Range(1.0f, 4.0f)));
        GroupID = GameManager.getGroupID();
        if (GroupID > 0)
        {
            myGod = GameManager.getGodInfo(GroupID);
        }
        SetSprite();
        SetInfo();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("IndexPart");
        }
    }

    private void SetSprite()
    {
        switch (GroupID)
        {
            case 1:
                godSprite = Horus;
                break;
            case 2:
                godSprite = Bastet;
                break;
            case 3:
                godSprite = Osiris;
                break;
            case 4:
                godSprite = Anubis;
                break;
        }
    }

    void SetInfo()
    {
        panel = GetComponent<Image>();
        panel.sprite = godSprite;
        godName.text = myGod.GodName.ToUpper();
        godDesciption.text = myGod.GodTitle;
        godParagraph1.text = "demands your presence to witness the reincarnation of" + "\n" +
        "' ramses II '" + "\n" + "the gratest pharaoh ever lived, coming back to this world to fulfill his destiny";
        godParagraph2.text = myGod.GodName + " wants " + myGod.GodPronoun2 + " to be chosen as the new patreon " + myGod.GodPronoun1 + " of the new empire.it is your " +
            "responsibility to make " + myGod.GodPronoun2 + " proud or suffer the wrath of a " + myGod.GodPronoun1;
        venueText.text = "on 12th november\n@ 2 pm\nin the old gym \n(come to " + myGod.GodVenue+ ")";
    }

    public void openPanel()
    {
        revealPanel.SetActive(true);
    }

    public void closePanel()
    {
        revealPanel.SetActive(false);
    }

    public void returnLoad()
    {
        GameManager.SaveData();
        SceneManager.LoadScene("IndexPart");
    }
}
