using UnityEngine;
using System.Collections;

public class ExplosionDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 2f);
	}
	

}
