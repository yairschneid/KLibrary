using KofmanLibrary.Models;
using PropertyChanged;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;

namespace KofmanLibrary.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ReactiveCommand<Unit, Unit> BookListBorrowFilter { get; }
        public ObservableCollection<Book> BooksViewList { get; set; }
        public Database Database { get; }
        public int NumOfBorrows { get; set; }
        public bool FlyoutOverView { get; set; }
        public MainViewModel()
        {
            BooksViewList = new ObservableCollection<Book>();
            Database = new Database();
            var books = Database.Books;
            foreach (var book in books)
            {
                BooksViewList.Add(book.Value);
            }
            NumOfBorrows = Database.GetNumOfBorrows();
            FlyoutOverView = true;
            BookListBorrowFilter = ReactiveCommand.Create(ViewBorrowed);
        }

        private void ViewBorrowed()
        {
            var list = Database.GetBorrowed();
            BooksViewList.Clear();
            foreach(var book in list)
            {
                BooksViewList.Add(book);
            }
        }
    }
}
