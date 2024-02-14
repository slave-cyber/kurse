using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace Galenko;

public partial class order : Window
{
    private List<nomers> _scripts;
    private MySqlConnection _sqlConnection;
    private string connectrionString = "server=localhost;port=3306;database=valdberis;UserID=swekoling;password=swekoling";
    public order()
    {
        InitializeComponent();
        string full = "SELECT * FROM номер";
        ShowTable(full);
    }
    
    public void ShowTable(string sql)
    {
        _scripts = new List<nomers>();
        _sqlConnection = new MySqlConnection(connectrionString);
        _sqlConnection.Open();
        MySqlCommand command = new MySqlCommand(sql, _sqlConnection);
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read() && reader.HasRows)
        {
            var current = new nomers()
            {
                id3 = reader.GetInt32("id"),
                orderID = reader.GetInt32("orderID"),
                ProductID = reader.GetString("ProductID"),
                Kol-vo = reader.GetInt32("Kol-vo"),
                prise = reader.GetInt32("prise")
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

    private void T5_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        var filtersad = _scripts;
        filtersad = filtersad.Where(x => x.type_nom.Contains(t5.Text)).ToList();
        Grid.ItemsSource = filtersad;
    }

    private void Add_OnClick(object? sender, RoutedEventArgs e)
    {
        _sqlConnection.Open();
        string sqlInsert = $"INSERT INTO order (id стоимость) values ('{t2.Text}', '{t3.Text}', '{t4.Text}')";
        MySqlCommand command = new MySqlCommand(sqlInsert, _sqlConnection);
        command.ExecuteNonQuery();
        _sqlConnection.Close();
    }

    private void Save_OnClick(object? sender, RoutedEventArgs e)
    {
        _scripts = new List<nomers>();
        _sqlConnection = new MySqlConnection(connectrionString);
        _sqlConnection.Open();
        string sql = "SELECT * FROM order";
        MySqlCommand command = new MySqlCommand(sql, _sqlConnection);
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read() && reader.HasRows)
        {
            var current = new nomers()
            {
                id3 = reader.GetInt32("id"),
                orderID = reader.GetInt32("orderID"),
                ProductID = reader.GetString("ProductID"),
                Kol-vo = reader.GetInt32("Kol-vo"),
                prise = reader.GetInt32("prise")
            };
            _scripts.Add(current);
        }
        _sqlConnection.Close();
        Grid.ItemsSource = _scripts;
    }

    private void Update_OnClick(object? sender, RoutedEventArgs e)
    {
        _sqlConnection.Open();
        string sqlInsert = $"UPDATE order set orderID ='{t2.Text}' , ProductID = '{t3.Text}', Kol-vo = '{t4.Text}' WHERE id = '{t1.Text}'";
        MySqlCommand command = new MySqlCommand(sqlInsert, _sqlConnection);
        command.ExecuteNonQuery();
        _sqlConnection.Close();
    }

    private void Delete_OnClick(object? sender, RoutedEventArgs e)
    {
        _sqlConnection.Open();
        string sqlInsert = $"DELETE  FROM order WHERE id = '{t1.Text}'";
        MySqlCommand command = new MySqlCommand(sqlInsert, _sqlConnection);
        command.ExecuteNonQuery();
        _sqlConnection.Close();
    }
}