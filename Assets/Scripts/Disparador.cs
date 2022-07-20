using UnityEngine;

public class Disparador : MonoBehaviour {
    public GameObject _prefabBala;
    public Transform _origenBala;
    public float _enfriamientoDisparo = 0.3f;
    
    private float _temporizador;

    private void Update() {

        _temporizador -= Time.deltaTime;

        if (_temporizador <= 0f) {
            if (Input.GetKeyDown(KeyCode.Space)) {

                Instantiate(_prefabBala, _origenBala.position, transform.rotation);
                _temporizador = _enfriamientoDisparo;
            }
        }
    }
}
