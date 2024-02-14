using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;

namespace Galenko;

public partial class MainWindow : Window
{
   
    
    public MainWindow()
    {
        InitializeComponent();
    }


    private void Hotel_OnClick(object? sender, RoutedEventArgs e)
    {
        tovar hotel = new tovar();
        this.Hide();
        hotel.Show();
    }

    private void Client_OnClick(object? sender, RoutedEventArgs e)
    {
        Client client = new Client();
        this.Hide();
        client.Show();
    }

    private void Nomer_OnClick(object? sender, RoutedEventArgs e)
    {
        order nomer = new order();
        this.Hide();
        nomer.Show();
    }
}