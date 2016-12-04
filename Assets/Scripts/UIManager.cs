﻿using UnityEngine;
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

    public GameObject AsPanel;
    public GameObject BsPanel;
    public GameObject CsPanel;
    public GameObject AsOpenRef;
    public GameObject BsOpenRef;
    public GameObject CsOpenRef;
    public GameObject ClosedRef;

    public GameObject LevelInfo;
    public GameObject LevelInfoOpenRef;
    public GameObject LevelInfoCloseRef;

    public Text levelText;
    public int levelNum;

    public GameObject EndLevelOverlay;

    // Use this for initialization
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            active = false;
            levelSelectPos = levelSelect.transform.position;
        }
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
            iTween.MoveTo(levelSelectPanel, levelSelectPanelOpenRef.transform.position, 0.35f);
            Invoke("SlideLettersDown", .36f);
        }
        else
        {
            iTween.MoveTo(AsPanel, ClosedRef.transform.position, 0.25f);
            iTween.MoveTo(BsPanel, ClosedRef.transform.position, 0.5f);
            iTween.MoveTo(CsPanel, ClosedRef.transform.position, 0.75f);
            Invoke("CloseLevels", 0.75f);
        } 
    }

    void SlideLettersDown()
    {
        iTween.MoveTo(AsPanel, AsOpenRef.transform.position, 0.5f);
        iTween.MoveTo(BsPanel, BsOpenRef.transform.position, 0.75f);
        iTween.MoveTo(CsPanel, CsOpenRef.transform.position, 1f);
    }

    void CloseLevels()
    {
        iTween.MoveTo(levelSelectPanel, levelSelectPanelCloseRef.transform.position, 0.5f);
        Invoke("Deactivate", 0.4f);
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

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Nextlevel()
    {
        if(SceneManager.GetActiveScene().buildIndex < 15)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update () {
	    
	}
}
