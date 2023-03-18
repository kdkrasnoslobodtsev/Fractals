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
    /// Множество Кантора.
    /// </summary>
    class CantorSet : Fractal
    {
        /// <summary>
        /// Конструктор Множества Кантора.
        /// </summary>
        public CantorSet()
        {
            RecMax = 10;
        }

        /// <summary>
        /// Переопределенный метод для рисования Множества Кантора.
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
            if(y3 < 0)
            {
                throw new ArgumentException("Некорректно введенные данные");
            }
            if (step > RecMax)
            {
                step = RecMax;
                MessageBox.Show($"Превышена максимальная глубина рекурсии. На экран будет выведен фрактал с глубиной рекурсии, равной {RecMax}");
            }
            if (step > 0)
            {
                Line myLine = new Line();
                myLine.Stroke = Brushes.Black;
                myLine.X1 = x1;
                myLine.X2 = x2;
                myLine.Y1 = y1;
                myLine.Y2 = y2;
                myLine.StrokeThickness = 5;
                can.Children.Add(myLine);
                double ax, ay, bx, by;
                ax = x1 + (x2 - x1) / 3;
                ay = y1 + y3;
                bx = x2 - (x2 - x1) / 3;
                by = y2 + y3;
                y1 += y3;
                y2 += y3;
                DrawFractal(can, width, height, x1, y1, ax, ay, x3, y3, side, angle, leftAngle, rightAngle, step - 1, count);
                DrawFractal(can, width, height, bx, by, x2, y2, x3, y3, side, angle, leftAngle, rightAngle, step - 1, count);
            }
        }
    }
}
