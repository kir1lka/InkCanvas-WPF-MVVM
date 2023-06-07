using Laba10.Commands;
using Laba10.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;

namespace Laba10.ViewModels
{
    internal class MainWinodwViewModel : ViemModel
    {
        ///////////////////////////////////
        ///Field

        #region StatusBarLable

        private string _statusBarLable = "...";

        public string StatusBarLable
        {
            get => _statusBarLable;
            set => Set(ref _statusBarLable, value);
        }

        #endregion       

        #region ValueSlider

        private double _valueSlider = 1;

        public double ValueSlider
        {
            get => _valueSlider;
            set
            {
                if (EditModeInkCanvas != null)
                {
                    var newSize = value;

                    DrawingAttributesInkCanvas.Width = newSize;
                    DrawingAttributesInkCanvas.Height = newSize;

                }

                StatusBarLable = $"Размер кисти: {value}";

                Set(ref _valueSlider, value);
            }
        }

        #endregion

        ///InkCanvas

        #region InkCanvasBackground

        private SolidColorBrush _inkCanvaskBackground;

        public SolidColorBrush InkCanvasBackground
        {
            get => _inkCanvaskBackground;
            set => Set(ref _inkCanvaskBackground, value);
        }

        #endregion

        #region EditModeInkCanvas

        private InkCanvas _editModeInkCanvas = new InkCanvas();

        public InkCanvas EditModeInkCanvas
        {
            get => _editModeInkCanvas;
            set => Set(ref _editModeInkCanvas, value);           
        }

        #endregion

        #region DrawingAttributesInkCanvas

        private DrawingAttributes _drawingAttributesInkCanvas = new DrawingAttributes();

        public DrawingAttributes DrawingAttributesInkCanvas
        {
            get => _drawingAttributesInkCanvas;
            set => Set(ref _drawingAttributesInkCanvas, value);
        }

        #endregion

        ///Combobox

        #region SelectedValueCombobox

        private string _selectedValueCombobox = "Красный";
        public string SelectedValueCombobox
        {
            get => _selectedValueCombobox;
            set
            {
                Color color;
                switch (value)
                {
                    case "Красный":
                        color = Colors.Red;
                        break;
                    case "Синий":
                        color = Colors.Blue;
                        break;
                    case "Зеленый":
                        color = Colors.Green;
                        break;
                    default:
                        color = Colors.White;
                        break;
                }

                var brush = new SolidColorBrush(color);
                DrawingAttributesInkCanvas.Color = brush.Color;


                StatusBarLable = $"Выбран цвет кисти: {value}";
                Set(ref _selectedValueCombobox, value);
            }

        }

        #endregion

        #region ItemsCombobox

        private ObservableCollection<string> _itemsCombobox;
        public ObservableCollection<string> ItemsCombobox
        {
            get => _itemsCombobox;
            set => Set(ref _itemsCombobox, value);

        }

        #endregion


        ///////////////////////////////////
        /// Command

        ///MenuItemCommand

        #region MenuItemBackgroundWhiteCommand

        public ICommand MenuItemBackgroundWhiteCommand { get; }

        private void ExecuteMenuItemBackgroundWhiteCommand(object p)
        {
            InkCanvasBackground = new SolidColorBrush(Colors.Transparent);
            StatusBarLable = "Изменен цвет фона на белый";
        }

        #endregion

        #region MenuItemBackgroundBlackCommand

        public ICommand MenuItemBackgroundBlackCommand { get; }

        private void ExecuteMenuItemBackgroundBlackCommand(object p)
        {
            InkCanvasBackground = new SolidColorBrush(Colors.Black);
            StatusBarLable = "Изменен цвет фона на черный";
        }

        #endregion

        #region MenuItemExitCommand

        public ICommand MenuItemExitCommand { get; }

        private async void ExecuteMenuItemExitCommand(object p)
        {
            StatusBarLable = "Выход из приложения";

            await Task.Delay(1000);

            Application.Current.Shutdown();

        }

        #endregion

        #region MenuItemAboutCommand

        public ICommand MenuItemAboutCommand { get; }

        private void ExecuteMenuItemAboutCommand(object p)
        {
            MessageBox.Show("Разработчик: Блинов Кирилл, гр. 90002095");
        }

        #endregion


        ///ToolBarCommand

        #region ToggleButtonCommand

        public ICommand ToggleButtonCommand { get; }

        private void ExecuteToggleButtonCommand(object p)
        {
            ToggleButtonMethod();
        }

        private bool CanExecuteToggleButtonCommand(object p)
        {
            
            return true;
        }

        #endregion

        ///////////////////////////////////
        /// Constructor  
        public MainWinodwViewModel()
        {
            ///Combobox
            ItemsCombobox = new ObservableCollection<string>
            {
                "Красный",
                "Синий",
                "Зеленый"
            };

            ///Default 
            var brush = new SolidColorBrush(Colors.Red);
            DrawingAttributesInkCanvas.Color = brush.Color;

            ///MenuItemCommand
            MenuItemBackgroundWhiteCommand = new LambdaCommand(ExecuteMenuItemBackgroundWhiteCommand);
            MenuItemBackgroundBlackCommand = new LambdaCommand(ExecuteMenuItemBackgroundBlackCommand);
            MenuItemExitCommand = new LambdaCommand(ExecuteMenuItemExitCommand);
            MenuItemAboutCommand = new LambdaCommand(ExecuteMenuItemAboutCommand);

            //ToolBarCommand
            ToggleButtonCommand = new LambdaCommand(ExecuteToggleButtonCommand, CanExecuteToggleButtonCommand);

        }

        ///////////////////////////////////
        /// Method
        public void ToggleButtonMethod()
        {
            //var button = (ToggleButton)sender;

            //selectedMode = button.Content.ToString();

            //foreach (var item in Toolbar.Items)
            //{
            //    if (item is ToggleButton toolButton && toolButton != button)
            //    {
            //        toolButton.IsChecked = false;
            //    }
            //}

            //button.IsChecked = true;

            //switch (selectedMode)
            //{
            //    case "Рисование":
            //        EditModeInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            //        StatusBarLable = "Выбран режим рисование";
            //        break;
            //    case "Редактирование":
            //        EditModeInkCanvas.EditingMode = InkCanvasEditingMode.Select;
            //        StatusBarLable = "Выбран режим редактирование";
            //        break;
            //    case "Удаление":
            //        EditModeInkCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
            //        StatusBarLable = "Выбран режим удаленеия";
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
