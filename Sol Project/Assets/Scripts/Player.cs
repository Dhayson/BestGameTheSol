// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""f87cc14d-1c98-46b7-ad78-51ef52f5317c"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8e7fa51f-89d6-433e-9ccf-a7267dad877f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run Left"",
                    ""type"": ""Button"",
                    ""id"": ""b02daaa8-02f5-4f00-9349-02d56a80b230"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run Right"",
                    ""type"": ""Button"",
                    ""id"": ""f0a56ab5-f417-440e-ab3c-7b7d3d15fc3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run Any"",
                    ""type"": ""Value"",
                    ""id"": ""557f08b1-e8e6-4974-a078-da21cd898eb4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d40c907a-e75c-4940-b294-d8c6b5204449"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b3c9d0d-6a1a-49f7-bb3f-35e490884dec"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7e32c59-c0ad-49f3-a82a-c2069deb2c1e"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e052b123-b129-49d3-9b5b-a626cc8fe0b5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""346dd50b-56f9-43c6-a311-fa8aaf7a11ed"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb7f793e-8f85-4b88-a3b2-797e3e6d8e54"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5d512c8-f8d3-4ede-80b8-cf1f5955dcc4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run Any"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_RunLeft = m_Gameplay.FindAction("Run Left", throwIfNotFound: true);
        m_Gameplay_RunRight = m_Gameplay.FindAction("Run Right", throwIfNotFound: true);
        m_Gameplay_RunAny = m_Gameplay.FindAction("Run Any", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_RunLeft;
    private readonly InputAction m_Gameplay_RunRight;
    private readonly InputAction m_Gameplay_RunAny;
    public struct GameplayActions
    {
        private @Player m_Wrapper;
        public GameplayActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @RunLeft => m_Wrapper.m_Gameplay_RunLeft;
        public InputAction @RunRight => m_Wrapper.m_Gameplay_RunRight;
        public InputAction @RunAny => m_Wrapper.m_Gameplay_RunAny;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @RunLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunLeft;
                @RunLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunLeft;
                @RunLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunLeft;
                @RunRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunRight;
                @RunRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunRight;
                @RunRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunRight;
                @RunAny.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunAny;
                @RunAny.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunAny;
                @RunAny.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunAny;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @RunLeft.started += instance.OnRunLeft;
                @RunLeft.performed += instance.OnRunLeft;
                @RunLeft.canceled += instance.OnRunLeft;
                @RunRight.started += instance.OnRunRight;
                @RunRight.performed += instance.OnRunRight;
                @RunRight.canceled += instance.OnRunRight;
                @RunAny.started += instance.OnRunAny;
                @RunAny.performed += instance.OnRunAny;
                @RunAny.canceled += instance.OnRunAny;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnRunLeft(InputAction.CallbackContext context);
        void OnRunRight(InputAction.CallbackContext context);
        void OnRunAny(InputAction.CallbackContext context);
    }
}
