using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpforce;
    [SerializeField] private float playerspeed;
    [SerializeField] private Vector2 jumpheight;
    [SerializeField] private float positionradius, obsticleRadi;
    [SerializeField] private LayerMask groundLayer, obsticleLayer;
    [SerializeField] private Transform playerpos, hipsPos;
    public bool isonground, isObsticle;
    [SerializeField] private Moving_Script _movingobject;
    //[SerializeField] Player_Inputs _Inputs;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collider2D[] collider = transform.GetComponentsInChildren<Collider2D>();
        for(int i = 0; i < collider.Length; i++)
        {
            for(int k = i; k < collider.Length; k++)
            {
                Physics2D.IgnoreCollision(collider[i], collider[k]);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float MovementX = Input.GetAxisRaw("Horizontal");

        if (MovementX != 0)
        {
            if(MovementX > 0 && isonground)
            {
                anim.Play("Walking");
                rb.AddForce(Vector2.right * playerspeed * Time.deltaTime);
            }
            else if(MovementX < 0 && isonground)
            {
                anim.Play("WalkingBack");
                rb.AddForce(Vector2.left * playerspeed * Time.deltaTime);
            }
            else
            {
                anim.Play("Idle");
            }
        }
        else
        {
            anim.Play("Idle");
        }

        isonground = Physics2D.OverlapCircle(playerpos.position, positionradius, groundLayer);
        isObsticle = Physics2D.OverlapCircle(hipsPos.position, obsticleRadi, obsticleLayer);
        if(isonground == true && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jumping");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
        } 
        if(obsticleLayer != null)
        {
            _movingobject.MoveObsticle(isObsticle);
        }
    }
    private void OnDrawGizmos()
    {
        if(groundLayer != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(playerpos.position, positionradius);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(hipsPos.position, obsticleRadi);

        }
    }
}