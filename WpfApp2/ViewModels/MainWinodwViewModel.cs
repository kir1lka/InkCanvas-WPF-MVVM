using Laba10.Commands;
using Laba10.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Net.Sockets;
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
        //Properties

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

        //InkCanvas

        #region InkCanvasBackground

        private SolidColorBrush _inkCanvaskBackground;

        public SolidColorBrush InkCanvasBackground
        {
            get => _inkCanvaskBackground;
            set => Set(ref _inkCanvaskBackground, value);
        }

        #endregion

        #region EditModeInkCanvas

        private InkCanvasEditingMode _editModeInkCanvas = new InkCanvasEditingMode();

        public InkCanvasEditingMode EditModeInkCanvas
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

        //Combobox

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

        //RadioButton

        #region IsInkModeChecked

        private bool _isInkModeChecked;
        public bool IsInkModeChecked
        {
            get => _isInkModeChecked;
            set
            {
                if (_isInkModeChecked != value)
                {
                    _isInkModeChecked = value;
                    Set(ref _isInkModeChecked, value);
                }
            }
        }

        #endregion

        #region IsEditingModeChecked

        private bool _isEditingModeChecked;
        public bool IsEditingModeChecked
        {
            get => _isEditingModeChecked;
            set
            {
                if (_isEditingModeChecked != value)
                {
                    _isEditingModeChecked = value;
                    Set(ref _isEditingModeChecked, value);
                }
            }
        }

        #endregion

        #region IsDeleteModeChecked

        private bool _isDeleteModeChecked;
        public bool IsDeleteModeChecked
        {
            get => _isDeleteModeChecked;
            set
            {
                if (_isDeleteModeChecked != value)
                {
                    _isDeleteModeChecked = value;
                    Set(ref _isDeleteModeChecked, value);
                }
            }
        }

        #endregion

        ///////////////////////////////////
        // Command

        //MenuItemCommand

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


        //ToolBarCommand

        #region RadioButtonCommand

        public ICommand RadioButtonCommand { get; }

        private void ExecuteRadioButtonCommand(object p)
        {
            string mode = p.ToString();
            IsInkModeChecked = mode == "Рисование";
            IsEditingModeChecked = mode == "Редактирование";
            IsDeleteModeChecked = mode == "Удаление";

            string selectedMode = p.ToString();
            RadioButtonMethod(selectedMode);
        }

        #endregion




        ///////////////////////////////////
        // Constructor  
        public MainWinodwViewModel()
        {
            //Default 
            var brush = new SolidColorBrush(Colors.Red);
            DrawingAttributesInkCanvas.Color = brush.Color;

            string selectedMode = "Рисование";
            RadioButtonMethod(selectedMode);
            IsInkModeChecked = true;

            //Combobox items
            ItemsCombobox = new ObservableCollection<string>
            {
                "Красный",
                "Синий",
                "Зеленый"
            };

            //MenuItemCommand
            MenuItemBackgroundWhiteCommand = new LambdaCommand(ExecuteMenuItemBackgroundWhiteCommand);
            MenuItemBackgroundBlackCommand = new LambdaCommand(ExecuteMenuItemBackgroundBlackCommand);
            MenuItemExitCommand = new LambdaCommand(ExecuteMenuItemExitCommand);
            MenuItemAboutCommand = new LambdaCommand(ExecuteMenuItemAboutCommand);

            //ToolBarCommand
            RadioButtonCommand = new LambdaCommand(ExecuteRadioButtonCommand);
        }

        ///////////////////////////////////
        // Method
        public void RadioButtonMethod(string selectedMode)
        {
            switch (selectedMode)
            {
                case "Рисование":
                    EditModeInkCanvas = InkCanvasEditingMode.Ink;
                    StatusBarLable = "Выбран режим рисование";
                    break;
                case "Редактирование":
                    EditModeInkCanvas = InkCanvasEditingMode.Select;
                    StatusBarLable = "Выбран режим редактирование";
                    break;
                case "Удаление":
                    EditModeInkCanvas = InkCanvasEditingMode.EraseByPoint;
                    StatusBarLable = "Выбран режим удаления";
                    break;
                default:
                    break;
            }
        }
    }
}
