using UnityEngine;
using UnityEngine.UIElements;

public class SpinState : IReelState
{
    private ReelController reelController;
    private float scrollDistance;
    private int lastStepIndex = 0;

    public SpinState(ReelController reelCtrl)
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

    public void ToSpinState()
    {
        
    }

    public void ToStandbyState()
    {

    }
    public void ToStopState()
    {
        reelController.currentState = reelController.stopState;
        scrollDistance = 0;
        lastStepIndex = 0;
    }

    private void MoveReel(float offset)
    {
        reelController.reel.style.translate = new Translate(0, Length.Pixels(offset));
    }

    private void UpdateIcons()
    {
        // funktio jossa iconi 1 -> 2 -> 3 -> 4 -> uusi iconi
        // tähän saa kans tehtyy sillee et se ottaa ne iconit blurratuista versioista
        //
        // icons indexi 1 saa olla se keskimmäisin joka luetaan

        reelController.currentIcon++;
        int nextIcon = (reelController.currentIcon + 2) % reelController.iconArray.Length;
        for (int i = 0; i < reelController.visibleIcons; i++)
        {
            reelController.icons[i].style.backgroundImage = reelController.icons[i + 1].style.backgroundImage;
        }

        //kammotus
        reelController.icons[reelController.visibleIcons].style.backgroundImage = Background.FromSprite(reelController.reelManager.sprites[reelController.iconArray[nextIcon]]);
        
        // katso onko seuraavan cyclin iconi reelController.result ja voiko pysähtyöä
        if ((reelController.currentIcon + 3) % reelController.iconArray.Length == reelController.result && CanReelStop(reelController.reelIndex))
        {
            ToStopState();
        } 
    }
    
    private bool CanReelStop(int reelIndex)
    {
        if(reelIndex == 0)
        {
            reelController.reelManager.reelSpinState[reelIndex] = false;
            return true;
        }
        for(int i = 0; i < reelIndex; i++)
        {
            if(reelController.reelManager.reelSpinState[i] == true)
            {
                return false;
            }
        }
        reelController.reelManager.reelSpinState[reelIndex] = false;
        return true;
    }
}
