using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class ReelManager : MonoBehaviour
{
    public Sprite[] sprites;
    public List<ReelController> reels;

    public SlotMachine slotMachine;

    public InputActionAsset inputActions;
    private InputAction spinAction;
    private InputAction testAction;

    [SerializeField] private float spinSpeed;

    public bool isSpinning = false;
    public bool[] reelSpinState = new bool[5];

    void Awake()
    {
        Unsubscribe();
        spinAction = inputActions.FindActionMap("SlotMachine").FindAction("Spin");
        testAction = inputActions.FindActionMap("SlotMachine").FindAction("Test");
        spinAction.performed += OnSpin;
        testAction.performed += Test;
    }

    private void Unsubscribe()
    {
        if (spinAction != null) spinAction.performed -= OnSpin;
        if (testAction != null) spinAction.performed -= Test;
    }

    void Start()
    {
        slotMachine = new SlotMachine();

        int i = 0;
        foreach (ReelController reel in reels)
        {
            reel.iconArray = AppConstants.reelArrays[i];
            reel.spinSpeed = spinSpeed;
            reel.reelIndex = i;
            i++;
        }

    }

    public void OnSpin(InputAction.CallbackContext context)
    {
        if (!isSpinning)
        {
            isSpinning = true;

            int[] resultArr = slotMachine.SpinReels();
            int i = 0;
            foreach (ReelController reel in reels)
            {
                reel.currentState = reel.spinState;
                reel.result = resultArr[i];
                reelSpinState[i] = true;
                i++;
                //Debug.Log(reel.result);
            }
        }
    }

    public void Test(InputAction.CallbackContext context)
    {
        if (!isSpinning)
        {
            isSpinning = true;

            int[] resultArr = slotMachine.ForceWin(6, 3, AppConstants.paylines[5]);
            int i = 0;
            foreach (ReelController reel in reels)
            {
                reel.currentState = reel.spinState;
                reel.result = resultArr[i];
                reelSpinState[i] = true;
                i++;
                //Debug.Log(reel.result);
            }
        }
    }
}
