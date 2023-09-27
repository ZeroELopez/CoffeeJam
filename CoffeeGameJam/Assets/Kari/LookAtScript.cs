using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoffeeJam.Visuals
{
    public class LookAtScript : MonoBehaviour
    {
        public Transform lookAt;
        Vector3 lookAtV;
        public bool MainCamera = false;
        public static LookAtScript cam;

        [SerializeField] bool ignoreX;
        // Start is called before the first frame update
        private void Awake()
        {
            if (MainCamera)
                cam = this;
        }
        void Start()
        {


            
        }

        // Update is called once per frame
        void Update()
        {
            if (lookAt == null && cam != null)
                lookAt = cam.transform;

            if (lookAt == null)
                return;
            lookAtV = lookAt.position;

            if (ignoreX)
                lookAtV.x = transform.position.x;

            transform.LookAt(lookAtV, -Vector3.forward);
        }
    }
}