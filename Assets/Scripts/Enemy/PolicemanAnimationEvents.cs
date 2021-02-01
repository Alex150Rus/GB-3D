using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicemanAnimationEvents : MonoBehaviour
{
    public PlaySound playsound;
    public string stepsSoundName;


    // Start is called before the first frame update
    void Start()
    {
        playsound = GetComponentInChildren<PlaySound>();
    }

    private void OnGround()
    {
        playsound.Play(stepsSoundName);
    }
}
