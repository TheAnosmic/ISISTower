using UnityEngine;

public class Zoom : IPickup
{
    public override void Use(Player player)
    {
        var camera = GameObject.Find("Main Camera");
        camera.transform.Translate(0, 0, 1);
    }
}
