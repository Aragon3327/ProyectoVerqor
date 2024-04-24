using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Movement : MonoBehaviour
{
    AudioManager audioManager;
    //[SerializeField] private GameObject walksound;
    //private AudioSource sonidoCaminar;
    private float speedX = 2.5f;
    private float speedY = 2.5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        // audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //sonidoCaminar = walksound.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float HMov = Input.GetAxis("Horizontal");
        float VMov = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(HMov * speedX, VMov * speedY);
        
        //iniciar el sonido de caminar
        // if (HMov != 0 || VMov != 0)
        // {
        //     audioManager.Playsfx(audioManager.walk);
        // }
    }
}
