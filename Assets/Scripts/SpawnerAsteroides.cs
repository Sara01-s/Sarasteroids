using UnityEngine;

public class SpawnerAsteroides : MonoBehaviour {
    public GameObject _prefabAsteroide;
    public float _intervaloSpawn = 5f;
    public int _maxAsteroides = 20;
    
    private float _timer;
    private int _numeroAsteroides = 0;

    // Uso método (usado en Asteroide.cs (línea 49))
    public void RestarAsteroide() {
        _numeroAsteroides--;
    }

    private void Awake() {
        // Establecer timer a 5 segundos
        _timer = _intervaloSpawn;

        // Asegurarse que el spawner está en (0, 0)
        transform.position = Vector3.zero;
    }

    private void Update() {
        if (_numeroAsteroides <= _maxAsteroides) {
            if (_timer <= 0) {
                // Spawnear asteroides
                float _randomX = Random.Range(transform.position.y - 4f, transform.position.y + 6);
                float _randomY = Random.Range(transform.position.x + 5f, transform.position.x - 5);
                Vector3 posicionRandom = new Vector3(_randomX, _randomY, 0f);
                Quaternion rotacionRandom = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

                Instantiate(_prefabAsteroide, posicionRandom, rotacionRandom, transform);
                _numeroAsteroides++;

                // Resetear timer a 5 segundos
                _timer = _intervaloSpawn;
            }
            else {
               // Decrementar timer
              _timer -= Time.deltaTime;
            }
        }  
    }
}
