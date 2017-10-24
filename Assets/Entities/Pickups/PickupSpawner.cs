using UnityEngine;
using UnityEngine.UI;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField]
    private float _respawnTime = 3;

    [SerializeField]
    private IPickup _pickup;

    [SerializeField]
    private Image _timerImage;


    private float _currentRespawnTimer;
    private bool _isPickupSpawned;

    private void Start()
    {
        SpwanPickup();
    }

    private void Update()
    {
        if (!_isPickupSpawned)
        {
            _currentRespawnTimer += Time.deltaTime;
            _timerImage.fillAmount = _currentRespawnTimer / _respawnTime;
            if (_currentRespawnTimer >= _respawnTime)
            {
                SpwanPickup();
            }
        }
    }

    private void SpwanPickup()
    {
        _isPickupSpawned = true;
        GetComponent<Collider>().enabled = true;
        GetComponent<Renderer>().enabled = true;
    }

    public IPickup Pickup()
    {
        _isPickupSpawned = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<Renderer>().enabled = false;
        _currentRespawnTimer = 0;
        _timerImage.fillAmount = 0;

        return _pickup;
    }
}
