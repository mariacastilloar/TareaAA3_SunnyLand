using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
public class BoxScript : MonoBehaviour
{
    AudioSource[] allSources;
    AudioSource audioSource;
    AudioSource movementSource;
    Rigidbody2D rb;
   
    bool isPlaying = false;
 
    // Start is called before the first frame update
    void Start()
    {
   
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("the  mass of this sphere is" + rb.mass);
        
        allSources = GetComponents<AudioSource>();
        audioSource = allSources [0];
        movementSource = allSources [1];
    }
 
    void FixedUpdate() {
        Debug.Log("speed" + rb.velocity.magnitude);
        
        float v = rb.velocity.magnitude;
        if (v > 1 && !isPlaying) {
            movementSource.Play();
            isPlaying = true;
        } else if (v < 1 && isPlaying) {
            movementSource.Stop();
            isPlaying = false;
        }
    }
 
    // Update is called once per frame
    void Update()
    {
        
    }
 
    void OnCollisionEnter2D(Collision2D collision) {

       Debug.Log("OnCollisionEnter2D");
       audioSource.Play();
   }

}