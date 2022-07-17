using UnityEngine;

public class Reposicionar : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Borde")) {

            Borde.TipoBorde bordeChocado = other.GetComponent<Borde>().GetTipoBorde();

            switch (bordeChocado) {
                case Borde.TipoBorde.Izquierda:
                    transform.position = new Vector3(8f, transform.position.y, 0f);
                break;
                
                case Borde.TipoBorde.Derecha:
                    transform.position = new Vector3(-8f, transform.position.y, 0f);
                break;

                case Borde.TipoBorde.Arriba:
                    transform.position = new Vector3(transform.position.x, -3, 0f);
                break;

                case Borde.TipoBorde.Abajo:
                    transform.position = new Vector3(transform.position.x, 5f, 0f);
                break;
            }
        }
    }    
}
