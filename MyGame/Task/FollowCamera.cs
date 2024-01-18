using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowCamera : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;
    //public float minZoom = 100f;
    public float maxZoom = 10f;
    Camera cam;
    private void Start()
    {
        cam = Camera.main.GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        if (targets.Count == 0)
            return;
        move();
        zoom();
    }
    void zoom()
    {
        
        float newZoom = Mathf.Lerp(maxZoom, getGreatestDistance()+getGreatestDistanceZ(), getGreatestDistance()+getGreatestDistanceZ()/50f );
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView,newZoom,Time.deltaTime);
    }
    float getGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i=0;i<targets.Count;i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }
    float getGreatestDistanceZ()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.z;
    }
    void move()
    {
        Vector3 centerPoint = getCenterPoint();

        Vector3 newPosition = centerPoint + offset;
        transform.position = newPosition;
    }
    Vector3 getCenterPoint()
    {
        if (targets.Count == 0)
        {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}
