using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

//Create a WinFormsapp that maintains a todo list in a
//ListBox. Allow a user to add, remove, edit, and
//complete items. Double-clicking on a list item should
//mark it complete.
//Set up the ListBoxso that when an item is selected,
//you can use the arrow keys to move it up or down in
//priority. Ensure that the priority number is displayed
//on the item and that it changes when the item
//moves.

namespace todo_winforms_challenge
{
    public partial class ToDos : Form
    {
        private static BindingList<ToDoItemModel> toDos = new BindingList<ToDoItemModel>();

        public ToDos()
        {
            InitializeComponent();
            WireUpLists();
        }

        private void WireUpLists()
        {
            toDoListBox.DataSource = toDos;
            toDoListBox.DisplayMember = nameof(ToDoItemModel.ToString);
        }

        private void AddToDoItem(string todoText)
        {
            if (string.IsNullOrWhiteSpace(todoText))
            {
                ShowMessage("Please enter a to-do before trying to add it to the list.", "Empty to-do", MessageBoxIcon.Error);
                return;
            }

            toDos.Add(new ToDoItemModel { PositionNumber = toDos.Count + 1, TodoText = todoText });
            toDoTextBox.Clear();
            toDoTextBox.Focus();
        }

        private void RemoveSelectedToDoItem()
        {
            var selectedItem = GetSelectedToDoItem();
            if (selectedItem == null) return;

            toDos.Remove(selectedItem);
            ReorderToDoItems();
        }

        private void EditSelectedToDoItem()
        {
            var selectedItem = GetSelectedToDoItem();
            if (selectedItem == null) return;

            string newTodoText = Prompt.ShowDialog("Please enter a new value.", $"Editing {selectedItem.TodoText}");
            if (string.IsNullOrEmpty(newTodoText))
            {
                ShowMessage("No input provided, to-do item was not changed.");
                return;
            }

            selectedItem.TodoText = newTodoText;
            ShowMessage($"To-do item changed to: {newTodoText}");
            RefreshToDoList();
        }

        private void CompleteSelectedToDoItem()
        {
            var selectedItem = GetSelectedToDoItem();
            if (selectedItem == null) return;

            selectedItem.IsComplete = true;
            RefreshToDoList();
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
                ShowMessage("Select a to-do first.");
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

        private void RefreshToDoList()
        {
            toDoListBox.DataSource = null;
            toDoListBox.DataSource = toDos;
            toDoListBox.DisplayMember = nameof(ToDoItemModel.ToString);
        }

        private void ShowMessage(string message, string caption = "Information", MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
        }

        private void addToDoButton_Click(object sender, EventArgs e)
        {
            AddToDoItem(toDoTextBox.Text);
        }

        private void removeToDoButton_Click(object sender, EventArgs e)
        {
            RemoveSelectedToDoItem();
        }

        private void editToDoButton_Click(object sender, EventArgs e)
        {
            EditSelectedToDoItem();
        }

        private void toDoListBox_DoubleClick(object sender, EventArgs e)
        {
            CompleteSelectedToDoItem();
        }

        private void toDoListBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.IsInputKey = true;
            }
        }

        private void toDoListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                MoveSelectedToDoItem(e.KeyCode == Keys.Up);
                e.Handled = true;
            }
        }
    }

    public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };

                Label textLabel = new Label()
                {
                    Left = 50,
                    Top = 20,
                    Text = text,
                    AutoSize = true
                };

                TextBox textBox = new TextBox()
                {
                    Left = 50,
                    Top = 50,
                    Width = 400,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right
                };

                Button confirmation = new Button()
                {
                    Text = "Ok",
                    Left = 350,
                    Width = 100,
                    Top = 80,
                    DialogResult = DialogResult.OK,
                    Anchor = AnchorStyles.Right | AnchorStyles.Bottom
                };

                confirmation.Click += (sender, e) => { prompt.Close(); };

                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
    }

}