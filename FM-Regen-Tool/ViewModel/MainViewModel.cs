using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FM_Regen_Tool.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FM_Regen_Tool.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public RequiredPage RequiredPage { get; } = new RequiredPage();
        public OptionalPage OptionalPage { get; } = new OptionalPage();

        public Page CurrentPage { get; set; }
        public RelayCommand SwitchPageCommand { get; private set; }

        public string ButtonContent { get; set;}

        public MainViewModel()
        {
            CurrentPage = RequiredPage;
            ButtonContent = "Switch to Optional Page";

            SwitchPageCommand = new RelayCommand(SwitchPage);
        }

        public void SwitchPage()
        {
            if (CurrentPage is RequiredPage)
            {
                CurrentPage = OptionalPage;
                ButtonContent = "Switch to Required Page";
            }
            else
            {
                CurrentPage = RequiredPage;
                ButtonContent = "Switch to Optional Page";
            }

            OnPropertyChanged(nameof(CurrentPage));
            OnPropertyChanged(nameof(ButtonContent));
        }
    }
}
