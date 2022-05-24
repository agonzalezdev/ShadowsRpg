using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Stats")]
    [SerializeField] private CharacterStats stats;

    [Header("Panels")]
    [SerializeField] private GameObject statsPanel;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject inspectorQuestsPanel;
    [SerializeField] private GameObject characterQuestsPanel;

    [Header("Bars")]
    [SerializeField] private Image characterHP;
    [SerializeField] private Image characterMana;
    [SerializeField] private Image characterExp;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI textHP;
    [SerializeField] private TextMeshProUGUI textMana;
    [SerializeField] private TextMeshProUGUI textExp;
    [SerializeField] private TextMeshProUGUI textLevel;

    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI statDmg;
    [SerializeField] private TextMeshProUGUI statDefense;
    [SerializeField] private TextMeshProUGUI statSpeed;
    [SerializeField] private TextMeshProUGUI statCritical;
    [SerializeField] private TextMeshProUGUI statBlock;
    [SerializeField] private TextMeshProUGUI statLevel;
    [SerializeField] private TextMeshProUGUI statExp;
    [SerializeField] private TextMeshProUGUI statRequiredExpToNextLevel;

    [Header("Attributes")]
    [SerializeField] private TextMeshProUGUI attrStr;
    [SerializeField] private TextMeshProUGUI attrInt;
    [SerializeField] private TextMeshProUGUI attrDex;
    [SerializeField] private TextMeshProUGUI attrAvailableAttributePoints;


    private float currentHP;
    private float maxHP;

    private float currentMana;
    private float maxMana;

    private float currentExp;
    private float requiredExpToNewLevel;

    void Update()
    {
        UpdatePlayerUI();
        UpdateStatsPanel();
    }

    private void UpdatePlayerUI()
    {
        characterHP.fillAmount = Mathf.Lerp(
            characterHP.fillAmount,
            currentHP / maxHP,
            10f * Time.deltaTime
        );

        characterMana.fillAmount = Mathf.Lerp(
            characterMana.fillAmount,
            currentMana / maxMana,
            10f * Time.deltaTime
        );

        characterExp.fillAmount = Mathf.Lerp(
            characterExp.fillAmount,
            currentExp / requiredExpToNewLevel,
            10f * Time.deltaTime
        );

        textHP.text = $"{currentHP} / {maxHP}";
        textMana.text = $"{currentMana} / {maxMana}";
        textExp.text = $"{currentExp} / {requiredExpToNewLevel} ({((currentExp/requiredExpToNewLevel) * 100):F1}%)";
        textLevel.text = $"Level {stats.Level}";
    }

    public void UpdateStatsPanel()
    {
        if (!statsPanel.activeSelf)
            return;

        statDmg.text = stats.Dmg.ToString();
        statDefense.text = stats.Defense.ToString();
        statSpeed.text = $"{stats.Speed:F1}%";
        statCritical.text = $"{stats.CriticalChance:F1}%";
        statBlock.text = $"{stats.BlockChance}%";
        statLevel.text = stats.Level.ToString();
        statExp.text = stats.CurrentExp.ToString();
        statRequiredExpToNextLevel.text = stats.RequiredExpToNextLevel.ToString();

        attrStr.text = stats.Strenght.ToString();
        attrInt.text = stats.Intelligence.ToString();
        attrDex.text = stats.Dexterity.ToString();
        attrAvailableAttributePoints.text = $"Points {stats.AvailableAttributePoints}";
    }



    public void UpdateCharacterHP(float currentHP, float maxHP)
    {
        this.currentHP = currentHP;
        this.maxHP = maxHP;
    }

    public void UpdateCharacterMana(float currentMana, float maxMana)
    {
        this.currentMana = currentMana;
        this.maxMana = maxMana;
    }

    public void UpdateCharacterExp(float currentExp, float requiredExp)
    {
        this.currentExp = currentExp;
        this.requiredExpToNewLevel = requiredExp;
    }

    #region Panels

    public void TriggerStatsPanel()
    {
        statsPanel.SetActive(!statsPanel.activeSelf);
    }

    public void TriggerInventoryPanel()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    public void TriggerInspectorQuestsPanel()
    {
        inspectorQuestsPanel.SetActive(!inspectorQuestsPanel.activeSelf);
    }

    public void TriggerCharacterQuestsPanel()
    {
        characterQuestsPanel.SetActive(!characterQuestsPanel.activeSelf);
    }

    public void OpenInteracionPanel(NPCInteractionType nPCInteractionType)
    {
        switch (nPCInteractionType)
        {
            case NPCInteractionType.Dialog:
                break;
            case NPCInteractionType.OpenQuests:
                TriggerInspectorQuestsPanel();
                break;
            case NPCInteractionType.OpenStore:
                break;
            case NPCInteractionType.OpenCrafting:
                break;
            default:
                break;
        }
    }

    #endregion
}
