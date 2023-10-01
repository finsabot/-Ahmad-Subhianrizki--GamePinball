using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBumper : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;

    public AudioManager audioManager;
    public VFXManager vfxManager;

    private Renderer renderer;
    private Animator animator;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        renderer.material.color = color;
    }
   private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            //animasi
            animator.SetTrigger("Hit");

            //playsfx
            audioManager.PlaySFX(collision.transform.position);

            //playvfx
            vfxManager.PlayVFX(collision.transform.position);
        }
    }
}
