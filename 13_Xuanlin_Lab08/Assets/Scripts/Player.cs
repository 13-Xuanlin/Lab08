using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public Text scoreText;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "SCORE: " + score;
    }


    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(0, verticalInput * speed * Time.deltaTime, 0);


        if (transform.position.y >= 5.5)
        {

            transform.position = new Vector3(transform.position.x, 5.5f, transform.position.z);
        }
        if (transform.position.y <= -3)
        {

            transform.position = new Vector3(transform.position.x, -3f, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("LoseScene");

        }
        if (collision.gameObject.tag == "Point")
        {
            score++;
            scoreText.text = "SCORE: " + score;
            // audioSource.PlayOneShot(Point);
             //CheckScore();
        }
    }
}
