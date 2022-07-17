using UnityEngine;

public class Disparador : MonoBehaviour {
    public GameObject _prefabBala;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) 
            Instantiate(_prefabBala, transform.position, transform.rotation);
    }
}
