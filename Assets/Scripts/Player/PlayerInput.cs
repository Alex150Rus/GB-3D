using System;
using UnityEngine;

//не совсем верная реализация
public class PlayerInput : MonoBehaviour
{

    [SerializeField] private string _horizontalAxis = "Horizontal";
    [SerializeField] private string _verticalAxis = "Vertical";
    [SerializeField] private string _fireBtn1 = "Fire1";
    [SerializeField] private string _fireBtn2 = "Fire2";
    [SerializeField] private string _cancel = "Cancel";

    private Vector3 _inputAxis;
    private bool _takingInput = true;

    public static Action<Vector3> OnInput;
    public static Action<Boolean> OnInputSpaceBtn;
    public static Action<Boolean> OnInputFireBtn;
    public static Action<Boolean> OnInputFireBtn2;
    public static Action<Boolean> OnInputQ;
    public static Action<Boolean> OnInputEscape;
    public static Action<Boolean, Vector3> OnInputMMB;

    private void Update()
    {

        float horizontal = Input.GetAxis(_horizontalAxis);
        float vertical = Input.GetAxis(_verticalAxis);

        _inputAxis.Set(horizontal, 0f, vertical);

        //всем ктл подписался на событие OnInput отдали _inputAxis
        OnInput?.Invoke(_inputAxis);

        if (_takingInput)
        {
            OnInputSpaceBtn?.Invoke(Input.GetKeyDown(KeyCode.Space));
            OnInputFireBtn?.Invoke(Input.GetButtonDown(_fireBtn2));
            OnInputFireBtn2?.Invoke(Input.GetButtonDown(_fireBtn1));
            OnInputQ?.Invoke(Input.GetKeyDown(KeyCode.Q));
            OnInputMMB?.Invoke(Input.GetMouseButton(2), new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0));
        }

        OnInputEscape?.Invoke(Input.GetButtonDown(_cancel));
    }

    public void TakingInput(bool takingItput)
    {
        _takingInput = takingItput;
    }

}
