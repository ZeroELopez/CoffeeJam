using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ObjectShake : MonoBehaviour
{
    public AnimationCurve animationCurve;
    public float multiplier;
    public float length;

    Vector3 origins;

    // Start is called before the first frame update
    void Start()
    {
        origins = transform.localPosition;

        //time = 0;
    }

    float time = float.MaxValue;
    // Update is called once per frame
    void Update()
    {
        if (time < length)
        {
            Vector3 movement = new Vector3(Random.Range(-multiplier, multiplier), Random.Range(-multiplier, multiplier));

            transform.localPosition = origins + (movement * animationCurve.Evaluate(time / length));

            time += Time.deltaTime;
        }        
    }

    public void Shake() => time = 0;

    public void ShakeMultiplier(float newMultiplier)
    {
        time = 0;
        multiplier = newMultiplier;
    }

}
