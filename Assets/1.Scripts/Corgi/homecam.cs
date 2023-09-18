using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homecam : MonoBehaviour
{
    public Transform objectTofollow;
    public float followSpeed = 2.75f;
    public float sensitivity = 100f;
    public float clampAngle;

    private float rotX;
    private float rotY;

    public Transform realCamera;
    public Vector3 dirNormalized;
    public Vector3 finalDir;
    public float minDistance;
    public float maxDistance;
    public float finalDistance;
    int layerMask = 7 << 8;
    public float smoothness = 10f;
    
    void Start()
    {
        layerMask = ~layerMask;
        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;

        dirNormalized = realCamera.localPosition.normalized;
        finalDistance = realCamera.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        rotX -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
        clampAngle = 20f;
        transform.rotation = rot;
    }

    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectTofollow.position, followSpeed * Time.smoothDeltaTime);
        finalDir = transform.TransformPoint(dirNormalized * maxDistance);
        
        RaycastHit hit;

        if(Physics.Linecast(transform.position, finalDir, out hit, layerMask))
        {
            finalDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }else{
            finalDistance = maxDistance;
        }

        realCamera.localPosition = Vector3.Lerp(realCamera.localPosition, dirNormalized * finalDistance, Time.deltaTime * smoothness);
    }

}
