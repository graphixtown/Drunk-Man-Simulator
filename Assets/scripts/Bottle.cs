using UnityEngine;

public class Bottle : MonoBehaviour
{
    private float breakspeed = 6.5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer rbSprite;
    [SerializeField] private ParticleSystem breakParticle;
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private AudioSource breakSoundSource;
    private bool broken = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        breakSoundSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(broken) return;
        float impactSpeed = collision.relativeVelocity.magnitude;
        if(impactSpeed >= breakspeed)
        {
            Break();
        }
    }
    private void Break()
    {
        if(breakSound != null && breakSoundSource != null)
        {
            breakSoundSource.PlayOneShot(breakSound);
        }
        broken = true;
        ParticleSystem effect = Instantiate(breakParticle, transform.position, Quaternion.identity);
        Destroy(effect.gameObject, effect.main.duration + effect.main.startLifetime.constantMax);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        float destroyDelay = breakSound != null ? breakSound.length : 0.1f;
        Destroy(gameObject, destroyDelay);
    }
}
