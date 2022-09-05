using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    public float offsetZ;
    
    private void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, offsetZ);
    }
}
