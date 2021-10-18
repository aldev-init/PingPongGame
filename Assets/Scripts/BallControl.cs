using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    //variable
    private Rigidbody2D rb2D;
    //besar gaya awal yang diberikan untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;
    //variable untuk merekam titik tumbuk terakhir
    private Vector2 tracetOrigin;

    // Start is called before the first frame update
    void Start()
    {
        tracetOrigin = transform.position;
        rb2D = GetComponent<Rigidbody2D>();

        //mulai game
        restartGame();
    }

    // Update is called once per frame
    void Update()
    {
        //belum ada code
        //debug
        // Debug.Log(getTracetOrigin());
    }

    //fungsi reset posisi bola ke tengah
    void resetBall()
    {
        //reset posisi 0,0
        transform.position = Vector2.zero;
        //reset kecepatan 0,0
        rb2D.velocity = Vector2.zero;
    }

    void pushBall()
    {
        //tentukan nilai komponen y dari gaa dorong antara  -yInitialForce dan yInitialForce
        float yRandomInitialForce = Random.Range(-yInitialForce,yInitialForce);

        //tentukan nilai acak antara 0(inklusif) dan 2(eklusif)
        float randomDirection = Random.Range(0,2);

        //jika nilai dibawah 1, bola bergerak ke kiri
        //jika tidak, bola bergerak kek kanan.
        if(randomDirection < 1.0f)
        {
            //gunakan gaya untuk menggerakan bola ini
            rb2D.AddForce(new Vector2(-xInitialForce,yRandomInitialForce));
        }
        else
        {
            rb2D.AddForce(new Vector2(xInitialForce,yRandomInitialForce));
        }
    }

    void restartGame()
    {
        //kembalikan posisi bola
        //panggil fungsi resetBall()
        resetBall();

        //setelah 2 detik, berikan gaya ke bola / panggil method pushBall()
        Invoke("pushBall",1);
    }

    //method dibawah ini berfungsi untuk menampilkan debug nantinya
    //ketika bola beranjak dari tumbukan dengan raket
    void OnCollisionExit2D(Collision2D other)
    {
        tracetOrigin = transform.position;
    }

    public Vector2 getTracetOrigin()
    {
        return tracetOrigin;
    }
}
