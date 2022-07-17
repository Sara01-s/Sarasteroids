using UnityEngine;

public class Borde : MonoBehaviour {
    public enum TipoBorde { Izquierda, Derecha, Arriba, Abajo }
    public TipoBorde _tipoBorde;

    // Uso función (En Resposicionar (línea 9))
    public TipoBorde GetTipoBorde() {
        return _tipoBorde;
    }
}
