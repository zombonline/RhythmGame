using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    [SerializeField] Sprite standardSprite;
    [SerializeField] Sprite pressedSprite;
    [SerializeField] KeyCode buttonKey;
    [SerializeField] AudioClip sfx;

    SpriteRenderer SprRender;

    // Start is called before the first frame update
    void Start()
    {
        SprRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(buttonKey))
        {
            SprRender.sprite = pressedSprite;
            AudioSource.PlayClipAtPoint(sfx, Camera.main.transform.position, 1f);
        }
        if (Input.GetKeyUp(buttonKey))
        {
            SprRender.sprite = standardSprite;
        }
    }
}
