using UnityEngine;

public class Balance : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Rigidbody2D RB;
    [Header("Floating Values")]
    [SerializeField] private float TargetRotation;
    [SerializeField] private float force;

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            RB.MoveRotation(Mathf.LerpAngle(RB.rotation, TargetRotation, 0 * Time.deltaTime));
        }
        else
        {
            RB.MoveRotation(Mathf.LerpAngle(RB.rotation, TargetRotation, force * Time.deltaTime));
        }
    }
    
}
