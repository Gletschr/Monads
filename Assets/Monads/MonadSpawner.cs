using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonadSpawner : MonoBehaviour {

    public GameObject monadPrefab;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
            SpawnRandomMonad(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
	}

    void SpawnRandomMonad(Vector3 position) {
        GameObject monad = Instantiate(monadPrefab);
        monad.transform.position = new Vector3(position.x, position.y, 0.0f);
    }

}
