using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;


public class ReelController : MonoBehaviour
{
    public PanelRenderer m_panelRenderer;
    List<VisualElement> icons;

    public VisualTreeAsset icon;

    public string reelName;

    private VisualElement reel;

    public int[] iconArray = { };

    public float spinSpeed = 1.0f;
    [SerializeField] private float spinOffset;

    private void OnEnable()
    {
        m_panelRenderer = GameObject.Find("PanelRenderer").GetComponent<PanelRenderer>();
        m_panelRenderer.RegisterUIReloadCallback(OnUIReload);
    }

    private void OnDisable() => m_panelRenderer.UnregisterUIReloadCallback(OnUIReload);

    void OnUIReload(PanelRenderer pr, VisualElement root, int version)
    {
        reel = root.Q<VisualElement>(reelName).Q<VisualElement>("IconHolder");
        instantiateIcons();
        //big wins
    }

    void Update()
    {
        if (reel == null)
        {
            return;
        }
        spinOffset += reel.resolvedStyle.height * spinSpeed * Time.deltaTime;
        MoveReel(spinOffset);

        /*
        //käytä resolved style kun haluut jonkun asian renderöidyn koon
        if (spinOffset >= reel.resolvedStyle.height / 5) // icon holderin korkeus / iconien määrällä
        {
            icons = reel.Query<VisualElement>("Icon").ToList();
            Debug.Log(icons[0].resolvedStyle.backgroundImage);
            icons[0].BringToFront();
            spinOffset = 0;
        }
        */

        // tapahtuu kun reelit lopettavat pyörimisen

    }

    private void MoveReel(float offset)
    {
        reel.style.translate = new Translate(0, Length.Pixels(offset));
    }

    private void instantiateIcons()
    {
        foreach (int i in iconArray)
        {
            VisualElement instantiatedIcon = icon.Instantiate();
            reel.Add(instantiatedIcon);

        }

    }
}
