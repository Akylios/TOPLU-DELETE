using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toplu_delete
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            string filePath = @"dosyayolu.txt";

            try
            {
                if (File.Exists(filePath))
                {
                    string[] filePaths = File.ReadAllLines(filePath);

                    foreach (string path in filePaths)
                    {
                        if (!string.IsNullOrWhiteSpace(path) && Directory.Exists(path))
                        {
                            DeleteFiles(path);
                        }
                    }

                    //MessageBox.Show("Tüm dosyalar başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //MessageBox.Show("Dosya yolu içeren metin dosyası bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteFiles(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath);

            if (files.Length > 0)
            {
                foreach (string file in files)
                {
                    File.Delete(file); // Dosyayı sil
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
