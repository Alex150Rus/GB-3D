using System;
using UnityEngine;

//не совсем верная реализация
public class PlayerInput : MonoBehaviour
{

    [SerializeField] private string horizontalAxis = "Horizontal";
    [SerializeField] private string verticalAxis = "Vertical";
    [SerializeField] private string fireBtn = "Fire1";

    private Vector3 _inputAxis;

    public static Action<Vector3> OnInput;
    public static Action<Boolean> OnInputSpaceBtn;
    public static Action<Boolean> OnInputFireBtn;

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis(horizontalAxis);
        float vertical = Input.GetAxis(verticalAxis);

        _inputAxis.Set(horizontal, 0f, vertical);

        //всем ктл подписался на событие OnInput отдали _inputAxis
        OnInput?.Invoke(_inputAxis);
    }

    private void Update()
    {
        OnInputSpaceBtn?.Invoke(Input.GetKeyDown(KeyCode.Space));
        OnInputFireBtn?.Invoke(Input.GetButtonDown(fireBtn));
    }

}
