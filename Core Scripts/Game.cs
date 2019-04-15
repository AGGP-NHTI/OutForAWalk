using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game Class manages Game Rules in child classes. 
/// Inherits from Info
/// Spawn Point Management are implemented in this class
/// </summary>
public class Game : BaseInfo
{
    public GameObject SpawnPointPrefab;

    public GameObject player1Spawn;
    public GameObject player2Spawn;

    public Camera mainCamera;
    private Vector3 offset;

    public GameObject _player1Instance;
    public GameObject _player2Instance;

    public void Awake()
    {
        _player1Instance = Instantiate(player1Spawn, SpawnPointPrefab.transform);
        _player2Instance = Instantiate(player2Spawn, SpawnPointPrefab.transform);
    }

    void Start()
    {
        offset = mainCamera.transform.position - _player1Instance.transform.position;
    }

    void Update()
    {
        if (!_player1Instance)
        {
            _player1Instance = _player2Instance;
        }
    }

    void LateUpdate()
    {
        mainCamera.transform.position = _player1Instance.transform.position + offset;
    }
}
