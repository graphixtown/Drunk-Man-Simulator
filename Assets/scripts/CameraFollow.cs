using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float smoothing;
    [SerializeField] private Transform _targetPos;
    [SerializeField] private Vector3 _offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPos = _targetPos.position + _offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothing * Time.deltaTime);
        transform.position = smoothPos;
    }
}
