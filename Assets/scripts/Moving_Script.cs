using UnityEngine;

public class Moving_Script : MonoBehaviour
{
    [SerializeField] Transform Pos1, Pos2;
    [SerializeField] private float _MoveSpeed;
    [SerializeField] private PlayerController _PlayerController;
    //[SerializeField] Rigidbody2D _obsticleBody;

    public void MoveObsticle(bool isObsticle)
    {
        if(isObsticle)
        {
            transform.position = Vector3.MoveTowards(transform.position, Pos2.position, _MoveSpeed * Time.deltaTime);
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, Pos1.position, _MoveSpeed * Time.deltaTime);
    }
}
