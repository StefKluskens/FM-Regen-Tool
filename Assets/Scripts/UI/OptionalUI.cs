using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
public class OptionalUI : UIScreen
{
    private static readonly Dictionary<Ethnicity, string> _ethnicityLabels = new()
    {
        { Ethnicity.Random, "Random" },
        { Ethnicity.NorthernEuropean, "Northern European" },
        { Ethnicity.MediterraneanHispanic, "Mediterranean / Hispanic" },
        { Ethnicity.NorthAfricanMiddleEastern, "North African / Middle Eastern" },
        { Ethnicity.AfricanCaribbean, "African / Caribbean" },
        { Ethnicity.Asian, "Asian" },
        { Ethnicity.SouthEastAsian, "South East Asian" },
        { Ethnicity.PacificIslander, "Pacific Islander" },
        { Ethnicity.NativeAmerican, "Native American" },
        { Ethnicity.NativeAustralian, "Native Australian" },
        { Ethnicity.MixedRaceWhiteBlack, "Mixed Race (White / Black)" },
        { Ethnicity.EastAsian, "East Asian" }
    };

    private static readonly Dictionary<Foot, string> _footLabels = new()
    {
        { Foot.RightOnly, "Right Only" },
        { Foot.LeftOnly, "Left Only" },
        { Foot.RightPreferred, "Right Preferred" },
        { Foot.LeftPreferred, "Left Preferred" },
        { Foot.Both, "Both" }
    };

    public static readonly Dictionary<Position, string> _positionLabels = new()
    {
        { Position.GOALKEEPER, "Goalkeeper" },
        { Position.DEFENDER_LEFT_SIDE, "Defender (Left Side)" },
        { Position.DEFENDER_RIGHT_SIDE, "Defender (Right Side)" },
        { Position.DEFENDER_CENTRAL, "Defender (Central)" },
        { Position.MIDFIELDER_LEFT_SIDE, "Midfielder (Left Side)" },
        { Position.MIDFIELDER_RIGHT_SIDE, "Midfielder (Right Side)" },
        { Position.MIDFIELDER_CENTRAL, "Midfielder (Central)" },
        { Position.ATTACKING_MIDFIELDER_LEFT_SIDE, "Attacking Midfielder (Left Side)" },
        { Position.ATTACKING_MIDFIELDER_RIGHT_SIDE, "Attacking Midfielder (Right Side)" },
        { Position.ATTACKING_MIDFIELDER_CENTRAL, "Attacking Midfielder (Central)" },
        { Position.ATTACKER_CENTRAL, "Attacker (Central)" }
    };

    public OptionalUI(VisualElement rootElement)
        : base(rootElement)
    {
        Initialize();
    }

    public override void Initialize()
    {
        InitEthnicityDropdown();
        InitFootDropdown();
        InitPositionDropdown();
    }

    private void InitEthnicityDropdown()
    {
        DropdownField ethnicityDropdown = Root.Q<DropdownField>("EthnicityInput");
        if (ethnicityDropdown == null)
        {
            Debug.LogError("Did not find Ethnicity dropdown field");
            return;
        }

        ethnicityDropdown.choices = _ethnicityLabels.Values.ToList();
        ethnicityDropdown.index = 0;
        ethnicityDropdown.RegisterValueChangedCallback(evt =>
        {
            Ethnicity selected = _ethnicityLabels.FirstOrDefault(x => x.Value == evt.newValue).Key;
        });
    }

    private void InitFootDropdown()
    {
        DropdownField footDropdown = Root.Q<DropdownField>("FootInput");
        if (footDropdown == null)
        {
            Debug.LogError("Did not find foot dropdown field");
            return;
        }

        footDropdown.choices = _footLabels.Values.ToList();
        footDropdown.index = 0;
        footDropdown.RegisterValueChangedCallback(evt =>
        {
            Foot selected = _footLabels.FirstOrDefault(x => x.Value == evt.newValue).Key;
        });
    }

    private void InitPositionDropdown()
    {
        DropdownField positionDropdown = Root.Q<DropdownField>("PositionInput");
        if (positionDropdown == null)
        {
            Debug.LogError("Did not find position dropdown field");
            return;
        }

        positionDropdown.choices = _positionLabels.Values.ToList();
        positionDropdown.index = 0;
        positionDropdown.RegisterValueChangedCallback(evt =>
        {
            Position selected = _positionLabels.FirstOrDefault(x => x.Value == evt.newValue).Key;
        });
    }
}
