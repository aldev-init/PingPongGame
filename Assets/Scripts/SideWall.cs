using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    //game manager
    [SerializeField]
    private GameManager gameManager;
    public PlayerControl player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //akan dipanggil ketika objek lain bercollider (bola) bersentuhan dengan dinding samping
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Ball")
        {
            player.incrementScore();
        }

        //jika score masih dibawah maxscore game manager maka game akan terus berjalan
        if(player.score() < gameManager.maxScore)
        {
            //ini akan memanggil game objek yang membentur dinding yaitu bola dan akan memanggil method dari script yang digunakan objek tersebut
            //SendMessageOptions.RequireReceiver digunakan untuk memastikan ada method resetBall() di dalam method restartGame() jika tidak ada maka akan muncuk exception
            other.gameObject.SendMessage("restartGame",2.0f,SendMessageOptions.RequireReceiver);
        }
    }
}
