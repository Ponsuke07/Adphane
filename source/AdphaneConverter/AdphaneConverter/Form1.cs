using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using System.IO;
namespace Cvsharp_test
{
    public partial class Form1 : Form
    {

        private IplImage originalImg;
        public Form1()
        {
            InitializeComponent();
        }

        private void file_select_Click(object sender, EventArgs e)
        {
            DialogResult dRet;

            OpenFileDialog ofd = new OpenFileDialog();
            if ((dRet = ofd.ShowDialog()) == DialogResult.OK)
            {
                //input_fname.Text = ofd.SafeFileName;
                //input_fname.Text = ofd.FileName;
                //pictureBoxIpl1.ImageIpl = new IplImage(input_fname.Text);
                try
                {
                    originalImg = new IplImage(ofd.FileName);
                    IplImage img =  Cv.CloneImage(originalImg);
                    IplImage gray_img = Cv.CreateImage(Cv.Size(img.Width, img.Height), BitDepth.U8, 1);
                    Cv.CvtColor(img, gray_img, ColorConversion.RgbToGray);
                    Cv.CvtColor(gray_img, img, ColorConversion.GrayToRgb);
                    gamma_bar.Value = 20;
                    gamma_bar.Enabled = true;
                    Convert_buttom.Enabled = true;
                    update(img);
                }
                catch (OpenCvSharp.OpenCvSharpException ex)
                {
                    
                    if(ex.Message == "Failed to create IplImage")
                        MessageBox.Show("画像が開けません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                
            }
            else
            {
//                input_fname.Text = "";
            }

        }
        unsafe private void Comvert_buttom_Click(object sender, EventArgs e)
        {
            DialogResult dRet;
            IplImage source_image=pictureBoxIpl1.ImageIpl;
            String output="";
            UInt16 i, j;
            byte* p = (byte*)source_image.ImageData;
            if ((dRet = saveFileDialog.ShowDialog()) == DialogResult.OK)
            {
  //              input_fname.Text = saveFileDialog.FileName;
                for (i = 0; i < source_image.Height; i++)
                {
                    for (j = 0; j < source_image.Width; j++)
                    {
                        output += string.Format("{0:f2}", 1.0 - (p[i * source_image.WidthStep + j * 3] / 255.0));
                        if (j < source_image.Width - 1)
                            output += " ";
                        if (j == source_image.Width - 1)
                            output += "\n";
                    }
                
                }
                
                StreamWriter sw = new StreamWriter("output.dat", false, Encoding.ASCII);
                sw.Write(output);
                //end of writing dat file.
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
                psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
                psi.FileName = "openscad.com";
                psi.Arguments = "-o " + saveFileDialog.FileName + " lith.scad";
                System.Diagnostics.Process temp = System.Diagnostics.Process.Start(psi);
                MessageBox.Show("STLファイル作成中です。しばらくお待ちください。");
                temp.WaitForExit();
                sw.Close();
                MessageBox.Show("Complet!");
            }
            else
            {
    //            input_fname.Text = "";
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void gamma_bar_Scroll(object sender, EventArgs e)
        {
            changeParam();
        }

        private void changeParam()
        {
            CvMat source_img = ConvertFromIplImage(Cv.CloneImage(originalImg));
            //CvMat source_img = ConvertFromIplImage(pictureBoxIpl1.ImageIpl);
            CvMat gray_img = new CvMat(source_img.Height, source_img.Width, MatType.CV_8U);
            Cv.CvtColor(source_img, gray_img, ColorConversion.RgbToGray);
            double a = (gamma_bar.Value * 0.01 + 0.8);
            //Cv.Threshold(gray_img, gray_img, 100,255, ThresholdType.Binary);
            UInt32[] lut = new UInt32[256];
            unsafe
            {
                byte* b = gray_img.DataByte;
                for (int y = 0; y < gray_img.Height; y++)
                {
                    for (int x = 0; x < gray_img.Width; x++)
                    {
                        *b = (byte)(Math.Pow((double)*b / 255.0, (1.0 / a)) * 255);
                        b++;
                    }
                }
            }
            //MessageBox.Show(a.ToString("F"));
            /*for(int i = 0; i< 256; i++){
                lut[i] = (UInt32)(Math.Pow((double)i / 255.0, 1.0 / a) * 255.0);
                System.Diagnostics.Trace.WriteLine(lut[i]);
            }
            CvMat lut_mat = new CvMat(1, 256, MatrixType.U8C1, lut);
            Cv.LUT(source_img, source_img, lut_mat);
            */
            //pictureBoxIpl1.RefreshIplImage(source_img);
            //pictureBoxIpl1.ImageIpl = ConvertFromCvMat(source_img);
            Cv.CvtColor(gray_img, source_img, ColorConversion.GrayToRgb);
            update(ConvertFromCvMat(source_img));
        }


        private void update(IplImage image)
        {
            pictureBoxIpl1.ImageIpl = image;
        }

        private IplImage ConvertFromCvMat(CvMat mat){
            return Cv.GetImage(mat);
        }
        private CvMat ConvertFromIplImage(IplImage image)
        {
            return Cv.GetMat(image);
        }




        

    }
}
