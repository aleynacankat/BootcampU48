using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] private GameObject _BoxCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
            {
                _animator.SetTrigger("Door");
                _BoxCollider.SetActive(false);
            }
    }
}
