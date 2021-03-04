using System.Drawing;
using System;
using System.Collections.Generic;

namespace ImageProcess
{
    public class ImageGenerate : ImageEditor
    {

        public override void SetMode(MODE m) {
            switch (m)
            {
                case MODE.None:
                    mouseMode = MODE.None;
                    break;
                case MODE.Threshold:
                    break;
                case MODE.Draw:
                    mouseMode = MODE.Draw;
                    break;
                case MODE.Move:
                    break;
                case MODE.Warp:
                    break;
                case MODE.WarpNearest:
                    break;
            }
        }

        //
        //basic generation functions-------------------------------------------
        //


        /// <summary>
        /// This class function fills the base image with white.
        /// </summary>
        /// <param name="image">image to edit</param>
        public static void FillWhite(Image image)
        {
            for (int r = 0; r < image.BaseImage.Height; r++)
            {
                // Looping over the columns of the array
                for (int c = 0; c < image.BaseImage.Width ; c++)
                {
                    image.BaseImage.SetPixel(c, r, Color.White);
                }
            }

        }

        public static void FillPostWhite(Image image)
        {
            for (int r = 0; r < image.PostImage.Height; r++)
            {
                // Looping over the columns of the array
                for (int c = 0; c < image.PostImage.Width; c++)
                {
                    image.PostImage.SetPixel(c, r, Color.White);
                }
            }

        }

        public static void FillGreen(Image image)
        {
            for (int r = 0; r < image.BaseImage.Height; r++)
            {
                // Looping over the columns of the image
                for (int c = 0; c < image.BaseImage.Width; c++)
                {
                    image.BaseImage.SetPixel(c, r, Color.Green);
                }
            }
        }

        public static void FillCornflowerBlue(Image image)
        {
            for (int r = 0; r < image.BaseImage.Height; r++)
            {
                // Looping over the columns of the image
                for (int c = 0; c < image.BaseImage.Width; c++)
                {
                    image.BaseImage.SetPixel(c, r, Color.FromArgb(100, 149, 237));
                }
            }
        }

        public static void FillHorizontalGradient(Image image)
        {
            for (int r = 0; r < image.BaseImage.Height; r++)
            {
                for (int c = 0; c < image.BaseImage.Width; c++)
                {
                    byte value = (byte) ((float) c / (float) image.BaseImage.Width * 255);
                    Color newColor = Color.FromArgb(value, value, value);
                    image.BaseImage.SetPixel(c, r, newColor);
                }
            }
        }

        public static void FillVerticalBlueGradient(Image image)
        {
            for (int r = 0; r < image.BaseImage.Height; r++)
            {
                for (int c = 0; c < image.BaseImage.Width; c++)
                {
                    byte value = (byte)((float) r / (float)image.BaseImage.Height * 255);
                    Color newColor = Color.FromArgb(0, 0, (255-value));
                    image.BaseImage.SetPixel(c, r, newColor);
                }
            }
        }

        public static void FillDiagonalGradient(Image image)
        {
            for (int r = 0; r < image.BaseImage.Height; r++)
            {
                for (int c = 0; c < image.BaseImage.Width; c++)
                {
                    byte greenXValue = (byte)(127 - (float)c / (float)image.BaseImage.Width * 127);
                    byte redXValue = (byte)((float)c / (float)image.BaseImage.Width * 127);

                    byte redYValue = (byte)(127 - (float)r / (float)image.BaseImage.Height * 127);
                    byte greenYValue = (byte)((float)r / (float)image.BaseImage.Height * 127);

                    Color newColor = Color.FromArgb(255-(redXValue+redYValue), 255-(greenXValue+greenYValue), 0);
                    image.BaseImage.SetPixel(c, r, newColor);
                }
            }
        }

        public static void HorizontalLine(Image image)
        {
            int r = 100;

            for (int c = 0; c < image.BaseImage.Width; c++)
            {
                image.BaseImage.SetPixel(c, r, Color.Yellow);
            }
        }

        public static void VerticalLine(Image image)
        {
            int c = 100;

            for (int r = 0; r < image.BaseImage.Height; r++)
            {
                image.BaseImage.SetPixel(c, r, Color.Yellow);
                image.BaseImage.SetPixel(c+1, r, Color.Yellow);
            }
        }

