using UnityEngine;
using UnityEngine.UIElements;

public class StopState : IReelState
{
    
    private ReelController reelController;
    private float scrollDistance;
    private int lastStepIndex = 0;

    public StopState(ReelController reelCtrl)
    {
        reelController = reelCtrl;
    }
    public void UpdateState()
    {
        float iconHeight = reelController.reel.resolvedStyle.height / (reelController.visibleIcons + 1);
        scrollDistance += reelController.spinSpeed * Time.deltaTime;
        reelController.spinOffset = (scrollDistance % iconHeight);
        MoveReel(reelController.spinOffset);

        int currentStep = Mathf.FloorToInt(scrollDistance / iconHeight);
        if (currentStep != lastStepIndex)
        {
            lastStepIndex = currentStep;
            UpdateIcons();
        }   
    }

    private void MoveReel(float offset)
    {
        reelController.reel.style.translate = new Translate(0, Length.Pixels(offset));
    }
    
    public void ToSpinState()
    {
        
    }
    
    public void ToStandbyState()
    {
        reelController.currentState = reelController.standbyState;    
        if(reelController.reelIndex == 4)
        {
            reelController.reelManager.isSpinning = false;
            
        }
    }

    public void ToStopState()
    {

    }

    private void UpdateIcons()
    {
        // funktio jossa iconi 1 -> 2 -> 3 -> 4 -> uusi iconi
        // tähän saa kans tehtyy sillee et se ottaa ne iconit blurratuista versioista
        //
        // icons indexi 1 saa olla se keskimmäisin joka luetaan

        reelController.currentIcon = (reelController.currentIcon + 1) % reelController.iconArray.Length;
        int nextIcon = (reelController.currentIcon + 2) % reelController.iconArray.Length;
        for (int i = 0; i < reelController.visibleIcons; i++)
        {
            reelController.icons[i].style.backgroundImage = reelController.icons[i + 1].style.backgroundImage;
        }

        //kammotus
        reelController.icons[reelController.visibleIcons].style.backgroundImage = Background.FromSprite(reelController.reelManager.sprites[reelController.iconArray[nextIcon]]);
        
        // katso onko seuraavan cyclin iconi reelController.result
        if (reelController.currentIcon == reelController.result)
        {
            ToStandbyState();
            MoveReel(0);
        } 
    }
}
