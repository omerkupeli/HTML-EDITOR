

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WPF_HTML_EDITOR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static bool save = false;  
        //bu html dosyasının kaydedilme durumunu kontrol edecek
        //default değer false dosyanın kaydedilmediğini gösterir
        //ama bir dosya açıldığımda true olacak ve
        //bir dosya kaydedildiğinde değeri true olacak

        static string savepath;
        public MainWindow()
        {
            InitializeComponent();
            SaveBtn.IsEnabled = false;

            textBox1.Text = "<HTML>\n\t<HEAD>\n\t\t<TITLE>MyWebsite1</TITLE>\n\t</HEAD>\n\n\n\t<BODY>\n\n\n\t</BODY>\n</HTML>";
        }

        /// <summary>
        /// Yeni bir Html dosyası oluşturmak için buton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SaveBtn.IsEnabled == true)
            {
                MessageBoxResult MsgBoxresult = MessageBox.Show("Dosya Kaydedilsin mi?", "Dosya kaydetmek istiyor musun", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (MsgBoxresult == MessageBoxResult.Yes)
                {
                    MainWindow obj = new MainWindow();
                    Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                    sfd.DefaultExt = ".htm";
                    sfd.Filter = "HTML File (.html)|*.html| HTM Files (.htm)|*.htm";
                    if (sfd.ShowDialog() == true && sfd.FileName.Length > 0)
                    {
                        File.WriteAllText(sfd.FileName, textBox1.Text);
                    }
                }
                textBox1.Text = string.Empty;
                SaveBtn.IsEnabled = false;
            }
        }
        /// <summary>
        /// Var olan bir dosyayı açmak için buton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                MainWindow obj = new MainWindow();
                Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                sfd.DefaultExt = ".htm";
                sfd.Filter = "HTML File (.html)|*.html| HTM Files (.htm)|*.htm";
                if (sfd.ShowDialog() == true && sfd.FileName.Length > 0)
                {
                    File.WriteAllText(sfd.FileName, textBox1.Text);
                    savepath = sfd.FileName.ToString();
                    save = true;
                }
            }
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.DefaultExt = ".htm";
            ofd.Filter = "HTML File (.html)|*.html| HTM Files (.htm)|*.htm";
            if (ofd.ShowDialog() == true)
            {
                StreamReader StreamReader1 = new StreamReader(ofd.FileName, Encoding.Default);
                textBox1.Text = StreamReader1.ReadToEnd();
                save = true;
                savepath = ofd.FileName.ToString();
            }
            SaveBtn.IsEnabled = false;
            save = true;
        }
        /// <summary>
        /// kodlarımızı yazdığımız textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            SaveBtn.IsEnabled = true;
        }
        /// <summary>
        /// editörü kapatmak için buton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SaveBtn.IsEnabled == true)
            {
                MessageBoxResult MsgBoxresult = MessageBox.Show("Dosya Kaydedilsin mi ?", "Dosya kaydetmek istiyor musun", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (MsgBoxresult == MessageBoxResult.Yes)
                {
                    MainWindow obj = new MainWindow();
                    Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                    sfd.DefaultExt = ".htm";
                    sfd.Filter = "HTML File (.html)|*.html| HTM Files (.htm)|*.htm";
                    if (sfd.ShowDialog() == true && sfd.FileName.Length > 0)
                    {
                        File.WriteAllText(sfd.FileName, textBox1.Text);
                    }
                    this.Close();
                }
                else if (MsgBoxresult == MessageBoxResult.No)
                {
                    this.Close();
                }
                else
                {

                }

            }

        }
        /// <summary>
        /// dosyamızı kaydetmek için buton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (save == false)
            {
                Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                sfd.DefaultExt = ".htm";
                sfd.Filter = "HTML File (.html)|*.html| HTM Files (.htm)|*.htm";
                if (sfd.ShowDialog() == true && sfd.FileName.Length > 0)
                {
                    File.WriteAllText(sfd.FileName, textBox1.Text);
                    savepath = sfd.FileName.ToString();
                    save = true;
                }
            }
            else
            {
                File.WriteAllText(savepath, textBox1.Text);
            }
        }
        /// <summary>
        /// kalın yazma etiketi koymak için buton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoldBtn_Click(object sender, RoutedEventArgs e)
        {
            textBox1.SelectedText = "<B>" + textBox1.SelectedText + "</B>";
        }
        /// <summary>
        /// italik yazma etiketi koymak için buton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItalicBtn_Click(object sender, RoutedEventArgs e)
        {
            textBox1.SelectedText = "<I>" + textBox1.SelectedText + "</I>";
        }
        /// <summary>
        /// metnin altını çizmek için etiket koyan buton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnderLineBtn_Click(object sender, RoutedEventArgs e)
        {
            textBox1.SelectedText = "<U>" + textBox1.SelectedText + "</U>";
        }
        /// <summary>
        /// 1 den 6 ya kadar <H></H> etiketi koyan buton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {
                textBox1.SelectedText = "<H" + comboBox1.SelectedIndex + ">" + textBox1.SelectedText + "</H" + comboBox1.SelectedIndex + ">";
            }

        }
        /// <summary>
        /// paragraf etiketi koymak için buton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParagraphBtn_Click(object sender, RoutedEventArgs e)
        {
            textBox1.SelectedText = "<P>" + textBox1.SelectedText + "</P>";
        }
        /// <summary>
        /// yazdığımız kodların önizlemesini görmek için buton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (save == true)
            {
                Preview preview1 = new Preview(savepath);
                preview1.Show();
            }
            else
            {
                MessageBox.Show("Lütfen Önce Dosyanızı Kaydedin", "Html dosyasını kaydet", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }
        /// <summary>
        /// önceden kaydedilmiş dosyayı farklı şekilde kaydeden buton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
            sfd.DefaultExt = ".htm";
            sfd.Filter = "HTML File (.html)|*.html| HTM Files (.htm)|*.htm";
            if (sfd.ShowDialog() == true && sfd.FileName.Length > 0)
            {
                File.WriteAllText(sfd.FileName, textBox1.Text);
                savepath = sfd.FileName.ToString();
                save = true;
            }
        }
        /// <summary>
        /// form eleman etiketleri koymak için textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTags_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectionIndex = textBox1.SelectionStart;
            if (FormTags.SelectedIndex == 1)//form etiketi
            {
                string insertText = "<form name=\"İsmi buraya giriniz\" action=\"Put Your action Here p\" method=\"post\">\n\n</form>";
                textBox1.Text = textBox1.Text.Insert(selectionIndex, insertText);
                textBox1.SelectionStart = selectionIndex + insertText.Length;
            }
            else if (FormTags.SelectedIndex == 2)//textbox
            {
                string insertText = "<input type=\"text\" name=\"InsertNameHere\">";
                textBox1.Text = textBox1.Text.Insert(selectionIndex, insertText);
                textBox1.SelectionStart = selectionIndex + insertText.Length;
            }
            else if (FormTags.SelectedIndex == 3)//Password
            {
                string insertText = "<input type=\"password\" name=\"pwd1\">";
                textBox1.Text = textBox1.Text.Insert(selectionIndex, insertText);
                textBox1.SelectionStart = selectionIndex + insertText.Length;
            }
            else if (FormTags.SelectedIndex == 4)//CheckBox
            {
                string insertText = "<input type=\"checkbox\" name=\"isim_ver\" value=\"değer_ver\">Item_Name";
                textBox1.Text = textBox1.Text.Insert(selectionIndex, insertText);
                textBox1.SelectionStart = selectionIndex + insertText.Length;
            }
            else if (FormTags.SelectedIndex == 5)//Radio
            {
                string insertText = "<input type=\"radio\" name=\"isim_ver\" value=\"değer_ver\">Item_Name";
                textBox1.Text = textBox1.Text.Insert(selectionIndex, insertText);
                textBox1.SelectionStart = selectionIndex + insertText.Length;
            }
            else if (FormTags.SelectedIndex == 6)//Button
            {
                string insertText = "<input type=\"submit\" value=\"Submit\">";
                textBox1.Text = textBox1.Text.Insert(selectionIndex, insertText);
                textBox1.SelectionStart = selectionIndex + insertText.Length;
            }
            else if (FormTags.SelectedIndex == 7)//Drop Down
            {
                string insertText = "<select name=\"Selection_Name\">\n</br><option value=\"1\">1</option>\n</br><option value=\"2\">2</option>\n</br><option value=\"3\">2</option>\n</br><option value=\"4\">4</option>\n</br><option value=\"5\">5</option>\n</br></select>\n";
                textBox1.Text = textBox1.Text.Insert(selectionIndex, insertText);
                textBox1.SelectionStart = selectionIndex + insertText.Length;
            }
            else if (FormTags.SelectedIndex == 8)//Text Area
            {
                string insertText = "<textarea rows=\"10\" cols=\"30\">Insert Text Here</textarea>";
                textBox1.Text = textBox1.Text.Insert(selectionIndex, insertText);
                textBox1.SelectionStart = selectionIndex + insertText.Length;
            }
            else
            {

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertImgBtn_Click(object sender, RoutedEventArgs e)
        {
            if (save == false)
            {
                MessageBox.Show("Lütfen Önce Dosyayı Kaydediniz");
            }
            else
            {
                var selectionIndex = textBox1.SelectionStart;
                Microsoft.Win32.OpenFileDialog ofd2 = new Microsoft.Win32.OpenFileDialog();
                ofd2.DefaultExt = ".jpg";
                ofd2.Filter = "JPG File (.jpg)|*.jpg|BMP (.bmp)|*.bmp|GIF (.gif)|*.gif|PNG (.png)|*.png|ALL Files (.)|*.*";
                if (ofd2.ShowDialog() == true)
                {
                    string insertText = "<img src=\"" + ofd2.FileName + "\"/>";
                    textBox1.Text = textBox1.Text.Insert(selectionIndex, insertText);
                    textBox1.SelectionStart = selectionIndex + insertText.Length;
                }
            }
        }
        /// <summary>
        /// link koyma etiketi yazdıran buton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (save == false)
            {
                MessageBox.Show("Lütfen Önce Dosyayı Kaydedin");
            }
            else
            {
                var selectionIndex = textBox1.SelectionStart;
                string insertText = "<a href=\"dosyanın_linki\">Link_Name<a>";
                textBox1.Text = textBox1.Text.Insert(selectionIndex, insertText);
                textBox1.SelectionStart = selectionIndex + insertText.Length;
            }
        }
        /// <summary>
        ///  satır atlama etiketi koyan link
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBrak_Click(object sender, RoutedEventArgs e)
        {
            var selectionIndex = textBox1.SelectionStart;
            string insertText = "</BR>";
            textBox1.Text = textBox1.Text.Insert(selectionIndex, insertText);
            textBox1.SelectionStart = selectionIndex + insertText.Length;
        }
    }
}