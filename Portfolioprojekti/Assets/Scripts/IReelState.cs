using UnityEngine;

public interface IReelState
{
    void UpdateState();
    
    void ToSpinState();
    
    void ToStandbyState();
    void ToStopState();
}
