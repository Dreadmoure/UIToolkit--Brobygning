using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GameWorldUIController : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int coins = 0;

    private Label _healthLabel;
    private Label _coinsLabel;
    
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
        _healthLabel = root.Q<Label>("livesLabel");
        _coinsLabel = root.Q<Label>("coinsLabel");
        
        Button takeDamageButton = root.Q<Button>("takeDamageButton");
        Button addCoinsButton = root.Q<Button>("addCoinsButton");
        
        UpdateUI();

        takeDamageButton.clicked += TakeDamage;
        addCoinsButton.clicked += AddCoins;
    }

    private void UpdateUI()
    {
        _healthLabel.text = health.ToString();
        _coinsLabel.text = coins.ToString();
    }

    private void TakeDamage()
    {
        health -= 10;
        UpdateUI();
    }
    
    private void AddCoins()
    {
        coins += 10;
        UpdateUI();
    }
}
