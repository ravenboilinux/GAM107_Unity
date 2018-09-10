using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public string MainMenuScene;
    public string StartingScene;

    [SerializeField]
    public ButtonCompanent StartButton;
    [SerializeField]
    public ButtonCompanent LoadButton;
    [SerializeField]
    public ButtonCompanent OptionsButton;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Use this for initialization
    void Start () {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name.Equals(MainMenuScene))
        {
            LoadMainMenu();
        }
    }

    private void LoadMainMenu()
    {
        setUpButtonHandler(StartButton.ButtonName, StartButton.ButtonText, StartGame);
        setUpButtonHandler(LoadButton.ButtonName, LoadButton.ButtonText, LoadGame);
        setUpButtonHandler(OptionsButton.ButtonName, OptionsButton.ButtonText, GameOptions);
    }

    private void setUpButtonHandler(string buttonName,string buttonText, UnityAction call)
    {
        var button = GameObject.Find(buttonName).GetComponent<UnityEngine.UI.Button>();
        button.GetComponentInChildren<Text>().text = buttonText;
        button.onClick.AddListener(call);
    }

    void LoadGame()
    {
        Debug.Log("Load Game");
    }
    void StartGame()
    {
        SceneManager.LoadScene(StartingScene);
    }
    void GameOptions()
    {
        Debug.Log("Game Options");
    }

}