        public static void DiagonalLine(Image image)
        {
            int r = 100;

            for (int c = 100; c < 400; c++)
            {
                image.BaseImage.SetPixel(c, r, Color.Yellow);

                if (c % 3 == 0)
                {
                    r++;
                }
            }
        }

        public static void Mono(Image image)
        {
            for (int r = 0; r < image.BaseImage.Height; r++)
            {
                for (int c = 0; c < image.BaseImage.Width; c++)
                {
                    Color p = image.BaseImage.GetPixel(c, r);
                    int avgVal = (p.R + p.G + p.B) / 3;
                    Color newColor = Color.FromArgb(avgVal, avgVal, avgVal);
                    image.BaseImage.SetPixel(c, r, newColor);
                }
            }
        }

        public static void Median(Image image)
        {
            int windowX, windowY, sumR, sumG, sumB;

            for (int r = 2; r < (image.BaseImage.Height - 2); r++)
            {
                for (int c = 2; c < (image.BaseImage.Width - 2); c++)
                {
                    sumR = sumG = sumB = 0;

                    for (windowY = r - 1; windowY <= (r + 1); windowY++) 
                    {
                        for (windowX = c - 1; windowX <= (c + 1); windowX++)
                        {
                            Color p = image.BaseImage.GetPixel(windowX, windowY);
                            sumR += p.R;
                            sumG += p.G;
                            sumB += p.B;
                        }
                    }

                    sumR /= 9;
                    sumG /= 9;
                    sumB /= 9;

                    image.PostImage.SetPixel(c, r, Color.FromArgb(sumR, sumG, sumB));
                }
            }
        }

        private static int ClampColorElem(double val)
        {
            return (int)Math.Max(Math.Min(val, 255), 0);
        }

        private static Color Kernel(int x, int y, Image image, int[] kernel)
        {
            // im so so sorry
            if (kernel.Length == 9)
            {
                int rVal, gVal, bVal;
                rVal = gVal = bVal = 0;

                int kernelVal;

                for (int r = -1; r <= 1; r++)
                {
                    for (int c = -1; c <= 1; c++)
                    {
                        kernelVal = kernel[(3 * (r + 1)) + (c + 1)];
                        Color p = image.BaseImage.GetPixel(x - c, y - r);
                        rVal += (p.R * kernelVal);
                        gVal += (p.G * kernelVal);
                        bVal += (p.B * kernelVal);
                    }
                }

                rVal = ClampColorElem(rVal);
                gVal = ClampColorElem(gVal);
                bVal = ClampColorElem(bVal);

                return Color.FromArgb(rVal, gVal, bVal);
            } else
            {
                int rVal, gVal, bVal;
                rVal = gVal = bVal = 0;

                int kernelVal;

                for (int r = -2; r <= 2; r++)
                {
                    for (int c = -2; c <= 2; c++)
                    {
                        kernelVal = kernel[(5 * (r + 2)) + (c + 2)];
                        Color p = image.BaseImage.GetPixel(x - c, y - r);
                        rVal += (p.R * kernelVal);
                        gVal += (p.G * kernelVal);
                        bVal += (p.B * kernelVal);
                    }
                }

                rVal = ClampColorElem(rVal);
                gVal = ClampColorElem(gVal);
                bVal = ClampColorElem(bVal);

                return Color.FromArgb(rVal, gVal, bVal);
            }
        }

        public static void Prewitt(Image image)
        {
            int[] x_kernel = {
                5, 8, 10, 8, 5,
                4, 10, 20, 10, 4,
                0, 0, 0, 0, 0,
                -4, -10, -20, -10, -4,
                -5, -8, -10, -8, -5
            };

            int[] y_kernel = {
                -5, -4, 0, 4, 5,
                -8, -10, 0, 10, 8,
                -10, -20, 0, 20, 10,
                -8, -10, 0, 10, 8,
                -5, -4, 0, 4, 5
            };

            for (int r = 2; r < (image.BaseImage.Height - 2); r++)
            {
                for (int c = 2; c < (image.BaseImage.Width - 2); c++)
                {
                    Color xCol = Kernel(c, r, image, x_kernel);
                    Color yCol = Kernel(c, r, image, y_kernel);

                    image.PostImage.SetPixel(c, r, euclideanDist(xCol, yCol));
                }
            }
        }

