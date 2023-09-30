using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineByPosition : MonoBehaviour
{
    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    List<Vector3> locs = new List<Vector3>();
    float time = 0;
    [SerializeField] float intervals = .5f;
    [SerializeField] int MaxLength = 30;
    [SerializeField] Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > intervals)
        {
            locs.Add(transform.position + offset);
            time = 0;
        }

        if (locs.Count < 1)
            return;

        if (locs.Count > MaxLength)
            locs.RemoveAt(0);

        lineRenderer.positionCount = locs.Count;

        lineRenderer.SetPositions(locs.ToArray());
    }
}
