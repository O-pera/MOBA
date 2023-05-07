using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private bool drawGizmo = false;

    [SerializeField] private Vector3 boxSize = Vector3.one;
    [SerializeField] private float maxDistance = 1.0f;
    [SerializeField] private bool _isGrounded = false;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsGrounded { get => _isGrounded; }

    private void OnDrawGizmos() {
        if(drawGizmo == false)
            return;

        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);
    }

    private void Update() {
        _isGrounded = Physics.BoxCast(transform.position, boxSize, transform.up, transform.rotation, maxDistance, _groundLayer);
    }
}
