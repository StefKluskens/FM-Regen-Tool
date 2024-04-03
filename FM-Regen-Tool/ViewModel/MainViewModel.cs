using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FM_Regen_Tool.Model;
using FM_Regen_Tool.View;
using System.Diagnostics;
using System.Windows.Controls;
using System.IO;

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

        private List<Player> _players = new List<Player>();

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
            (RequiredPage.DataContext as RequiredVM)?.NewPlayer();
            (OptionalPage.DataContext as OptionalVM)?.NewPlayer();
        }

        public void SavePlayer()
        {
            Player player = new Player();

            (RequiredPage.DataContext as RequiredVM)?.SavePlayer(player);
            (OptionalPage.DataContext as OptionalVM)?.SavePlayer(player);

            _players.Add(player);
        }

        public void ExportFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog.Title = "Save File";
            saveFileDialog.DefaultExt = "edt";
            saveFileDialog.Filter = "EDT files (*.edt)|*.edt";
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = File.CreateText(saveFileDialog.FileName))

                foreach (Player player in _players)
                {
                    Debug.WriteLine(player.GetPlayerString());
                    sw.WriteLine(player.GetPlayerString());
                }
            }
        }
    }
}
