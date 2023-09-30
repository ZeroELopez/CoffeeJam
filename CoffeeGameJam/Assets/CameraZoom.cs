using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public AnimationCurve animationCurve;

    public static CameraZoom instance;
    public Camera cam;
    public float multiplier;
    public float length;

    float origins;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        origins = cam.fieldOfView;

        if (cam != null)
            instance = this;
        //time = 0;
    }

    float time = float.MaxValue;
    // Update is called once per frame
    void Update()
    {
        if (time < length)
        {
            cam.fieldOfView = origins + (multiplier * animationCurve.Evaluate(time / length));

            time += Time.deltaTime;
        }
    }

    public void Zoom() => instance.time = 0;

    public void ZoomMultiplier(float newMultiplier)
    {
        instance.time = 0;
        instance.multiplier = newMultiplier;
    }
}
