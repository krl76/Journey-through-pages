using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rigidbody;

    IEnumerator Bushing(Collider other)
    {
        _animator.SetBool("isBushing", other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E));
        _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(2.3f);
        _animator.SetBool("isBushing", false);
        
    }

    private void OnTriggerStay(Collider other)
    {
        StartCoroutine(Bushing(other));
    }
}
