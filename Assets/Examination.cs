using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examination : MonoBehaviour {
    public Color color;
    public float timer;
    public SpriteRenderer rend1;
    public SpriteRenderer rend2;
    public SpriteRenderer rend3;
    public int RandomColor = 0;
    public int lastPrint;
    public float random;
    public float speed = 4f;
    public float rotationspeed = -180f;
	// Use this for initialization
	void Start () {
        rend1.color = color;
        rend2.color = color;
        rend3.color = color;
        //Slumpmäsig hastighet på skeppet
        float random = (Random.Range(1f, 10f));
        speed = (random);
        //Slumpmäsig position i start av spel
        transform.Translate(new Vector3(Random.Range(-9f, 9f), Random.Range(-5f, 5f)));
	}
	
	// Update is called once per frame
	void Update () {
        // Beräknar tiden varje sekund.
        if(Time.time > lastPrint + 1f)
        {
            lastPrint = Mathf.RoundToInt(Time.time);
            Debug.Log("Time: " + lastPrint);
        }
        
        //Gör så att skeppet rör sig hela tiden.
        transform.Translate(0, speed * Time.deltaTime, 0, Space.Self);
        //Gör så att när man trycker på D knappen så svänger skeppet åt höger, och gör den blå.
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, rotationspeed * Time.deltaTime);
            rend1.color = Color.blue;
            rend2.color = Color.blue;
            rend3.color = Color.blue;
        }
        //Gör så att när man trycker på A knappen så svänger skeppet vänster, och gör den grön.
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, -rotationspeed /2 * Time.deltaTime);
            rend1.color = Color.green;
            rend2.color = Color.green;
            rend3.color = Color.green;
        }
        //Gör så att när man trycker på S så går den hälften av sin fart.
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed / 2 * Time.deltaTime, 0, Space.Self);
        }
        // Byter till en slumpmäsig färg när man trycker space.
        if (Input.GetKey(KeyCode.Space))
        {
            float RandomColor1 = Random.Range(0f, 1f);
            float RandomColor2 = Random.Range(0f, 1f);
            float RandomColor3 = Random.Range(0f, 1f);
            
            Color col = new Color(RandomColor1, RandomColor2, RandomColor3);
            
                rend1.color = col;
                rend2.color = col;
                rend3.color = col;
           
          
        }
        //När x värdet blir mindre än -10 flyttas den till 10 på x axeln
        if (transform.position.x < -10)
        {
            transform.position = new Vector3(10, (transform.position.y));
        }
        //När x värdet går över 10 flyttas skeppet till -10 på x axeln
        if (transform.position.x > 10)
        {
            transform.position = new Vector3(-10, (transform.position.y));
        }
        //När y värdet blir mindre än -6 fluttas skeppet till 6 på y axeln
        if (transform.position.y < -6)
        {
            transform.position = new Vector3((transform.position.x), 6);
        }
        //När y värdet går över 6 flyttas skeppet till -6 på y axeln
        if (transform.position.y > 6)
        {
            transform.position = new Vector3((transform.position.x), -6);
        }
    }
}
