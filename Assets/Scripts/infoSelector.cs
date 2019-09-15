using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class infoSelector : MonoBehaviour
{
    public Sprite Anubis,Osiris,Bastet,Horus;
    Sprite GodSprite;
    Image panel;
    public GameObject revealPanel;
    public TextMeshProUGUI godName, godDesciption, godParagraph1, godParagraph2;
    public Text venueText;
    int groupNo;
    string GodName, GodDescription, Godpronoun, Godgender;
    string plAnu, plOsi, plBas, plHor, place;

    private void Start()
    {
        //PlayerPrefs.SetInt("Group ID", Mathf.RoundToInt(Random.Range(1.0f, 4.0f)));
        groupNo = PlayerPrefs.GetInt("Group ID");
        plAnu = "AnubisPlace";
        plOsi = "OsirisPlace";
        plBas = "BastetPlace";
        plHor = "HorusPlace";
        switch (groupNo)
        {
            case 1:
                GodName = "HORUS";
                GodDescription = "protector of egypt";
                Godpronoun = "him";
                Godgender = "god";
                GodSprite = Horus;
                place = plHor;
                break;
            case 2:
                GodName = "BASTET";
                GodDescription = "protector of people";
                Godpronoun = "her";
                Godgender = "goddess";
                GodSprite = Bastet;
                place = plBas;
                break;
            case 3:
                GodName = "OSIRIS";
                GodDescription = "lord of the underworld";
                Godpronoun = "him";
                Godgender = "god";
                GodSprite = Osiris;
                place = plOsi;
                break;
            case 4:
                GodName = "ANUBIS";
                GodDescription = "god of death";
                Godpronoun = "him";
                Godgender = "god";
                GodSprite = Anubis;
                place = plAnu;
                break;
        }

        panel = GetComponent<Image>();
        panel.sprite = GodSprite;
        godName.text = GodName;
        godDesciption.text = GodDescription;
        godParagraph1.text = "demands your presence to witness the reincarnation of" + "\n" +
        "' ramses II '" + "\n" + "the gratest pharaoh ever lived, coming back to this world to fulfill his destiny";
        godParagraph2.text = GodName.ToLower() + " wants "+ Godpronoun +" to be chosen as the new patreon " + Godgender + " of the new empire.it is your " +
            "responsibility to make " + Godpronoun + " proud or suffer the wrath of a " + Godgender;
        venueText.text = "on 29th october\n@ night\nin the " + place;
        PlayerPrefs.SetString("Gatherplace", place);
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
        SceneManager.LoadScene("IndexPart");
    }
}
