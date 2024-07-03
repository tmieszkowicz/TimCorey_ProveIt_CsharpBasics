namespace todo_winforms_challenge
{
    partial class ToDos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            addToDoButton = new Button();
            toDoLabel = new Label();
            toDoTextBox = new TextBox();
            toDoListLabel = new Label();
            toDoListBox = new ListBox();
            editToDoButton = new Button();
            removeToDoButton = new Button();
            SuspendLayout();
            // 
            // addToDoButton
            // 
            addToDoButton.Location = new Point(786, 111);
            addToDoButton.Margin = new Padding(6);
            addToDoButton.Name = "addToDoButton";
            addToDoButton.Size = new Size(113, 42);
            addToDoButton.TabIndex = 2;
            addToDoButton.Text = "Add";
            addToDoButton.UseVisualStyleBackColor = true;
            addToDoButton.Click += addToDoButton_Click;
            // 
            // toDoLabel
            // 
            toDoLabel.AutoSize = true;
            toDoLabel.Location = new Point(111, 63);
            toDoLabel.Margin = new Padding(6, 0, 6, 0);
            toDoLabel.Name = "toDoLabel";
            toDoLabel.Size = new Size(89, 32);
            toDoLabel.TabIndex = 1;
            toDoLabel.Text = "To Do :";
            // 
            // toDoTextBox
            // 
            toDoTextBox.Location = new Point(201, 60);
            toDoTextBox.Margin = new Padding(6);
            toDoTextBox.Name = "toDoTextBox";
            toDoTextBox.Size = new Size(698, 39);
            toDoTextBox.TabIndex = 0;
            // 
            // toDoListLabel
            // 
            toDoListLabel.AutoSize = true;
            toDoListLabel.Location = new Point(105, 153);
            toDoListLabel.Margin = new Padding(6, 0, 6, 0);
            toDoListLabel.Name = "toDoListLabel";
            toDoListLabel.Size = new Size(119, 32);
            toDoListLabel.TabIndex = 3;
            toDoListLabel.Text = "To Do List";
            // 
            // toDoListBox
            // 
            toDoListBox.FormattingEnabled = true;
            toDoListBox.ItemHeight = 32;
            toDoListBox.Location = new Point(111, 191);
            toDoListBox.Margin = new Padding(6);
            toDoListBox.Name = "toDoListBox";
            toDoListBox.Size = new Size(788, 292);
            toDoListBox.TabIndex = 3;
            toDoListBox.DoubleClick += toDoListBox_DoubleClick;
            toDoListBox.KeyDown += toDoListBox_KeyDown;
            toDoListBox.PreviewKeyDown += toDoListBox_PreviewKeyDown;
            // 
            // editToDoButton
            // 
            editToDoButton.Location = new Point(111, 495);
            editToDoButton.Margin = new Padding(6);
            editToDoButton.Name = "editToDoButton";
            editToDoButton.Size = new Size(113, 42);
            editToDoButton.TabIndex = 4;
            editToDoButton.Text = "Edit";
            editToDoButton.UseVisualStyleBackColor = true;
            editToDoButton.Click += editToDoButton_Click;
            // 
            // removeToDoButton
            // 
            removeToDoButton.Location = new Point(236, 495);
            removeToDoButton.Margin = new Padding(6);
            removeToDoButton.Name = "removeToDoButton";
            removeToDoButton.Size = new Size(113, 42);
            removeToDoButton.TabIndex = 5;
            removeToDoButton.Text = "Remove";
            removeToDoButton.UseVisualStyleBackColor = true;
            removeToDoButton.Click += removeToDoButton_Click;
            // 
            // ToDos
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1066, 580);
            Controls.Add(removeToDoButton);
            Controls.Add(editToDoButton);
            Controls.Add(toDoListBox);
            Controls.Add(toDoListLabel);
            Controls.Add(toDoTextBox);
            Controls.Add(toDoLabel);
            Controls.Add(addToDoButton);
            Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Margin = new Padding(6);
            Name = "ToDos";
            Text = "ToDo List";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addToDoButton;
        private Label toDoLabel;
        private TextBox toDoTextBox;
        private Label toDoListLabel;
        private ListBox toDoListBox;
        private Button editToDoButton;
        private Button removeToDoButton;
    }
}
