using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Meant to be a component of a camera
public class CameraSupport : MonoBehaviour
{
    private Camera mTheCamera;   // Will find this on the gameObject
    private Bounds mWorldBound;  // Computed bound from the camera

    public enum WorldBoundStatus
    {
        Outside = 0,
        CollideLeft = 1,
        CollideRight = 2,
        CollideTop = 4,
        CollideBottom = 8,
        Inside = 16
    };

    // Start is called before the first frame update
    void Awake()  // camera may be disabled by some in Start(), so init in Awake.
    {
        mTheCamera = gameObject.GetComponent<Camera>();
        Debug.Assert(mTheCamera != null); // if this is null, then, the script is not on a Camera and nothing works

        Debug.Log("Camera Start:" + gameObject.name);

        #region bound support
        mWorldBound = new Bounds();
        UpdateWorldWindowBound();
        #endregion
    }

    void Update()
    {
        UpdateWorldWindowBound();
    }

    public Bounds GetWorldBound() { return mWorldBound; }

    #region bound support

    private void UpdateWorldWindowBound()
    {
        // get the main 
        if (null != mTheCamera)
        {
            float maxY = mTheCamera.orthographicSize;
            float maxX = mTheCamera.orthographicSize * mTheCamera.aspect;
            float sizeX = 2 * maxX;
            float sizeY = 2 * maxY;

            // Make sure z-component is always zero
            Vector3 c = mTheCamera.transform.position;
            c.z = 0.0f;
            mWorldBound.center = c;
            mWorldBound.size = new Vector3(sizeX, sizeY, 1f);  // z is arbitrary!!
        }
    }

    // Cannot use the regular bounds intersect() and contains() function
    // Because we are not using the Z-values 
    private bool BoundsIntersectInXY(Bounds b1, Bounds b2)
    {
        return (b1.min.x < b2.max.x) && (b1.max.x > b2.min.x) &&  
               (b1.min.y < b2.max.y) && (b1.max.y > b2.min.y);
    }

    private bool BoundsContainsPointXY(Bounds b, Vector3 pt)
    {
        return ((b.min.x < pt.x) && (b.max.x > pt.x) &&
                (b.min.y < pt.y) && (b.max.y > pt.y));
    }

    public WorldBoundStatus CollideWorldBound(Bounds objBound, float region = 1f)
    {
        WorldBoundStatus status = WorldBoundStatus.Outside;
        Bounds b = new Bounds(transform.position, region * mWorldBound.size);

        if (BoundsIntersectInXY(b, objBound))
        {
            if (objBound.max.x > b.max.x)
                status |= WorldBoundStatus.CollideRight;
            if (objBound.min.x < b.min.x)
                status |= WorldBoundStatus.CollideLeft;
            if (objBound.max.y > b.max.y)
                status |= WorldBoundStatus.CollideTop;
            if (objBound.min.y < b.min.y)
                status |= WorldBoundStatus.CollideBottom;
            // not testing Z anymore!! if ((objBound.min.z < mWorldBound.min.z) || (objBound.max.z > mWorldBound.max.z))

            if (status == WorldBoundStatus.Outside)  // intersects and no bounds touch ==> Inside!
                status = WorldBoundStatus.Inside;  
        }

        return status;
    }

    public WorldBoundStatus ClampToWorldBound(Transform t, float region = 1f)
    {
        Vector3 p = t.position;
        WorldBoundStatus status = WorldBoundStatus.Outside;
        Bounds b = new Bounds(transform.position, region * mWorldBound.size);
                
        if (p.x > b.max.x) 
        {
            status |= WorldBoundStatus.CollideRight;
            p.x = b.max.x;
        }
        if (p.x < b.min.x)
        {
            status |= WorldBoundStatus.CollideLeft;
            p.x = b.min.x;
        }
        if (p.y > b.max.y)
        {
            status |= WorldBoundStatus.CollideTop;
            p.y = b.max.y;
        }
        if (p.y < b.min.y)
        {
            status |= WorldBoundStatus.CollideBottom;
            p.y = b.min.y;
        }
        
        t.position = p;
        return status;
    }
    #endregion

    #region Viewport support
    public void SetViewportMinPos(float x, float y)
    {
        Rect r = mTheCamera.rect;
        mTheCamera.rect = new Rect(x, y, r.width, r.height);
    }

    public void SetViewprotSize(float w, float h)
    {
        Rect r = mTheCamera.rect;
        mTheCamera.rect = new Rect(r.x, r.y, w, h);
    }
    #endregion
}