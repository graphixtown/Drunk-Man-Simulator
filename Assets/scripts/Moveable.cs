using UnityEngine;

public class Moveable : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _wallBody;
    [SerializeField] private Transform _Collidecheck;
    [SerializeField] private LayerMask _Collidemask;
    [SerializeField] private float _Radius;
    private bool _isCollide;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _wallBody = GetComponent<Rigidbody2D>();
        _wallBody.simulated = false;
    }

    // Update is called once per frame
    void Update()
    {
        _isCollide = Physics2D.OverlapCircle(_Collidecheck.position, _Radius, _Collidemask);
        if(_isCollide)
        {
            _wallBody.simulated = true;
        }
    }
    private void OnDrawGizmos()
    {
        if (_Collidecheck == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_Collidecheck.position, _Radius);
    }
    
}
