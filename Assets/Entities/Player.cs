using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IDynamicStageEntity {

    [SerializeField]
    private IController controller;

    [SerializeField]
    private Vector2 spawnPosition;

    public void Spawn()
    {
        transform.position = spawnPosition;
    }

    public void UpdateMovement()
    {
        controller.UpdateDirection();
        controller.UpdateSpeed();
    }
}
