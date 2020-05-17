// GENERATED AUTOMATICALLY FROM 'Assets/DefaultControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DefaultControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DefaultControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DefaultControl"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""08e9933d-c64b-4eee-9def-d4f928505ef9"",
            ""actions"": [
                {
                    ""name"": ""rightInner"",
                    ""type"": ""Button"",
                    ""id"": ""83acfcfa-a172-469b-bb60-85906695b37e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""rightOuter"",
                    ""type"": ""Button"",
                    ""id"": ""09d29f2a-ac18-42e7-966c-1547fa7c0677"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""leftInner"",
                    ""type"": ""Button"",
                    ""id"": ""8d27961d-311a-4c47-8922-f3e7efc30610"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""leftOuter"",
                    ""type"": ""Button"",
                    ""id"": ""b343595c-7eba-4f8a-9229-f8ca43793272"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DoubleInner"",
                    ""type"": ""Button"",
                    ""id"": ""f946c9fb-e657-41fe-9591-a3486c2500e8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c9ae5698-5b4e-4d8e-a1a2-d02a6b1c19bb"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""rightInner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbda89ae-ca20-4117-9a1f-ae42494d9c0d"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""rightOuter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""376f37fa-1d92-4f9d-94fe-c0ebd6f5722c"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""leftInner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27c04ba4-944d-411a-bac7-6e38e541cccb"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""leftOuter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a688d17-93dc-4c5c-904e-5e674052bfc2"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DoubleInner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0ab6981-c717-4cea-afa9-0045d4e9a4ff"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DoubleInner"",
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
        m_Gameplay_rightInner = m_Gameplay.FindAction("rightInner", throwIfNotFound: true);
        m_Gameplay_rightOuter = m_Gameplay.FindAction("rightOuter", throwIfNotFound: true);
        m_Gameplay_leftInner = m_Gameplay.FindAction("leftInner", throwIfNotFound: true);
        m_Gameplay_leftOuter = m_Gameplay.FindAction("leftOuter", throwIfNotFound: true);
        m_Gameplay_DoubleInner = m_Gameplay.FindAction("DoubleInner", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_rightInner;
    private readonly InputAction m_Gameplay_rightOuter;
    private readonly InputAction m_Gameplay_leftInner;
    private readonly InputAction m_Gameplay_leftOuter;
    private readonly InputAction m_Gameplay_DoubleInner;
    public struct GameplayActions
    {
        private @DefaultControl m_Wrapper;
        public GameplayActions(@DefaultControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @rightInner => m_Wrapper.m_Gameplay_rightInner;
        public InputAction @rightOuter => m_Wrapper.m_Gameplay_rightOuter;
        public InputAction @leftInner => m_Wrapper.m_Gameplay_leftInner;
        public InputAction @leftOuter => m_Wrapper.m_Gameplay_leftOuter;
        public InputAction @DoubleInner => m_Wrapper.m_Gameplay_DoubleInner;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @rightInner.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightInner;
                @rightInner.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightInner;
                @rightInner.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightInner;
                @rightOuter.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightOuter;
                @rightOuter.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightOuter;
                @rightOuter.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightOuter;
                @leftInner.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftInner;
                @leftInner.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftInner;
                @leftInner.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftInner;
                @leftOuter.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftOuter;
                @leftOuter.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftOuter;
                @leftOuter.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftOuter;
                @DoubleInner.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDoubleInner;
                @DoubleInner.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDoubleInner;
                @DoubleInner.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDoubleInner;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @rightInner.started += instance.OnRightInner;
                @rightInner.performed += instance.OnRightInner;
                @rightInner.canceled += instance.OnRightInner;
                @rightOuter.started += instance.OnRightOuter;
                @rightOuter.performed += instance.OnRightOuter;
                @rightOuter.canceled += instance.OnRightOuter;
                @leftInner.started += instance.OnLeftInner;
                @leftInner.performed += instance.OnLeftInner;
                @leftInner.canceled += instance.OnLeftInner;
                @leftOuter.started += instance.OnLeftOuter;
                @leftOuter.performed += instance.OnLeftOuter;
                @leftOuter.canceled += instance.OnLeftOuter;
                @DoubleInner.started += instance.OnDoubleInner;
                @DoubleInner.performed += instance.OnDoubleInner;
                @DoubleInner.canceled += instance.OnDoubleInner;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnRightInner(InputAction.CallbackContext context);
        void OnRightOuter(InputAction.CallbackContext context);
        void OnLeftInner(InputAction.CallbackContext context);
        void OnLeftOuter(InputAction.CallbackContext context);
        void OnDoubleInner(InputAction.CallbackContext context);
    }
}
