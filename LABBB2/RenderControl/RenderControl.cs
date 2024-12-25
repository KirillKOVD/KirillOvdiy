using System;
using System.Drawing;

namespace LABBB2
{
    public partial class RenderControl : OpenGL
    {
        public RenderControl()
        {
            InitializeComponent();
        }

        float a = 0.2f; // Размер квадрата

        private void ONRENDER(object sender, EventArgs e)
        {
            glClear(GL_COLOR_BUFFER_BIT);
            glClearColor(0.5f, 0.5f, 0.5f, 0f);
            glLoadIdentity();
            glViewport(0, 0, Width, Height); // Установите правильный вид

            // Рисуем желтый квадрат
            glPushMatrix();
            glColor3f(1, 1, 0); // Желтый
            glTranslatef(-a, -a, 0); // Центрируйте квадрат
            DrawSquare();
            glPopMatrix();

            // Рисуем треугольники
            DrawColoredTriangles();
        }

        private void DrawSquare()
        {
            glBegin(GL_QUADS);
            glVertex2f(-a, -a);
            glVertex2f(a, -a);
            glVertex2f(a, a);
            glVertex2f(-a, a);
            glEnd();
        }

        private void DrawColoredTriangles()
        {
            float triangleHeight = a * (float)Math.Sqrt(3) / 2; // Высота треугольника


            // Нижний треугольник (зеленый)
            glPushMatrix();
            glColor3f(0, 1, 0); // Зеленый
            glTranslatef(-0.2f, 0.17f, 0); // Положение ниже квадрата
            glRotatef(0, 0, 0, 1); // Поворот на 180 градусов
            DrawTriangle();
            glPopMatrix();

            // Левый верхний треугольник (зеленый)
            glPushMatrix();
            glColor3f(0, 1, 0); // Зеленый
            glTranslatef(-0.2f, -0.57f, 0); // Положение слева выше квадрата
            glRotatef(180, 0, 0, 1); // Поворот на 180 градусов
            DrawTriangle();
            glPopMatrix();

            // Левый нижний треугольник (синий)
            glPushMatrix();
            glColor3f(0, 0, 1); // Синий
            glTranslatef(0, -0.4f, 0); // Положение слева ниже квадрата
            glRotatef(0, 0, 0, 1); // Поворот на -60 градусов
            DrawTriangle();
            glPopMatrix();

            // Правый верхний треугольник (синий)
            glPushMatrix();
            glColor3f(0, 0, 1); // Синий
            glTranslatef(0, 0, 0); // Положение справа выше квадрата
            glRotatef(180, 0, 0, 1); // Поворот на -60 градусов
            DrawTriangle();
            glPopMatrix();

           
        }

        private void DrawTriangle()
        {
            glBegin(GL_TRIANGLES);
            glVertex2f(0, 0);
            glVertex2f(-a, -a * (float)Math.Sqrt(3) / 2);
            glVertex2f(a, -a * (float)Math.Sqrt(3) / 2);
            glEnd();
        }
    }
}