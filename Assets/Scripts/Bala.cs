using UnityEngine;

public class Bala : MonoBehaviour {
    public float _velocidad = 5f;
    public float _tiempoDeVida = 1f;

    private void Update() {
        if (_tiempoDeVida <= 0) Destroy(gameObject);
        else _tiempoDeVida -= Time.deltaTime;
        
        transform.position += transform.up * _velocidad * Time.deltaTime;
    }    
}
