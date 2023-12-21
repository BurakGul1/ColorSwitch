using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed = 100f;
    void Update()
    {
        transform.Rotate(0,0,_speed * Time.deltaTime);
    }
}
