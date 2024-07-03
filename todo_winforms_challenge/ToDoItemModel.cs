using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace todo_winforms_challenge
{
    public class ToDoItemModel : INotifyPropertyChanged
    {
        private bool isComplete = false;
        private string todoText;
        private int positionNumber;

        public int PositionNumber { 
            get => positionNumber;
            set
            {
                positionNumber = value;
                OnPropertyChanged();
            }
        }
        public string TodoText { get => todoText;
            set
            {
                todoText = value;
                OnPropertyChanged();
            } 
        }
        public bool IsComplete { get => isComplete;
            set
            {
                isComplete = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null) 
            { 
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string ToString()
        {
            if (!IsComplete) 
            {
                return $"{PositionNumber}: {TodoText} - In progress.";
            }
            return $"{PositionNumber}: {TodoText} - Done.";
        }
    }
}
