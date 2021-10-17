using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2BotScript : MonoBehaviour
{
    public GameObject ball;
    private Rigidbody2D rb2D;
    private float yBoundary = 9.0f;
    Vector2 objekPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb2D.velocity;
        Vector2 velocityBall = ball.gameObject.GetComponent<Rigidbody2D>().velocity;
        //pergerakan bot
        if(velocity.y < velocityBall.y)
        {
            velocity.y = 10.0f;
        }
        else if(velocity.y > -velocityBall.y)
        {
            velocity.y = -10.0f;
        }
        //masukan kembali perubahan
        rb2D.velocity = velocity;

        //batas
        Vector3 position = transform.position;
        //jika raket melewati batas atas
        if(position.y > yBoundary)
        {
            position.y = yBoundary;
        }

        //jika raket melewati batas bawah
        else if(position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }
        //masukan kembali
        transform.position = position;


        //posisi akan mengikuti game objek bola
        Debug.Log("Objek Ini: "+transform.position);
        Debug.Log("Objek Bola: "+ball.transform.position);

        Debug.Log("Velocity Ini: "+ velocity);
        Debug.Log("Velocity Bola: "+velocityBall);
    }
    //perbaiki bot script ini 
}
