using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
 public Sprite crankDown;
 public Sprite crankUp;
 public SpriteRenderer checkpointRenderer;
 public bool cekCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
     checkpointRenderer = GetComponent<SpriteRenderer> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
     if(other.tag == "Karakter") {
      checkpointRenderer.sprite = crankUp;
      cekCheckpoint = true;
     }
    }
}