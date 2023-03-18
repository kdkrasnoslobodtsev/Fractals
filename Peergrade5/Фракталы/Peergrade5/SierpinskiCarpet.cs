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
    /// Ковёр Серпинскоо
    /// </summary>
    class SierpinskiCarpet : Fractal
    {
        /// <summary>
        /// Конструктор Ковра Серпинского.
        /// </summary>
        public SierpinskiCarpet()
        {
            RecMax = 6;
        }

        /// <summary>
        /// Переопределенный метод для рисования Ковра Серпинского.
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
            if (step > RecMax)
            {
                step = RecMax;
                MessageBox.Show($"Превышена максимальная глубина рекурсии. На экран будет выведен фрактал с глубиной рекурсии, равной {RecMax}");
            }
            if (step > 0)
            {
                if (count == 0)
                {
                    Rectangle rect = new Rectangle();
                    rect.Width = width;
                    rect.Height = height;
                    rect.Fill = Brushes.Blue;
                    rect.Margin = new Thickness(0, 0, 0, 0);
                    can.Children.Add(rect);
                    DrawFractal(can, width, height, x1, y1, x2, y2, x3, y3, side, angle, leftAngle, rightAngle, step, count + 1);
                }
                else
                {
                    Rectangle rectWh = new Rectangle();
                    rectWh.Width = width / 3;
                    rectWh.Height = height / 3;
                    rectWh.Fill = Brushes.White;
                    rectWh.Margin = new Thickness(x1, y1, 0, 0);
                    can.Children.Add(rectWh);
                    DrawFractal(can, rectWh.Width, rectWh.Height, x1 - 2 * rectWh.Width / 3, y1 - 2 * rectWh.Height / 3, x2, y2, x3, y3, side, angle, leftAngle, rightAngle, step - 1, count + 1);
                    DrawFractal(can, rectWh.Width, rectWh.Height, x1 + rectWh.Width / 3, y1 - 2 * rectWh.Height / 3, x2, y2, x3, y3, side, angle, leftAngle, rightAngle, step - 1, count);
                    DrawFractal(can, rectWh.Width, rectWh.Height, x1 + 4 * rectWh.Width / 3, y1 - 2 * rectWh.Height / 3, x2, y2, x3, y3, side, angle, leftAngle, rightAngle, step - 1, count);
                    DrawFractal(can, rectWh.Width, rectWh.Height, x1 + 4 * rectWh.Width / 3, y1 + rectWh.Height / 3, x2, y2, x3, y3, side, angle, leftAngle, rightAngle, step - 1, count);
                    DrawFractal(can, rectWh.Width, rectWh.Height, x1 + 4 * rectWh.Width / 3, y1 + 4 * rectWh.Height / 3, x2, y2, x3, y3, side, angle, leftAngle, rightAngle, step - 1, count);
                    DrawFractal(can, rectWh.Width, rectWh.Height, x1 + rectWh.Width / 3, y1 + 4 * rectWh.Height / 3, x2, y2, x3, y3, side, angle, leftAngle, rightAngle, step - 1, count);
                    DrawFractal(can, rectWh.Width, rectWh.Height, x1 - 2 * rectWh.Width / 3, y1 + 4 * rectWh.Height / 3, x2, y2, x3, y3, side, angle, leftAngle, rightAngle, step - 1, count);
                    DrawFractal(can, rectWh.Width, rectWh.Height, x1 - 2 * rectWh.Width / 3, y1 + rectWh.Height / 3, x2, y2, x3, y3, side, angle, leftAngle, rightAngle, step - 1, count);
                }
            }
        }
    }
}
