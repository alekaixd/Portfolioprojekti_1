using UnityEngine;
using UnityEngine.UIElements;

public class SpinState : IReelState
{
    private ReelController reelController;

    public SpinState(ReelController reelCtrl)
    {
        reelController = reelCtrl;
    }
    public void UpdateState()
    {
        reelController.spinOffset += reelController.reel.resolvedStyle.height * reelController.spinSpeed * Time.deltaTime;
        MoveReel(reelController.spinOffset);
    }
    
    public void ToSpinState()
    {
        
    }
    
    public void ToStandbyState()
    {
        
    }
    public void ToStopState()
    {
        
    }

    private void MoveReel(float offset)
    {
        reelController.reel.style.translate = new Translate(0, Length.Pixels(offset));
    }
   
}
