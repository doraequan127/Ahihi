using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror
{
    public class TestMirror : MonoBehaviour
    {
        public Camera mirrorCamera;
        public Material mirrorMaterial;

        private void Awake()
        {
            mirrorCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            mirrorMaterial.mainTexture = mirrorCamera.targetTexture;
        }

        private void Update()
        {
            mirrorCamera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z * -1);
        }
    }
}