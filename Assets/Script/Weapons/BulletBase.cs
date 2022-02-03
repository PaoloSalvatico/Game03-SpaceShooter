using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletBase : MonoBehaviour
{
    public float speed = 10;

    public float lifetime = 5;

    protected Rigidbody2D _rb;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnEnable()
    {
        StartCoroutine("AutoDeactivation");
    }

    protected virtual void OnDisable()
    {
        StopCoroutine("AutoDeactivation");
    }

    protected virtual IEnumerator AutoDeactivation()
    {
        yield return new WaitForEndOfFrame();
        _rb.velocity = transform.up * speed;

        yield return new WaitForSeconds(lifetime);
        gameObject.SetActive(false);
    }

    protected virtual void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
