using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace Galenko;

public partial class tovar : Window
{
 
    private MySqlConnection _sqlConnection;
    private string connectrionString = "server=10.10.1.24;port=3306;database=abd9;UserID=user_01;password=user01pro";
    public tovar()
    {
    
        string full = "SELECT * FROM отель";

    }
    private void Back_OnClick(object sender, System.EventArgs e)
    {
        if (TextBox = "123" && TextBox1 = "123") 
        {
            MainWindow eee = new MainWindow();
            MainWindow.Show();
            this.Hide();
        }
        else
        {
            Show(ObjectiveCMarshal.MessageSendFunction).error('неправельно ведены данные');
        }
    }  
   
}