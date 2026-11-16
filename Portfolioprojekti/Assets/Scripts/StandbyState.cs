using UnityEngine;

public class StandbyState : IReelState
{
    private ReelController reelController;

    public StandbyState(ReelController reelCtrl)
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
