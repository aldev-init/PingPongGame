using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //variable declare
    //objek player1
    public PlayerControl player1;
    private Rigidbody2D player1Rb;
    
    //objek player2
    public PlayerControl player2;
    private Rigidbody2D playerRb2;

    //objek bola
    public BallControl ball;
    private Rigidbody2D ballRb;
    private CircleCollider2D ballCollider;

    //skor maksimal
    public int maxScore;

    // Start is called before the first frame update
    void Start()
    {
        //inisialisasi
        player1Rb = GetComponent<Rigidbody2D>();
        playerRb2 = GetComponent<Rigidbody2D>();
        ballRb = GetComponent<Rigidbody2D>();
        ballCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    private void OnGUI()
    {
         //menampilkan Gui Score
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12,20,100,100),""+player1.score());
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12,20,100,100),""+player2.score());

        //membuat tombol sekaligus kondisi jika tombol ditekan
        if(GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            //reset score kedua pemain
            player1.resetScore();
            player2.resetScore();

            //restart game
            ball.SendMessage("restartGame",0.5f,SendMessageOptions.RequireReceiver);
        }

        if(player1.score() == maxScore)
        {
            //menampilkan text player 1 menang
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 10, 2000, 1000), "PLAYER ONE WINS");

            //dan reset bola menjadi ke tengah
            ball.SendMessage("resetBall",null,SendMessageOptions.RequireReceiver);
        }
        else if(player2.score() == maxScore)
        {
            //menampilkan text player 2 menang
            GUI.Label(new Rect(Screen.width / 2 + 30, Screen.height / 2 - 10, 2000, 1000), "PLAYER TWO WINS");

            //dan reset bola menjadi ke tengah
            ball.SendMessage("resetBall",null,SendMessageOptions.RequireReceiver);
        }
    }
}
