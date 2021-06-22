using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcessoRemotoInterface.Conexao;
using MySql.Data.MySqlClient;

using static AcessoRemotoInterface.Configuracao.Configuracao;

namespace AcessoRemotoInterface.Utils
{
    static class CapturaDeTela
    {

        static private int telaX = Screen.PrimaryScreen.Bounds.Width;
        static private int telaY = Screen.PrimaryScreen.Bounds.Height;

        //static private Bitmap bitmap = new Bitmap(telaX, telaY);
        //static private Graphics graphics;


        static public void CapturarTela()
        {
            Icon icon = new Icon("C:\\chrystyan\\acessoremoto\\cursor.ico");
            Bitmap bitmap = new Bitmap(telaX, telaY);
            Graphics graphics;

            graphics = Graphics.FromImage(bitmap);
            
            graphics.CopyFromScreen(Point.Empty, Point.Empty, Screen.PrimaryScreen.Bounds.Size);
            graphics.DrawIcon(icon, Cursor.Position.X, Cursor.Position.Y);

            ConverterBitmapToBytes(bitmap);
            
            graphics.Dispose();
            bitmap.Dispose();

            graphics = null;
            bitmap = null;
        }

        static public void ConverterBitmapToBytes(Image imagem)
        {
            var imagemBytes = new MemoryStream();


            ImageCodecInfo codec = ImageCodecInfo.GetImageEncoders().First(enc => enc.FormatID == ImageFormat.Jpeg.Guid);

            EncoderParameters imgParams = new EncoderParameters(1);

            imgParams.Param = new[] { new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 15L) };
            //Salvar a imagem a imagem
            imagem.Save(imagemBytes, codec, imgParams);


            //imagem.Save(imagemBytes, ImageFormat.Jpeg);
            
            ClienteToDB.EnviarCaptura(imagemBytes.ToArray());
        }

        static public Stream ConverterBytesToStream()
        {
            byte[] imagemByte = ControlerToDB.ReceberCaptura();

            return new MemoryStream(imagemByte);
        }
    }
}
