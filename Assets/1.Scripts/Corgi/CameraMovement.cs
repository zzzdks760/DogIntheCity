using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    public PlayerMovement playermovement = null;
    public GameObject cam1, cam2;
    public bool ch = false;

    public Transform objectTofollow;
    public float followSpeed = 2.75f;
    public float sensitivity = 100f;
    public float clampAngle = 40f;

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

    

    // Start is called before the first frame update
    void Start()
    {
        layerMask = ~layerMask;
        //InvokeRepeating("RayCheck", 0.5f, 0.5f);
        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;

        dirNormalized = realCamera.localPosition.normalized;
        finalDistance = realCamera.localPosition.magnitude;

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        CamChanges();
        anims();

        if(!playermovement.stops && playermovement.landing == true && playermovement.jumping == false)
        {
            if(cam1.activeSelf == true)
            {
                rotX -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
                rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

                rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
                Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
                clampAngle = 20f;
                transform.rotation = rot;
                
            }
            else
            {
                rotX -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
                rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

                rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
                Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
                clampAngle = 40f;
                transform.rotation = rot;
                cam2.transform.rotation = rot;
            }
        }
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

    void CamChanges()
    {
        if(Input.GetButtonUp("Change"))
        {
            if(cam1.activeSelf == true)
            {
                cam1.SetActive(false);
                cam2.SetActive(true);
                ch = true;
            }
            else
            {
                cam1.SetActive(true);
                cam2.SetActive(false);
                ch = false;
            }
        }
    }
    
    void anims()
    {
        if(cam2.activeSelf == true)
        {
            if(playermovement._controller.isGrounded && !playermovement.stops)
            {
                if(Input.GetButtonDown("bite") || Input.GetButtonDown("bark") || Input.GetButtonDown("Jump"))
                {
                    if(cam2.activeSelf == true)
                    {
                        clampAngle = 0f;
                        Quaternion rot = Quaternion.Euler(0, 0, 0);
                        transform.rotation = rot; 
                    }
                    else
                    {
                        clampAngle = 0f;
                        Quaternion rot = Quaternion.Euler(0, 0, 0);
                        transform.rotation = rot; 
                    }
                }
            }
        }
    }

    
}
