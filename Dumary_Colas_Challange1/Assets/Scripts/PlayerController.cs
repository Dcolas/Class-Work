using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int count;
    private int score;
    private int negPickups;
    public Text countText;
    public Text negPickUpsText;
    public Text winText;
    private bool level2;
    public GameObject Player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        negPickups = 0;
        SetAllText();
        level2 = false;
        winText.text = "";
    }

    void FixedUpdate()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");
        float colorR = Mathf.Abs(Player.transform.position.x / 10);
        float colorG = Mathf.Abs(Player.transform.position.x / 10);
        float colorB = Mathf.Abs(Player.transform.position.y / 10);

        Vector3 movement = new Vector3(movementHorizontal, 0.0f, movementVertical);

        Color colornow = new Vector4(colorR, colorG, colorB, 0.0f);

        Player.GetComponent<Renderer>().material.color = colornow;
        

        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetAllText();

        }
        else if (other.gameObject.CompareTag("negPick Up"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
            negPickups = negPickups + 1;
            SetAllText();
        }
        if (count >= 12 && level2 == false)
        {
            transform.position = new Vector3(20.0f, Player.transform.position.y, 3.0f);
            level2 = true;
        }

    }
    void SetAllText()
    {
        countText.text = "Count: " + count.ToString();
        negPickUpsText.text = "Red Pick Ups: " + negPickups.ToString();

        if (count >= 24)
        {
            winText.text = "You won with game with a score of: " + score.ToString();
        }

    }    
}
 