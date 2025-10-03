using SFB;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class RegenAppUI : MonoBehaviour
{
    private UIDocument _regenUI;

    private RequiredUI _requiredUI;
    private OptionalUI _optionalUI;

    [SerializeField] private PlayerSO _playerSO;

    private List<PlayerItem> _playerItems = new();

    [SerializeField] private VisualTreeAsset _playerItemUI;
    private Tab _playerListTab;

    private void Awake()
    {
        _regenUI = GetComponent<UIDocument>();

        _requiredUI = new RequiredUI(_regenUI.rootVisualElement.Q<VisualElement>("RequiredInfoTemplate"));
        _optionalUI = new OptionalUI(_regenUI.rootVisualElement.Q<VisualElement>("OptionalInfoTemplate"));

        _playerListTab = _regenUI.rootVisualElement.Q<Tab>("PlayerListTab");

        RegisterButtonClickEvents();

        _playerSO.ClearData();
    }

    private void OnDestroy()
    {
        _playerSO.ClearData();
    }

    private void RegisterButtonClickEvents()
    {
        Button createPlayerButton = _regenUI.rootVisualElement.Q<Button>("CreatePlayerButton");
        createPlayerButton.RegisterCallback<ClickEvent>(OnCreateButtonClicked);

        Button exportFileButton = _regenUI.rootVisualElement.Q<Button>("ExportFileButton");
        exportFileButton.RegisterCallback<ClickEvent>(OnExportFileButtonClicked);
    }

    private void OnCreateButtonClicked(ClickEvent evt)
    {
        if (!_playerSO.IsInputValid())
        {
            //TODO Give warning to user that input was invalid
            return;
        }

        //_playerSO.BirthDate = _requiredUI.DateOfBirth;

        VisualElement element = new();
        element.dataSource = _playerSO;
        _playerItemUI.CloneTree(element);
        _playerListTab.Add(element);

        string playerData = _playerSO.GetPlayerString();

        PlayerItem player = new PlayerItem(element, playerData);
        _playerItems.Add(player);
        player.DeleteAction.AddListener(DeletePlayer);

        _playerSO.ClearData();
        _requiredUI.ResetDateOfBirth();
    }

    private void OnExportFileButtonClicked(ClickEvent evt)
    {
        /*
         * For each player created
         * "DETAILED_FUTURE_REGEN" + player line
         * 
         * Save as support_staff.edt
         */

        string savePath = GetSavePath();        
        foreach (PlayerItem player in _playerItems)
        {
            string line = "\"DETAILED_FUTURE_REGEN\" ";
            line += player.PlayerData;
            line += '\n';

            File.WriteAllText(savePath, line);
        }
    }

    private string GetSavePath()
    {
        ExtensionFilter[] extensionList = new[]
        {
            new ExtensionFilter("Editor", "edt")
        };
        return StandaloneFileBrowser.SaveFilePanel("Save File", "", "support_staff", extensionList);
    }

    private void DeletePlayer(PlayerItem player)
    {
        _playerListTab.Remove(player.Root);
        _playerItems.Remove(player);
    }
}
