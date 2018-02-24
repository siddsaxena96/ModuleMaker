using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//GitTest
public class GameController : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject ball;
    public Button[] buttons;
    public GameObject correct;
    private int numberOfBalls=0;
	
    // Use this for initialization
	void Start () {
        spawnBalls ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey (KeyCode.R)) {
            reset ();
        }
	}

    public void spawnBalls()
    {
        numberOfBalls = Random.Range (1, 10);
        //Debug.Log (numberOfBalls);

        for (int i = 0; i < numberOfBalls; i++) {

            Instantiate (ball, spawnPoints [i].position, Quaternion.identity);
        
        }

        int correctIndex = Random.Range (0, 3);
        int factor = -1;
        for (int i = 0; i < buttons.Length; i++) {

            if (i == correctIndex) {
                buttons [i].GetComponentInChildren<Text>().text=numberOfBalls.ToString ();
                buttons [i].onClick.AddListener (delegate{checkAnswer (numberOfBalls);});

            } else {
                buttons [i].GetComponentInChildren<Text>().text=(numberOfBalls + factor).ToString ();
                buttons [i].onClick.AddListener (delegate{checkAnswer (numberOfBalls + factor);});
                factor *= -1;
            }

        }

    }

    public void checkAnswer(int answer){
        if (answer == numberOfBalls) {
            Debug.Log ("Correct");
            correct.SetActive (true);         
        } else {
            Debug.Log ("Loser");
        }
    }

    public void reset()
    {
        //Reload the current scene
        correct.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
        
}
