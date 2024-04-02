using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FM_Regen_Tool.Model;
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
        public RelayCommand NewPlayerCommand { get; private set; }
        public RelayCommand SavePlayerCommand { get; private set; }
        public RelayCommand ExportFileCommand { get; private set; }

        public string ButtonContent { get; set;}

        private Player _player = new Player();

        public MainViewModel()
        {
            CurrentPage = RequiredPage;
            ButtonContent = "Switch to Optional Page";

            SwitchPageCommand = new RelayCommand(SwitchPage);

            NewPlayerCommand = new RelayCommand(NewPlayer);
            SavePlayerCommand = new RelayCommand(SavePlayer);
            ExportFileCommand = new RelayCommand(ExportFile);
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

        public void NewPlayer()
        {
            RequiredVM.NewPlayer(_player);
            OptionalVM.NewPlayer(_player);
        }

        public void SavePlayer()
        {
            RequiredVM.SavePlayer();
            OptionalVM.SavePlayer();
        }

        public void ExportFile()
        {
            RequiredVM.ExportFile();
            OptionalVM.ExportFile();
        }
    }
}
