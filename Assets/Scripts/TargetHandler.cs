using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TargetHandler : MonoBehaviour
{
    int GroupID,artifacts;
    public Text artifactText;
    public GameObject progressPanel, Date, Time, Venue, Night, Pharaohs;
    public GameObject[] texts;

    void Start()
    {
        GroupID = PlayerPrefs.GetInt("Group ID");
        artifacts = 0;
        artifactText.text = "ARTIFACTS   0";
        progressPanel.SetActive(false);
        texts = new GameObject[5];
        texts[0] = Night;
        texts[1] = Pharaohs;
        texts[2] = Date;
        texts[3] = Time;
        texts[4] = Venue;
        for(int j = 0; j < 5; j++)
        {
            texts[j].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit,1<<8))
            {
                if(hit.collider.name == "Pharaoh")
                {
                    Destroy(hit.collider.gameObject);
                    collectArtifact();
                }
            }
        }

        if (artifacts >= 6)
        {
            progressPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("IndexPart");
        }
    }

    public void collectArtifact()
    {
        if (artifacts < 5)
        {
            texts[artifacts].SetActive(true);
        }
        artifacts += 1;
        artifactText.text = "ARTIFACTS   " + artifacts;
    }

    public void progressFaction()
    {
        SceneManager.LoadScene("ChoosingPart");
    }
}
