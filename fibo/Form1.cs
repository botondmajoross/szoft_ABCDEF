namespace fibo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++) 
            {
                Button b = new Button();
                b.Top = i * 30;
                b.Text = fibo(i).ToString();
                Controls.Add(b);
            }
        }

        int fibo(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return fibo(n-1) + fibo(n-2);

        }

    }
}