using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed, _jumpForce;
    [SerializeField] private float _circleRadi;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Rigidbody2D _playerbody;
    [SerializeField] private LayerMask _groundlayer;
    private float _movementForce, _upForce;
    [SerializeField] private bool _isGrounded, _isItsObsticle;

    void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _circleRadi, _groundlayer);
        
        _movementForce = Player_Inputs.instance.MoveInput.x * _moveSpeed * Time.deltaTime;
        _playerbody.linearVelocityX = _movementForce;

        if(Player_Inputs.instance.JumpInput && _isGrounded)
        {
            _playerbody.linearVelocity = new Vector2(_playerbody.linearVelocityX, _jumpForce);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deadzone"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

    private void OnDrawGizmos()
    {
        if (_groundCheck == null) return;
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_groundCheck.position, _circleRadi);
    }
}
