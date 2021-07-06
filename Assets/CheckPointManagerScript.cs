using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CheckPointManagerScript : MonoBehaviour
{
    public static CheckPointManagerScript instance;

  //  [HideInInspector]
    public Vector3 lastCheckPointPos;
    public Quaternion lastCheckPointQuat;

    public GameObject KartClassicPlayer;

    public string teleportToLastCheckpoint = "Teleport";

    CameraManagerScript cameraManagerScript;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cameraManagerScript = CameraManagerScript.instance;
        SwitchToCameraTPS();
    }

    void Update()
    {
        if(Input.GetButton(teleportToLastCheckpoint) && lastCheckPointPos != Vector3.zero)
        {
            TeleportToLastCheckpoint();
        }
    }

    private void TeleportToLastCheckpoint()
    {
        KartClassicPlayer.GetComponent<Rigidbody>().velocity = Vector3.zero;
        KartClassicPlayer.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        KartClassicPlayer.transform.position = lastCheckPointPos;
        KartClassicPlayer.transform.rotation = lastCheckPointQuat;
    }

    public void SwitchToCameraFPS()
    {
        cameraManagerScript = CameraManagerScript.instance;
        cameraManagerScript.transform.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y = 1;
        cameraManagerScript.transform.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.z = 0;
    }

    public void SwitchToCameraTPS()
    {
        cameraManagerScript = CameraManagerScript.instance;
        cameraManagerScript.transform.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y = 3;
        cameraManagerScript.transform.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.z = -6;
    }
}