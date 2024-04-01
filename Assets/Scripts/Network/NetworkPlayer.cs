using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkPlayer : NetworkBehaviour, IPlayerLeft
{
    public static NetworkPlayer local { get; set; }
    void Start()
    {

    }

    public override void Spawned()
    {
        base.Spawned();
        if (Object.HasInputAuthority)
        {
            local = this;

            Debug.Log("Spawned Local Player");
        }
        else
        {
            Camera localCamera = GetComponentInChildren<Camera>();
            localCamera.enabled = false;

            AudioListener listener = GetComponentInChildren<AudioListener>();
            listener.enabled = false;

            Debug.Log("Spawned Remote Player");
        }
    }

    public void PlayerLeft(PlayerRef player)
    {
        if (player = Object.InputAuthority)
            Runner.Despawn(Object);
    }
}
