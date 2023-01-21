using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int lives;
    private int m_points;
    public int points { get; set; } //encapsulation
    public float horizontalInput;
    public float verticalInput;
    public float speed = 15.0f;
    public float xRange = 50.0f;
    public float zRange = 12.5f;
    public  bool gameover = false;
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover)
        {
            Debug.Log("Lives: " + lives + " Score: " + m_points);
        }
        else
        {
            Debug.Log("Game Over");
        }

        CheckBounds();
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position+new Vector3(0,0,5), projectilePrefab.transform.rotation);
        }
    }

    //Abstraction
    void CheckBounds()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange); ;
        }
    }
}
