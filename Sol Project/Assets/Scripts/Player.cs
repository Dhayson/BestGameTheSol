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
        },
        {
            ""name"": ""Change Controller"",
            ""id"": ""dd09a60f-9ab1-41c4-8be3-5fb14701dea5"",
            ""actions"": [
                {
                    ""name"": ""Keyboard"",
                    ""type"": ""Button"",
                    ""id"": ""53cb2678-d9da-45af-b905-79fb2e9427a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Gamepad"",
                    ""type"": ""Button"",
                    ""id"": ""3c6ed620-6eec-4c6e-ad1d-929d9f2a3c10"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Change Gamepad"",
                    ""type"": ""Button"",
                    ""id"": ""91b1d495-95e6-446c-912d-a27896d848ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3c83b764-86b4-4ec1-bee1-b21fd15314ba"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Keyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4551b70d-f094-4abf-85dd-0c44748e3a22"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gamepad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b27668e-4549-4e5e-9d93-731a0d9898da"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gamepad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a05f1c6a-18b5-4b3c-9e3b-d397431476d0"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gamepad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13371442-9596-4fc5-8e55-e3fa70bf8899"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gamepad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1cdd978-94b0-483e-b5d4-38d08c5f5ee9"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gamepad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f707a4af-d22c-4f7d-9aa9-cca429cedcbd"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gamepad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82ddec37-9098-4e20-b714-bb180c2f7a76"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gamepad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9b8df82-16c4-4df1-b7b4-8971a1014ae1"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gamepad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4be5d08b-6a70-43da-b417-b4dfba562bfa"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Change Gamepad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Meta"",
            ""id"": ""64802365-5103-4bdf-9a3d-8cdeec73d502"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b9526b0d-2bff-4848-aa84-dc3d8e9ed2b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Save"",
                    ""type"": ""Button"",
                    ""id"": ""40b132c4-682c-41a0-8eee-1614b7eff99a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DeleteSave"",
                    ""type"": ""Button"",
                    ""id"": ""e9cc63df-8754-4e57-804d-1450425e09c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""06d94dff-32ec-4773-9f77-bf5d4c68c105"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a833aa03-f642-4424-80b0-6bb4cd327b37"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac9a90ef-aa3d-4ffa-b65a-2eaf012382fe"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f195da8-7f0b-4e24-9095-6b95b11cd019"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeleteSave"",
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
        // Change Controller
        m_ChangeController = asset.FindActionMap("Change Controller", throwIfNotFound: true);
        m_ChangeController_Keyboard = m_ChangeController.FindAction("Keyboard", throwIfNotFound: true);
        m_ChangeController_Gamepad = m_ChangeController.FindAction("Gamepad", throwIfNotFound: true);
        m_ChangeController_ChangeGamepad = m_ChangeController.FindAction("Change Gamepad", throwIfNotFound: true);
        // Meta
        m_Meta = asset.FindActionMap("Meta", throwIfNotFound: true);
        m_Meta_Pause = m_Meta.FindAction("Pause", throwIfNotFound: true);
        m_Meta_Save = m_Meta.FindAction("Save", throwIfNotFound: true);
        m_Meta_DeleteSave = m_Meta.FindAction("DeleteSave", throwIfNotFound: true);
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

    // Change Controller
    private readonly InputActionMap m_ChangeController;
    private IChangeControllerActions m_ChangeControllerActionsCallbackInterface;
    private readonly InputAction m_ChangeController_Keyboard;
    private readonly InputAction m_ChangeController_Gamepad;
    private readonly InputAction m_ChangeController_ChangeGamepad;
    public struct ChangeControllerActions
    {
        private @Player m_Wrapper;
        public ChangeControllerActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Keyboard => m_Wrapper.m_ChangeController_Keyboard;
        public InputAction @Gamepad => m_Wrapper.m_ChangeController_Gamepad;
        public InputAction @ChangeGamepad => m_Wrapper.m_ChangeController_ChangeGamepad;
        public InputActionMap Get() { return m_Wrapper.m_ChangeController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ChangeControllerActions set) { return set.Get(); }
        public void SetCallbacks(IChangeControllerActions instance)
        {
            if (m_Wrapper.m_ChangeControllerActionsCallbackInterface != null)
            {
                @Keyboard.started -= m_Wrapper.m_ChangeControllerActionsCallbackInterface.OnKeyboard;
                @Keyboard.performed -= m_Wrapper.m_ChangeControllerActionsCallbackInterface.OnKeyboard;
                @Keyboard.canceled -= m_Wrapper.m_ChangeControllerActionsCallbackInterface.OnKeyboard;
                @Gamepad.started -= m_Wrapper.m_ChangeControllerActionsCallbackInterface.OnGamepad;
                @Gamepad.performed -= m_Wrapper.m_ChangeControllerActionsCallbackInterface.OnGamepad;
                @Gamepad.canceled -= m_Wrapper.m_ChangeControllerActionsCallbackInterface.OnGamepad;
                @ChangeGamepad.started -= m_Wrapper.m_ChangeControllerActionsCallbackInterface.OnChangeGamepad;
                @ChangeGamepad.performed -= m_Wrapper.m_ChangeControllerActionsCallbackInterface.OnChangeGamepad;
                @ChangeGamepad.canceled -= m_Wrapper.m_ChangeControllerActionsCallbackInterface.OnChangeGamepad;
            }
            m_Wrapper.m_ChangeControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Keyboard.started += instance.OnKeyboard;
                @Keyboard.performed += instance.OnKeyboard;
                @Keyboard.canceled += instance.OnKeyboard;
                @Gamepad.started += instance.OnGamepad;
                @Gamepad.performed += instance.OnGamepad;
                @Gamepad.canceled += instance.OnGamepad;
                @ChangeGamepad.started += instance.OnChangeGamepad;
                @ChangeGamepad.performed += instance.OnChangeGamepad;
                @ChangeGamepad.canceled += instance.OnChangeGamepad;
            }
        }
    }
    public ChangeControllerActions @ChangeController => new ChangeControllerActions(this);

    // Meta
    private readonly InputActionMap m_Meta;
    private IMetaActions m_MetaActionsCallbackInterface;
    private readonly InputAction m_Meta_Pause;
    private readonly InputAction m_Meta_Save;
    private readonly InputAction m_Meta_DeleteSave;
    public struct MetaActions
    {
        private @Player m_Wrapper;
        public MetaActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Meta_Pause;
        public InputAction @Save => m_Wrapper.m_Meta_Save;
        public InputAction @DeleteSave => m_Wrapper.m_Meta_DeleteSave;
        public InputActionMap Get() { return m_Wrapper.m_Meta; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MetaActions set) { return set.Get(); }
        public void SetCallbacks(IMetaActions instance)
        {
            if (m_Wrapper.m_MetaActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_MetaActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_MetaActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_MetaActionsCallbackInterface.OnPause;
                @Save.started -= m_Wrapper.m_MetaActionsCallbackInterface.OnSave;
                @Save.performed -= m_Wrapper.m_MetaActionsCallbackInterface.OnSave;
                @Save.canceled -= m_Wrapper.m_MetaActionsCallbackInterface.OnSave;
                @DeleteSave.started -= m_Wrapper.m_MetaActionsCallbackInterface.OnDeleteSave;
                @DeleteSave.performed -= m_Wrapper.m_MetaActionsCallbackInterface.OnDeleteSave;
                @DeleteSave.canceled -= m_Wrapper.m_MetaActionsCallbackInterface.OnDeleteSave;
            }
            m_Wrapper.m_MetaActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Save.started += instance.OnSave;
                @Save.performed += instance.OnSave;
                @Save.canceled += instance.OnSave;
                @DeleteSave.started += instance.OnDeleteSave;
                @DeleteSave.performed += instance.OnDeleteSave;
                @DeleteSave.canceled += instance.OnDeleteSave;
            }
        }
    }
    public MetaActions @Meta => new MetaActions(this);
    public interface IGameplayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnRunLeft(InputAction.CallbackContext context);
        void OnRunRight(InputAction.CallbackContext context);
        void OnRunAny(InputAction.CallbackContext context);
    }
    public interface IChangeControllerActions
    {
        void OnKeyboard(InputAction.CallbackContext context);
        void OnGamepad(InputAction.CallbackContext context);
        void OnChangeGamepad(InputAction.CallbackContext context);
    }
    public interface IMetaActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnSave(InputAction.CallbackContext context);
        void OnDeleteSave(InputAction.CallbackContext context);
    }
}
