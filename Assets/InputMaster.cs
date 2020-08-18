// GENERATED AUTOMATICALLY FROM 'Assets/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Airship"",
            ""id"": ""904e458e-7c35-42c6-bd2e-f039f0daf49d"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""7c094b26-8761-46ec-a9da-d23f682478cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""c669d69a-19f8-469c-b8ff-05a5c033d9bc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""54483c1a-f957-48a2-b77b-50bd0895abef"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cdb9456-447a-4f30-96c0-6d161f82e6f3"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""608d1fed-4203-4b6e-8576-9df334bd86b9"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""761b1b29-780a-42d2-80e5-78cf5ea8ce3a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MouseKeyboard"",
            ""bindingGroup"": ""MouseKeyboard"",
            ""devices"": []
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": []
        }
    ]
}");
        // Airship
        m_Airship = asset.FindActionMap("Airship", throwIfNotFound: true);
        m_Airship_Shoot = m_Airship.FindAction("Shoot", throwIfNotFound: true);
        m_Airship_Aim = m_Airship.FindAction("Aim", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Airship
    private readonly InputActionMap m_Airship;
    private IAirshipActions m_AirshipActionsCallbackInterface;
    private readonly InputAction m_Airship_Shoot;
    private readonly InputAction m_Airship_Aim;
    public struct AirshipActions
    {
        private @InputMaster m_Wrapper;
        public AirshipActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Airship_Shoot;
        public InputAction @Aim => m_Wrapper.m_Airship_Aim;
        public InputActionMap Get() { return m_Wrapper.m_Airship; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AirshipActions set) { return set.Get(); }
        public void SetCallbacks(IAirshipActions instance)
        {
            if (m_Wrapper.m_AirshipActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_AirshipActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_AirshipActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_AirshipActionsCallbackInterface.OnShoot;
                @Aim.started -= m_Wrapper.m_AirshipActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_AirshipActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_AirshipActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_AirshipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public AirshipActions @Airship => new AirshipActions(this);
    private int m_MouseKeyboardSchemeIndex = -1;
    public InputControlScheme MouseKeyboardScheme
    {
        get
        {
            if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("MouseKeyboard");
            return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IAirshipActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
    }
}
