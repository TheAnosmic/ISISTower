using UnityEngine;
public class Player : MonoBehaviour {

    [SerializeField]
    private IController controller;

    [SerializeField]
    private Vector2 spawnPosition;

    public void Start()
    {
        transform.position = spawnPosition;
    }

    public void Update()
    {
        controller.UpdateDirection();
        controller.UpdateSpeed();
    }
}
