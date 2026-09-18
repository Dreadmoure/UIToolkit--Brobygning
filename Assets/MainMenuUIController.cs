using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuUIController : MonoBehaviour
{
    private void OnEnable()
    {
        PanelRenderer panelRenderer = GetComponent<PanelRenderer>();
        
        panelRenderer.RegisterUIReloadCallback(OnUIReload);
    }
    
    private void OnDisable()
    {
        PanelRenderer panelRenderer = GetComponent<PanelRenderer>();
        
        panelRenderer.UnregisterUIReloadCallback(OnUIReload);
    }

    private void OnUIReload(PanelRenderer renderer, VisualElement root, int version)
    {
        VisualElement rootUI = root;

        Button playButton = rootUI.Q<Button>("playButton");

        playButton.clicked += PlayGame;
    }

    private void PlayGame()
    {
        Debug.Log("Starting game!");
    }
}
