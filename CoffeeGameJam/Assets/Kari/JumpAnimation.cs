using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class JumpAnimation : MonoBehaviour
{
    [SerializeField] float multiplier = 1;
    [SerializeField] float length = 1;
    [SerializeField] AnimationCurve curveX;
    [SerializeField] AnimationCurve curveY;
    [SerializeField] AnimationCurve curveZ;

    [SerializeField] bool Range;
    float lerpValue = 0;
    [SerializeField] AnimationCurve maxCurveX;
    [SerializeField] AnimationCurve maxCurveY;
    [SerializeField] AnimationCurve maxCurveZ;

    float time = float.MaxValue;
    Vector3 origin;
    bool active = false;

    [SerializeField] bool PlayOnStart = false;
    private void Start()
    {
        if (PlayOnStart)
            StartAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            transform.position = origin +
                Evaluate();

            if (time > length)
                active = false;
            time += Time.deltaTime;
        }
        
    }

    Vector3 Evaluate()
    {
        if (!Range)
            return new Vector3(
                        curveX.Evaluate(time / length) * multiplier,
                        curveY.Evaluate(time / length) * multiplier,
                        curveZ.Evaluate(time / length) * multiplier);

        return new Vector3(
                        Mathf.Lerp(curveX.Evaluate(time / length), maxCurveX.Evaluate(time / length), lerpValue) * multiplier,
                        Mathf.Lerp(curveY.Evaluate(time / length), maxCurveY.Evaluate(time / length), lerpValue) * multiplier,
                        Mathf.Lerp(curveZ.Evaluate(time / length), maxCurveZ.Evaluate(time / length), lerpValue) * multiplier);


    }

    public void StartAnimation()
    {
        time = 0;
        active = true;
        lerpValue = Random.Range((float)0, (float)1);
        origin = transform.position;
    }
}
