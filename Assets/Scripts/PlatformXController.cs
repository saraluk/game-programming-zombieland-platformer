using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformXController : MonoBehaviour
{
    static float speed = 2;
    public int minBound;
    public int maxBound;
    float speedX = speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        transform.Translate(speedX * Time.deltaTime, 0,0);

        if(pos.x > maxBound)
        {
            speedX = -1*speed;
        }
        if (pos.x < minBound)
        {
            speedX = speed;
        }
    }
}
