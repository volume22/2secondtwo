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
using System.Xml;

namespace _2secondtwo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Circulation> currencies = new List<Circulation>();
        public MainWindow()
        {
            InitializeComponent();
            ReadXml();
        }
        private void TextBoxFrom(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
                && (!textBox.Text.Contains(".")
                && textBox.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
        public void ReadXml()
        {
            Box1.Items.Add("KZT");
            XmlDocument doc = new XmlDocument();
            doc.Load("https://www.nationalbank.kz/rss/rates_all.xml");
            XmlNodeList cl = doc.GetElementsByTagName("item");
            foreach (XmlNode item in cl)
            {
                string title = item["title"].InnerText;
                double description = double.Parse(item["description"].InnerText.Replace('.', ','));
                currencies.Add(new Circulation(title, description));
                Box2.Items.Add(title);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = (from t in currencies
                          where t.title == Box2.Text
                          select t).ToList();
            foreach (var elem in result)
            {
                try
                {
                    textBox2.Text = Math.Round((double.Parse(textBox.Text.Replace('.', ',')) / elem.description), 2).ToString();
                }
                catch
                {
                    textBox.Text = "Enter Numb";
                }
            }
        }
    }
}
