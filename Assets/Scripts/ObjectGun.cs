using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectGun : MonoBehaviour {

  public Camera pickingCamera;
  public GameObject objectToShoot;
  public float impulseAmount;
  public Vector3 spawnOffset;
  public Text firePromptText;

    private float _coolDownTime = 1.0f;
    private float _elapsedTime = 0.0f;
	// Use this for initialization
	void Start () {
    if(objectToShoot == null || objectToShoot.GetComponent<Rigidbody>() == null) {
      Debug.Log("You're a terrible person for not having a valid object here. You should feel bad.");
    }
	}
	
	// Update is called once per frame
	void Update () {
    _elapsedTime += Time.deltaTime;
    if (_elapsedTime >= _coolDownTime)
    {
        firePromptText.text = "Fire!";
        if (Input.GetMouseButtonDown(0) == true)
        {
            Rigidbody rigidbody = objectToShoot.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                firePromptText.text = "Reloading...";

                GameObject newGO = GameObject.Instantiate(objectToShoot);

                Vector3 positionToSpawnAt = transform.position + (transform.forward) + spawnOffset;
                newGO.transform.position = positionToSpawnAt;

                // Creates a ray that is cast from the mouse's position into the world.
                Vector3 mousePosition = Input.mousePosition;
                Ray pickingRay = pickingCamera.ScreenPointToRay(mousePosition);

                rigidbody = newGO.GetComponent<Rigidbody>();
                rigidbody.AddForce(pickingRay.direction.normalized * impulseAmount, ForceMode.Impulse);

                Destroy(newGO, 1.0f);

                 _elapsedTime = 0;
            }
        } 
    }
  }
}