        public static void Sobel(Image image)
        {
            int[] x_kernel = {
                2, 2, 4, 2, 2,
                1, 1, 2, 1, 1,
                0, 0, 0, 0, 0,
                -1, -1, -2, -1, -1,
                -2, -2, -4, -2, -2
            };

            int[] y_kernel = {
                -2, -1, 0, 1, -2,
                -2, -1, 0, 1, -2,
                -4, -2, 0, 2, -4,
                -2, -1, 0, 1, -2,
                -2, -1, 0, 1, -2
            };

            for (int r = 2; r < (image.BaseImage.Height - 2); r++)
            {
                for (int c = 2; c < (image.BaseImage.Width - 2); c++)
                {
                    Color xCol = Kernel(c, r, image, x_kernel);
                    Color yCol = Kernel(c, r, image, y_kernel);

                    image.PostImage.SetPixel(c, r, euclideanDist(xCol, yCol));
                }
            }
        }

        public static void rotateImage(Image image, int degrees)
        {
            if (image == null) return;

            using (Graphics graphics = Graphics.FromImage(image.BaseImage))
            {
                graphics.TranslateTransform(image.BaseImage.Width / 2, image.BaseImage.Height / 2);
                graphics.RotateTransform(degrees);
                graphics.TranslateTransform(-image.BaseImage.Width / 2, -image.BaseImage.Height / 2);
                FillWhite(image);
                graphics.DrawImage(image.PostImage, new Point(0, 0));
            }
        }

