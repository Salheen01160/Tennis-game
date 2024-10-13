using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{

     public float speed;
     public GameObject Player;
     public GameObject cpu;
     public GameObject ball;
     public bool is_started=false;
     Vector3 cpu_target_position;
     public float err_margen;
     public GameObject[] Levels;
    public Text My_scoreTXT;
    public Text cpu_scoreTXT;
    public int defultScore ;
    public int Myscore;
    public int CpuScore;
    public GameObject GameOverPanel;
    public Text ResultTXT;
   
    private void Awake()
    {
        if (LevelManager.instance == null)
        {
            SceneManager.LoadScene("Menu");

        }
    }
   


    void Start() 
    {
        if (LevelManager.instance.diffculty == 1)
        {
            err_margen = 6;
        }
        else if (LevelManager.instance.diffculty == 2)
        {
            err_margen = 4;
        }
        else if (LevelManager.instance.diffculty == 3)
        {
            err_margen = 0;
        }
        Myscore = defultScore;
        CpuScore = defultScore;
      
        GameObject NewLevel = Instantiate(Levels[Random.Range(0, 3)]);
        NewLevel.transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        My_scoreTXT.text = Myscore.ToString();
        cpu_scoreTXT.text = CpuScore.ToString();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SceneManager.LoadScene("Game");
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene("Menu");

        }

        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput > 0&&Player.transform.position.y<3.4)
        {
            Player.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            if (is_started == false)
            {
                is_started = true;
                ball.GetComponent<Ball>().startBallMove();
            }

        }
        else if (verticalInput < 0 && Player.transform.position.y > -3.4)
        {
            Player.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            if (is_started == false)
            {
                is_started = true;
                ball.GetComponent<Ball>().startBallMove();
            }
        }
        if (ball.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            cpu_target_position = ball.transform.position + new Vector3(0, Random.Range(-err_margen, err_margen),0);

            if (cpu_target_position.y > cpu.transform.position.y)
            {
                cpu.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
            else
            {
                cpu.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            }
        }
    }
}
