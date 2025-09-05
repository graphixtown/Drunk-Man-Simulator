using UnityEngine;

public class grabbing : MonoBehaviour
{
    [SerializeField] private KeyCode mousebutton;
    private bool hold;
    void Update()
    {
        if(Input.GetKey(mousebutton))
        {
            hold = true;
        }
        else
        {
            hold = false;
            //Debug.Log("Arm distroyed");
            Destroy(GetComponent<FixedJoint2D>());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hold)
        {
            Rigidbody2D rb = collision.transform.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                FixedJoint2D Fj = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                Fj.connectedBody = rb;
            }
            else
            {
                FixedJoint2D Fj = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
            }
        }
    }
}
