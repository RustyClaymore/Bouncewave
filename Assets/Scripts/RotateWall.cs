using UnityEngine;
using System.Collections;

public class RotateWall : MonoBehaviour {

    public float durationBeforeRotate;
    private float currentDuration;

	// Use this for initialization
	void Start () {
        currentDuration = durationBeforeRotate;
	}
	
	// Update is called once per frame
	void Update () {
        currentDuration -= Time.deltaTime;

        if(currentDuration <= 0)
        {
            currentDuration = durationBeforeRotate;
            transform.Rotate(new Vector3(0, 0, 90));
            if(transform.tag == "BouncyObject")
            {
                transform.tag = "NonBouncyObject";
            }
            else
            {
                transform.tag = "BouncyObject";
            }
        }
	}
}
