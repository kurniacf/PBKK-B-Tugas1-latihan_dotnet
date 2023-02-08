using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace tugas1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>();

        public MainWindow()
        {
            InitializeComponent();
            transactionsListBox.ItemsSource = transactions;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string description = descriptionTextBox.Text;
            decimal amount;
            if (decimal.TryParse(amountTextBox.Text, out amount))
            {
                transactions.Add(new Transaction() { Description = description, Amount = amount });
                descriptionTextBox.Clear();
                amountTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Invalid amount");
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Transaction selectedTransaction = (Transaction)transactionsListBox.SelectedItem;
            if (selectedTransaction != null)
            {
                int selectedIndex = transactions.IndexOf(selectedTransaction);
                string description = descriptionTextBox.Text;
                decimal amount;
                if (decimal.TryParse(amountTextBox.Text, out amount))
                {
                    transactions[selectedIndex] = new Transaction() { Description = description, Amount = amount };
                    descriptionTextBox.Clear();
                    amountTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Invalid amount");
                }
            }
            else
            {
                MessageBox.Show("Please select a transaction to edit");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Transaction selectedTransaction = (Transaction)transactionsListBox.SelectedItem;
            if (selectedTransaction != null)
            {
                transactions.Remove(selectedTransaction);
                descriptionTextBox.Clear();
                amountTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please select a transaction to delete");
            }
        }
    }

    public class Transaction
    {
        public string? Description { get; set; }
        public decimal Amount { get; set; }

        public override string ToString()
        {
            return $"{Description}: {Amount:C}";
        }
    }
}
