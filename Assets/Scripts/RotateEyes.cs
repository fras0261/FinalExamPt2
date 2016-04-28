using UnityEngine;
using System.Collections;

public class RotateEyes : MonoBehaviour {

  public Vector3 rotationAxis = new Vector3(0.0f, 1.0f, 0.0f);
  public float rotationAngle = 20.0f;
	
	// Update is called once per frame
	void Update () {
    // Rotate the eyes around the Y-axis @ 20-degrees/second.
    transform.Rotate(rotationAxis, rotationAngle * Time.deltaTime);
	}

    public void RotateBurst()
    {
        float elapsedTime = 0.0f;
        float burstDuration = 5.0f;

        while (elapsedTime < burstDuration)
        {
            transform.Rotate(rotationAxis, (rotationAngle + 60) * Time.deltaTime);
            elapsedTime += Time.deltaTime;
        }
            
    }
}