        public static void flipHorizontally(Image image)
        {
            image.BaseImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

        public static void Translate(Image image, int x, int y)
        {
            if (image == null) return;

            FillPostWhite(image);
            
            for (int r = 1; r < image.BaseImage.Height; r++)
            {
                for (int c = 1; c < image.BaseImage.Width; c++)
                {
                    if (c+x < image.BaseImage.Width && c+x > 0 && r + y < image.BaseImage.Height && r + y > 0)
                    {
                        image.PostImage.SetPixel(c + x, r + y, image.BaseImage.GetPixel(c, r));
                    }
                }
            }
        }

        public static void Point(Image image)
        {
            if (image == null) return;

            FillPostWhite(image);

            // get random sample points
            Random r = new Random();
            int samples = (int) (0.2 * image.BaseImage.Width * image.BaseImage.Height);
            var coords = new List<Tuple<int, int>> {};

            for (int i = 0; i < samples; i++)
            {
                int randomX = r.Next(2, image.BaseImage.Width-2);
                int randomY = r.Next(2, image.BaseImage.Height-2);
                coords.Add(Tuple.Create(randomX, randomY));
            }

            for (int i = 0; i < samples; i++)
            {
                makePoint(image, image.BaseImage.GetPixel(coords[i].Item1, coords[i].Item2), coords[i].Item1, coords[i].Item2);
            }
        }

        private static void makePoint(Image image, Color fill, int x, int y)
        {
            for (int r = y-2; r <= y+2; r++)
            {
                for (int c = x-2; c <= x+2; c++)
                {
                    image.PostImage.SetPixel(c, r, fill);
                }
            }
        }

        public static void BlueScreen(Image image)
        {
            if (image == null) return;

            int a1 = 7;
            double a2 = 1;
            Bitmap mars = Properties.Resources.mars;

            for (int r = 1; r < image.BaseImage.Height; r++)
            {
                for (int c = 1; c < image.BaseImage.Width; c++)
                {
                    Color p = image.BaseImage.GetPixel(c, r);
                    int alpha = (int)(1 - a1 * (p.B - a2 * p.G));

                    Color newP;
                    if (alpha > 0)
                    {
                        newP = p;
                    } else
                    {
                        newP = mars.GetPixel(c, r);
                    }

                    image.PostImage.SetPixel(c, r, newP);
                }
            }
        }

        private static Color euclideanDist(Color xCol, Color yCol)
        {
            int rVal, gVal, bVal;
            rVal = gVal = bVal = 0;

            rVal = (int) Math.Sqrt(Math.Pow(xCol.R, 2) + Math.Pow(yCol.R, 2));
            gVal = (int) Math.Sqrt(Math.Pow(xCol.G, 2) + Math.Pow(yCol.G, 2));
            bVal = (int) Math.Sqrt(Math.Pow(xCol.B, 2) + Math.Pow(yCol.B, 2));

            rVal = ClampColorElem(rVal);
            gVal = ClampColorElem(gVal);
            bVal = ClampColorElem(bVal);

            return Color.FromArgb(rVal, gVal, bVal);
        }

        public static void Sharpen(Image image)
        {
            int[] kernel = { 0, -1, 0, -1, 5, -1, 0, -1, 0 };

            for (int r = 1; r < (image.BaseImage.Height - 1); r++)
            {
                for (int c = 1; c < (image.BaseImage.Width - 1); c++)
                {
                    image.PostImage.SetPixel(c, r, Kernel(c, r, image, kernel));
                }
            }
        }

        public static void RedChannelFilter(Image image)
        {
            for (int r = 1; r < (image.BaseImage.Height - 1); r++)
            {
                for (int c = 1; c < (image.BaseImage.Width - 1); c++)
                {
                    Color p = image.BaseImage.GetPixel(c, r);
                    image.PostImage.SetPixel(c, r, Color.FromArgb(p.R, 0, 0));
                }
            }
        }

        public static void Scale(Image image, double factor)
        {
            FillPostWhite(image);

            int xCenter = image.BaseImage.Width / 2;
            int yCenter = image.BaseImage.Height / 2;

            for (int r = 1; r < (image.BaseImage.Height - 1); r++)
            {
                for (int c = 1; c < (image.BaseImage.Width - 1); c++)
                {
                    Color p = image.BaseImage.GetPixel(c, r);
                    int newX = (int)(xCenter + (c - xCenter) * factor);
                    int newY = (int)(yCenter + (r - yCenter) * factor);
                    image.PostImage.SetPixel(newX, newY, p);
                }
            }
        }

        public static void Triangle(Image image)
        {
            FillPostWhite(image);

            int xCenter = image.BaseImage.Width / 2;
            int yCenter = image.BaseImage.Height / 2;

            double scale;

            for (int r = 0; r < image.BaseImage.Height; r++)
            {
                for (int c = 0; c < image.BaseImage.Width; c++)
                {   
                    scale = (r / ((double) image.BaseImage.Height + 0.01));
                    Console.WriteLine(scale);
                    Color p = image.BaseImage.GetPixel(c, r);
                    int newX = (int)(xCenter + ((c - xCenter) * scale));
                    int newY = (int)(yCenter + ((r - yCenter) * scale));
                    if (newX < image.BaseImage.Width && newX > 0 && newY < image.BaseImage.Height && newY > 0)
                    {
                        image.PostImage.SetPixel(newX, newY, p);
                    }
                }
            }
        }

        public static void ComposeRed(Image image)
        {
            Color red = Color.FromArgb(255, 0, 0);
            double alpha = 0.2;

            for (int r = 1; r < (image.BaseImage.Height - 1); r++)
            {
                for (int c = 1; c < (image.BaseImage.Width - 1); c++)
                {
                    Color p = image.BaseImage.GetPixel(c, r);
                    Color newP = Color.FromArgb(ClampColorElem((alpha * Color.Red.R) + p.R), p.G, p.B);

                    image.PostImage.SetPixel(c, r, newP);
                }
            }
        }

        /// <summary>
        /// This class function fills the base image with black.
        /// </summary>
        /// <param name="image">image to edit</param>
        public static void FillBlack(Image image)
        {
            for (int r = 0; r < image.BaseImage.Height; r++)
            {
                // Looping over the columns of the array
                for (int c = 0; c < image.BaseImage.Width; c++)
                {
                    image.BaseImage.SetPixel(c, r, Color.Black);
                }
            }

        }

        //
        // Mouse functions----------------------------------------------------
        //

        /// <summary>
        /// Draw a red dot at the given point onthe base image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void MousePress(Image image, int x, int y)
        {
            // We count the mouse clicks
            switch (mouseMode)
            {
                case MODE.Draw:
                    if(x< image.BaseImage.Width && y < image.BaseImage.Height)
                        image.BaseImage.SetPixel(x, y- image.Offset, Color.Red);
                    mouseMode = MODE.Move;
                    break;

            }
        }

        public override void MouseRelease()
        {
            if(mouseMode == MODE.Move)
                mouseMode = MODE.Draw;
        }

        /// <summary>
        /// Draw a red dot at the given point onthe base image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void MouseMove(Image image, int x, int y)
        {

            switch (mouseMode)
            {
                case MODE.Move:
                    if (x < image.BaseImage.Width && y < image.BaseImage.Height)
                        image.BaseImage.SetPixel(x, y- image.Offset, Color.Red);
                    break;
            }

        }
    }
}
