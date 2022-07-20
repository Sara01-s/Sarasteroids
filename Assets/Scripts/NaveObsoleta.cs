using UnityEngine;

/* Aquí me equivoqué porque malinterpreté la pauta
 * pero lo dejo porqué está chistoso
 */

[RequireComponent(typeof(Rigidbody))]
public class NaveObsoleta : MonoBehaviour {
    [Header("Variables Movimiento")]
    [Range(0f, 10f)] public float _dragInicial;
    [Range(0f, 1f)] public float _factorDrag;

    public float _fuerzaDeMovimiento;
    public float _velMovimientoMax = 0.5f;

    [Header("Variables Rotación")]
    [Range(0f, 25f)] public float _angularDragInicial;
    [Range(0f, 1f)] public float _factorAngularDrag;

    public float _fuerzaDeRotacion;
    public float _velRotacionMax = 0.5f;

    // Útiles
    private int _dirPositiva = 1, _dirNegativa = -1;
    private Rigidbody _rb;

    private void Awake() { 
        _rb = GetComponent<Rigidbody>();
        _rb.angularDrag = _angularDragInicial;
        _rb.drag = _dragInicial;
    }

    // uso Método
    private void Acelerar(float factorAcelaracion) {
        _rb.angularDrag = (_rb.angularDrag <= _velRotacionMax) ? 
                           _velRotacionMax : _rb.angularDrag -= factorAcelaracion;
    }

    private void LimitarVelocidad() {
        _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, 10f);
    }

    private void FixedUpdate() {
        // Movimiento
        

        if (Input.GetKey(KeyCode.UpArrow)) {
            LimitarVelocidad();

            _rb.AddForce(transform.up * _fuerzaDeMovimiento * _dirPositiva);
            _rb.drag = 0f;
            return;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            LimitarVelocidad();

            _rb.AddForce(transform.up * _fuerzaDeMovimiento * _dirNegativa);
            _rb.drag = 0f;
            return;
        }

        // Desacelerar movimiento
        _rb.drag = (_rb.drag >= _dragInicial) ? 
                    _dragInicial : _rb.drag += _factorDrag;


        // Rotación
        if (Input.GetKey(KeyCode.LeftArrow)) {
            _rb.AddTorque(Vector3.forward * _fuerzaDeRotacion * _dirPositiva, ForceMode.Acceleration);
            Acelerar(_factorAngularDrag);
            return;
        } 

        if (Input.GetKey(KeyCode.RightArrow)) {
            _rb.AddTorque(Vector3.forward * _fuerzaDeRotacion * _dirNegativa, ForceMode.Acceleration);
            Acelerar(_factorAngularDrag);
            return;
        } 
        
        // Desacelerar rotación
        _rb.angularDrag = (_rb.angularDrag >= _angularDragInicial) ?
                           _angularDragInicial : _rb.angularDrag += _factorAngularDrag;
    }
}
