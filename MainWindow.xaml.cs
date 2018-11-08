using System.Windows;
using System.Windows.Controls;

namespace CryptoTools {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
        }

        private bool checkPasswd() {
            if (!pwd.Equals(Passwd.Password)) {
                MessageBox.Show("请先配置密码再使用！");
                return false;
            }
            return true;
        }

        private void Passwd_PasswordChanged(object sender, RoutedEventArgs e) {
            PasswordBox passwordtext = (PasswordBox)sender;
            PasswordBoxBindingHelper.SetPasswordBoxSelection(passwordtext,
                passwordtext.Password.Length + 1, passwordtext.Password.Length + 1);
            if (PswdStr.DropItems == null && passwordtext.Password.Length > 4
                && pwd.Equals(passwordtext.Password)) {
                // 预设密码数据
                PswdStr.DropItems = new string[]
                {
                "12345678876543211234567887654abc", "123456"
                };
            }

        }

        private void Decrypt_Click(object sender, RoutedEventArgs e) {
            if (!checkPasswd()) {
                return;
            }
            RetStr.Text = Common.AesDecrypt(this.SourceStr.Text,
               this.PswdStr.Text);
        }

        private const string pwd = "yyjzjk";

        private void Encrypt_Click(object sender, RoutedEventArgs e) {
            if (!checkPasswd()) {
                return;
            }
            RetStr.Text = Common.AesEncrypt(this.SourceStr.Text,
               this.PswdStr.Text);
        }
    }
}
