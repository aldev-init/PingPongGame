using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //Declare variable
    //tombol w untuk ke atas
    public KeyCode upButton = KeyCode.W;
    //tombol s untuk kebawah
    public KeyCode downButton = KeyCode.S;
    //speed raket
    public float speed = 10.0f;
    //batas bawah dan atas scene game
    //tergantung ukuran scene
    public float yBoundary = 9.0f;
    //rigidbody2D raket ini
    private Rigidbody2D rb2D;
    //skor pemain
    public int scorePlayer;
    //variable untuk mendeteksi tumbukan antar raket dan bola
    private ContactPoint2D lastContact;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Mengambil componen velocity yang ada dirigidbody2D
        Vector2 velocity = rb2D.velocity;

        //kondisi jika player menekan tombol w maka akan bergerak ke atas secara vertical
        if(Input.GetKey(upButton))
        {
            velocity.y = speed;
        }

        //kondisi jika plaer menekan tombol s maka akan bergerak ke bawah secara vertical
        else if(Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }

        //jika player tidak menekan tombol apapun
        else
        {
            velocity.y = 0.0f;
        }

        //masukan kembali kecepatannya ke komponen velocity yang ada di komponen rigidbody2D
        rb2D.velocity = velocity;



        //Membuat batas game
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

        //masukan kembali ke posisi transformnya
        transform.position = position;

        //debug
        // Debug.Log(lastContactPoint());
    }

    //method untuk menambah score 
    public void incrementScore()
    {
        scorePlayer++;
    }

    //method untuk reset score
    public void resetScore()
    {
        scorePlayer = 0;
    }

    //method untuk mendapatkan score player
    public int score()
    {
        return scorePlayer;
    }

    //sedikit catatan
    //vector2 dan vector3 digunakan untuk mengambil sumbu x,y,z

    //method untuk  mengambil/mengembalikan lastContact
    public ContactPoint2D lastContactPoint()
    {
        return lastContact;
    }
    //method ketika terjadi tumbukan
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.name.Equals("Ball"))
        {
            lastContact = other.GetContact(0);
        }
    }
}
