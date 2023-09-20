using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoffeeJam.Visuals
{
    public class LookAtScript : MonoBehaviour
    {
        public Transform lookAt;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (lookAt == null)
                return;

            transform.LookAt(lookAt, -Vector3.forward);
        }
    }
}