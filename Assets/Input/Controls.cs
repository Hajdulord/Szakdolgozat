// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""gameplay"",
            ""id"": ""284de814-2a7c-44b8-9fc7-ff8874d52e18"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""1eca2775-4343-463a-a6e4-1356fac1a972"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""35581d04-cdc4-4a13-b644-f3d115e76bf2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NormalAttack"",
                    ""type"": ""Value"",
                    ""id"": ""c514ae93-9a67-4c5d-93ac-50f2b25d43d7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Value"",
                    ""id"": ""ea917ed2-65c0-4731-9ddd-0b5dede6a965"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Item1"",
                    ""type"": ""Value"",
                    ""id"": ""f4975306-6990-461f-afc2-8c2f4dc203af"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Item2"",
                    ""type"": ""Value"",
                    ""id"": ""57c7c039-110b-4109-a897-0e59ee6ba632"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Item3"",
                    ""type"": ""Value"",
                    ""id"": ""57f6761a-9061-4d8e-aa0c-758e32b8ca9f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Item4"",
                    ""type"": ""Value"",
                    ""id"": ""4a0001bc-9858-4610-ac05-c2d13edc7ae6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Value"",
                    ""id"": ""747528fc-70e2-4313-b1a6-0a6b6c41a6fb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""999762c2-a975-41c6-bf70-87e4af643982"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c758b569-1c41-4191-8330-81ded6354645"",
                    ""path"": ""<Keyboard>/#(A)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""52c3b89e-8d06-4c2b-b5f7-7cfbc6e1d114"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6e267712-b570-4841-8aad-e1c459245c3f"",
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
                    ""id"": ""a6c0e789-6b04-499b-9a94-c21c1ac11cee"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NormalAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bb8aca5-5157-44cd-ad97-bc2a9cb8b9f4"",
                    ""path"": ""<Keyboard>/leftAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49cc069d-ddad-403d-9b0a-f14714cfaa62"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d54ac745-82b5-4c68-ba96-ac62439ce62d"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""420d670c-d953-429c-adbf-7f8c29fc3a4c"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""386bc1dd-d93c-46a0-be23-451789e60fde"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f3a74d1-5cf3-48c0-a825-288f4c76eff0"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // gameplay
        m_gameplay = asset.FindActionMap("gameplay", throwIfNotFound: true);
        m_gameplay_Move = m_gameplay.FindAction("Move", throwIfNotFound: true);
        m_gameplay_Jump = m_gameplay.FindAction("Jump", throwIfNotFound: true);
        m_gameplay_NormalAttack = m_gameplay.FindAction("NormalAttack", throwIfNotFound: true);
        m_gameplay_Dash = m_gameplay.FindAction("Dash", throwIfNotFound: true);
        m_gameplay_Item1 = m_gameplay.FindAction("Item1", throwIfNotFound: true);
        m_gameplay_Item2 = m_gameplay.FindAction("Item2", throwIfNotFound: true);
        m_gameplay_Item3 = m_gameplay.FindAction("Item3", throwIfNotFound: true);
        m_gameplay_Item4 = m_gameplay.FindAction("Item4", throwIfNotFound: true);
        m_gameplay_Pause = m_gameplay.FindAction("Pause", throwIfNotFound: true);
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

    // gameplay
    private readonly InputActionMap m_gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_gameplay_Move;
    private readonly InputAction m_gameplay_Jump;
    private readonly InputAction m_gameplay_NormalAttack;
    private readonly InputAction m_gameplay_Dash;
    private readonly InputAction m_gameplay_Item1;
    private readonly InputAction m_gameplay_Item2;
    private readonly InputAction m_gameplay_Item3;
    private readonly InputAction m_gameplay_Item4;
    private readonly InputAction m_gameplay_Pause;
    public struct GameplayActions
    {
        private @Controls m_Wrapper;
        public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_gameplay_Move;
        public InputAction @Jump => m_Wrapper.m_gameplay_Jump;
        public InputAction @NormalAttack => m_Wrapper.m_gameplay_NormalAttack;
        public InputAction @Dash => m_Wrapper.m_gameplay_Dash;
        public InputAction @Item1 => m_Wrapper.m_gameplay_Item1;
        public InputAction @Item2 => m_Wrapper.m_gameplay_Item2;
        public InputAction @Item3 => m_Wrapper.m_gameplay_Item3;
        public InputAction @Item4 => m_Wrapper.m_gameplay_Item4;
        public InputAction @Pause => m_Wrapper.m_gameplay_Pause;
        public InputActionMap Get() { return m_Wrapper.m_gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @NormalAttack.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNormalAttack;
                @NormalAttack.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNormalAttack;
                @NormalAttack.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNormalAttack;
                @Dash.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Item1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnItem1;
                @Item1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnItem1;
                @Item1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnItem1;
                @Item2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnItem2;
                @Item2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnItem2;
                @Item2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnItem2;
                @Item3.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnItem3;
                @Item3.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnItem3;
                @Item3.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnItem3;
                @Item4.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnItem4;
                @Item4.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnItem4;
                @Item4.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnItem4;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @NormalAttack.started += instance.OnNormalAttack;
                @NormalAttack.performed += instance.OnNormalAttack;
                @NormalAttack.canceled += instance.OnNormalAttack;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Item1.started += instance.OnItem1;
                @Item1.performed += instance.OnItem1;
                @Item1.canceled += instance.OnItem1;
                @Item2.started += instance.OnItem2;
                @Item2.performed += instance.OnItem2;
                @Item2.canceled += instance.OnItem2;
                @Item3.started += instance.OnItem3;
                @Item3.performed += instance.OnItem3;
                @Item3.canceled += instance.OnItem3;
                @Item4.started += instance.OnItem4;
                @Item4.performed += instance.OnItem4;
                @Item4.canceled += instance.OnItem4;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GameplayActions @gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnNormalAttack(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnItem1(InputAction.CallbackContext context);
        void OnItem2(InputAction.CallbackContext context);
        void OnItem3(InputAction.CallbackContext context);
        void OnItem4(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
