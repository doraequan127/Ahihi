using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class RockSmall : MonoBehaviour
    {
        private float speed;

        private void Awake()
        {
            speed = Random.Range(3f, 8f);
        }

        private void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime);
            transform.Rotate(new Vector3(0, 0, 1));
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.name == "WallBelow")
                Destroy(gameObject);
        }
    }
}