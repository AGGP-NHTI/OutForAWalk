using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject player2;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        if (player.activeSelf == false)
        {
            player = player2;
        }
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}