using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private int _health = 100;
    public Text healthText;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameOverCheck();
	}

    public void LoseHealth()
    {
        _health -= 5;
        healthText.text = "Health: " + _health;
    }

    public void GameOverCheck()
    {
        if(_health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
