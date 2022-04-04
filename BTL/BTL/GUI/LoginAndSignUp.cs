using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
namespace BTL
{
    public partial class LoginAndSignUp : Form
    {
        public LoginAndSignUp()
        {
            InitializeComponent();
            addElementInList();
            bunifuCheckBox2.Checked = false;
            bunifuIconButton6.Parent = bunifuPictureBox1;
            bunifuIconButton6.BackgroundColor = Color.Transparent;
            bunifuIconButton7.BackgroundColor = Color.Transparent;
            bunifuIconButton8.BackgroundColor = Color.Transparent;
            bunifuIconButton7.Parent = bunifuPictureBox1;
            bunifuIconButton8.Parent = bunifuPictureBox1;
            menuIcon.Parent = bunifuPictureBox1;
            menuIcon.BackColor = Color.Transparent;
        }
        GUI.MainForm mainForm = new GUI.MainForm();
        //Các đối tượng sử dụng trong Form Register
        private List<BunifuTextBox> ListRegisterBoxs = new List<BunifuTextBox>();
        private List<Label> ListRegisterLabels = new List<Label>();
        private List<BunifuUserControl> ListRegisterUserControls = new List<BunifuUserControl>();
        private List<BunifuIconButton> ListRegisterBtns = new List<BunifuIconButton>();
        private List<BunifuLabel> ListRegisterEmptyErrorMessage = new List<BunifuLabel>();
        //Các đối tượng dùng chung cho 2 form
        private List<BunifuPictureBox> ListPics = new List<BunifuPictureBox>();
        private List<BunifuIconButton> ListSocialIcon = new List<BunifuIconButton>();
        //Đối tượng dùng cho Form Login
        private List<BunifuTextBox> ListLoginBoxs = new List<BunifuTextBox>();
        private List<Label> ListLoginLabels = new List<Label>();
        private List<BunifuIconButton> ListLoginBtns = new List<BunifuIconButton>();
        private List<BunifuUserControl> ListLoginUserControls = new List<BunifuUserControl>();
        private List<BunifuLabel> ListLoginEmptyErrorMessage = new List<BunifuLabel>();
        //Các biến phát sinh
        string primaryColor = "3C4071";
        string whiteColor = "FFFFFF";
        string grayColor = "F5F5F7";
        string dsTextColor = "8B8FA8";
        string errorBorderColor = "fb5e5e";
        string errorFillColor = "fee7ec";
        bool isValidated;
        bool isRegisterClick;
        bool isLoginClick;
        //Tài khoản để Test Login
        string userName = "daovietbao";
        string userPassword = "123456";
        private void LoginAndSignUp_Load(object sender, EventArgs e) { this.ActiveControl = ListRegisterBoxs[0]; isValidated = false; isRegisterClick = false; isLoginClick = false; bunifuUserControl1.Visible = false; bunifuUserControl2.Visible = false; bunifuUserControl3.Visible = false; }
        //Add các đối tượng
        private void addElementInList()
        {
            //Dùng trong Form Register
            ListRegisterBoxs.Add(bunifuTextBox1);ListRegisterBoxs.Add(bunifuTextBox2);ListRegisterBoxs.Add(bunifuTextBox3);
            ListRegisterLabels.Add(label3);ListRegisterLabels.Add(label4);ListRegisterLabels.Add(label5);
            ListRegisterBtns.Add(bunifuIconButton1);ListRegisterBtns.Add(bunifuIconButton2);ListRegisterBtns.Add(bunifuIconButton3);
            ListRegisterUserControls.Add(bunifuUserControl1);ListRegisterUserControls.Add(bunifuUserControl2);ListRegisterUserControls.Add(bunifuUserControl3);
            //Dùng chung trong Form
            ListRegisterEmptyErrorMessage.Add(bunifuLabel4);ListRegisterEmptyErrorMessage.Add(bunifuLabel3);ListRegisterEmptyErrorMessage.Add(bunifuLabel2);
            ListPics.Add(bunifuPictureBox1);
            //Dùng trong Form Login
            ListLoginBoxs.Add(bunifuTextBox5); ListLoginBoxs.Add(bunifuTextBox6);
            ListLoginBtns.Add(bunifuIconButton5); ListLoginBtns.Add(bunifuIconButton4);
            ListLoginLabels.Add(label2); ListLoginLabels.Add(label1);
            ListLoginUserControls.Add(bunifuUserControl5);ListLoginUserControls.Add(bunifuUserControl4);
            ListLoginEmptyErrorMessage.Add(bunifuLabel8); ListLoginEmptyErrorMessage.Add(bunifuLabel10);
            ListSocialIcon.Add(bunifuIconButton6); ListSocialIcon.Add(bunifuIconButton7); ListSocialIcon.Add(bunifuIconButton8);
        }
        //Load, Enter Event
        private void loadAndEnterAnimateChange(BunifuTextBox thisBox,BunifuIconButton thisBtn,Label thisLabel, string imgName, string thisColor, int lcX, int lcY, int fontSize, string labelColor)
        {
            thisBtn.Image = new System.Drawing.Bitmap($@"..\..\Image\{imgName}.png");
            thisBtn.BackgroundColor = ColorTranslator.FromHtml($"#{thisColor}");
            thisBtn.BorderColor = ColorTranslator.FromHtml($"#{thisColor}");
            thisLabel.BackColor = ColorTranslator.FromHtml($"#{thisColor}");
            thisLabel.ForeColor = ColorTranslator.FromHtml($"#{labelColor}");
            thisLabel.Location = new Point(lcX, lcY);
            thisLabel.Font = new System.Drawing.Font("Quicksand", fontSize, FontStyle.Bold);
            thisLabel.Image = null;
        }
        //Leave Event
        private void leaveAnimateChangeloadAnimateChange(BunifuUserControl thisUserControl ,BunifuLabel thisErrorMessage , BunifuTextBox thisBox, BunifuIconButton thisBtn, Label thisLabel, string imgName, string hideImg, string thisColor, int lcX, int lcY, int fontSize, bool isClick)
        {
            thisBtn.Image = new System.Drawing.Bitmap($@"..\..\Image\{imgName}.png");
            thisBtn.BackgroundColor = ColorTranslator.FromHtml($"#{thisColor}");
            thisBtn.BorderColor = ColorTranslator.FromHtml($"#{thisColor}");
            if (thisBox.Text == "")
            {
                thisLabel.Font = new System.Drawing.Font("Quicksand", fontSize, FontStyle.Bold);
                thisLabel.Location = new Point(lcX, lcY);
                thisLabel.BackColor = ColorTranslator.FromHtml($"#{thisColor}");
                thisLabel.Image = null;
                thisLabel.ForeColor = ColorTranslator.FromHtml($"#{dsTextColor}");
                thisBox.OnIdleState.BorderColor = ColorTranslator.FromHtml($"#{dsTextColor}");
            }
            else
            {
                thisLabel.Image = new System.Drawing.Bitmap($@"..\..\Image\{hideImg}.png");
            }
            if(isClick == true)
            {
                if(thisBox.Text == "")
                {
                    thisUserControl.Visible = true;
                    thisErrorMessage.Visible = true;
                } else
                {
                    thisUserControl.Visible = false;
                }
            }
        }
        //Sự kiện Load, Enter, Leave Event của TextBox
        //TextBox form Đăng Ký
        private void bunifuTextBox1_Load(object sender, EventArgs e) { loadAndEnterAnimateChange(ListRegisterBoxs[0], ListRegisterBtns[0], ListRegisterLabels[0], "Profile", whiteColor, 22, 120, 9, primaryColor);}
        private void bunifuTextBox1_Enter(object sender, EventArgs e) { loadAndEnterAnimateChange(ListRegisterBoxs[0], ListRegisterBtns[0], ListRegisterLabels[0], "Profile", whiteColor, 22, 120, 9, primaryColor); }
        private void bunifuTextBox1_Leave(object sender, EventArgs e) { leaveAnimateChangeloadAnimateChange(ListRegisterUserControls[0], ListRegisterEmptyErrorMessage[0] ,ListRegisterBoxs[0], ListRegisterBtns[0], ListRegisterLabels[0], "ProfileDS", "Vector", grayColor, 66, 150, 12, isRegisterClick); }
        private void bunifuTextBox2_Enter(object sender, EventArgs e) { loadAndEnterAnimateChange(ListRegisterBoxs[1], ListRegisterBtns[1], ListRegisterLabels[1], "Solid", whiteColor, 22, 218, 9, primaryColor); }
        private void bunifuTextBox2_Leave(object sender, EventArgs e) { leaveAnimateChangeloadAnimateChange(ListRegisterUserControls[1], ListRegisterEmptyErrorMessage[1], ListRegisterBoxs[1], ListRegisterBtns[1], ListRegisterLabels[1], "SolidDS", "Vector3", grayColor, 66, 247, 12, isRegisterClick);}
        private void bunifuTextBox2_Load(object sender, EventArgs e) { loadAndEnterAnimateChange(ListRegisterBoxs[1], ListRegisterBtns[1], ListRegisterLabels[1], "SolidDS", grayColor, 66, 247, 12, dsTextColor);}
        private void bunifuTextBox3_Enter(object sender, EventArgs e) {loadAndEnterAnimateChange(ListRegisterBoxs[2], ListRegisterBtns[2], ListRegisterLabels[2], "Lock-Fill", whiteColor, 22, 314, 9, primaryColor); showPassBtnRegister.BackColor = Color.White; }
        private void bunifuTextBox3_Leave(object sender, EventArgs e) { leaveAnimateChangeloadAnimateChange(ListRegisterUserControls[2], ListRegisterEmptyErrorMessage[2], ListRegisterBoxs[2], ListRegisterBtns[2], ListRegisterLabels[2], "Lock-FillNoColor", "Vector3", grayColor, 66, 345, 12, isRegisterClick); showPassBtnRegister.BackColor = ColorTranslator.FromHtml($"#{grayColor}"); }
        private void bunifuTextBox3_Load(object sender, EventArgs e) { loadAndEnterAnimateChange(ListRegisterBoxs[2], ListRegisterBtns[2], ListRegisterLabels[2], "Lock-FillNoColor", grayColor, 66, 345, 12, dsTextColor); showPassBtnRegister.BackColor = ColorTranslator.FromHtml($"#{grayColor}");}
        //TextBox form Đăng Nhập
        private void bunifuTextBox5_Load(object sender, EventArgs e) { loadAndEnterAnimateChange(ListLoginBoxs[0], ListLoginBtns[0], ListLoginLabels[0], "ProfileDS", whiteColor, 22, 120, 9, primaryColor); }
        private void bunifuTextBox5_Enter(object sender, EventArgs e) { loadAndEnterAnimateChange(ListLoginBoxs[0], ListLoginBtns[0], ListLoginLabels[0], "Profile", whiteColor, 22, 120, 9, primaryColor); }
        private void bunifuTextBox5_Leave(object sender, EventArgs e) { leaveAnimateChangeloadAnimateChange(ListLoginUserControls[0], ListLoginEmptyErrorMessage[0], ListLoginBoxs[0], ListLoginBtns[0], ListLoginLabels[0], "ProfileDS", "Vector", grayColor, 66, 150, 12, isLoginClick); }
        private void bunifuTextBox6_Load(object sender, EventArgs e) { loadAndEnterAnimateChange(ListLoginBoxs[1], ListLoginBtns[1], ListLoginLabels[1], "Lock-FillNoColor", grayColor, 66, 248, 12, dsTextColor); showPassBtnLogin.BackColor = ColorTranslator.FromHtml($"#{grayColor}"); }
        private void bunifuTextBox6_Enter(object sender, EventArgs e) { loadAndEnterAnimateChange(ListLoginBoxs[1], ListLoginBtns[1], ListLoginLabels[1], "Lock-Fill", whiteColor, 22, 217, 9, primaryColor); showPassBtnLogin.BackColor = Color.White; }
        private void bunifuTextBox6_Leave(object sender, EventArgs e) { leaveAnimateChangeloadAnimateChange(ListLoginUserControls[1], ListLoginEmptyErrorMessage[1], ListLoginBoxs[1], ListLoginBtns[1], ListLoginLabels[1], "Lock-FillNoColor", "Vector3", grayColor, 66, 248, 12, isLoginClick); showPassBtnLogin.BackColor = ColorTranslator.FromHtml($"#{grayColor}"); }
        //Sự kiện xảy khi chữ trong TextBox thay đổi
        private void bunifuTextBox1_TextChange(object sender, EventArgs e) { showErrorMessage(isRegisterClick, ListRegisterBoxs[0], ListRegisterEmptyErrorMessage[0]); }
        private void bunifuTextBox2_TextChange(object sender, EventArgs e) { showErrorMessage(isRegisterClick, ListRegisterBoxs[1], ListRegisterEmptyErrorMessage[1]); }
        private void bunifuTextBox3_TextChange(object sender, EventArgs e) { showErrorMessage(isRegisterClick, ListRegisterBoxs[2], ListRegisterEmptyErrorMessage[2]); }
        private void bunifuTextBox5_TextChange(object sender, EventArgs e) { showErrorMessage(isLoginClick, ListLoginBoxs[0], ListLoginEmptyErrorMessage[0]); }
        private void bunifuTextBox6_TextChange(object sender, EventArgs e) { showErrorMessage(isLoginClick, ListLoginBoxs[1], ListLoginEmptyErrorMessage[1]); }
        //Sự kiện đổi màu khi hover vào các Social Icon
        private void bunifuIconButton6_MouseHover(object sender, EventArgs e) { ListSocialIcon[0].Image = new System.Drawing.Bitmap(@"..\..\Image\facebook-hover.png"); }
        private void bunifuIconButton6_MouseLeave(object sender, EventArgs e) { ListSocialIcon[0].Image = new System.Drawing.Bitmap(@"..\..\Image\facebook.png"); }
        private void bunifuIconButton7_MouseHover(object sender, EventArgs e) { ListSocialIcon[01].Image = new System.Drawing.Bitmap(@"..\..\Image\instagram-hover.png"); }
        private void bunifuIconButton7_MouseLeave(object sender, EventArgs e) { ListSocialIcon[1].Image = new System.Drawing.Bitmap(@"..\..\Image\instagram.png"); }
        private void bunifuIconButton8_MouseHover(object sender, EventArgs e) { ListSocialIcon[2].Image = new System.Drawing.Bitmap(@"..\..\Image\skype-hover.png"); }
        private void bunifuIconButton8_MouseLeave(object sender, EventArgs e) { ListSocialIcon[2].Image = new System.Drawing.Bitmap(@"..\..\Image\skype.png"); }
        //Sự kiện Click
        private void bunifuUserControl2_Click(object sender, EventArgs e) { ListRegisterBoxs[1].Focus(); ListRegisterUserControls[1].Visible = false; }
        private void bunifuUserControl3_Click(object sender, EventArgs e) { ListRegisterBoxs[2].Focus(); ListRegisterUserControls[2].Visible = false; }
        private void bunifuUserControl1_Click(object sender, EventArgs e) { ListRegisterBoxs[0].Focus(); ListRegisterUserControls[0].Visible = false; }
        private void bunifuUserControl5_Click(object sender, EventArgs e) { ListLoginBoxs[0].Focus(); ListLoginUserControls[0].Visible = false; }
        private void bunifuUserControl4_Click(object sender, EventArgs e) { ListLoginBoxs[1].Focus(); ListLoginUserControls[1].Visible = false; }
        //Khi click sẽ chạy hàm chuyển Form
        //Chuyển sang Form Login và ẩn Form Register
        private void loginLabel_Click(object sender, EventArgs e) { transferForm("login"); }
        //Chuyển sang Form Register và ẩn Form Login
        private void registerLabel_Click(object sender, EventArgs e) { transferForm("register"); }
        private void label3_Click(object sender, EventArgs e) { bunifuTextBox1.Focus(); ListRegisterUserControls[0].Visible = false; }
        private void label4_Click(object sender, EventArgs e) { bunifuTextBox2.Focus(); ListRegisterUserControls[1].Visible = false; }
        private void label5_Click(object sender, EventArgs e){ bunifuTextBox3.Focus(); ListLoginUserControls[0].Visible = false; }
        private void label2_Click(object sender, EventArgs e) { ListLoginBoxs[0].Focus(); ListLoginUserControls[0].Visible = false; }
        private void label1_Click(object sender, EventArgs e) { ListLoginBoxs[1].Focus(); ListLoginUserControls[1].Visible = false; }
        //Show password đã ẩn khi click
        //Khi click sẽ chạy hàm hiển thị mật khẩu và sẽ hiển thị mật khẩu ở Form Login, click lần 2 sẽ trở về dạng ẩn
        private void shownPassBtnRegister_Click(object sender, EventArgs e) { showPassword(ListRegisterBoxs[2], showPassBtnRegister); }
        ////Khi click sẽ chạy hàm hiển thị mật khẩu và sẽ hiển thị mật khẩu ở Form Login, click lần 2 sẽ trở về dạng ẩn
        private void showPassBtnLogin_Click(object sender, EventArgs e) { showPassword(ListLoginBoxs[1], showPassBtnLogin); }
        int temp = 0;
        //Show Menu chức năng
        private void menuIcon_Click(object sender, EventArgs e)
        {
            temp++;
            bunifuPictureBox1.Image = new System.Drawing.Bitmap($@"..\..\Image\Bg2.png");
            if(temp == 2)
            {
                bunifuPictureBox1.Image = new System.Drawing.Bitmap($@"..\..\Image\Bg1.png");
                temp = 0;
            }
            
        }
        //Khi click đăng ký sẽ chạy hàm Validate
        int i;
        string formStyle = null;
        private void registerBtn_Click(object sender, EventArgs e)
        {
            i = 0;
            hideBox.Focus();
            formStyle = "register";
            isVaidate.Start();
            isRegisterClick = true;
        }
        //Khi click đăng ký sẽ chạy hàm Validate
        private void loginBtn_Click(object sender, EventArgs e) {
            i = 0;
            hideBox.Focus();
            formStyle = "login";
            isVaidate.Start();
            isLoginClick = true;
        }
        //Các hàm xử lý, Kiểm tra
        //Hiển thị Password
        private void showPassword(BunifuTextBox thisBox, BunifuLabel thisBnfLabel)
        {
            if (thisBox.UseSystemPasswordChar == true)
            {
                thisBnfLabel.BackgroundImage = new System.Drawing.Bitmap(@"..\..\Image\NoEyes-Fill.png");
                thisBox.UseSystemPasswordChar = false;
                thisBox.PasswordChar = default;
            }
            else if (thisBox.UseSystemPasswordChar == false)
            {
                thisBnfLabel.BackgroundImage = new System.Drawing.Bitmap(@"..\..\Image\Eyes-Fill.png");
                thisBox.UseSystemPasswordChar = true;
                thisBox.PasswordChar = '●';
            }
        }
        //Kiểm tra TextBox xem có trống và có đúng kiểu hay không, nếu không đúng sẽ in ra lỗi
        private void showErrorMessage(bool isChecked, BunifuTextBox thisBox ,BunifuLabel thisErrorMessage)
        {
            if (isChecked == true)
            {
                if (thisBox.Text != "")
                {
                    thisErrorMessage.Visible = false;
                }
                else
                {
                    if (thisErrorMessage == ListLoginEmptyErrorMessage[0])
                    {
                        thisErrorMessage.Text = "Tên không thể để trống";
                    }
                    else
                    {
                        thisErrorMessage.Text = "Mật khẩu không thể để trống";
                    }
                    thisErrorMessage.Visible = true;
                }
            }
        }
        /*Hàm kiểm tra xem các TextBox có còn trống hay không, và có đúng thông tin đăng nhập hay không, nếu còn trống hoặc sai thông tin sẽ in
         thông báo lỗi, nếu đúng thông tin và TextBox không trống thì sẽ đăng nhập thành công*/
        private void Validate(List<BunifuTextBox> thisListBox, List<BunifuUserControl> thisUserControl, List<BunifuLabel> thisErrorMessage, int start, int end, string style)
        {
            int count = 0;
            for(int i = start; i < end; i++)
            {
                if(thisListBox[i].Text == "")
                {
                    thisUserControl[i].Visible = true;
                    thisErrorMessage[i].Visible = true;
                }
                if(thisListBox[i].Text != "" && style == "login")
                {
                    count++;
                }
                if(count == 2)
                {
                    checkUserInfo(userName, userPassword);
                    count = 0;
                }
            }
        }
        //Hàm kiểm tra thông tin tài khoản đã nhập, nếu đúng thì login, nếu sai sẽ hiện thông báo lỗi
        private void checkUserInfo(string userName, string userPassword)
        {
            if (ListLoginBoxs[0].Text == userName && ListLoginBoxs[1].Text == userPassword)
            {
                mainForm.ShowDialog();
                ListLoginEmptyErrorMessage[0].Text = "Tài khoản không thể để trống";
                ListLoginEmptyErrorMessage[1].Text = "Mật khẩu không thể để trống";
            }
            else
            {
                if (ListLoginBoxs[0].Text != userName)
                {
                    ListLoginEmptyErrorMessage[0].Text = "Tài khoản không đúng, vui lòng thử lại!";
                    ListLoginEmptyErrorMessage[0].Visible = true;
                } 
                if(ListLoginBoxs[1].Text != userName) { 
                    ListLoginEmptyErrorMessage[1].Text = "Mật khẩu không đúng, vui lòng thử lại!";
                    ListLoginEmptyErrorMessage[1].Visible = true;
                }
            }
        }
        //Hàm chạy, bắt đầu validate
        private void runValidate(string style, int i)
        {
            if (i == 3 && style == "register")
            {
                Validate(ListRegisterBoxs, ListRegisterUserControls, ListRegisterEmptyErrorMessage, 0, ListRegisterBoxs.Count, "register");
                isVaidate.Stop();
            }
            if (i == 3 && style == "login")
            {
                Validate(ListLoginBoxs, ListLoginUserControls, ListLoginEmptyErrorMessage, 0, ListLoginBoxs.Count, "login");
                isVaidate.Stop();
            }
        }
        //Valite sau thời gian cụ thể
        private void isVaidate_Tick(object sender, EventArgs e)
        {
            i += 1;
            if(i == 3)
            {
                runValidate(formStyle, i);
                i = 0;
            }
        }
        //Hàm đổi Form và bật tắt các chức năng cần thiết khi đổi Form
        private void transferForm(string formName)
        {
            if(formName == "login")
            {
                isRegisterClick = false;
                for(int i = 0; i < ListRegisterUserControls.Count; i++)
                {
                    ListRegisterUserControls[i].Visible = false;
                    ListRegisterEmptyErrorMessage[i].Visible = false;
                }
                hideBox.Focus();
                formActivated = "login";
                timer1.Start();
                loginForm.Visible = true;
                registerForm.Visible = false;
            }
            if(formName == "register")
            {
                isLoginClick = false;
                for (int i = 0; i < ListLoginUserControls.Count; i++)
                {
                    ListLoginUserControls[i].Visible = false;
                    ListLoginEmptyErrorMessage[i].Visible = false;
                }
                hideBox.Focus();
                formActivated = "register";
                timer1.Start();
                ListLoginEmptyErrorMessage[0].Text = "Tài khoản không thể để trống";
                ListLoginEmptyErrorMessage[1].Text = "Mật khẩu không thể để trống";
                registerForm.Visible = true;
                loginForm.Visible = false;
            }
        }
        //Hàm để Focus vào TextBox đầu tiên khi đổi từ Register Form sang Login Form và ngược lại
        private void loadFocus(string formName)
        {
            if(formName == "login")
            {
                ListLoginBoxs[0].Focus();
            }
            if(formName == "register")
            {
                ListRegisterBoxs[0].Focus();
            }
        }
        int t;
        string formActivated;
        //Event chạy hàm sau một khoảng thời gian nào đó
        private void timer1_Tick(object sender, EventArgs e)
        {
            t += 1;
            if (t == 3)
            {
                loadFocus(formActivated);
                timer1.Stop();
                t = 0;
            }
        }
    }
}
