using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Create a .NET Core WPFapp that captures and
//displays todo items. The user should be able to add,
//edit, complete, and remove todo items in a ListBox.
//When the user double-clicks on a todo, strike it
//through and mark it complete.
//Set up the ListBox so that the user can drag and drop
//the todosto reorder them. Also, ensure that all
//completed todo items are placed at the bottom by
//default.

namespace todo_wpf_challenge
{
    public partial class MainWindow : Window
    {
        BindingList<ToDoItemModel> toDos = new BindingList<ToDoItemModel>();

        public MainWindow()
        {
            InitializeComponent();
            WireUpLists();
        }

        private void WireUpLists()
        {
            toDoListBox.ItemsSource = toDos;
        }

        private void AddToDoItem(string todoText)
        {
            if (string.IsNullOrWhiteSpace(todoText))
            {
                Prompt.ShowMonolog("Please enter a to-do before trying to add it to the list..", "Error");
                return;
            }

            toDos.Add(new ToDoItemModel { PositionNumber = toDos.Count + 1, TodoText = todoText });
            toDoTextBox.Clear();
            toDoTextBox.Focus();
            toDoListBox.Items.Refresh();
        }

        private void RemoveSelectedToDoItem()
        {
            var selectedItem = GetSelectedToDoItem();
            if (selectedItem == null) return;

            toDos.Remove(selectedItem);
            ReorderToDoItems();
            toDoListBox.Items.Refresh();
        }

        private void EditSelectedToDoItem()
        {
            var selectedItem = GetSelectedToDoItem();
            if (selectedItem == null) return;

            string newTodoText = Prompt.ShowDialog("Please enter a new value.", $"Editing {selectedItem.TodoText}");
            if (string.IsNullOrEmpty(newTodoText))
            {
                Prompt.ShowMonolog("No input provided, to-do item was not changed.", $"Editing {selectedItem.TodoText}");
                return;
            }

            selectedItem.TodoText = newTodoText;
            Prompt.ShowMonolog($"To-do item changed to: {newTodoText}", $"Editing {selectedItem.TodoText}");
            toDoListBox.Items.Refresh();
        }

        private void CompleteSelectedToDoItem()
        {
            var selectedItem = GetSelectedToDoItem();
            if (selectedItem == null) return;

            selectedItem.IsComplete = !selectedItem.IsComplete;

            if (selectedItem.IsComplete) 
            {
                toDos.Remove(selectedItem);
                toDos.Add(selectedItem);
            }

            toDoListBox.Items.Refresh();
        }

        private void MoveSelectedToDoItem(bool moveUp)
        {
            var selectedItem = GetSelectedToDoItem();
            if (selectedItem == null) return;

            int currentIndex = selectedItem.PositionNumber - 1;
            if ((moveUp && currentIndex == 0) || (!moveUp && currentIndex == toDos.Count - 1)) return;

            toDos.Remove(selectedItem);
            toDos.Insert(currentIndex + (moveUp ? -1 : 1), selectedItem);
            ReorderToDoItems();
            toDoListBox.SelectedIndex = currentIndex + (moveUp ? -1 : 1);
        }

        private ToDoItemModel GetSelectedToDoItem()
        {
            var selectedItem = (ToDoItemModel)toDoListBox.SelectedItem;
            if (selectedItem == null)
            {
                Prompt.ShowMonolog("Select a to-do first.", "Error");
            }
            return selectedItem;
        }

        private void ReorderToDoItems()
        {
            for (int i = 0; i < toDos.Count; i++)
            {
                toDos[i].PositionNumber = i + 1;
            }
        }

        private void ShowMessage(string message, string caption = "Information", MessageBoxImage icon = MessageBoxImage.Information)
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK, icon);
        }

        private void addToDoListBox_Click(object sender, RoutedEventArgs e)
        {
            AddToDoItem(toDoTextBox.Text);
        }
        private void toDoListBox_DoubleClick(object sender, RoutedEventArgs e)
        {
            CompleteSelectedToDoItem();
        }

        private void editToDoListBox_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedToDoItem();
        }

        private void deleteToDoListBox_Click(object sender, RoutedEventArgs e)
        {
            RemoveSelectedToDoItem();
        }
    }
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Window prompt = new Window()
            {
                Width = 500,
                Height = 200,
                Title = caption,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ResizeMode = ResizeMode.NoResize,
                Background = new SolidColorBrush(Color.FromArgb(230, 39, 37, 55)),
                Foreground = Brushes.White,
                FontFamily = new FontFamily("DFKai-SB")
            };

            Grid grid = new Grid();
            grid.Margin = new Thickness(20);

            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

            Label textLabel = new Label()
            {
                Content = text,
                Margin = new Thickness(0, 0, 0, 10),
                Foreground = Brushes.White,
                FontSize = 16
            };
            Grid.SetRow(textLabel, 0);

            TextBox textBox = new TextBox()
            {
                Margin = new Thickness(0, 0, 0, 10),
                Background = Brushes.White,
                Foreground = Brushes.Black,
                FontSize = 16,
                Padding = new Thickness(5)
            };
            Grid.SetRow(textBox, 1);

            Button confirmation = new Button()
            {
                Content = "Ok",
                Width = 100,
                HorizontalAlignment = HorizontalAlignment.Right,
                Background = new SolidColorBrush(Color.FromRgb(58, 160, 255)),
                Foreground = Brushes.White,
                BorderBrush = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Padding = new Thickness(5)
            };
            confirmation.Click += (sender, e) => { prompt.DialogResult = true; prompt.Close(); };
            Grid.SetRow(confirmation, 2);

            grid.Children.Add(textLabel);
            grid.Children.Add(textBox);
            grid.Children.Add(confirmation);

            prompt.Content = grid;

            return prompt.ShowDialog() == true ? textBox.Text : "";
        }

        public static void ShowMonolog(string text, string caption)
        {
            Window prompt = new Window()
            {
                Width = 500,
                Height = 150,
                Title = caption,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ResizeMode = ResizeMode.NoResize,
                Background = new SolidColorBrush(Color.FromArgb(230, 39, 37, 55)), // semi-transparent background
                Foreground = Brushes.White,
                FontFamily = new FontFamily("DFKai-SB")
            };

            Grid grid = new Grid();
            grid.Margin = new Thickness(20);

            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

            Label textLabel = new Label()
            {
                Content = text,
                Margin = new Thickness(0, 0, 0, 10),
                Foreground = Brushes.White,
                FontSize = 16
            };
            Grid.SetRow(textLabel, 0);

            Button confirmation = new Button()
            {
                Content = "Ok",
                Width = 100,
                HorizontalAlignment = HorizontalAlignment.Right,
                Background = new SolidColorBrush(Color.FromRgb(58, 160, 255)),
                Foreground = Brushes.White,
                BorderBrush = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Padding = new Thickness(5)
            };
            confirmation.Click += (sender, e) => { prompt.DialogResult = true; prompt.Close(); };
            Grid.SetRow(confirmation, 1);

            grid.Children.Add(textLabel);
            grid.Children.Add(confirmation);

            prompt.Content = grid;

            prompt.ShowDialog();
        }
    }
}