using System;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

[UxmlElement]
public partial class DateOfBirthElement : VisualElement
{
    private Label _elementLabel;

    private VisualElement _dropdownHolder;
    private DropdownField _daySelector;
    private DropdownField _monthSelector;
    private DropdownField _yearSelector;

    private Label _dateTextHolder;

    private PlayerSO _playerSo;

    public DateOfBirthElement() 
    {
        _playerSo = Resources.Load("PlayerHolder") as PlayerSO;

        _elementLabel = new Label("Date of Birth");
        _elementLabel.name = "DateOfBirthLabel";
        Add(_elementLabel);

        _dropdownHolder = new VisualElement();
        _dropdownHolder.name = "DateDropdowns";
        Add(_dropdownHolder);

        style.flexDirection = FlexDirection.Row;

        _dropdownHolder.style.flexDirection = FlexDirection.Row;
        _dropdownHolder.AddToClassList("dob-holder");

        _daySelector = new DropdownField();
        _daySelector.name = "DaySelector";
        _dropdownHolder.Add(_daySelector);

        _monthSelector = new DropdownField();
        _monthSelector.name = "MonthSelector";
        FillMonthDropdown();
        _dropdownHolder.Add(_monthSelector);

        _yearSelector = new DropdownField();
        _yearSelector.name = "YearSelector";
        FillYearDropdown();
        _dropdownHolder.Add(_yearSelector);

        _monthSelector.RegisterValueChangedCallback(evt => UpdateDays());
        _yearSelector.RegisterValueChangedCallback(evt => UpdateDays());

        UpdateDays();

        _dateTextHolder = new Label("dd/mm/yyyy");
        _dateTextHolder.name = "DateHolder";
        Add(_dateTextHolder);
        _dateTextHolder.SetBinding(
            "text",
            new DataBinding
            {
                dataSource = _playerSo,
                dataSourcePath = PropertyPath.FromName("BirthDate"), // name of property in the bound object
                bindingMode = BindingMode.TwoWay
            });

        _dateTextHolder.RegisterValueChangedCallback(evt =>
        {
            UpdateDropdownsFromDate(evt.newValue);
        });
        _dateTextHolder.style.display = DisplayStyle.None;

        _daySelector.RegisterValueChangedCallback(_ => PushDateBack());
        _monthSelector.RegisterValueChangedCallback(_ => PushDateBack());
        _yearSelector.RegisterValueChangedCallback(_ => PushDateBack());
        PushDateBack();

        AddToClassList("dob-row");
    }

    private void PushDateBack()
    {
        _dateTextHolder.text = $"{_daySelector.text}/{_monthSelector.text}/{_yearSelector.text}";
    }

    private void UpdateDropdownsFromDate(string date)
    {
        if (string.IsNullOrEmpty(date))
        { 
            return;
        }

        var parts = date.Split('/');
        if (parts.Length != 3)
        {
            return;
        }

        if (int.TryParse(parts[0], out int day))
        {
            _daySelector.index = day - 1;
        }

        if (int.TryParse(parts[1], out int month))
        {
            _monthSelector.index = month - 1;
        }

        if (int.TryParse(parts[2], out int year))
        {
            _yearSelector.index = year - 2008;
        }
    }

    private void UpdateDays()
    {
        int month = int.Parse(_monthSelector.text);
        int year = int.Parse(_yearSelector.text);

        int daysInMonth = DateTime.DaysInMonth(year, month);

        List<string> newDays = new();
        for (int i = 1; i <= daysInMonth; i++)
        {
            newDays.Add(i.ToString());
        }

        string previousDay = _daySelector.value;

        _daySelector.choices = newDays;

        if (previousDay != null && newDays.Contains(previousDay))
        {
            _daySelector.value = previousDay;
        }
        else
        { 
            _daySelector.value = newDays[0];
        }
    }

    private void FillMonthDropdown()
    {
        _monthSelector.choices = new List<string>();

        for (int i = 1; i < 13; i++)
        {
            _monthSelector.choices.Add(i.ToString());
        }

        _monthSelector.index = 0;
    }

    private void FillYearDropdown()
    {
        _yearSelector.choices = new List<string>();

        for (int i = 2008; i < 2100; i++)
        {
            _yearSelector.choices.Add(i.ToString());
        }

        _yearSelector.index = 0;
    }

    public string GetDateAsString()
    {
        string dateString = _daySelector.text + '/' + _monthSelector.text + '/' + _yearSelector.text;
        return dateString;
    }

    public void ResetDateOfBirth()
    {
        _daySelector.index = 0;
        _monthSelector.index = 0;
        _yearSelector.index = 0;
    }
}
