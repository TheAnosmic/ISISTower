using UnityEngine;

[System.Serializable]
enum ETILE_STATE
{
    SOLID = 0,
    SLIPPERY = 1,
    SLOWING = 2,
}

public class Tile : MonoBehaviour {

    [SerializeField]
    private ETILE_STATE State;
}
