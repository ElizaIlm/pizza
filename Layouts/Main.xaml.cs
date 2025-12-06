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
using eliza13pr.Classes;

namespace eliza13pr.Layout
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public List <Classes.Dish> AllDishes = new List <Classes.Dish> ();
        public Main()   
        {
            InitializeComponent();
        }
        public void CreatePizza()
        {
            for (int i = 0; i < dishs.Count; i++) // перебираем пиццы
            {
                var bc = new BrushConverter(); // создаём конвертор цвета

                Grid global = new Grid(); // создаём элемент Grid
                global.Height = 100; // указываем высоту
                global.Background = (Brush)bc.ConvertFrom("#FFECECEC"); // указываем цвет
                if (i > 0) global.Margin = new Thickness(0, 10, 0, 0); // задаём отступы

                Image logo = new Image(); // создаём изображение
                if (File.Exists(mainWindow.localPath + @"\image\dish\" + dishs[i].img + ".png")) // проверяем существует ли файл
                    logo.Source = new BitmapImage(new Uri(mainWindow.localPath + @"\image\dish\" + dishs[i].img + ".png")); // указываем
                else
                    logo.Source = new BitmapImage(new Uri(mainWindow.localPath + @"\image\icon.png")); // указываем картинку

                logo.HorizontalAlignment = System.Windows.HorizontalAlignment.Left; // задаём привязку по горизонтали
                logo.Height = 50; // устанавливаем высоту
                logo.Margin = new Thickness(10, 10, 0, -10); // устанавливаем отступы
                logo.VerticalAlignment = System.Windows.VerticalAlignment.Top; // устанавливаем привязку по вертикали
                logo.Width = 50; // устанавливаем ширину
                global.Children.Add(logo); // добавляем в элемент Grid

                Label name = new Label(); // создаём текст
                name.Content = dishs[i].name; // устанавливаем наименование
                name.HorizontalAlignment = System.Windows.HorizontalAlignment.Left; // устанавливаем привязку по горизонтали
                name.VerticalAlignment = System.Windows.VerticalAlignment.Top; // устанавливаем привязку по вертикали
                name.Margin = new Thickness(65, 0, 0, 0); // устанавливаем отступы
                name.FontWeight = FontWeights.Bold; // задаём толщину текста
                global.Children.Add(name); // добавляем в элемент Grid

                Label description = new Label(); // создаём текст
                description.Content = dishs[i].description; // устанавливаем описание
                description.HorizontalAlignment = System.Windows.HorizontalAlignment.Left; // устанавливаем привязку по горизонтали
                description.VerticalAlignment = System.Windows.VerticalAlignment.Top; // устанавливаем привязку по вертикали
                description.Margin = new Thickness(65, 20, 0, 0);  // устанавливаем отступы
                global.Children.Add(description); // добавляем в элемент Grid
                if (dishs[i].ingredients.Count != 0) // если ингредиенты блюда существуют
                {
                    Label ingredient = new Label(); // создаём текст
                    string str_ingredient = ""; // собираем ингредиенты
                    for (int j = 0; j < dishs[i].ingredients.Count; j++) // перебираем ингредиенты
                    {
                        str_ingredient += dishs[i].ingredients[j].name; // запоминаем наименование ингред
                        if (j != dishs[i].ingredients.Count - 1) // если это не последнее ингредиент
                        {
                            str_ingredient += ", "; // ставим запятую
                        }
                    }

                    ingredient.Content = "Состав: " + str_ingredient; // устанавливаем описание ингредиентов
                    ingredient.HorizontalAlignment = System.Windows.HorizontalAlignment.Left; // устанавливаем привязку по горизонтали
                    ingredient.VerticalAlignment = System.Windows.VerticalAlignment.Top; // устанавливаем привязку по вертикали
                    ingredient.Margin = new Thickness(65, 40, 0, 0); // устанавливаем отступы
                    global.Children.Add(ingredient); // добавляем в элемент Grid
                }
                Label price = new Label(); // создаём текст
                price.Content = "Цена: " + dishes[i].sizes[0].price + " р."; // устанавливаем текст
                price.HorizontalAlignment = System.Windows.HorizontalAlignment.Left; // устанавливаем привязку по горизонтали
                price.VerticalAlignment = System.Windows.VerticalAlignment.Bottom; // устанавливаем привязку по вертикали
                price.Margin = new Thickness(65, 0, 0, 10); // устанавливаем отступы
                global.Children.Add(price); // добавляем в элемент Grid

                Label wes = new Label(); // создаём текст
                wes.Content = "Вес: " + dishs[i].sizes[0].wes + " г."; // устанавливаем текст
                wes.HorizontalAlignment = System.Windows.HorizontalAlignment.Left; // устанавливаем привязку по горизонтали
                wes.VerticalAlignment = System.Windows.VerticalAlignment.Bottom; // устанавливаем привязку по вертикали
                wes.Margin = new Thickness(236, 0, 0, 10); // устанавливаем отступы
                global.Children.Add(wes); 

                Button button1 = new Button(); // создаём кнопку
                Button button2 = new Button(); // создаём кнопку
                Button button3 = new Button(); // создаём кнопку

                // низ
                Button minus = new Button(); // создаём кнопку
                TextBox count = new TextBox(); // создаём элемент ввода текста
                Button plus = new Button(); // создаём кнопку
                CheckBox order = new CheckBox(); // создаём CheckBox

                button1.Content = dishs[i].sizes[0].size + " см."; // устанавливаем текст
                button1.HorizontalAlignment = System.Windows.HorizontalAlignment.Right; // устанавливаем привязку по горизонтали
                button1.VerticalAlignment = System.Windows.VerticalAlignment.Top; // устанавливаем привязку по вертикали
                button1.Margin = new Thickness(0, 10, 110, 0); // устанавливаем отступы
                button1.Width = 45; // устанавливаем ширину
                button1.Background = Brushes.White; // устанавливаем цвет
                button1.Foreground = (Brush)bc.ConvertFrom("#FFDD3333"); // устанавливаем цвет текста
                button1.Tag = i; // запоминаем id элемента в теге
                button1.Click += delegate
                {
                    price.Content = "Цена: " + dishs[int.Parse(button1.Tag.ToString())].sizes[0].price + " р."; // обновляем цену
                    wes.Content = "Вес: " + dishs[int.Parse(button1.Tag.ToString())].sizes[0].wes + " г."; // обновляем вес
                    button1.Background = Brushes.White; // изменяем цвет
                    button1.Foreground = (Brush)bc.ConvertFrom("#FFDD3333"); // изменяем цвет текста

                    button2.Background = (Brush)bc.ConvertFrom("#FFDD3333"); // изменяем цвет
                    button2.Foreground = Brushes.White; // изменяем цвет текста
                    button3.Background = (Brush)bc.ConvertFrom("#FFDD3333"); // изменяем цвет
                    button3.Foreground = Brushes.White; // изменяем цвет текста

                    dishs[int.Parse(button1.Tag.ToString())].activeSize = 0; // запоминаем активный размер
                    count.Text = dishs[int.Parse(button1.Tag.ToString())].sizes[0].countOrder.ToString(); // изменяем стоимость блюда
                    order.IsChecked = dishs[int.Parse(button1.Tag.ToString())].sizes[0].orders; // Снимаем галочку выбора блюда
                };
                global.Children.Add(button2);
                button3.Content = dishs[i].sizes[2].size + " см."; // устанавливаем текст
                button3.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                button3.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                button3.Margin = new Thickness(0, 10, 10, 0);
                button3.Width = 45;
                button3.Tag = i; // запоминаем id элемента в тег
                button3.Click += delegate
                {
                        price.Content = "Цена: " + dishs[int.Parse(button2.Tag.ToString())].sizes[2].price + " р."; // обновляем цену
                        wes.Content = "Вес: " + dishes[int.Parse(button2.Tag.ToString())].sizes[2].wes + " г."; // обновляем вес
                        button3.Background = Brushes.White; // изменяем цвет
                        button3.Foreground = (Brush)bc.ConvertFrom("#FFD03333"); // изменяем цвет текста

                        button1.Background = (Brush)bc.ConvertFrom("#FFD03333"); // изменяем цвет
                        button1.Foreground = Brushes.White; // изменяем цвет текста
                        button2.Background = (Brush)bc.ConvertFrom("#FFD03333"); // изменяем цвет
                        button2.Foreground = Brushes.White; // изменяем цвет текста

                        dishs[int.Parse(button1.Tag.ToString())].activeSize = 2; // запоминаем активный размер
                        count.Text = dishs[int.Parse(button1.Tag.ToString())].sizes[2].countOrder.ToString(); // изменяем стоимость блюда
                        order.IsChecked = dishs[int.Parse(button1.Tag.ToString())].sizes[2].orders; // Снимаем галочку выбора блюда
                    
                };
                global.Children.Add(button3);

                minus.Content = "-"; // устанавливаем текст
                minus.HorizontalAlignment = System.Windows.HorizontalAlignment.Right; // устанавливаем привязку по горизонтали
                minus.VerticalAlignment = System.Windows.VerticalAlignment.Bottom; // устанавливаем привязку по вертикали
                minus.Margin = new Thickness(0, 0, 103.6f, 10); // устанавливаем отступы
                minus.Width = 19; // устанавливаем ширину
                minus.Tag = i; // запоминаем id элемента в тег
                minus.Click += delegate // назначаем действие
                {
                    if (count.Text != "") // если текст не равен пустоте
                    {
                        if (int.Parse(count.Text) > 0) // если кол-во заказанных пиц больше 0
                        {
                            count.Text = (int.Parse(count.Text) - 1).ToString(); // вычитаем

                            int id = int.Parse(minus.Tag.ToString()); // Преобразуем ID
                            dishs[id].sizes[dishs[id].activeSize].countOrder = int.Parse(count.Text); // уменьшаем количество
                        }
                    }
                };
                global.Children.Add(minus); // добавляем в элемент Grid

                count.Text = "0"; // устанавливаем текст
                count.HorizontalAlignment = System.Windows.HorizontalAlignment.Right; // устанавливаем привязку по горизонтали
                count.VerticalAlignment = System.Windows.VerticalAlignment.Bottom; // устанавливаем привязку по вертикали
                count.Margin = new Thickness(0, 0, 33.6f, 10); // устанавливаем отступы
                count.TextWrapping = TextWrapping.Wrap; // выравниваем текст
                count.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center; // выравниваем текст
                count.Width = 65; // устанавливаем ширину
                count.Height = 19; // устанавливаем высоту
                count.Tag = i; // запоминаем id элемента в тег
                global.Children.Add(count); // добавляем в элемент Grid

                plus.Content = "+"; // устанавливаем текст
                plus.HorizontalAlignment = System.Windows.HorizontalAlignment.Right; // устанавливаем привязку по горизонтали
                plus.VerticalAlignment = System.Windows.VerticalAlignment.Bottom; // устанавливаем привязку по вертикали
                plus.Margin = new Thickness(0, 0, 9.6f, 10); // устанавливаем отступы
                plus.Width = 19; // устанавливаем ширину
                plus.Tag = i; // запоминаем id элемента в тег
                plus.Click += delegate // назначаем действие
                {
                    if (count.Text != "") // если текст не равен пустоте
                    {
                        if (int.Parse(count.Text) < 15) // если кол-во заказанных пиц меньше 15
                        {
                            count.Text = (int.Parse(count.Text) + 1).ToString(); // прибавляем

                            int id = int.Parse(plus.Tag.ToString()); // Преобразуем ID
                            dishs[id].sizes[dishs[id].activeSize].countOrder = int.Parse(count.Text); // уменьшаем кол-во заказанных блюд
                        }
                    }
                };
                global.Children.Add(plus); // добавляем в элемент Grid

                order.Content = "Выбрать"; // устанавливаем текст
                order.HorizontalAlignment = System.Windows.HorizontalAlignment.Right; // устанавливаем привязку по горизонтали
                order.VerticalAlignment = System.Windows.VerticalAlignment.Bottom; // устанавливаем привязку по вертикали
                order.Margin = new Thickness(0, 0, 128, 13); // устанавливаем отступы
                order.Tag = i; // запоминаем id элемента в тег
                order.Click += delegate // назначаем действие
                {
                    int id = int.Parse(order.Tag.ToString()); // Преобразуем ID
                    dishs[id].sizes[dishs[id].activeSize].orders = (bool)order.IsChecked; // уменьшаем кол-во заказанных блюд
                };
                global.Children.Add(order); // добавляем в элемент Grid

                parent.Children.Add(global); // добавляем в элемент родителя
            }
        }
    }
}
