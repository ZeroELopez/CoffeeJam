using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoffeeJam.Visuals
{
    public class LookAtScript : MonoBehaviour
    {
        public Transform lookAt;
        Vector3 lookAtV;

        [SerializeField] bool ignoreX;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (lookAt == null)
                return;
            lookAtV = lookAt.position;

            if (ignoreX)
                lookAtV.x = transform.position.x;

            transform.LookAt(lookAtV, -Vector3.forward);
        }
    }
}