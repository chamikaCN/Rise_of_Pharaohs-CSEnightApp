using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using TMPro;
using UnityEngine.SceneManagement;

public class factionHandler : MonoBehaviour
{
    int GroupID;
    public GameObject item1, item2, item3, item4, button;
    public Text topText, loadingText;
    public TextMeshProUGUI groupText;
    string fullText, loadingfullText, trackingStatus, imageTargetname, groupName;

    void Start()
    {
        fullText = "you belong to the followers of";
        loadingfullText = " 0 0 0 0 0 0";
        imageTargetname = "ImageTarget";
        GroupID = PlayerPrefs.GetInt("Group ID");
        activateFactions();
        button.gameObject.SetActive(false);
        StartCoroutine(showText(fullText, topText));
        trackingStatus = "TRACKED";
        StatusChanger();
    }

    void Update()
    {
        StatusChanger();
    }

    void activateFactions()
    {
        switch (GroupID)
        {
            case 1:
                groupName = "Horus";
                item1.SetActive(true);
                item2.SetActive(false);
                item3.SetActive(false);
                item4.SetActive(false);
                break;
            case 2:
                groupName = "BASTET";
                item1.SetActive(false);
                item2.SetActive(true);
                item3.SetActive(false);
                item4.SetActive(false);
                break;
            case 3:
                groupName = "OSIRIS";
                item1.SetActive(false);
                item2.SetActive(false);
                item3.SetActive(true);
                item4.SetActive(false);
                break;
            case 4:
                groupName = "ANUBIS";
                item1.SetActive(false);
                item2.SetActive(false);
                item3.SetActive(false);
                item4.SetActive(true);
                break;
        }
    }

    IEnumerator showText(string text, Text positionText)
    {
        for (int k = 0; k < text.Length; k++)
        {
            positionText.text = text.Substring(0, k + 1);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator showLoader()
    {
        while (trackingStatus == "NO_POSE")
        {
            for (int k = 0; k < loadingfullText.Length; k++)
            {
                loadingText.text = loadingfullText.Substring(0, k + 1);
                yield return new WaitForSeconds(0.2f);
            }
        }

    }

    private string isTrackingMarker(string imageTargetName)
    {
        var imageTarget = GameObject.Find(imageTargetName);
        var trackable = imageTarget.GetComponent<TrackableBehaviour>();
        var status = trackable.CurrentStatus;
        return status.ToString();
    }

    void StatusChanger()
    {
        if (trackingStatus != isTrackingMarker(imageTargetname))
        {
            trackingStatus = isTrackingMarker(imageTargetname);
            changeLoadingText();
        }
    }

    void changeLoadingText()
    {
        if (trackingStatus == "NO_POSE")
        {
            loadingText.gameObject.SetActive(true);
            groupText.gameObject.SetActive(false);
            StartCoroutine(showLoader());
        }
        else
        {
            loadingText.gameObject.SetActive(false);
            groupText.text = groupName;
            groupText.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
        }
    }

    public void proceedNext()
    {
        SceneManager.LoadScene("InfoPart");
    }

}
