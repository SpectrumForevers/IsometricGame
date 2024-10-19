using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfrerTime : MonoBehaviour
{
    [SerializeField] float timeDestroy = 2f;
    private void Start()
    {
        StartCoroutine(DestroyTimer());
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(timeDestroy);
        Destroy(gameObject);
        yield return null;

    }
}
