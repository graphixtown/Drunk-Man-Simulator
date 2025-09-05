using UnityEngine;

public class Arms : MonoBehaviour
{
    int speed = 300;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;
    [SerializeField] private KeyCode mouseButton;
    void Update()
    {
        Vector3 playerpos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0);
        Vector3 difference = playerpos - transform.position;
        float rotationZ = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        if(Input.GetKey(mouseButton))
        {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, -rotationZ - 90 ,speed * Time.deltaTime));
        }
    }
}
