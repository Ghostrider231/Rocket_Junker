using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    [SerializeField] private GameObject Boss;
    [SerializeField] private int timer = 90;

    private void Start()
    {
        
        StartCoroutine(HideObject());

    }

    IEnumerator HideObject()
    {
        yield return new WaitForSeconds(timer);
        Instantiate(Boss);
    }
}
