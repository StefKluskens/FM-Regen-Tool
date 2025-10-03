using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Player")]
public class PlayerSO : ScriptableObject
{
    [Header("Required Info")]
    public string FirstName;
    public string LastName;
    public string BirthDate;
    public int SkinTone;
    public int ClubID;
    public int HairColour;

    [Header("Optional Info")]
    public string Nation;
    public string NickName;
    public int FavouriteClubID;
    public int Height;
    public int Weight;
    public int CurrentAbility;
    public int PotentialAbility;
    public int FavouriteNumber;
    public string BirthCity;
    public int Ethnicity;
    public int PreferredFoot;
    public int Position;

    public void ClearData()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        BirthDate = string.Empty;
        SkinTone = 0;
        ClubID = 0;
        HairColour = 0;

        Nation = string.Empty;
        NickName = string.Empty;
        FavouriteClubID = 0;
        Height = 0;
        Weight = 0;
        CurrentAbility = 0;
        PotentialAbility = 0;
        FavouriteNumber = 0;
        BirthCity = string.Empty;
        Ethnicity = 0;
        PreferredFoot = 0;
        Position = 0;
    }

    public string GetPlayerString()
    {
        int skinToneValue = SkinTone + 1;
        int ethnicityValue = Ethnicity - 1;

        Position pos = (Position)Position;
        string positionString = pos.ToString();

        List<string> parts = new List<string>
        {
            FirstName,
            NickName,
            LastName,
            BirthDate,
            Nation,
            FavouriteClubID.ToString(),
            ethnicityValue.ToString(),
            skinToneValue.ToString(),
            HairColour.ToString(),
            Height.ToString(),
            Weight.ToString(),
            PreferredFoot.ToString(),
            positionString,
            FavouriteNumber.ToString(),
            BirthCity,
            CurrentAbility.ToString(),
            PotentialAbility.ToString(),
            ClubID.ToString()
        };

        string playerString = string.Join(" ", parts.Select(p => $"\"{p}\""));

        return playerString;
    }

    public bool IsInputValid()
    {
        return FirstName != string.Empty
            && LastName != string.Empty
            && ClubID > 0;
    }
}

public enum HairColour
{
    Random,
    Blond,
    LightBrown,
    DarkBrown,
    Red,
    Black,
    Grey,
    Bald
}

public enum Ethnicity
{
    Random,
    NorthernEuropean,
    MediterraneanHispanic,
    NorthAfricanMiddleEastern,
    AfricanCaribbean,
    Asian,
    SouthEastAsian,
    PacificIslander,
    NativeAmerican,
    NativeAustralian,
    MixedRaceWhiteBlack,
    EastAsian
}

public enum Foot
{
    RightOnly,
    LeftOnly,
    RightPreferred,
    LeftPreferred,
    Both
}

public enum Position
{
    GOALKEEPER,
    DEFENDER_LEFT_SIDE,
    DEFENDER_RIGHT_SIDE,
    DEFENDER_CENTRAL,
    MIDFIELDER_LEFT_SIDE,
    MIDFIELDER_RIGHT_SIDE,
    MIDFIELDER_CENTRAL,
    ATTACKING_MIDFIELDER_LEFT_SIDE,
    ATTACKING_MIDFIELDER_RIGHT_SIDE,
    ATTACKING_MIDFIELDER_CENTRAL,
    ATTACKER_CENTRAL
}