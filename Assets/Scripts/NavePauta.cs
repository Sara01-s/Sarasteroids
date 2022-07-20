using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class NavePauta : MonoBehaviour {
    private Rigidbody _rb;

    public float _fuerzaMovimiento, _fuerzaGiro;
    public float _horizontal, _vertical;

    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    void Update() {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() {
        _rb.AddForce(transform.up * _fuerzaMovimiento * _vertical);
        _rb.AddTorque(transform.forward * -_fuerzaGiro * _horizontal);
    }
}
