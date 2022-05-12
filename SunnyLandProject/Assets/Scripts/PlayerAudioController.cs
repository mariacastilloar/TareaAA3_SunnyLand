using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    // keep track of the jumping state ... 
    bool isJumping = false;
    // make sure to keep track of the movement as well !
    bool isPlaying = false;
     AudioSource[] allSources;
     AudioSource cherrySource;
     AudioSource crouchSource;
     AudioSource footstepsSource;
     AudioSource jumpSource;
     AudioSource landSource;


    Rigidbody2D rb; // note the "2D" prefix 
    
    // Start is called before the first frame update
    void Start()
    {
	rb = GetComponent<Rigidbody2D>();
   	// get the references to your audio sources here ! 
       allSources = GetComponents<AudioSource>();
       cherrySource = allSources [0];
       crouchSource = allSources [1];
       footstepsSource = allSources [2];
       jumpSource = allSources [3];
       landSource = allSources [4];

    }

    // FixedUpdate is called whenever the physics engine updates
    void FixedUpdate() {
         Debug.Log("speed" + rb.velocity.magnitude);
        
        float v = rb.velocity.magnitude;
        if (v > 1 && !isPlaying) {
            footstepsSource.Play();
            isPlaying = true;
        } else if (v < 1 && isPlaying) {
            footstepsSource.Stop();
            isPlaying = false;
        }
    }
	// Use the ridgidbody instance to find out if the fox is
	// moving, and play the respective sound !
	// Make sure to trigger the movement sound only when
	// the movement begins ...

	// Use a magnitude threshold of 1 to detect whether the
	// fox is moving or not !
	// i.e.
	// if ( ??? > 1 && ???) {
	//    play sound here !
	// } else if ( ??? < 1 &&) {
	//   stop sound here !
	// }	
    
    
    // trigger your landing sound here !
    public void OnLanding() {
      
        isJumping = false;
        print("the fox has landed");

        landSource.Play();
	// to keep things cleaner, you might want to
	// play this sound only when the fox actually jumoed ...
    }

    // trigger your crouching sound here
    public void OnCrouching() {
        print("the fox is crouching");

        crouchSource.Play();
    }
 
    // trigger your jumping sound here !
    public void OnJump() {
        isJumping = true;
        print("the fox has jumped");

        jumpSource.Play();
    }


    // trigger your cherry collection sound here !
    public void OnCherryCollect() {
        print("the fox has collected a cherry");

        cherrySource.Play();
    }
}

