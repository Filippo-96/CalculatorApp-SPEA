using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace CalculatorApp
{
  public partial class MainWindow : Window
  {
    private string expression = "";               // espressione visualizzata e valutata
    private readonly List<string> history = new(); // storico operazioni

    public MainWindow()
    {
      InitializeComponent();
    }

    // Gestisce numeri, operatori, parentesi, radice e potenza
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      string content = (string)((Button)sender).Content;

      fInsert(content);
    }

    private void fInsert(String content)
    {
      // Aggiunge il token all'espressione
      if (content == "√")
      {
        expression += "√"; // token radice
      }
      else if (content == "^")
      {
        expression += "^"; // token potenza
      }
      else
      {
        expression += content; // numeri e operatori
      }
      Display.Text = expression;
    }

    // Valuta l’espressione corrente
    private void Equals_Click(object sender, RoutedEventArgs e)
    {
      fCalculate();
    }

    private void fCalculate()
    {
      if (string.IsNullOrWhiteSpace(expression)) return;

      double result;
      bool ok = CalculatorLogic.Evaluate(expression, out result);

      if (ok)
      {
        Display.Text = result.ToString();
        history.Add($"{expression} = {result}");
        HistoryList.ItemsSource = null;
        HistoryList.ItemsSource = history;
        expression = result.ToString(); // consente di continuare a calcolare
      }
      else
      {
        Display.Text = "Errore";
        expression = "";
      }
    }


    // Pulisce display ed espressione
    private void Clear_Click(object sender, RoutedEventArgs e)
    {
      expression = "";
      Display.Text = "";
    }

    // Mostra / nasconde lo storico
    private void History_Click(object sender, RoutedEventArgs e)
    {
      HistoryPanel.Visibility = HistoryPanel.Visibility == Visibility.Visible
          ? Visibility.Collapsed
          : Visibility.Visible;

      // scorri all’ultima operazione
      if (history.Count > 0 && HistoryPanel.Visibility == Visibility.Visible)
        HistoryList.ScrollIntoView(history[^1]);
    }

    private void Sin_Click(object sender, RoutedEventArgs e)
    {
      double result = 0;
      CalculatorLogic.Sin(Double.Parse(Display.Text), out result);
      Display.Text = result.ToString();
    }

    private void Cos_Click(object sender, RoutedEventArgs e)
    {
      double result = 0;
      CalculatorLogic.Cos(Double.Parse(Display.Text), out result);
      Display.Text = result.ToString();
    }

    private void Tan_Click(object sender, RoutedEventArgs e)
    {
      double result = 0;
      CalculatorLogic.Tan(Double.Parse(Display.Text), out result);
      Display.Text = result.ToString();
    }

    private void Asin_Click(object sender, RoutedEventArgs e)
    {
      double result = 0;
      CalculatorLogic.Asin(Double.Parse(Display.Text), out result);
      Display.Text = result.ToString();
    }

    private void Acos_Click(object sender, RoutedEventArgs e)
    {
      double result = 0;
      CalculatorLogic.Acos(Double.Parse(Display.Text), out result);
      Display.Text = result.ToString();
    }

    private void Atan_Click(object sender, RoutedEventArgs e)
    {
      double result = 0;
      CalculatorLogic.Atan(Double.Parse(Display.Text), out result);
      Display.Text = result.ToString();
    }

    private void DegreeToRad_Click(object sender, RoutedEventArgs e)
    {
      double result = 0;
      CalculatorLogic.DegreeToRad(Double.Parse(Display.Text), out result);
      Display.Text = result.ToString();
    }

    private void RadToDegree_Click(object sender, RoutedEventArgs e)
    {
      double result = 0;
      CalculatorLogic.RadToDegree(Double.Parse(Display.Text), out result);
      Display.Text = result.ToString();
    }

    private void Pi_Click(object sender, RoutedEventArgs e)
    {
      fInsert(Math.PI.ToString());
    }

    private void NepreroNumber_Click(object sender, RoutedEventArgs e)
    {
      fInsert(Math.E.ToString());
    }
  }
}