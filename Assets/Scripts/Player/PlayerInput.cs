using System;
using UnityEngine;

//не совсем верная реализация
public class PlayerInput : MonoBehaviour
{

    [SerializeField] private string _horizontalAxis = "Horizontal";
    [SerializeField] private string _verticalAxis = "Vertical";

    private Vector3 _inputAxis;

    public static Action<Vector3> OnInput;
    public static Action<Boolean> OnInputSpaceBtn;

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis(_horizontalAxis);
        float vertical = Input.GetAxis(_verticalAxis);

        _inputAxis.Set(horizontal, 0f, vertical);

        //всем ктл подписался на событие OnInput отдали _inputAxis
        OnInput?.Invoke(_inputAxis);
    }

    private void Update()
    {
        OnInputSpaceBtn?.Invoke(Input.GetKeyDown(KeyCode.Space));
    }

}
