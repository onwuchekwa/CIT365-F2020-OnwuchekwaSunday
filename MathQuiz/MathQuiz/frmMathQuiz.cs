using System;
using System.Drawing;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class frmMathQuiz : Form
    {
        // Create a Random object called randomizer 
        // to generate random numbers.
        Random randomizer = new Random();

        // These integer variables store the numbers
        // for the addition problem. 
        int addend1;
        int addend2;

        // These integer variables store the numbers 
        // for the subtraction problem. 
        int minuend;
        int subtrahend;

        // These integer variables store the numbers 
        // for the multiplication problem. 
        int multiplicand;
        int multiplier;

        // These integer variables store the numbers 
        // for the division problem. 
        int dividend;
        int divisor;

        // This integer variable keeps track of the 
        // remaining time.
        int timeLeft;

        // Initialize window media player
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();

        /// <summary>
        /// Start the quiz by filling in all of the problems
        /// and starting the timer.
        /// </summary>
        public void StartTheQuiz()
        {
            // Fill in the addition problem.
            // Generate two random numbers to add.
            // Store the values in the variables 'addend1' and 'addend2'.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convert the two randomly generated numbers
            // into strings so that they can be displayed
            // in the label controls.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // 'sum' is the name of the NumericUpDown control.
            // This step makes sure its value is zero before
            // adding any values to it.
            sum.Value = 0;

            // Fill in the subtraction problem.
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Fill in the multiplication problem.
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Fill in the division problem.
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        /// <summary>
        /// Check the answer to see if the user got everything right.
        /// </summary>
        /// <returns>True if the answer's correct, false otherwise.</returns>
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
            {
                return true;
            }
            else
            {
               return false;
            }
        }

        /// <summary>
        /// Perform arithematic operation between two numbers
        /// </summary>
        /// <returns>Return the value of the operation</returns>
        public int performOperation(int num1, int num2, Func<int, int, int> bitOpr)
        {
            return bitOpr(num1, num2);
        }

        /// <summary>
        /// Play an audio if user get the all the answers correct
        /// </summary>
        public void playAudio()
        {            
            player.URL = @"audio/app-7.mp3";
            player.controls.play();            
        }

        public frmMathQuiz()
        {
            InitializeComponent();
        }

        private void frmMathQuiz_Load(object sender, EventArgs e)
        {
            // Get today's date
            currentDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();

            // Reset controls
            startButton.Enabled = false;
            timeLabel.ForeColor = Color.Black;
            timeLabel.BackColor = SystemColors.Control;
            sum.ForeColor = Color.Black;
            difference.ForeColor = Color.Black;
            product.ForeColor = Color.Black;
            quotient.ForeColor = Color.Black;
            sum.BackColor = Color.White;
            difference.BackColor = Color.White;
            product.BackColor = Color.White;
            quotient.BackColor = Color.White;
            player.controls.stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // If CheckTheAnswer() returns true, then the user 
                // got the answer right. Stop the timer,
                // play an audio,
                // and show a MessageBox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                playAudio();
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // Notify user if time left is 6 seconds
                if (timeLeft <= 6)
                {
                    timeLabel.BackColor = Color.Red;
                    timeLabel.ForeColor = Color.White;
                }
                else
                {
                    timeLabel.ForeColor = Color.Black;
                    timeLabel.BackColor = SystemColors.Control;
                }

                // If CheckTheAnswer() return false, keep counting
                // down. Decrease the time left by one second and 
                // display the new time left by updating the 
                // Time Left label.
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // If the user ran out of time, stop the timer, show 
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {
            // Perform operation and change fore and back colors of NumericUpDown
            int result = performOperation(addend1, addend2, (x, y) => x + y);
            sum.ForeColor = Color.White;

            if (result == sum.Value)
            {
                sum.BackColor = Color.Green;
            }
            else
            {
                sum.BackColor = Color.Red;
            }
        }

        private void difference_ValueChanged(object sender, EventArgs e)
        {
            // Perform operation and change fore and back colors of NumericUpDown
            int result = performOperation(minuend, subtrahend, (x, y) => x - y);
            difference.ForeColor = Color.White;

            if (result == difference.Value)
            {
                difference.BackColor = Color.Green;
            }
            else
            {
                difference.BackColor = Color.Red;
            }
        }

        private void product_ValueChanged(object sender, EventArgs e)
        {
            // Perform operation and change fore and back colors of NumericUpDown
            int result = performOperation(multiplicand, multiplier, (x, y) => x * y);
            product.ForeColor = Color.White;

            if (result == product.Value)
            {
                product.BackColor = Color.Green;
            }
            else
            {
                product.BackColor = Color.Red;
            }
        }

        private void quotient_ValueChanged(object sender, EventArgs e)
        {
            // Perform operation and change fore and back colors of NumericUpDown
            int result = performOperation(dividend, divisor, (x, y) => x / y);
            quotient.ForeColor = Color.White;

            if (result == quotient.Value)
            {
                quotient.BackColor = Color.Green;
            }
            else
            {
                quotient.BackColor = Color.Red;
            }
        }
    }
}