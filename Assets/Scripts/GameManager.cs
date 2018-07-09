using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public SceneSwitcher sceneScript;

    public GameObject player;
    public List<GameObject> zombies;
    public List<GameObject> guards;

    public enum IGameState
    {
        MainMenu,
        GameScene,
        Credits
    };

    public IGameState currentGameState;

	// Use this for initialization
	void Awake ()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        sceneScript = GetComponent<SceneSwitcher>();
	}

    private void Start()
    {
        sceneScript.LoadMainMenu();
    }

    // Update is called once per frame
    void Update ()
    {
        switch (currentGameState)
        {
            case IGameState.MainMenu:
                //MainMenu State
                if (currentGameState != IGameState.MainMenu)
                {
                    sceneScript.LoadMainMenu();
                }
                break;

            case IGameState.GameScene:
                //GamePlay State
                if (currentGameState != IGameState.GameScene)
                {
                    sceneScript.LoadGameScene();
                }
                break;

            case IGameState.Credits:
                //Credits State
                if (currentGameState != IGameState.Credits)
                {
                    sceneScript.LoadCredits();
                }
                break;
        }
    }
}
