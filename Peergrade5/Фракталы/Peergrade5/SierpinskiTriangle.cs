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
    /// Треугольник Серпинского
    /// </summary>
    class SierpinskiTriangle : Fractal
    {
        public SierpinskiTriangle()
        {
            RecMax = 7;
        }

        /// <summary>
        /// Переопределенный метод для рисования Треугольника Серпинского.
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
        /// <param name="side">Длина отрезка</param>
        /// <param name="angle">Основной угол</param>
        /// <param name="leftAngle">Левый угол</param>
        /// <param name="rightAngle">Правый угол</param>
        /// <param name="step">Шаг рекурсии</param>
        /// <param name="count">Количество пройденных шагов</param>
        public override void DrawFractal(Canvas can, double width, double height, double x1, double y1, double x2, double y2, double x3, double y3, double side, double angle, double leftAngle, double rightAngle, int step, int count)
        {
            if(step > RecMax)
            {
                step = RecMax;
                MessageBox.Show($"Превышена максимальная глубина рекурсии. На экран будет выведен фрактал с глубиной рекурсии, равной {RecMax}");
            }
            if (step > 0)
            {
                Line line1 = new Line(), line2 = new Line(), line3 = new Line();

                line1.X1 = x1;
                line1.X2 = x2;
                line1.Y1 = y1;
                line1.Y2 = y2;
                line1.Stroke = Brushes.Blue;
                line1.StrokeThickness = 5;
                can.Children.Add(line1);
                line2.X1 = x2;
                line2.X2 = x3;
                line2.Y1 = y2;
                line2.Y2 = y3;
                line2.Stroke = Brushes.Blue;
                line2.StrokeThickness = 5;
                can.Children.Add(line2);
                line3.X1 = x3;
                line3.X2 = x1;
                line3.Y1 = y3;
                line3.Y2 = y1;
                line3.Stroke = Brushes.Blue;
                line3.StrokeThickness = 5;
                can.Children.Add(line3);
                DrawFractal(can, width, height, x1, y1, (x2 + x1) / 2, (y2 + y1) / 2, (x3 + x1) / 2, y1, side, angle, leftAngle, rightAngle, step - 1, count);
                DrawFractal(can, width, height, (x1 + x2) / 2, (y2 + y1) / 2, x2, y2, (x2 + x3) / 2, (y2 + y3) / 2, side, angle, leftAngle, rightAngle, step - 1, count);
                DrawFractal(can, width, height, (x3 + x1) / 2, y3, (x2 + x3) / 2, (y2 + y3) / 2, x3, y3, side, angle, leftAngle, rightAngle, step - 1, count);
            }
        }
    }
}
