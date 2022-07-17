using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Asteroide : MonoBehaviour {
    public enum TipoAsteroide { Grande, Chico };
    public TipoAsteroide _asteroide;    

    public GameObject _asteroideChico;
    public float _velocidad;

    private SpawnerAsteroides _spawnerPadre;
    private bool _esGrande;

    private void Awake() {
        // Obtener referencia del objeto padre que creó este asteroide
        // Esta referencia siempre existe ya que el padre instancia asteroides como hijos
        _spawnerPadre = GetComponentInParent<SpawnerAsteroides>();

        switch (_asteroide) {
            // Configuración si es grande
            case TipoAsteroide.Grande:

                _esGrande = true;
                _velocidad = 5f;
            break;

            // Configuración si es chico
            case TipoAsteroide.Chico:

                _esGrande = false;
                _velocidad = 8f;
            break;
        }
    }
    
    private void Update() {
        // Ir hacia el "arriba" del objeto en todo momento
        transform.position += transform.up * _velocidad * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Bala")) { // Al asteroide le llegó una bala:

            if (_esGrande) {
                Quaternion rotacionRandom = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
                Quaternion rotacionRandom2 = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

                Instantiate(_asteroideChico, transform.position, rotacionRandom);
                Instantiate(_asteroideChico, transform.position, rotacionRandom2);

                // Resta 1 al total de asteroides en el juego. Esto ayuda a que haya un límite de asteroides
                _spawnerPadre.RestarAsteroide();

                Destroy(other.gameObject);
                Destroy(gameObject);
            }

            else { // Es chico
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
