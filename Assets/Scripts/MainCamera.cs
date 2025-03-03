using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player;
    [SerializeField] public float cameraMinX;
    [SerializeField] public float cameraMaxX;
    [SerializeField] public float cameraMinY;
    [SerializeField] public float cameraMaxY;
    [SerializeField] public float playerOffsetX;
    [SerializeField] public float playerOffsetY;

    void Update()
    {
        float positionX = transform.position.x;
        float positionY = transform.position.y;

        if (player.position.x - transform.position.x > playerOffsetX && transform.position.x < cameraMaxX)
        {
            positionX = player.position.x - playerOffsetX;
        }
        else if (transform.position.x - player.position.x > playerOffsetX && transform.position.x > cameraMinX)
        {
            positionX = player.position.x + playerOffsetX;
        }

        if (player.position.y - transform.position.y > playerOffsetY && transform.position.y < cameraMaxY)
        {
            positionY = player.position.y - playerOffsetY;
        }
        else if (transform.position.y - player.position.y > playerOffsetY && transform.position.y > cameraMinY)
        {
            positionY = player.position.y + playerOffsetY;
        }

        transform.position = new Vector3(positionX, positionY, transform.position.z);
    }
}
