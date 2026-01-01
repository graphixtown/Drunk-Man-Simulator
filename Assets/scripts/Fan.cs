using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] private string PLAYER_TAG;
    [SerializeField] private Rigidbody2D _playerBody;
    [SerializeField] private float _Pressure;
    private bool _isTargetInRange;
    private void FixedUpdate()
    {
        if (_isTargetInRange)
        {
            Vector2 direction = (_playerBody.transform.localPosition - transform.localPosition).normalized;
            _playerBody.AddForce(direction * _Pressure, ForceMode2D.Force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PLAYER_TAG)) Invoke(nameof(ApplyForce), 1);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PLAYER_TAG)) ApplyForce(false);
    }

    private void ApplyForce(bool IsInRange = true)
    {
        if (IsInRange) _isTargetInRange = true;
        else
        {
            _isTargetInRange = false;
        }
    }
}
