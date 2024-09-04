using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveablesManager : MonoBehaviour
{
    GameObject player;
    
    
    float posX;
    float posY;


    public static float speedMultiplier = .75f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Asteroid") && collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Asteroid") && collision.gameObject.CompareTag("SafeZone"))
        {
            StartCoroutine(DestroyAsteroid());
        }

        if (gameObject.CompareTag("Pill") && collision.gameObject.CompareTag("SafeZone"))
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        if (player == null)
            return;

        posX = transform.position.x;
        posY = transform.position.y;

        posX = Mathf.Lerp(transform.position.x, player.transform.position.x, speedMultiplier * Time.deltaTime);
        posY = Mathf.Lerp(transform.position.y, player.transform.position.y, speedMultiplier * Time.deltaTime);

        transform.position = new Vector3(posX, posY);

    }

    IEnumerator DestroyAsteroid()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }
}