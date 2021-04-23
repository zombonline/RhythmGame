using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    bool canbePressed;

    public KeyCode keyToPress;

    bool goodHit = false;
    bool perfectHit = false;

    [SerializeField] Transform raycastStart;
    [SerializeField] float RaycastCheckLength;
    [SerializeField] LayerMask NoteLayer;
    [SerializeField] bool somethingunder;

    [SerializeField] float timeFromPlayer;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.position + Vector3.up * FindObjectOfType<BeatScroller>().speed * timeFromPlayer;
    }

    // Update is called once per frame
    void Update()
    {

        //checking for notes under
        RaycastHit2D noteCheck = Physics2D.Raycast
                (raycastStart.position, Vector2.down, RaycastCheckLength, NoteLayer);
        if (noteCheck)
        { Debug.DrawLine(raycastStart.position, raycastStart.position + Vector3.down * RaycastCheckLength, Color.red); }
        if (!noteCheck)
        { Debug.DrawLine(raycastStart.position, raycastStart.position + Vector3.down * RaycastCheckLength, Color.green); }
        somethingunder = noteCheck;

        if (Input.GetKeyDown(keyToPress) && !noteCheck)
        {
            if(canbePressed)
            {
                if(perfectHit)
                {
                    FindObjectOfType<LevelManager>().PerfectHit();
                    FindObjectOfType<ParticleController>().PerfectHit(this.tag);
                }
                else if (goodHit && !perfectHit)
                {
                    FindObjectOfType<LevelManager>().GoodHit();
                    FindObjectOfType<ParticleController>().GoodHit(this.tag);
                }
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        canbePressed = true;
        if(collision.tag == "Good Hit")
        {
            goodHit = true;
        }
        if (collision.tag == "Perfect Hit")
        {
            perfectHit = true;
        }
        if(collision.tag == "Miss")
        {
            FindObjectOfType<LevelManager>().Miss();
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
            canbePressed = false;
        if(collision.tag == "Good Hit")
        {
            goodHit = false;
        }
        if (collision.tag == "Perfect Hit")
        {
            perfectHit = false;
        }
    }



}
