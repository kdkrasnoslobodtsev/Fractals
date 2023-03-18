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
    /// Дерево Пифагора
    /// </summary>
    class PyphagorasTree : Fractal
    {
        /// <summary>
        /// Конструктор Дерева Пифагора.
        /// </summary>
        public PyphagorasTree()
        {
            RecMax = 15;
        }

        /// <summary>
        /// Переопределенный метод для рисования Дерево Пифагора.
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
            if(x2 <= 0 || x2 > 1 || leftAngle < 0 || leftAngle > 180 || rightAngle < 0 || rightAngle > 180)
            {
                throw new ArgumentException("Некорректно введенные данные.");
            }
            if (step > RecMax)
            {
                step = RecMax;
                MessageBox.Show($"Превышена максимальная глубина рекурсии. На экран будет выведен фрактал с глубиной рекурсии, равной {RecMax}");
            }
            if (step > 0)
            {
                side *= x2;
                double xnew = Math.Round(x1 + side * Math.Cos(angle)), ynew = Math.Round(y1 - side * Math.Sin(angle));
                Line myLine = new Line();
                myLine.Stroke = Brushes.Black;
                myLine.X1 = x1;
                myLine.X2 = xnew;
                myLine.Y1 = y1;
                myLine.Y2 = ynew;
                myLine.StrokeThickness = 2;
                can.Children.Add(myLine);
                x1 = xnew;
                y1 = ynew;
                DrawFractal(can, width, height, x1, y1, x2, y2, x3, y3, side, angle + leftAngle, leftAngle, rightAngle, step - 1, count);
                DrawFractal(can, width, height, x1, y1, x2, y2, x3, y3, side, angle - rightAngle, leftAngle, rightAngle, step - 1, count);
            }
        }
    }
}
