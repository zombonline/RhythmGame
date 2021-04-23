using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public bool hasStarted;
    [SerializeField] LevelManager lvlManager;

    float timeLastFrame = 0;
    float deltaTime = 0;

    [SerializeField]public float speed = 1;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            // Detect how much time has passed in the song
            deltaTime = lvlManager.GetComponent<AudioSource>().time - timeLastFrame;
            timeLastFrame = lvlManager.GetComponent<AudioSource>().time;

            // Move forward at your speed based on how much time has passed in the music
            transform.position += Vector3.down * speed * deltaTime;
        }
    }
}
