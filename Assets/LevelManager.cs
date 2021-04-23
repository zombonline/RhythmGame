using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    [SerializeField] AudioSource levelTrack;
    [SerializeField] BeatScroller beatScroller;

    bool hasStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }




        if(!hasStarted)
        {
            if(Input.anyKeyDown)
            {
                hasStarted = true;
                beatScroller.hasStarted = true;
                levelTrack.Play();
            }
        }

    }

    public void GoodHit()
    {
        Debug.Log("Good!");
    }
    public void PerfectHit()
    {
        Debug.Log("Perfect!");
    }
    public void Miss()
    {
        Debug.Log("Miss!");
    }

}
