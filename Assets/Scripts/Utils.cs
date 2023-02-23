using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    // Start is called before the first frame update
    public static void RotateAround (Transform transform, Vector3 pivotPoint, Vector3 axis, float angle)
    {
         Quaternion rot = Quaternion.AngleAxis (angle, axis);
         transform.position = rot * (transform.position - pivotPoint) + pivotPoint;
         transform.rotation = rot * transform.rotation;
    }

    public static float WitchesHat(float value, float center=0f, float radius=1f,float peak=1f)
    {
        float rv, diff, slope;
        diff = value - center;

        if (Mathf.Abs(diff) > radius) return 0f;
        if (diff == 0f) return peak;

        slope = Mathf.Sign(-diff) * peak / radius;
        rv = slope * diff + peak;
        return rv;
    }
}
