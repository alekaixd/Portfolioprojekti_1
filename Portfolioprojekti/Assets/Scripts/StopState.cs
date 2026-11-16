using UnityEngine;

public class StopState : IReelState
{
    
    private ReelController reelController;

    public StopState(ReelController reelCtrl)
    {
        reelController = reelCtrl;
    }
    public void UpdateState()
    {
        
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
}
