using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;


namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        //#region обработчики
        //private string selectedMode = "Рисование";

        //public MainWindow()
        //{
        //    InitializeComponent();

        //    DataContext = this;

        //    ComboBoxColor.SelectedIndex = 0;

        //    InkModeCanvas.IsChecked = true;
        //    LabelTextFooter.Content = "Выбран режим рисования";

        //    if (DrawingCanvas != null)
        //    {
        //        var newSize = 5;

        //        DrawingCanvas.DefaultDrawingAttributes.Width = newSize;
        //        DrawingCanvas.DefaultDrawingAttributes.Height = newSize;

        //    }

        //}

        //private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Разработчик: Блинов Кирилл, гр. 90002095");
        //}

        //private async void MenuItemExit_Click(object sender, RoutedEventArgs e)
        //{
        //    LabelTextFooter.Content = "Выйти из приложения";

        //    await Task.Delay(1000);

        //    this.Close();
        //}

        //private void MenuItemBackgroundBlack_Click(object sender, RoutedEventArgs e)
        //{
        //    DrawingCanvas.Background = Brushes.Black;
        //    LabelTextFooter.Content = "Изменен цвет фона на черный";
        //}

        //private void MenuItemBackgroundWhite_Click(object sender, RoutedEventArgs e)
        //{
        //    DrawingCanvas.Background = Brushes.White;
        //    LabelTextFooter.Content = "Изменен цвет фона на белый";
        //}
        ////private void ToolButton_Click(object sender, RoutedEventArgs e)
        ////{
        ////    var button = (ToggleButton)sender;

        ////    selectedMode = button.Content.ToString();

        ////    foreach (var item in Toolbar.Items)
        ////    {
        ////        if (item is ToggleButton toolButton && toolButton != button)
        ////        {
        ////            toolButton.IsChecked = false;
        ////        }
        ////    }

        ////    button.IsChecked = true;

        ////    switch (selectedMode)
        ////    {
        ////        case "Рисование":
        ////            DrawingCanvas.EditingMode = InkCanvasEditingMode.Ink;
        ////            LabelTextFooter.Content = "Выбран режим рисования";
        ////            break;
        ////        case "Редактирование":
        ////            LabelTextFooter.Content = "Выбран режим редактирования";
        ////            DrawingCanvas.EditingMode = InkCanvasEditingMode.Select;
        ////            break;
        ////        case "Удаление":
        ////            LabelTextFooter.Content = "Выбран режим удаления";
        ////            DrawingCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
        ////            break;
        ////        default:
        ////            break;
        ////    }
        ////}
        //private void ComboBoxColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var selectedItem = (ComboBoxItem)ComboBoxColor.SelectedItem;
        //    var colorName = selectedItem.Content.ToString();

        //    Color color;
        //    switch (colorName)
        //    {
        //        case "Красный":
        //            color = Colors.Red;
        //            break;
        //        case "Синий":
        //            color = Colors.Blue;
        //            break;
        //        case "Зеленый":
        //            color = Colors.Green;
        //            break;
        //        default:
        //            color = Colors.White;
        //            break;
        //    }

        //    var brush = new SolidColorBrush(color);
        //    DrawingCanvas.DefaultDrawingAttributes.Color = brush.Color;

        //    LabelTextFooter.Content = $"Выбран цвет кисти: {colorName}";
        //}

        //private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    if (DrawingCanvas != null)
        //    {
        //        var newSize = e.NewValue;

        //        DrawingCanvas.DefaultDrawingAttributes.Width = newSize;
        //        DrawingCanvas.DefaultDrawingAttributes.Height = newSize;

        //        LabelTextFooter.Content = $"Размер кисти: {newSize}";
        //    }
        //}

        //private void MenuItem_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    var menuItem = (MenuItem)sender;
        //    var menuItemText = menuItem.Header.ToString();

        //    LabelTextFooter.Content = $"Выйти из приложения";
        //}

        //private void MenuItem_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    LabelTextFooter.Content = "...";
        //}
        //#endregion
    }
}
