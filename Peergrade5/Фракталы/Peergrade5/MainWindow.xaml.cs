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

namespace Peergrade5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int fractNum = -1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Button_Click_1(sender, e);
        }

        /// <summary>
        /// Выбор Дерева Пифагора.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fractNum = 0;
            Tree.BorderBrush = Brushes.Black;
            Koch.BorderBrush = Brushes.White;
            Carpet.BorderBrush = Brushes.White;
            Triangle.BorderBrush = Brushes.White;
            Kantor.BorderBrush = Brushes.White;
            Rec.Text = String.Empty;
        }

        /// <summary>
        /// Выбор Кривой Коха
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация события</param>
        private void Koch_Click(object sender, RoutedEventArgs e)
        {
            fractNum = 1;
            Tree.BorderBrush = Brushes.White;
            Koch.BorderBrush = Brushes.Black;
            Carpet.BorderBrush = Brushes.White;
            Triangle.BorderBrush = Brushes.White;
            Kantor.BorderBrush = Brushes.White;
            Rec.Text = String.Empty;
        }

        /// <summary>
        /// Выбор Ковра Серпинского
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация события</param>
        private void Carpet_Click(object sender, RoutedEventArgs e)
        {
            fractNum = 2;
            Tree.BorderBrush = Brushes.White;
            Koch.BorderBrush = Brushes.White;
            Carpet.BorderBrush = Brushes.Black;
            Triangle.BorderBrush = Brushes.White;
            Kantor.BorderBrush = Brushes.White;
            Rec.Text = String.Empty;
        }

        /// <summary>
        /// Выбор Треугольника Серпинского
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация события</param>
        private void Triangle_Click(object sender, RoutedEventArgs e)
        {
            fractNum = 3;
            Tree.BorderBrush = Brushes.White;
            Koch.BorderBrush = Brushes.White;
            Carpet.BorderBrush = Brushes.White;
            Triangle.BorderBrush = Brushes.Black;
            Kantor.BorderBrush = Brushes.White;
            Rec.Text = String.Empty;
        }

        /// <summary>
        /// Выбор Множества Кантора
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация события</param>
        private void Kantor_Click(object sender, RoutedEventArgs e)
        {
            fractNum = 4;
            Tree.BorderBrush = Brushes.White;
            Koch.BorderBrush = Brushes.White;
            Carpet.BorderBrush = Brushes.White;
            Triangle.BorderBrush = Brushes.White;
            Kantor.BorderBrush = Brushes.Black;
            Rec.Text = String.Empty;
        }

        /// <summary>
        /// Нажатие кнопки Нарисовать
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация события</param>
        private void Draw_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(Rec.Text == String.Empty)
                {
                    return;
                }
                switch (fractNum)
                {
                    case 0:
                        Canvas.Children.Clear();
                        PyphagorasTree fr0 = new PyphagorasTree();
                        fr0.DrawFractal(Canvas, 0, 0, 300, 400, double.Parse(Koef.Text), 0, 0, 0, 100, Math.PI / 2, Math.PI * double.Parse(leftAngle.Text) / 180, Math.PI * double.Parse(rightAngle.Text) / 180, int.Parse(Rec.Text), 0);
                        break;
                    case 1:
                        Canvas.Children.Clear();
                        KochSnow fr1 = new KochSnow();
                        fr1.DrawFractal(Canvas, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, int.Parse(Rec.Text), 0);
                        break;
                    case 2:
                        Canvas.Children.Clear();
                        SierpinskiCarpet fr2 = new SierpinskiCarpet();
                        fr2.DrawFractal(Canvas, 600, 600, 200, 200, 0, 0, 0, 0, 0, 0, 0, 0, int.Parse(Rec.Text), 0);
                        break;
                    case 3:
                        Canvas.Children.Clear();
                        SierpinskiTriangle fr3 = new SierpinskiTriangle();
                        fr3.DrawFractal(Canvas, 0, 0, 50, 400, 250, 53.59, 450, 400, 0, 0, 0, 0, int.Parse(Rec.Text), 0);
                        break;
                    case 4:
                        Canvas.Children.Clear();
                        CantorSet fr4 = new CantorSet();
                        fr4.DrawFractal(Canvas, 0, 0, 50, 50, 480, 50, 0, double.Parse(Distance.Text), 0, 0, 0, 0, int.Parse(Rec.Text), 0);
                        break;
                    default:
                        MessageBox.Show("Вы не выбрали фрактал");
                        Rec.Text = Koef.Text= leftAngle.Text = rightAngle.Text = String.Empty;
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"В ходе выполнения программы произошла ошибка. Откройте справку для выяснения причины. Сообщение ошибки:\n{ex.Message}");
                Rec.Text = String.Empty;
            }
        }

        /// <summary>
        /// Показывает информацию об использовании приложения.
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация события</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Добро пожаловать в приложение \"Фракталы\"\n" +
                "Здесь вы можете выбрать один из пяти фракталов для рисования:\n" +
                "1) Дерево Пифагора \n" +
                "Для его рисования следует нажать на кнопку \"Дерево Пифагора\". Важно!!! В первую очередь следует задать коэффициент и два угла, а уже после глубину рекурсии.\n" +
                "2) Кривая Коха\n" +
                "Для её рисования следует нажать на кнопку \"Кривая Коха\". Для нее требуется задать только глубину рекурсии" +
                "3) Ковёр Серпинского\n" +
                "Для его рисования следует нажать на кнопку \"Ковёр Серпинского\". Для нее требуется задать только глубину рекурсии\n" +
                "4) Треугольник Серпинского\n" +
                "Для его рисования следует нажать на кнопку \"Треугольник Серпинского\". Для нее требуется задать только глубину рекурсии\n" +
                "5) Множество Кантора\n" +
                "Для его рисования следует нажать на кнопку \"Множество Кантора\". Важно!!! В первую очередь следует задать расстояние между итерациями, а уже после глубину рекурсии\n" +
                "При изменении значения в поле \"Глубина рекурсии\" фрактал будет перерисован автоматически\n" +
                "При нажатии на кнопку \"Справка\" вы можете увидеть эту информацию еще раз\n" +
                "Углы принадлежит отрезку [0; 180]\n" +
                "Коэффициент принадлежит полуинтервалу (0; 1]\n" +
                "Удачи!!!");
        }
    }
}
