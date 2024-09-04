using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)
        {
            if (Input.mouseScrollDelta.y > 0 && transform.localScale.x < 6f
                                         && transform.localScale.y < 6f
                                         && transform.localScale.z < 6f)
                transform.localScale += new Vector3(.1f, .1f, .1f);
            else if (Input.mouseScrollDelta.y < 0 && transform.localScale.x > .6f
                                                  && transform.localScale.y > .6f
                                                  && transform.localScale.z > .6f)
                transform.localScale -= new Vector3(.1f, .1f, .1f);
        }
    }
}
