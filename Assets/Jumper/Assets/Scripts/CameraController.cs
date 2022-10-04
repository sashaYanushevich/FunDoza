    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static bool movecam;
    public static Vector3 neededpos;

    void Start()
    {
        movecam=false;
    }

    void FixedUpdate()
    {
        transform.eulerAngles=transform.eulerAngles-new Vector3(0,0,0);
        if(Camera.main.transform.position!=GameObject.FindGameObjectWithTag("GhostCamera").transform.position)
            if(movecam){
                Camera.main.transform.position=Vector3.Lerp(Camera.main.transform.position,neededpos,Time.deltaTime);
                if(Camera.main.transform.position==neededpos) movecam=false;
            }
    }
}
