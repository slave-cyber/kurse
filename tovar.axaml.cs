using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace Galenko;

public partial class tovar : Window
{
    private List<filter1> _filters;
    private List<scripts> _scripts;
    private MySqlConnection _sqlConnection;
    private string connectrionString = "server=10.10.1.24;port=3306;database=abd9;UserID=user_01;password=user01pro";
    public tovar()
    {
        InitializeComponent();
        string full = "SELECT * FROM отель";
        ShowTable(full);
        filter();
        filter2();
    }
    
    public void ShowTable(string sql)
    {
        _scripts = new List<scripts>();
        _sqlConnection = new MySqlConnection(connectrionString);
        _sqlConnection.Open();
        MySqlCommand command = new MySqlCommand(sql, _sqlConnection);
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read() && reader.HasRows)
        {
            var current = new scripts()
            {
                id = reader.GetInt32("id"),
                name = reader.GetString("название_отеля"),
                address = reader.GetString("адрес_отеля"),
                num = reader.GetInt32("телефон_отеля")
            };
            _scripts.Add(current);
        }

        _sqlConnection.Close();
        Grid.ItemsSource = _scripts;
    }

    private void Back_OnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        this.Hide();
        mainWindow.Show();
    }

    private void Add_OnClick(object? sender, RoutedEventArgs e)
    {
        _sqlConnection.Open();
        string sqlInsert = $"INSERT INTO отель (название_отеля, адрес_отеля, телефон_отеля) values ('{t2.Text}', '{t3.Text}', '{t4.Text}')";
        MySqlCommand command = new MySqlCommand(sqlInsert, _sqlConnection);
        command.ExecuteNonQuery();
        _sqlConnection.Close();
    }

    private void Save_OnClick(object? sender, RoutedEventArgs e)
    {
        _scripts = new List<scripts>();
        _sqlConnection = new MySqlConnection(connectrionString);
        _sqlConnection.Open();
        string sql = "SELECT * FROM отель";
        MySqlCommand command = new MySqlCommand(sql, _sqlConnection);
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read() && reader.HasRows)
        {
            var current = new scripts()
            {
                id = reader.GetInt32("id"),
                name = reader.GetString("название_отеля"),
                address = reader.GetString("адрес_отеля"),
                num = reader.GetInt32("телефон_отеля")
            };
            _scripts.Add(current);
        }
        Grid.ItemsSource = _scripts;
        _sqlConnection.Close();
        
    }

    private void Update_OnClick(object? sender, RoutedEventArgs e)
    {
        _sqlConnection.Open();
        string sqlInsert = $"UPDATE отель set название_отеля ='{t2.Text}' , адрес_отеля = '{t3.Text}', телефон_отеля = '{t4.Text}' WHERE id = '{t1.Text}'";
        MySqlCommand command = new MySqlCommand(sqlInsert, _sqlConnection);
        command.ExecuteNonQuery();
        _sqlConnection.Close();
    }

    private void Delete_OnClick(object? sender, RoutedEventArgs e)
    {
        _sqlConnection.Open();
        string sqlInsert = $"DELETE  FROM отель WHERE id = '{t1.Text}'";
        MySqlCommand command = new MySqlCommand(sqlInsert, _sqlConnection);
        command.ExecuteNonQuery();
        _sqlConnection.Close();
    }

    private void T5_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        var current = _scripts;
        current = current.Where(x => x.name.Contains(t5.Text)).ToList();
        Grid.ItemsSource = current;
    }

    private void filter()
    {
        _filters = new List<filter1>();
        _sqlConnection = new MySqlConnection(connectrionString);
        _sqlConnection.Open();
        string sql = "SELECT id, адрес_отеля FROM отель";
        MySqlCommand command = new MySqlCommand(sql, _sqlConnection);
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read() && reader.HasRows)
        {
            var current = new filter1()
            {
                id1 = reader.GetInt32("id"),
                adres = reader.GetString("адрес_отеля")
            };
            _filters.Add(current);
        }

        var combobox = this.Find<ComboBox>("Box");
        combobox.ItemsSource = _filters;
        _sqlConnection.Close();
    }

    private void Box_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var comboBox = (ComboBox)sender;
        var currentfilter = comboBox.SelectedItem as filter1;
        var filterdsa = _scripts.Where(x => x.id == currentfilter.id1).ToList();
        Grid.ItemsSource = filterdsa;
    }
    
    private void filter2()
    {
        _filters = new List<filter1>();
        _sqlConnection = new MySqlConnection(connectrionString);
        _sqlConnection.Open();
        string sql = "SELECT id, телефон_отеля FROM отель";
        MySqlCommand command = new MySqlCommand(sql, _sqlConnection);
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read() && reader.HasRows)
        {
            var current = new filter1()
            {
                id1 = reader.GetInt32("id"),
                number = reader.GetInt32("телефон_отеля")
            };
            _filters.Add(current);
        }

        var combobox = this.Find<ComboBox>("BoxName");
        combobox.ItemsSource = _filters;
        _sqlConnection.Close();
    }

    private void BoxName_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var comboBox = (ComboBox)sender;
        var currentfilter = comboBox.SelectedItem as filter1;
        var filList = _scripts.Where(x => x.id == currentfilter.id1).ToList();
        Grid.ItemsSource = filList;
    }
}