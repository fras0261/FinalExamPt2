using UnityEngine;
using System.Collections;

public class SugarDetection : MonoBehaviour {

    private GameObject _leftEye;
    private GameObject _rightEye;
    private GameController _gameController;

    void Start()
    {
        _leftEye = GameObject.Find("Left Eye");
        _rightEye = GameObject.Find("Right Eye");
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void OnCollisionEnter(Collision col)
    {
        GameObject collidedObject = col.collider.gameObject;
        if (!collidedObject.CompareTag("Tooth"))
        {
            _leftEye.GetComponent<RotateEyes>().RotateBurst();
            _rightEye.GetComponent<RotateEyes>().RotateBurst();

            _gameController.LoseHealth();
        }
    }
}
