using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using UnityEngine.Windows;

[System.Serializable]
public class PlayerItem : UIScreen
{
    private string _fullPlayerData;
    public string PlayerData => _fullPlayerData;
    public UnityEvent<PlayerItem> DeleteAction = new UnityEvent<PlayerItem>();

    public PlayerItem(VisualElement rootElement, string playerData)
        : base(rootElement)
    {
        _fullPlayerData = playerData;
        Initialize();
        RegisterButtonClicks();
    }

    public override void Initialize()
    {
        string[] parts = _fullPlayerData
        .Split('"')
        .Select(s => s.Trim())
        .Where((s, i) => i % 2 != 0)
        .ToArray();

        Label firstNameLabel = Root.Q<Label>("FirstNameLabel");
        firstNameLabel.text = parts[0];

        Label lastNameLabel = Root.Q<Label>("LastNameLabel");
        lastNameLabel.text = parts[2];
    }

    private void RegisterButtonClicks()
    {
        VisualElement namesHolder = Root.Q<VisualElement>("NamesHolder");
        namesHolder.RegisterCallback<ClickEvent>((evt) =>
        {
            FillInPlayerObject();
        });

        VisualElement deleteButton = Root.Q<VisualElement>("DeleteButton");
        deleteButton.RegisterCallback<ClickEvent>((evt) =>
        {
            DeleteAction?.Invoke(this);
        });
    }

    private void FillInPlayerObject()
    {
        TabView tabView = Root.parent.parent as TabView;
        if (tabView != null)
        {
            tabView.selectedTabIndex = 0;
        }

        PlayerSO player = Root.dataSource as PlayerSO;

        string[] parts = _fullPlayerData
        .Split('"')
        .Select(s => s.Trim())
        .Where((s, i) => i % 2 != 0)
        .ToArray();

        player.FirstName = parts[0];
        player.NickName = parts[1];
        player.LastName = parts[2];
        player.BirthDate = parts[3];
        player.Nation = parts[4];
        player.FavouriteClubID = int.Parse(parts[5]);
        player.Ethnicity = int.Parse(parts[6]) + 1;
        player.SkinTone = int.Parse(parts[7]) - 1;
        player.HairColour = int.Parse(parts[8]);
        player.Height = int.Parse(parts[9]);
        player.Weight = int.Parse(parts[10]);
        player.PreferredFoot = int.Parse(parts[11]);

        string playerPositionString = parts[12];
        player.Position = (int)Enum.Parse(typeof(Position), playerPositionString);

        player.FavouriteNumber = int.Parse(parts[13]);
        player.BirthCity = parts[14];
        player.CurrentAbility = int.Parse(parts[15]);
        player.PotentialAbility = int.Parse(parts[16]);
        player.ClubID = int.Parse(parts[17]);
    }
}
