using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LottoWForms
{
    public partial class GameForm : Form
    {
        private LoginForm loginForm;

        private List<List<int>> ticketNumbersList;

        public Authenticator auth;
        public BalanceManager balanceManager;
        public GameManager gameManager;
        public TicketManager ticketManager;

        public GameForm(LoginForm loginContext, Authenticator authContext)
        {
            InitializeComponent();
            this.loginForm = loginContext;
            this.auth = authContext;
            this.balanceManager = new BalanceManager();
            this.gameManager = new GameManager();
            this.ticketManager = new TicketManager();

            if (this.ticketManager.HasCheckedNumbers(this.auth.AuthUserId)) this.DisableBuyBtn(); 
            this.ticketList.Items.Clear();
            this.UpdateView();
        }

        public void DisableBuyBtn()
        {
            this.buyTicketBtn.Enabled = false;
        }

        public void DisableCheckBtn()
        {
            this.checkBtn.Enabled = false;
        }

        public void ShowWinningNumbers()
        {
            this.numbersLabel.Text = "Today's numbers: " + String.Join(',', this.gameManager._game.WinningNumbers);
            this.numbersLabel.Visible = true;
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.loginForm.Close();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            this.helloLabel.Text = "Hello " + this.auth.AuthUserLogin;
            this.prizeLabel.Text = $"Today's prize: {this.gameManager._game.Prize}zł";
            this.UpdateView();
        }

        public void UpdateView()
        {
            this.ticketList.Items.Clear();
            this.ticketNumbersList = this.ticketManager.GetTicketNumbers(this.auth.AuthUserId);
            this.ticketAvailableLabel.Text = "Tickets available: " + this.ticketManager.GetTicketAvailable(this.auth.AuthUserId);

            
            this.balanceLabel.Text = "Your balance: " + this.balanceManager.GetBalance(this.auth.AuthUserId).ToString() + "zł";

            foreach (var ticketNumber in this.ticketNumbersList)
            {
                ListViewItem item = new ListViewItem(String.Join(";", ticketNumber));
                this.ticketList.Items.Add(item);
            }

            List<int> guessedNoList = this.gameManager.GetNumberOfGuessed(this.auth.AuthUserId);

            for (int i = 0 ; i < guessedNoList.Count; i++)
            {
                this.ticketList.Items[i].SubItems.Add(guessedNoList[i].ToString());
            }

            if (!this.ticketManager.HasUserEnoughBalance(this.auth.AuthUserId)) { this.DisableBuyBtn(); }
            if (this.ticketManager.HasLimitBeenReached(this.auth.AuthUserId)) { this.DisableBuyBtn(); }
            if(this.ticketManager.HasCheckedNumbers(this.auth.AuthUserId)) 
            {
                this.ShowWinningNumbers();
                this.DisableBuyBtn();
                this.DisableCheckBtn(); 
            }
        }

        private void buyTicketBtn_Click(object sender, EventArgs e)
        {
            BuyTicketForm buyTicketForm = new BuyTicketForm(this);
            buyTicketForm.ShowDialog();
        }

        private void checkBtn_Click(object sender, EventArgs e)
        {
            this.gameManager.CheckPlayersNumbers(this.auth.AuthUserId);
            this.CheckWonPrize();
            this.UpdateView();
        }

        private void CheckWonPrize()
        {
            List<int> guessedNoList = this.gameManager.GetNumberOfGuessed(this.auth.AuthUserId);

            int prize = this.gameManager._game.Prize;
            for (int i = 0; i < guessedNoList.Count; i++)
            {
                switch (guessedNoList[i])
                {
                    case 0:
                        break;
                    case 1:
                        int wonPrize = Convert.ToInt32(Math.Round(Convert.ToDouble(prize) / Math.Pow(10, 6)));
                        MessageBox.Show($"Congratulations!!! You won {wonPrize}");
                        this.balanceManager.AddToBalance(this.auth.AuthUserId, wonPrize);
                        break;
                    case 2:
                        wonPrize = Convert.ToInt32(Math.Round(Convert.ToDouble(prize) / Math.Pow(10, 5)));
                        MessageBox.Show($"Congratulations!!! You won {wonPrize}");
                        this.balanceManager.AddToBalance(this.auth.AuthUserId, wonPrize);
                        break;
                    case 3:
                        wonPrize = Convert.ToInt32(Math.Round(Convert.ToDouble(prize) / Math.Pow(10, 3)));
                        MessageBox.Show($"Congratulations!!! You won {wonPrize}");
                        this.balanceManager.AddToBalance(this.auth.AuthUserId, wonPrize);
                        break;
                    case 4:
                        wonPrize = Convert.ToInt32(Math.Round(Convert.ToDouble(prize) / Math.Pow(10, 2)));
                        MessageBox.Show($"Congratulations!!! You won {wonPrize}");
                        this.balanceManager.AddToBalance(this.auth.AuthUserId, wonPrize);
                        break;
                    case 5:
                        wonPrize = Convert.ToInt32(Math.Round(Convert.ToDouble(prize) / Math.Pow(10, 6)));
                        MessageBox.Show($"Congratulations!!! You won {wonPrize}");
                        this.balanceManager.AddToBalance(this.auth.AuthUserId, wonPrize);
                        break;
                    case 6:
                        MessageBox.Show($"Congratulations!!! You won {this.gameManager._game.Prize}");
                        this.balanceManager.AddToBalance(this.auth.AuthUserId, this.gameManager._game.Prize);
                        break;
                }
            }
        }
    }
}
