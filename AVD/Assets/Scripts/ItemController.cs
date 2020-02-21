using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private Animator animator;
    public enum Type { Cherry, Diamond};
    public Type type;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("type", (int) type);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) ItemPicked(); 
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

    private void ItemPicked()
    {
        animator.SetTrigger("picked");
    }
}
