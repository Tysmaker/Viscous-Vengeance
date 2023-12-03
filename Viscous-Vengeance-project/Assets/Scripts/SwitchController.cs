using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public bool isActive { get; private set; }
    BoxCollider2D bc;
    [SerializeField] float cooldown;
    [SerializeField] Sprite[] sprites;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.gameObject.transform.position.y < transform.position.y)
        {
            isActive = true;
            sr.sprite = sprites[1];
            bc.enabled = false;
            Invoke("SwitchCooldown", cooldown);         
        }     
    }
    void SwitchCooldown()
    {
        isActive= false;
        sr.sprite= sprites[0];  
        bc.enabled = true;
    }
}
