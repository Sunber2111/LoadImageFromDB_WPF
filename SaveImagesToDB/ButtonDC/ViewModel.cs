using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SaveImagesToDB.ButtonDC
{
    public class ViewModel:BaseViewModel
    {
        private ObservableCollection<Book> _listWords;
        public ObservableCollection<Book> ListWords
        {
            get => _listWords;
            set
            {
                if (value != null)
                {
                    _listWords = value;
                    OnPropertyChanged("ListWords");
                }
            }
        }

        public ICommand Show { get; set; }

        public ViewModel()
        {

            ListWords = new ObservableCollection<Book>()
            {
                new Book() { Id=1,Name="Harry"},
                new Book() { Id=2,Name="potter"},
                new Book() { Id=3,Name="Dragon"}
            };

            Show = new RelayCommand<int>((p) => { return true; }, (p) =>{
                MessageBox.Show(p.ToString());
            });

        }

    }
}
