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

    //is debug window show or not
    private bool isWindowShow = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //inisialisasi
        player1Rb = GetComponent<Rigidbody2D>();
        playerRb2 = GetComponent<Rigidbody2D>();
        ballRb = ball.GetComponent<Rigidbody2D>();
        ballCollider = ball.GetComponent<CircleCollider2D>();
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
        // Toggle nilai debug window ketika pemain mengeklik tombol ini.
        if (GUI.Button(new Rect(Screen.width/2 - 60, Screen.height - 73, 120, 53), "TOGGLE\nDEBUG INFO"))
        {
            isWindowShow = !isWindowShow;
        }

        if(player1.score() == maxScore)
        {
            //menampilkan text player 1 menang
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 10, 2000, 1000), "PLAYER ONE WINS");

            //dan reset bola menjadi ke tengah
            ball.SendMessage("resetBall",null,SendMessageOptions.RequireReceiver);

            //reset posisi player
            player1.resetPosition(-15,0);
            player2.resetPosition(15,0);

        }
        else if(player2.score() == maxScore)
        {
            //menampilkan text player 2 menang
            GUI.Label(new Rect(Screen.width / 2 + 30, Screen.height / 2 - 10, 2000, 1000), "PLAYER TWO WINS");

            //dan reset bola menjadi ke tengah
            ball.SendMessage("resetBall",null,SendMessageOptions.RequireReceiver);
            
            //reset posisi player
            player1.resetPosition(-15,0);
            player2.resetPosition(15,0);
        }

         //window debug info
        //jika variable true maka tampilkan
        if(isWindowShow)
        {
            Color oldColor = GUI.backgroundColor;
            GUI.backgroundColor = Color.red;

            //variable variable fisika untuk debug
            float ballMass = ballRb.mass;
            Vector2 ballVelocity = ballRb.velocity; 
            float ballSpeed = ballRb.velocity.magnitude;
            Vector2 ballMomentum = ballMass * ballVelocity;
            float ballFriction = ballCollider.friction;

            //impulse
            float impulsePlayer1X = player1.lastContactPoint().normalImpulse;
            float impulsePlayer1Y = player1.lastContactPoint().tangentImpulse;
            float impulsePlayer2X = player2.lastContactPoint().normalImpulse;
            float impulsePlayer2Y = player2.lastContactPoint().tangentImpulse;

            string debugText = 
            "Ball Mass: "+ballMass+"\n" +
            "Ball Velocity: "+ballVelocity+"\n"+
            "Ball Speed: "+ballSpeed+"\n"+
            "Ball Momentum: "+ballMomentum+"\n"+
            "Ball friction: "+ballFriction+"\n"+
            "Last impulse from player 1 = (" + impulsePlayer1X + ", " + impulsePlayer1Y + ")\n" +
            "Last impulse from player 2 = (" + impulsePlayer2X + ", " + impulsePlayer2Y + ")\n";

            //tampilkan debug window
            GUIStyle guiStyle = new GUIStyle(GUI.skin.textArea);
            guiStyle.alignment = TextAnchor.UpperCenter;
            GUI.TextArea(new Rect(Screen.width/2 - 200, Screen.height - 200, 400, 110), debugText, guiStyle);
            // Kembalikan warna lama GUI
            GUI.backgroundColor = oldColor;

        }
    }

}
