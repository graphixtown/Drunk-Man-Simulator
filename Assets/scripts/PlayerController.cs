using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class PlayerController : MonoBehaviour
{
    [Header("Taking Refrence")]
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [Header("Floating, Vector Values")]
    [SerializeField] private float jumpforce;
    [SerializeField] private float playerspeed;
    [SerializeField] private Vector2 jumpheight;
    [SerializeField] private float positionradius, obsticleRadi;
    [Header("Layermask and Transform Refrence")]
    [SerializeField] private LayerMask groundLayer, obsticleLayer;
    [SerializeField] private Transform playerpos, hipsPos;
    [SerializeField] private Moving_Script _movingobject;
    [Header("Booleans")]
    [SerializeField] public bool isonground;
    [SerializeField] private bool isIntractioninRange;


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
    void Update()
    {
        //float MovementX = Input.GetAxisRaw("Horizontal");
        float MovementX = Player_Inputs.instance.MoveInput.x;
        Debug.Log(MovementX);
        if (MovementX != 0)
        {
            if (MovementX > 0)
            {
                if (isonground)
                {
                    anim.Play("Walking");
                    rb.AddForce(Vector2.right * playerspeed * Time.deltaTime);
                }
                else
                    rb.AddForce(Vector2.right * playerspeed / 2 * Time.deltaTime);
            }
            else if (MovementX < 0 && isonground)
            {
                if (isonground)
                {
                    anim.Play("WalkingBack");
                    rb.AddForce(Vector2.left * playerspeed * Time.deltaTime);
                }
                else
                    rb.AddForce(Vector2.left * playerspeed / 2 * Time.deltaTime);
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
        isIntractioninRange = Physics2D.OverlapCircle(hipsPos.position, obsticleRadi, obsticleLayer);
        if(isonground == true && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jumping");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
        } 
        /*if(obsticleLayer != null)
        {
            _movingobject.MoveObsticle(isIntractioninRange);
        }*/
    }
    private void FixedUpdate()
    {
        
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