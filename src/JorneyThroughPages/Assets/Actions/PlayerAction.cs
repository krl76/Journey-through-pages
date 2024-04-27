//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Actions/PlayerAction.inputactions
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

public partial class @PlayerAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerAction"",
    ""maps"": [
        {
            ""name"": ""UI"",
            ""id"": ""b76cf622-1221-4d33-bbea-c50c2c701579"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""f6af611c-ac2d-462c-97ba-caff6591752f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""cfcbc065-15d8-4827-9e00-a10df5c262d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5aca174b-6d91-4749-bea2-a952cf76e37e"",
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
                    ""id"": ""7ece7a97-a27d-4e88-a0f0-8715d43388df"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dialogs"",
            ""id"": ""49443550-d5bd-459f-89f8-82dceacfaf12"",
            ""actions"": [
                {
                    ""name"": ""ScrollDialog"",
                    ""type"": ""Button"",
                    ""id"": ""8857ca70-deeb-4e8b-ae00-4380d2012eac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5eafebfc-9071-4303-88c5-16cd485b15de"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScrollDialog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Pause = m_UI.FindAction("Pause", throwIfNotFound: true);
        m_UI_Interact = m_UI.FindAction("Interact", throwIfNotFound: true);
        // Dialogs
        m_Dialogs = asset.FindActionMap("Dialogs", throwIfNotFound: true);
        m_Dialogs_ScrollDialog = m_Dialogs.FindAction("ScrollDialog", throwIfNotFound: true);
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

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_Pause;
    private readonly InputAction m_UI_Interact;
    public struct UIActions
    {
        private @PlayerAction m_Wrapper;
        public UIActions(@PlayerAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_UI_Pause;
        public InputAction @Interact => m_Wrapper.m_UI_Interact;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);

    // Dialogs
    private readonly InputActionMap m_Dialogs;
    private List<IDialogsActions> m_DialogsActionsCallbackInterfaces = new List<IDialogsActions>();
    private readonly InputAction m_Dialogs_ScrollDialog;
    public struct DialogsActions
    {
        private @PlayerAction m_Wrapper;
        public DialogsActions(@PlayerAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @ScrollDialog => m_Wrapper.m_Dialogs_ScrollDialog;
        public InputActionMap Get() { return m_Wrapper.m_Dialogs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DialogsActions set) { return set.Get(); }
        public void AddCallbacks(IDialogsActions instance)
        {
            if (instance == null || m_Wrapper.m_DialogsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DialogsActionsCallbackInterfaces.Add(instance);
            @ScrollDialog.started += instance.OnScrollDialog;
            @ScrollDialog.performed += instance.OnScrollDialog;
            @ScrollDialog.canceled += instance.OnScrollDialog;
        }

        private void UnregisterCallbacks(IDialogsActions instance)
        {
            @ScrollDialog.started -= instance.OnScrollDialog;
            @ScrollDialog.performed -= instance.OnScrollDialog;
            @ScrollDialog.canceled -= instance.OnScrollDialog;
        }

        public void RemoveCallbacks(IDialogsActions instance)
        {
            if (m_Wrapper.m_DialogsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDialogsActions instance)
        {
            foreach (var item in m_Wrapper.m_DialogsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DialogsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DialogsActions @Dialogs => new DialogsActions(this);
    public interface IUIActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IDialogsActions
    {
        void OnScrollDialog(InputAction.CallbackContext context);
    }
}
