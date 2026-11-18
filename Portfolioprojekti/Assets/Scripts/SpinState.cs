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
        if (reelController.spinOffset >= reelController.reel.resolvedStyle.height / reelController.iconArray.Length) // icon holderin korkeus / iconien määrällä
        {
            reelController.icons = reelController.reel.Query<VisualElement>("Icon").ToList();
            reelController.icons[0].BringToFront();
            Debug.Log(reelController.icons[0]);
            /*
            for(int i = 0; i < reelController.iconArray.Length / 2; i++)
            {
                reelController.icons[i].BringToFront();
            }
            */

            // reelController.spinOffset -= reelController.reel.resolvedStyle.height/2;
            // reelController.spinOffset = 0 + reelController.reel.resolvedStyle.height * reelController.spinSpeed * Time.deltaTime;
            reelController.spinOffset = 0;
                
        }
    }
    
   
}
