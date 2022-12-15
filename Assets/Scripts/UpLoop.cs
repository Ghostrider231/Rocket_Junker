using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpLoop : MonoBehaviour
{
    public int timer = 0;
    public int limit = 15;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        while (timer < limit)
        {
            timer++;
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }

}
