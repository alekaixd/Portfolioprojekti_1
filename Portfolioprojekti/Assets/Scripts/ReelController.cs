using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;


public class ReelController : MonoBehaviour
{
    public PanelRenderer m_panelRenderer;
    public List<VisualElement> icons;

    [HideInInspector] public IReelState currentState;
    [HideInInspector] public StandbyState standbyState;
    [HideInInspector] public SpinState spinState;
    [HideInInspector] public StopState stopState;

    public VisualTreeAsset icon;

    public int reelIndex;

    public VisualElement reel;

    public int[] iconArray = { };
    
    private ReelManager reelManager;

    [HideInInspector] public float spinSpeed = 1.0f;
    [HideInInspector] public float spinOffset;
    
    public int result;

    void Awake()
    {
        standbyState = new StandbyState(this);
        spinState = new SpinState(this);
        stopState = new StopState(this);
        
        reelManager = GameObject.Find("PanelRenderer").GetComponent<ReelManager>();
    }

    private void OnEnable()
    {
        m_panelRenderer = GameObject.Find("PanelRenderer").GetComponent<PanelRenderer>();
        m_panelRenderer.RegisterUIReloadCallback(OnUIReload);
        currentState = standbyState;
    }

    private void OnDisable() => m_panelRenderer.UnregisterUIReloadCallback(OnUIReload);

    void OnUIReload(PanelRenderer pr, VisualElement root, int version)
    {
        reel = root.Q<VisualElement>(AppConstants.UIReelNames[reelIndex]).Q<VisualElement>("IconHolder");
        instantiateIcons();
        //big wins
    }

    void Update()
    {
        if (reel == null)
        {
            return;
        }
        currentState.UpdateState();

        /*
        //käytä resolved style kun haluut jonkun asian renderöidyn koon
        if (spinOffset >= reel.resolvedStyle.height / 2) // icon holderin korkeus / iconien määrällä
        {
            icons = reel.Query<VisualElement>("Icon").ToList();
            Debug.Log(icons[0].resolvedStyle.backgroundImage);
            icons[0].BringToFront();
            spinOffset = 0;
        }
        */

        // tapahtuu kun reelit lopettavat pyörimisen

    }

    private void instantiateIcons()
    {
        foreach (int i in iconArray)
        {
            VisualElement instantiatedIcon = icon.Instantiate();
            instantiatedIcon.style.backgroundImage = Background.FromSprite(reelManager.sprites[i]); 
            reel.Add(instantiatedIcon);
        }

    }
}
