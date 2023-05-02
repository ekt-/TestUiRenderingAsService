using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SharedProject
{
    public static class SaveToImage
    {
        public static void TrySavingWpfControlAsPng()
        {
            var uiElement = new MyTestWpfUserControl();
            var renderSize = new Size(500, 150);
            var serviceOrInteractive = Environment.UserInteractive ? "user" : "service";
            var tempFileName = $"{Common.OutputFolder}\\RenderTest_{nameof(MyTestWpfUserControl)}_{serviceOrInteractive}.png";
            uiElement.RenderAndSaveAsPng(renderSize, tempFileName);
        }

        public static void TrySavingWinFormControlAsPng()
        {
            var control = new MyTestWinFormUserControl();

            using (var bmp = new System.Drawing.Bitmap(300, 200))
            {
                control.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));
                var serviceOrInteractive = Environment.UserInteractive ? "user" : "service";
                var tempFileName = $"{Common.OutputFolder}\\RenderTest_{nameof(MyTestWinFormUserControl)}_{serviceOrInteractive}.png";
                bmp.Save(tempFileName);
            }
        }


        private static void RenderAndSaveAsPng(this UIElement targetUiElement, Size renderSize, string outputPath)
        {
            targetUiElement.Measure(renderSize);
            targetUiElement.Arrange(new Rect(renderSize));
            targetUiElement.UpdateLayout();

            var data = GetPngImageDataWithRenderTarget(targetUiElement, 1);
            using (var stream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                stream.Write(data, 0, data.Length);
                stream.Flush();
                stream.Close();
            }
        }

        // todo: forcing 96 dpi should be an option
        private static byte[] GetPngImageDataWithRenderTarget(UIElement targetUiElement, double scale)
        {
            Byte[] imageArray;
            double actualHeight = targetUiElement.RenderSize.Height;
            double actualWidth = targetUiElement.RenderSize.Width;
            double renderHeight = actualHeight * scale;
            double renderWidth = actualWidth * scale;
            RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)renderWidth, (int)renderHeight, 96, 96, PixelFormats.Pbgra32);
            VisualBrush sourceBrush = new VisualBrush(targetUiElement);
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            using (drawingContext)
            {
                drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0), new Point(actualWidth, actualHeight)));
            }
            renderTarget.Render(drawingVisual);

            var pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(renderTarget));

            using (var outputStream = new MemoryStream())
            {
                pngEncoder.Save(outputStream);
                imageArray = outputStream.ToArray();
            }

            return imageArray;
        }

    }
}