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

namespace Ukrashenie
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        int CountRecords;
        public ProductPage()
        {
            InitializeComponent();
            var CurrentProducts = Timerzyanov_UkrashenieEntities.GetContext().Product.ToList();

            CountRecords = CurrentProducts.Count;
            ProductListView.ItemsSource = CurrentProducts;
            SortProduct.SelectedIndex = 0;
            FilterProduct.SelectedIndex = 0;
            UpdateProducts();


        }

        private void UpdateProducts()
        {
            var currentProducts = Timerzyanov_UkrashenieEntities.GetContext().Product.ToList();

            if (FilterProduct.SelectedIndex == 0)
            {
                currentProducts = currentProducts.Where(p => (p.ProductMaxDiscount >= 0 && p.ProductMaxDiscount <= 100)).ToList();
            }
            if (FilterProduct.SelectedIndex == 1)
            {
                currentProducts = currentProducts.Where(p => (p.ProductMaxDiscount >= 0 && p.ProductMaxDiscount <= 9.99)).ToList();
            }
            if (FilterProduct.SelectedIndex == 2)
            {
                currentProducts = currentProducts.Where(p => (p.ProductMaxDiscount >= 10 && p.ProductMaxDiscount <= 14.99)).ToList();
            }
            if (FilterProduct.SelectedIndex == 3)
            {
                currentProducts = currentProducts.Where(p => (p.ProductMaxDiscount >= 15 && p.ProductMaxDiscount <= 100)).ToList();
            }

            currentProducts = currentProducts.Where(p => p.ProductName.ToLower().Contains(SearchProduct.Text.ToLower())).ToList();
            var OriginalSort = currentProducts;
            if (SortProduct.SelectedIndex==0)
            {
                currentProducts = OriginalSort;
            }
            if (SortProduct.SelectedIndex == 1)
            {
                currentProducts = currentProducts.OrderBy(p => p.ProductCost).ToList();
            }
            if (SortProduct.SelectedIndex == 2)
            {
                currentProducts = currentProducts.OrderByDescending(p => p.ProductCost).ToList();
            }

            ProductListView.ItemsSource = currentProducts;
            CountFiltered.Text = currentProducts.Count.ToString();
            CountTotal.Text= CountRecords.ToString();
        }




        private void SearchProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void SortProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void FilterProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }
    }
}
