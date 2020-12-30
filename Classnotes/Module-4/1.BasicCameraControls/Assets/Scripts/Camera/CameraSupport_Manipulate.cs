using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Meant to be a component of a camera
public partial class CameraSupport: MonoBehaviour
{
    public void MoveBy(float dx, float dy)
    {
        transform.position += new Vector3(dx, dy, 0f); // DO NOT change the Z-value!
        UpdateWorldWindowBound();
    }

    // CANNOT touch the z-value!
    public void MoveTo(float x, float y)
    {
        Vector3 p = transform.position;
        p.x = x;
        p.y = y;
        transform.position = p;
        UpdateWorldWindowBound();
    }

    // zoom > 1: zoom out, see more of the world
    // zoom < 1: zoom in, see less of the world
    // zoom == 0: ignored.
    public void Zoom(float zoom)
    {
        if (zoom > 0f)
        {
            mTheCamera.orthographicSize *= zoom;
            UpdateWorldWindowBound();
        }
    }

    // zoom > 1: zoom out, see more of the world
    // zoom < 1: zoom in, see less of the world
    // zoom == 0: ignored.
    public void ZoomTowards(Vector3 aPos, float zoom)
    {
        Vector3 delta = aPos - transform.position;
        delta *= (zoom - 1f);
        delta.z = 0f;
        transform.position -= delta;
        Zoom(zoom);
    }

    public void PushCameraByPos(Vector3 aPos, float region = 1f)
    {
        Bounds b = new Bounds(transform.position, region * mWorldBound.size);
        Vector3 delta = Vector3.zero;
        if (!BoundsContainsPointXY(b, aPos))
        {   // pos is outside, let's push
            if (aPos.x > b.max.x)
                delta.x = aPos.x - b.max.x;
            else if (aPos.x < b.min.x)
                delta.x = aPos.x - b.min.x;

            if (aPos.y > b.max.y)
                delta.y = aPos.y - b.max.y;
            else if (aPos.y < b.min.y)
                delta.y = aPos.y - b.min.y;

            transform.position += delta;
        }
        UpdateWorldWindowBound();
    }
}