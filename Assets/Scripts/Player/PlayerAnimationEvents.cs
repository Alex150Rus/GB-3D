using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{

    public PlaySound playsound;


    // Start is called before the first frame update
    void Start()
    {
        playsound = GetComponentInChildren<PlaySound>();
    }

    private void OnGround()
    {
        playsound.Play();
    }
}
