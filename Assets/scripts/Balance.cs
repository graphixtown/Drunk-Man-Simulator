using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private float TargetRotation;
    [SerializeField] private Rigidbody2D RB;
    [SerializeField] private float force;
    
    // Update is called once per frame
    void Update()
    {
        RB.MoveRotation(Mathf.LerpAngle(RB.rotation, TargetRotation, force * Time.deltaTime));
    }
}
