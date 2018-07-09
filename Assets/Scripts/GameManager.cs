using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // make static instance
    public static GameManager instance;

    // get scene switcher component to run as our state
    public SceneSwitcher sceneScript;

    // References to hold!
    public GameObject player;
    public List<GameObject> zombies;
    public List<GameObject> guards;

	// Use this for initialization
	void Awake ()
    {
        // Singleton
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

    // Always start game on MainMenu
    private void Start()
    {
        sceneScript.LoadMainMenu();
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
