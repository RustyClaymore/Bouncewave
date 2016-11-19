using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    
    public GameObject playButton;
    public GameObject levelSelect;
    public GameObject creditsButton;
    Vector3 levelSelectPos;
    bool active;

    public GameObject levelSelectPanel;
    public GameObject levelSelectPanelOpenRef;
    public GameObject levelSelectPanelCloseRef;

    public GameObject LevelInfo;
    public GameObject LevelInfoOpenRef;
    public GameObject LevelInfoCloseRef;

    public Text levelText;
    public int levelNum;

    public Scene[] GameLevels;

    // Use this for initialization
    void Start()
    {
        active = false;
        levelSelectPos = levelSelect.transform.position;
    }

    public void LevelSelect()
    {
        active = !active;

        if (active)
        {
            levelSelectPos = levelSelect.transform.position;
            iTween.ScaleTo(playButton, new Vector3(0, 1, 1), 0.5f);
            iTween.ScaleTo(creditsButton, new Vector3(0, 1, 1), 0.5f);
            iTween.MoveTo(levelSelect, playButton.transform.position, 0.5f);
            Invoke("SlideLevelsIn", 0.25f);
        }
        else
        {
            SlideLevelsIn();
            iTween.ScaleTo(playButton, new Vector3(1, 1, 1), 0.5f);
            iTween.ScaleTo(creditsButton, new Vector3(1, 1, 1), 0.5f);
            iTween.MoveTo(levelSelect, levelSelectPos, 0.8f);
        }        
    }

    void SlideLevelsIn()
    {
        if (active)
        {
            levelSelectPanel.SetActive(active);
            Debug.Log("triggered");
            iTween.MoveTo(levelSelectPanel, levelSelectPanelOpenRef.transform.position, 0.5f);
        }
        else
        {
            iTween.MoveTo(levelSelectPanel, levelSelectPanelCloseRef.transform.position, 0.5f);
            Invoke("Deactivate", 0.4f);
        } 
    }

    void Deactivate()
    {
        levelSelectPanel.SetActive(active);
    }

    public void OpenLevelInfo()
    {
        iTween.MoveTo(LevelInfo, LevelInfoOpenRef.transform.position, 0.5f);
    }

    public void CloseLevelInfo()
    {
        iTween.MoveTo(LevelInfo, LevelInfoCloseRef.transform.position, 0.5f);
    }

    public void DisplayLevelInfo(string level)
    {
        levelText.text = level;
    }

    public void SetNextLevel(int level)
    {
        levelNum = level;
    }

    public void PlayLevel()
    {
        SceneManager.LoadScene(levelNum);
    }

    // Update is called once per frame
    void Update () {
	    
	}
}
