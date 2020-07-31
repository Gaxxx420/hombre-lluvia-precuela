// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputMap : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""6717c4fe-73de-44c2-9602-d79c947230ab"",
            ""actions"": [
                {
                    ""name"": ""HorAxis"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9203c195-ece6-4f57-9461-d33053fd8e77"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""VerAxis"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f3ca92b1-5a98-4f68-9287-1d2a95f1262d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""6ade2ce2-9ef5-4c87-a05e-9f4bfeaabe3c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Edit"",
                    ""type"": ""Button"",
                    ""id"": ""47347d40-646b-4f31-9fb8-094fbcffc5aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""4aa92bd0-ba4f-436f-a8ec-f2fa2ac1dd9d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Warp"",
                    ""type"": ""Button"",
                    ""id"": ""bd3aab57-085e-41d2-928d-a231d245a2a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrows"",
                    ""id"": ""35b5ffc2-1c7e-48f5-9587-2ab7d8ff8896"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""04c626cd-06cc-480d-bf55-fb42aea8d613"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9d52a0cb-61ba-40ce-a2b7-16c145a195d2"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f097a6d7-4edc-45d8-a66c-6aab20fd7228"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc52234e-e265-4ee8-bf37-2734691d918b"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Edit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69e4e5dd-cb79-4f57-9087-71f4eb3f9898"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""b102f152-7063-49fc-8874-19bc846def74"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""72ad4e02-9f94-4e49-93f0-7c75ac171747"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0e617f1c-73ab-4988-9409-b7ccb6146d98"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f4a3b49c-8913-4882-8c71-e420bfe15fb1"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Warp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""c02e6323-8f46-4bbc-b5f6-ffa507d44db8"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""cf2bcf81-f0bf-4f06-a48d-8ab3f790b84f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""ff443a80-4ad0-413d-9d59-17ffb5546fcd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""d2fbfdca-65dd-4708-8443-c22ebe44b55d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""32a41841-93b1-4717-a08c-32667cbdeaca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""be41838b-0b24-4cb5-9579-6f2bfeb5348f"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b1e63a8-bffa-418d-82a3-28958af9b18f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8abd4b13-9413-4af7-8fbf-69656645eae1"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1a31ad7-3382-4ac4-9099-d69e5695124e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d4fd115-e5bf-43b8-a94f-72b135556577"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42ca57c9-7530-4d42-b182-b5db47e8da62"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b36a2e2-f8ae-444b-a9f4-dcd1495317b2"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d70f164-23d6-420c-9521-0233f211963b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b11ec3d4-a460-4137-83d3-aa231a96a3cd"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c03b2556-3ab4-4d93-a6b2-d932f88599a0"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51c05f47-6ada-43d3-907f-d6e853440157"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc534f5d-e70e-4500-8500-36203e0cc000"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_HorAxis = m_Main.FindAction("HorAxis", throwIfNotFound: true);
        m_Main_VerAxis = m_Main.FindAction("VerAxis", throwIfNotFound: true);
        m_Main_Jump = m_Main.FindAction("Jump", throwIfNotFound: true);
        m_Main_Edit = m_Main.FindAction("Edit", throwIfNotFound: true);
        m_Main_Dash = m_Main.FindAction("Dash", throwIfNotFound: true);
        m_Main_Warp = m_Main.FindAction("Warp", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Up = m_Menu.FindAction("Up", throwIfNotFound: true);
        m_Menu_Down = m_Menu.FindAction("Down", throwIfNotFound: true);
        m_Menu_Left = m_Menu.FindAction("Left", throwIfNotFound: true);
        m_Menu_Right = m_Menu.FindAction("Right", throwIfNotFound: true);
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

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_HorAxis;
    private readonly InputAction m_Main_VerAxis;
    private readonly InputAction m_Main_Jump;
    private readonly InputAction m_Main_Edit;
    private readonly InputAction m_Main_Dash;
    private readonly InputAction m_Main_Warp;
    public struct MainActions
    {
        private @PlayerInputMap m_Wrapper;
        public MainActions(@PlayerInputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @HorAxis => m_Wrapper.m_Main_HorAxis;
        public InputAction @VerAxis => m_Wrapper.m_Main_VerAxis;
        public InputAction @Jump => m_Wrapper.m_Main_Jump;
        public InputAction @Edit => m_Wrapper.m_Main_Edit;
        public InputAction @Dash => m_Wrapper.m_Main_Dash;
        public InputAction @Warp => m_Wrapper.m_Main_Warp;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @HorAxis.started -= m_Wrapper.m_MainActionsCallbackInterface.OnHorAxis;
                @HorAxis.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnHorAxis;
                @HorAxis.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnHorAxis;
                @VerAxis.started -= m_Wrapper.m_MainActionsCallbackInterface.OnVerAxis;
                @VerAxis.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnVerAxis;
                @VerAxis.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnVerAxis;
                @Jump.started -= m_Wrapper.m_MainActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnJump;
                @Edit.started -= m_Wrapper.m_MainActionsCallbackInterface.OnEdit;
                @Edit.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnEdit;
                @Edit.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnEdit;
                @Dash.started -= m_Wrapper.m_MainActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnDash;
                @Warp.started -= m_Wrapper.m_MainActionsCallbackInterface.OnWarp;
                @Warp.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnWarp;
                @Warp.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnWarp;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HorAxis.started += instance.OnHorAxis;
                @HorAxis.performed += instance.OnHorAxis;
                @HorAxis.canceled += instance.OnHorAxis;
                @VerAxis.started += instance.OnVerAxis;
                @VerAxis.performed += instance.OnVerAxis;
                @VerAxis.canceled += instance.OnVerAxis;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Edit.started += instance.OnEdit;
                @Edit.performed += instance.OnEdit;
                @Edit.canceled += instance.OnEdit;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Warp.started += instance.OnWarp;
                @Warp.performed += instance.OnWarp;
                @Warp.canceled += instance.OnWarp;
            }
        }
    }
    public MainActions @Main => new MainActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Up;
    private readonly InputAction m_Menu_Down;
    private readonly InputAction m_Menu_Left;
    private readonly InputAction m_Menu_Right;
    public struct MenuActions
    {
        private @PlayerInputMap m_Wrapper;
        public MenuActions(@PlayerInputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_Menu_Up;
        public InputAction @Down => m_Wrapper.m_Menu_Down;
        public InputAction @Left => m_Wrapper.m_Menu_Left;
        public InputAction @Right => m_Wrapper.m_Menu_Right;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnDown;
                @Left.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnRight;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    public interface IMainActions
    {
        void OnHorAxis(InputAction.CallbackContext context);
        void OnVerAxis(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnEdit(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnWarp(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
}
