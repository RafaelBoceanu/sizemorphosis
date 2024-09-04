using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    IEnumerator DestroyAsteroid(Collision2D col)
    {
        yield return new WaitForSeconds(2f);
        Destroy(col.gameObject);
    }
}
