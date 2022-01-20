//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Scripts/DebugKeys.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @DebugKeys : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @DebugKeys()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DebugKeys"",
    ""maps"": [
        {
            ""name"": ""debug"",
            ""id"": ""5161ff61-1fa5-44db-84cb-2c5feb49e5f3"",
            ""actions"": [
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""76b62ec5-46f5-4ea2-81ef-84718d1df686"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8379dab1-3480-45f2-892c-8a67f1fd545b"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // debug
        m_debug = asset.FindActionMap("debug", throwIfNotFound: true);
        m_debug_Quit = m_debug.FindAction("Quit", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // debug
    private readonly InputActionMap m_debug;
    private IDebugActions m_DebugActionsCallbackInterface;
    private readonly InputAction m_debug_Quit;
    public struct DebugActions
    {
        private @DebugKeys m_Wrapper;
        public DebugActions(@DebugKeys wrapper) { m_Wrapper = wrapper; }
        public InputAction @Quit => m_Wrapper.m_debug_Quit;
        public InputActionMap Get() { return m_Wrapper.m_debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null)
            {
                @Quit.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnQuit;
            }
            m_Wrapper.m_DebugActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
            }
        }
    }
    public DebugActions @debug => new DebugActions(this);
    public interface IDebugActions
    {
        void OnQuit(InputAction.CallbackContext context);
    }
}
