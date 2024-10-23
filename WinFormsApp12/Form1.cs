namespace WinFormsApp12
{
    public partial class Form1 : Form
    {
        int nr = 0;  // To keep track of the number of clicks
        Button[] buttons;  // Array to store buttons for easy reference

        public Form1()
        {
            InitializeComponent();

            // Initialize the button array with button references
            buttons = new Button[] { b1, b2, b3, b4, b5, b6, b7, b8, b9 };

            // Attach the event handler to all buttons
            foreach (Button btn in buttons)
            {
                btn.Click += new EventHandler(btn_click);
            }

            // Ensure that the reset and cancel buttons are connected to their respective event handlers
            btn_reset.Click += new EventHandler(btn_reset_click);
            btn_cancel.Click += new EventHandler(btn_cancel_click);
        }

        // Event handler for button click (gameplay)
        private void btn_click(object sender, EventArgs e)
        {
            nr++;  // Increment the number of clicks
            Button b = (Button)sender;

            // Set text to "X" or "O" based on the number of clicks
            b.Text = (nr % 2 != 0) ? "X" : "O";
            b.Enabled = false;  // Disable the button after it's clicked

            // Check if there is a winner
            if (CheckWinner())
            {
                MessageBox.Show((nr % 2 != 0) ? "X Wins" : "O Wins");
                ResetGame();
            }
            else if (AllButtonsDisabled())  // Check if all buttons are disabled (i.e., it's a tie)
            {
                MessageBox.Show("It's a Tie!");
                ResetGame();
            }
        }

        // Check if there is a winning combination
        private bool CheckWinner()
        {
            // Horizontal, vertical, and diagonal win conditions
            return
                (b1.Text == b2.Text && b2.Text == b3.Text && !b1.Enabled) ||
                (b4.Text == b5.Text && b5.Text == b6.Text && !b4.Enabled) ||
                (b7.Text == b8.Text && b8.Text == b9.Text && !b7.Enabled) ||

                (b1.Text == b4.Text && b4.Text == b7.Text && !b1.Enabled) ||
                (b2.Text == b5.Text && b5.Text == b8.Text && !b2.Enabled) ||
                (b3.Text == b6.Text && b6.Text == b9.Text && !b3.Enabled) ||

                (b1.Text == b5.Text && b5.Text == b9.Text && !b1.Enabled) ||
                (b3.Text == b5.Text && b5.Text == b7.Text && !b3.Enabled);
        }

        // Check if all buttons are disabled (for a tie game)
        private bool AllButtonsDisabled()
        {
            foreach (Button btn in buttons)
            {
                if (btn.Enabled) return false;  // If any button is still enabled, return false
            }
            return true;
        }

        // Reset the game after a win or a tie
        private void ResetGame()
        {
            nr = 0;  // Reset click counter
            foreach (Button btn in buttons)
            {
                btn.Enabled = true;  // Enable all buttons
                btn.Text = "";  // Clear the text from all buttons
            }
        }

        // Reset button functionality (reset game when the reset button is clicked)
        private void btn_reset_click(object sender, EventArgs e)
        {
            ResetGame();
        }

        // Close the form when the cancel button is clicked
        private void btn_cancel_click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
