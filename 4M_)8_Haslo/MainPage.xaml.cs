namespace _4M__8_Haslo
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGenerujClicked(object sender, EventArgs e)
        {
            string sSl = entDlugosc.Text;
            int dl = 0;
            bool czyLiczba = int.TryParse(sSl, out dl);
            if (!czyLiczba || dl < 1)
            {
                lblhaslo.Text = "długość musi być liczbą całkowitą dodatnią";
                return;
            }
            var czyMaleLit = chkMaleLit.IsChecked;
            var czyDuzeLit = chkDuzeLit.IsChecked;
            var czyCyfry = chkCyfry.IsChecked;
            var czyZnakSpec = chkZnakiSpec.IsChecked;

            if(!(czyMaleLit || czyDuzeLit || czyCyfry ||czyZnakSpec))
            {
                lblhaslo.Text = "musisz wybrać conajmniej jeden zestaw znaków";
                return;
            }

            string znaki = "";
            if(czyMaleLit) 
                for (char c='a'; c<='z'; c++)
                    znaki += c;
            if (czyDuzeLit)
                for (char c = 'A'; c <= 'Z'; c++)
                    znaki += c;
            if (czyCyfry)
                for (char c = '0'; c <= '9'; c++)
                    znaki += c;
            if (czyZnakSpec)
                znaki += "~`!@#$%^&*()_-+=[]{}\\|,.<>/?";

            Random random = new Random();
            string haslo = string.Empty;
            for(int i = 0;i<dl; i++)
            {
                haslo += znaki[random.Next(0,znaki.Length-1)]; ;
            }
            lblhaslo.Text = haslo;

        }

    }
}