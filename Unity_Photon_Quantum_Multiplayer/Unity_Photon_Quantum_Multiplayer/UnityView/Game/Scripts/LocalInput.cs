using System;
using Photon.Deterministic;
using Quantum;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class LocalInput : MonoBehaviour {

    [SerializeField] FloatingJoystick joystick;

    private void OnEnable() {
    QuantumCallback.Subscribe(this, (CallbackPollInput callback) => PollInput(callback));
  }

  public void PollInput(CallbackPollInput callback) {
        Quantum.Input i = new Quantum.Input();

        // Note: Use GetButton not GetButtonDown/Up Quantum calculates up/down itself.
        i.Jump = CrossPlatformInputManager.GetButton("Jump");

        Vector2 inputDirection = Vector2.zero;

        inputDirection.x = joystick.Horizontal;
        inputDirection.y = joystick.Vertical;

        i.DirectionX = (short)(inputDirection.x * 10);
        i.DirectionY = (short)(inputDirection.y * 10);

        callback.SetInput(i, DeterministicInputFlags.Repeatable);
  }
}
