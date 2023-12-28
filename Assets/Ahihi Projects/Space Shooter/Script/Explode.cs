using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(destroy());
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 4f * Time.deltaTime);
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(3.7f);
        Destroy(gameObject);
    }
}
