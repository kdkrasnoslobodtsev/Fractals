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
    /// Кривая Коха.
    /// </summary>
    class KochSnow : Fractal
    {
        /// <summary>
        /// Конструктор Кривой Коха.
        /// </summary>
        public KochSnow()
        {
            RecMax = 8;
        }

        /// <summary>
        /// Переопределенный метод для рисования первого шага Кривой Коха.
        /// </summary>
        /// <param name="can">Холст, на котором рисуется фрактал</param>
        /// <param name="width">Ширина</param>
        /// <param name="height">Высота</param>
        /// <param name="x1">Координата x 1 точки</param>
        /// <param name="y1">Координата y 1 точки</param>
        /// <param name="x2">Координата x 2 точки</param>
        /// <param name="y2">Координата y 2 точки</param>
        /// <param name="x3">Координата x 3 точки</param>
        /// <param name="y3">Координата y 3 точки</param>
        /// <param name="a">Длина отрезка</param>
        /// <param name="angle">Основной угол</param>
        /// <param name="leftAngle">Левый угол</param>
        /// <param name="rightAngle">Правый угол</param>
        /// <param name="step">Шаг рекурсии</param>
        /// <param name="count">Количество пройденных шагов</param>
        public override void DrawFractal(Canvas can, double width, double height, double x1, double y1, double x2, double y2, double x3, double y3, double a, double angle, double leftAngle, double rightAngle, int step, int count)
        {
            //Определим координаты исходного треугольника
            Line l = new Line();
            l.X1 = 30;
            l.X2 = 600;
            l.Y1 = 200;
            l.Y2 = 200;
            l.Stroke = Brushes.Black;
            //Зарисуем треугольник
            can.Children.Add(l);

            //Вызываем функцию Fractal для того, чтобы
            //нарисовать три кривых Коха на сторонах треугольника
            DrawCoh(can, l.X1, l.Y1, l.X2, l.Y2, 350, 400, step);
        }

        /// <summary>
        /// Метод для рисование Кривой Коха.
        /// </summary>
        /// <param name="can">Холст, на котором рисуется фрактал</param>
        /// <param name="x1">Координата x 1 точки</param>
        /// <param name="y1">Координата y 1 точки</param>
        /// <param name="x2">Координата x 2 точки</param>
        /// <param name="y2">Координата y 2 точки</param>
        /// <param name="x3">Координата x 3 точки</param>
        /// <param name="y3">Координата y 3 точки</param>
        /// <param name="step">Шаг рекурсии</param>
        public void DrawCoh(Canvas can, double x1, double y1, double x2, double y2, double x3, double y3, int step)
        {
            if (step > RecMax)
            {
                step = RecMax;
                MessageBox.Show($"Превышена максимальная глубина рекурсии. На экран будет выведен фрактал с глубиной рекурсии, равной {RecMax}");
            }
            if (step > 0)
            {
                double x4 = (x2 + 2 * x1) / 3, y4 = (y2 + 2 * y1) / 3;
                double x5 = (2 * x2 + x1) / 3, y5 = (y1 + 2 * y2) / 3;
                double xs = (x2 + x1) / 2, ys = (y2 + y1) / 2;
                double xn = (4 * xs - x3) / 3, yn = (4 * ys - y3) / 3;
                Line line1 = new Line(), line2 = new Line(), line3 = new Line();
                line1.X1 = x4;
                line1.Y1 = y4;
                line1.X2 = xn;
                line1.Y2 = yn;
                line1.Stroke = Brushes.Black;
                can.Children.Add(line1);
                line2.X1 = x5;
                line2.Y1 = y5;
                line2.X2 = xn;
                line2.Y2 = yn;
                line2.Stroke = Brushes.Black;
                can.Children.Add(line2);
                line3.X1 = x4;
                line3.Y1 = y4;
                line3.X2 = x5;
                line3.Y2 = y5;
                line3.Stroke = Brushes.White;
                line3.StrokeThickness = 2;
                can.Children.Add(line3);
                DrawCoh(can, x4, y4, xn, yn, x5, y5, step - 1);
                DrawCoh(can, xn, yn, x5, y5, x4, y4, step - 1);
                DrawCoh(can, x1, y1, x4, y4, (2 * x1 + x3) / 3, (2 * y1 + y3) / 3, step - 1);
                DrawCoh(can, x5, y5, x2, y2, (2 * x2 + x3) / 3, (2 * y2 + y3) / 3, step - 1);
            }
        }
    }
}
