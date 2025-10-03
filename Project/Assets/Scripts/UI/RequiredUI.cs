using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class RequiredUI : UIScreen
{
    public string DateOfBirth => _dateOfBirth.GetDateAsString();

    private static readonly Dictionary<HairColour, string> _hairLabels = new()
    {
        { HairColour.Random, "Random" },
        { HairColour.Blond, "Blond" },
        { HairColour.LightBrown, "Light Brown" },
        { HairColour.DarkBrown, "Dark Brown" },
        { HairColour.Red, "Red" },
        { HairColour.Black, "Black" },
        { HairColour.Grey, "Grey" },
        { HairColour.Bald, "Bald" },
    };

    private DateOfBirthElement _dateOfBirth;

    public RequiredUI(VisualElement rootElement)
        : base(rootElement)
    {
        Initialize();
    }

    public override void Initialize()
    {
        _dateOfBirth = Root.Q<DateOfBirthElement>("DateOfBirthInput");

        InitSkinToneDropdown();
        InitHairColourDropdown();
    }

    private void InitSkinToneDropdown()
    {
        DropdownField skinToneDropdown = Root.Q<DropdownField>("SkinToneInput");
        if (skinToneDropdown == null) 
        {
            Debug.LogError("Did not find skin tone dropdown field");
            return;
        }

        for (int i = 1; i < 21; i++)
        {
            skinToneDropdown.choices.Add(i.ToString());
        }
        skinToneDropdown.index = 0;
    }

    private void InitHairColourDropdown()
    {
        DropdownField hairColourDropdown = Root.Q<DropdownField>("HairColourInput");
        if (hairColourDropdown == null)
        {
            Debug.LogError("Did not find hair colour dropdown field");
            return;
        }

        hairColourDropdown.choices = _hairLabels.Values.ToList();
        hairColourDropdown.index = 0;
        hairColourDropdown.RegisterValueChangedCallback(evt =>
        {
            HairColour selected = _hairLabels.FirstOrDefault(x => x.Value == evt.newValue).Key;
        });
    }

    public void ResetDateOfBirth()
    {
        _dateOfBirth.ResetDateOfBirth();
    }
}
