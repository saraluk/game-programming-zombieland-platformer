using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformYController : MonoBehaviour
{
    static float speed = 2;
    float speedY = speed;
    public float minBound;
    public float maxBound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        transform.Translate(0, speedY * Time.deltaTime,0);

        if(pos.y > maxBound)
        {
            speedY = -1*speed;
        }
        if (pos.y < minBound)
        {
            speedY = speed;
        }
    }
}
