using System;
using UnityEngine;

//не совсем верная реализация
public class PlayerInput : MonoBehaviour
{

    [SerializeField] private string _horizontalAxis = "Horizontal";
    [SerializeField] private string _verticalAxis = "Vertical";
    [SerializeField] private string _fireBtn1 = "Fire1";
    [SerializeField] private string _fireBtn2 = "Fire2";

    private Vector3 _inputAxis;

    public static Action<Vector3> OnInput;
    public static Action<Boolean> OnInputSpaceBtn;
    public static Action<Boolean> OnInputFireBtn;
    public static Action<Boolean> OnInputFireBtn2;
    public static Action<Boolean> OnInputQ;

    private void Update()
    {
        float horizontal = Input.GetAxis(_horizontalAxis);
        float vertical = Input.GetAxis(_verticalAxis);

        _inputAxis.Set(horizontal, 0f, vertical);

        //всем ктл подписался на событие OnInput отдали _inputAxis
        OnInput?.Invoke(_inputAxis);
        OnInputSpaceBtn?.Invoke(Input.GetKeyDown(KeyCode.Space));
        OnInputFireBtn?.Invoke(Input.GetButtonDown(_fireBtn2));
        OnInputFireBtn2?.Invoke(Input.GetButtonDown(_fireBtn1));
        OnInputQ?.Invoke(Input.GetKeyDown(KeyCode.Q));
    }

}
