using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Koin : MonoBehaviour
{
	private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter2D(Collider2D other)
	{
		score = score + 5;
		Destroy(gameObject);
		UnityEngine.Debug.Log("Score: " + score);
	}
}
