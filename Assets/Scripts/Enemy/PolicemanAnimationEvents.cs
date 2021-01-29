using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicemanAnimationEvents : MonoBehaviour
{
    public PlaySound playsound;


    // Start is called before the first frame update
    void Start()
    {
        playsound = GetComponentInChildren<PlaySound>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGround()
    {
        playsound.Play();
    }
}
