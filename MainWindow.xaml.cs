using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using DemoEx.Models;
using DemoEx.Helpers;
using System.Collections.Generic;

namespace DemoEx
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadItems();
        }

        // Загрузка элементов из базы данных в ListBox
        private void LoadItems()
        {
            var items = DatabaseHelper.GetItems();
            ItemListBox.ItemsSource = items;
        }

        // Добавление элемента
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var addItemWindow = new AddItemWindow();
            if (addItemWindow.ShowDialog() == true)
            {
                var newItem = new ItemModel { Text = addItemWindow.InputText };
                DatabaseHelper.AddItem(newItem);
                LoadItems();
            }
        }

        // Изменение элемента
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ItemListBox.SelectedItems.Count == 1)
            {
                var selectedItem = (ItemModel)ItemListBox.SelectedItem;
                var editItemWindow = new EditItemWindow(selectedItem.Text);

                if (editItemWindow.ShowDialog() == true)
                {
                    DatabaseHelper.UpdateItem(selectedItem, editItemWindow.InputText);
                    LoadItems();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите один элемент для изменения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Удаление элемента
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = new List<ItemModel>();
            foreach (var item in ItemListBox.SelectedItems)
            {
                selectedItems.Add((ItemModel)item);
            }

            if (selectedItems.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранные элементы?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    DatabaseHelper.DeleteItems(selectedItems);
                    LoadItems();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите хотя бы один элемент для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Очистка всех элементов
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите очистить весь список?", "Подтверждение очистки", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                DatabaseHelper.ClearItems();
                LoadItems();
            }
        }

        // Подтверждение закрытия окна
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите закрыть приложение?", "Подтверждение закрытия", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
