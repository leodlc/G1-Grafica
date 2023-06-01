using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppGema
{
    class Gema
    {
        private float side;
        private SolidBrush brush;
        private Graphics mGraph;
        private Pen mPen, mPen2, mPen3, mPen4;

        public Gema() {
            side = 0;
            mPen = new Pen(Color.Black);
            mPen2 = new Pen(Color.Red);
            mPen3 = new Pen(Color.Blue);
            mPen4 = new Pen(Color.Yellow);
        }

        public void ReadData(TextBox txtSide) {
            try {
                side = float.Parse(txtSide.Text);
            } catch {
                MessageBox.Show("Ingreso no válido", "Mensaje de error");
            }
        }

        public void InitializeData(TextBox txtSide, PictureBox picCanvas) {
            txtSide.Text = "";
            txtSide.Focus();
            side = 0.0f;
            picCanvas.Refresh();
        }

        public PointF[] PuntosDecagonoMayor(PictureBox picCanvas) {

            mGraph = picCanvas.CreateGraphics();
            int centroX = picCanvas.Width / 2;
            int centroY = picCanvas.Height / 2;
            float radio = side / (2 * (float)Math.Sin(Math.PI / 10));

            PointF[] puntos = new PointF[10];

            for (int i = 0; i < 10; i++) {
                float angulo = (float)((2 * Math.PI / 10) * i);
                float x = centroX + radio * (float)Math.Cos(angulo);
                float y = centroY + radio * (float)Math.Sin(angulo);
                puntos[i] = new PointF(x, y);
            }
            return puntos;
        }

        public PointF[] PuntosDecagonoMedio(PictureBox picCanvas) {

            mGraph = picCanvas.CreateGraphics();
            int centroX = picCanvas.Width / 2;
            int centroY = picCanvas.Height / 2;

            // Coordenadas del decágono original
            PointF[] puntosDMayor = PuntosDecagonoMayor(picCanvas);

            // Coordenadas del decágono más pequeño
            PointF[] puntosDMedio = new PointF[10];

            for (int i = 0; i < 10; i++) {
                // Calcular los extremos de los lados del decágono original
                int sigIndice = (i + 1) % 10;
                float x1 = (puntosDMayor[i].X + puntosDMayor[sigIndice].X) / 2;
                float y1 = (puntosDMayor[i].Y + puntosDMayor[sigIndice].Y) / 2;

                // Calcular las coordenadas de los vértices del decágono más pequeño
                float nuevoX = centroX + (x1 - centroX) * 0.7f;
                float nuevoY = centroY + (y1 - centroY) * 0.7f;

                puntosDMedio[i] = new PointF(nuevoX, nuevoY);
            }
            return puntosDMedio;
        }

        public PointF[] PuntosDecagonoMenor(PictureBox picCanvas) {

            mGraph = picCanvas.CreateGraphics();
            int centroX = picCanvas.Width / 2;
            int centroY = picCanvas.Height / 2;
            float radio = side / (2 * (float)Math.Sin(Math.PI / 10));

            PointF[] puntosDMenor = new PointF[10];

            for (int i = 0; i < 10; i++) {
                float angulo = (float)((2 * Math.PI / 10) * i);
                float x = centroX + radio * (float)Math.Cos(angulo) * 0.35f;
                float y = centroY + radio * (float)Math.Sin(angulo) * 0.35f;
                puntosDMenor[i] = new PointF(x, y);
            }
            return puntosDMenor;
        }

        public void DibujarDecagonoMayor(PictureBox picCanvas) {

            mGraph = picCanvas.CreateGraphics();

            PointF[] puntosDMayor = PuntosDecagonoMayor(picCanvas);

            mGraph.DrawPolygon(mPen, puntosDMayor);

            mGraph.Dispose();
        }

        public void DibujarDecagonoMedio(PictureBox picCanvas) {

            mGraph = picCanvas.CreateGraphics();

            PointF[] puntosDMayor = PuntosDecagonoMayor(picCanvas);
            PointF[] puntosDMedio = PuntosDecagonoMedio(picCanvas);

            for (int i = 0; i < 10; i++) {
                mGraph.DrawLine(mPen4, puntosDMayor[i], puntosDMedio[i]);
            }

            mGraph.DrawLine(mPen4, puntosDMayor[0], puntosDMedio[0]);
            mGraph.DrawLine(mPen4, puntosDMayor[0], puntosDMedio[9]);
            mGraph.DrawLine(mPen4, puntosDMayor[9], puntosDMedio[8]);
            mGraph.DrawLine(mPen4, puntosDMayor[8], puntosDMedio[7]);
            mGraph.DrawLine(mPen4, puntosDMayor[7], puntosDMedio[6]);
            mGraph.DrawLine(mPen4, puntosDMayor[6], puntosDMedio[5]);
            mGraph.DrawLine(mPen4, puntosDMayor[5], puntosDMedio[4]);
            mGraph.DrawLine(mPen4, puntosDMayor[4], puntosDMedio[3]);
            mGraph.DrawLine(mPen4, puntosDMayor[3], puntosDMedio[2]);
            mGraph.DrawLine(mPen4, puntosDMayor[2], puntosDMedio[1]);
            mGraph.DrawLine(mPen4, puntosDMayor[1], puntosDMedio[0]);

            mGraph.DrawPolygon(mPen, puntosDMedio);

            mGraph.Dispose();
        }
             
        public void DibujarDecagonoMenor(PictureBox picCanvas) {

            mGraph = picCanvas.CreateGraphics();

            PointF[] puntosDMedio = PuntosDecagonoMedio(picCanvas);
            PointF[] puntosDMenor = PuntosDecagonoMenor(picCanvas);

            for (int i = 0; i < 10; i++) {
                mGraph.DrawLine(mPen4, puntosDMenor[i], puntosDMedio[i]);
            }

            mGraph.DrawLine(mPen4, puntosDMenor[0], puntosDMedio[9]);
            mGraph.DrawLine(mPen4, puntosDMenor[9], puntosDMedio[8]);
            mGraph.DrawLine(mPen4, puntosDMenor[8], puntosDMedio[7]);
            mGraph.DrawLine(mPen4, puntosDMenor[7], puntosDMedio[6]);
            mGraph.DrawLine(mPen4, puntosDMenor[6], puntosDMedio[5]);
            mGraph.DrawLine(mPen4, puntosDMenor[5], puntosDMedio[4]);
            mGraph.DrawLine(mPen4, puntosDMenor[4], puntosDMedio[3]);
            mGraph.DrawLine(mPen4, puntosDMenor[3], puntosDMedio[2]);
            mGraph.DrawLine(mPen4, puntosDMenor[2], puntosDMedio[1]);
            mGraph.DrawLine(mPen4, puntosDMenor[1], puntosDMedio[0]);

            mGraph.DrawPolygon(mPen, puntosDMenor);

            mGraph.Dispose();
        }

        public void PuntoFinal(PictureBox picCanvas) {

            mGraph = picCanvas.CreateGraphics();
            int centroX = picCanvas.Width / 2;
            int centroY = picCanvas.Height / 2;
        
            PointF puntoCentro = new PointF(centroX, centroY);

            PointF[] puntosDMenor = PuntosDecagonoMenor(picCanvas);

            for (int i = 0; i < 10; i++) {
                mGraph.DrawLine(mPen4, puntoCentro, puntosDMenor[i]);
            }
        }

        public void PintarPetalosP(PictureBox picCanvas) {

            brush = new SolidBrush(Color.Red);
            mGraph = picCanvas.CreateGraphics();

            PointF[] puntosDMayor = PuntosDecagonoMayor(picCanvas);
            PointF[] puntosDMedio = PuntosDecagonoMedio(picCanvas);
            PointF[] puntosDMenor = PuntosDecagonoMenor(picCanvas);

            PointF[] polPoints1 = { puntosDMayor[0], puntosDMedio[0], puntosDMenor[0], puntosDMedio[9] };
            PointF[] polPoints2 = { puntosDMayor[1], puntosDMedio[1], puntosDMenor[1], puntosDMedio[0] };
            PointF[] polPoints3 = { puntosDMayor[2], puntosDMedio[2], puntosDMenor[2], puntosDMedio[1] };
            PointF[] polPoints4 = { puntosDMayor[3], puntosDMedio[3], puntosDMenor[3], puntosDMedio[2] };
            PointF[] polPoints5 = { puntosDMayor[4], puntosDMedio[4], puntosDMenor[4], puntosDMedio[3] };
            PointF[] polPoints6 = { puntosDMayor[5], puntosDMedio[5], puntosDMenor[5], puntosDMedio[4] };
            PointF[] polPoints7 = { puntosDMayor[6], puntosDMedio[6], puntosDMenor[6], puntosDMedio[5] };
            PointF[] polPoints8 = { puntosDMayor[7], puntosDMedio[7], puntosDMenor[7], puntosDMedio[6] };
            PointF[] polPoints9 = { puntosDMayor[8], puntosDMedio[8], puntosDMenor[8], puntosDMedio[7] };
            PointF[] polPoints10 = { puntosDMayor[9], puntosDMedio[9], puntosDMenor[9], puntosDMedio[8] };

            // Pintar la región del decágono mayor
            mGraph.FillPolygon(new SolidBrush(Color.Yellow), polPoints1);
            mGraph.FillPolygon(new SolidBrush(Color.Yellow), polPoints2);
            mGraph.FillPolygon(new SolidBrush(Color.Yellow), polPoints3);
            mGraph.FillPolygon(new SolidBrush(Color.Yellow), polPoints4);
            mGraph.FillPolygon(new SolidBrush(Color.Yellow), polPoints5);
            mGraph.FillPolygon(new SolidBrush(Color.Yellow), polPoints6);
            mGraph.FillPolygon(new SolidBrush(Color.Yellow), polPoints7);
            mGraph.FillPolygon(new SolidBrush(Color.Yellow), polPoints8);
            mGraph.FillPolygon(new SolidBrush(Color.Yellow), polPoints9);
            mGraph.FillPolygon(new SolidBrush(Color.Yellow), polPoints10);

            mGraph.Dispose();
        }

        public void PintarPetalosS(PictureBox picCanvas) {

            int centroX = picCanvas.Width / 2;
            int centroY = picCanvas.Height / 2;

            brush = new SolidBrush(Color.Red);
            mGraph = picCanvas.CreateGraphics();

            PointF[] puntosDMedio = PuntosDecagonoMedio(picCanvas);
            PointF[] puntosDMenor = PuntosDecagonoMenor(picCanvas);
            PointF puntoCentro = new PointF(centroX, centroY);

            PointF[] polPoints1 = { puntosDMedio[0], puntosDMenor[0], puntoCentro, puntosDMenor[1] };
            PointF[] polPoints2 = { puntosDMedio[1], puntosDMenor[1], puntoCentro, puntosDMenor[2] };
            PointF[] polPoints3 = { puntosDMedio[2], puntosDMenor[2], puntoCentro, puntosDMenor[3] };
            PointF[] polPoints4 = { puntosDMedio[3], puntosDMenor[3], puntoCentro, puntosDMenor[4] };
            PointF[] polPoints5 = { puntosDMedio[4], puntosDMenor[4], puntoCentro, puntosDMenor[5] };
            PointF[] polPoints6 = { puntosDMedio[5], puntosDMenor[5], puntoCentro, puntosDMenor[6] };
            PointF[] polPoints7 = { puntosDMedio[6], puntosDMenor[6], puntoCentro, puntosDMenor[7] };
            PointF[] polPoints8 = { puntosDMedio[7], puntosDMenor[7], puntoCentro, puntosDMenor[8] };
            PointF[] polPoints9 = { puntosDMedio[8], puntosDMenor[8], puntoCentro, puntosDMenor[9] };
            PointF[] polPoints10 = { puntosDMedio[9], puntosDMenor[9], puntoCentro, puntosDMenor[0] };

            // Pintar la región del decágono mayor
            mGraph.FillPolygon(new SolidBrush(Color.YellowGreen), polPoints1);
            mGraph.FillPolygon(new SolidBrush(Color.BlueViolet), polPoints2);
            mGraph.FillPolygon(new SolidBrush(Color.YellowGreen), polPoints3);
            mGraph.FillPolygon(new SolidBrush(Color.BlueViolet), polPoints4);
            mGraph.FillPolygon(new SolidBrush(Color.YellowGreen), polPoints5);
            mGraph.FillPolygon(new SolidBrush(Color.BlueViolet), polPoints6);
            mGraph.FillPolygon(new SolidBrush(Color.YellowGreen), polPoints7);
            mGraph.FillPolygon(new SolidBrush(Color.BlueViolet), polPoints8);
            mGraph.FillPolygon(new SolidBrush(Color.YellowGreen), polPoints9);
            mGraph.FillPolygon(new SolidBrush(Color.BlueViolet), polPoints10);

            mGraph.Dispose();
        }

        // Función que cierra un formulario.
        public void CloseForm(Form ObjForm) {
            ObjForm.Close();
        }
    }
}
