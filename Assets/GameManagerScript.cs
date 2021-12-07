using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    int fallen = 0;
    public int max = 7;
    float time = 0f;
    bool won = false;
    public Text textBox;
    public float bestTime;

    // Start is called before the first frame update
    void Start()
    { 
        bestTime = PlayerPrefs.GetFloat("bestTime", 100000);
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(!won) {
            textBox.text = time.ToString("F2");
        }
    }
    public void AddFallen() {
        fallen += 1;

        if (fallen >= max) {
            textBox.text = "Voitit pelin ajalla " + time.ToString("F2");
            won = true;
            if(time < bestTime) {
                PlayerPrefs.SetFloat("bestTime", time);
                textBox.text = "Voitit pelin parhaalla ajalla!\nEntinen aika: " +
                    bestTime.ToString("F2") + "\nUusi aika: " + time.ToString("F2");
            }
        }
    }
}
