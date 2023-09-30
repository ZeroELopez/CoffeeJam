using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeAnimation : MonoBehaviour
{
    public AnimationCurve animationCurve;

    public static ObjectShake Camera;

    public float multiplier;
    public float length;

    Vector3 origins;



    // Start is called before the first frame update
    void Start()
    {
        origins = transform.localScale;

        //time = 0;
    }

    float time = float.MaxValue;
    public float setTime { get => time; set => time = value; }

    // Update is called once per frame
    void Update()
    {
        if (time < length)
        {
            transform.localScale = origins * (animationCurve.Evaluate(time / length));

            time += Time.deltaTime;
        }
    }

    public void Grow() => time = 0;

    public void GrowMultiplier(float newMultiplier)
    {
        time = 0;
        multiplier = newMultiplier;
    }

}
