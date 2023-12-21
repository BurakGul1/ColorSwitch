using System;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Update()
    {
        if (_player.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, _player.position.y, transform.position.z);
        }
    }
}
