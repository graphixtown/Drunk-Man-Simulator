using UnityEngine;

public class FsnButton : MonoBehaviour
{

    [SerializeField] private string FAN_TAG;
    private bool _shouldOn = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_shouldOn) return; 
        if (collision.gameObject.CompareTag(FAN_TAG)) GameObject.Find("Manager").GetComponent<FansManager>().ActivateFan(gameObject);
        _shouldOn = false;
    }
}
