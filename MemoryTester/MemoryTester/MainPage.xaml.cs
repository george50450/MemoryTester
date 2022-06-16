using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace MemoryTester
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Init();
            xmlreader();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        public void Init()
        {

            Title = "Memory Tester";



            //BackgroundColor = Constants.BackgroundColor;
            beginTestButtn.TextColor = Color.White;
            beginTestButtn.BackgroundColor = Constants.MainTextColor;


            welcomeIcon.HeightRequest = Constants.WelcmIconHeight;
        }

        private void BeginTestButtn_Clicked(object sender, EventArgs e)
        {


            //se periptws poy thelw na anoiksw selida me navigation drawer-toolbar 
            /*
            MasterDetailPage fpm = new MasterDetailPage();
            fpm.Master = new TestPage(); // You have to create a Master ContentPage()
            fpm.Detail = new NavigationPage(new TestPage()); // You have to create a Detail ContenPage()
            Application.Current.MainPage = fpm;*/

            //WORKS!!!!create a new toolbar without the button utility
            NavigationPage testpage = new NavigationPage(new TestPage(ValidWords))
            {
                BarBackgroundColor = Color.FromHex("#00b6a8"),
                BarTextColor = Color.FromHex("#ffffff")
            };

            Navigation.PushModalAsync(testpage);


            //WORKS!!!! ayth h grammh doyleve alla einai gia otan den doulevw me toolbar.ALLA AFOU DE THELW BACK DE XRHSIMOPOIW ALLO TOOLBAR
            //Navigation.PushModalAsync(new TestPage(ValidWords));


            //WORKS!!!! me ayth th grammh omws doulevei me toolbar kai exei kai to back
            //Navigation.PushAsync(new TestPage(ValidWords));



            /*

                        //Gia na paw apla se allo activity!!!!!!!!!!

                        Navigation.PushModalAsync(new TestPage());*/
        }

        public List<string> ValidWords = new List<string>();
        public void xmlreader()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string name = "MemoryTester.words.xml";
            try
            {
                using (Stream stream = assembly.GetManifestResourceStream(name))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string text = reader.ReadToEnd();
                        string[] lines = text.Split(
                        new[] { Environment.NewLine },
                        StringSplitOptions.None
                        );
                        //words.Text = lines[4];
                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (lines[i].Count(char.IsLetter) > 3 && (!lines[i].Contains("#")) && (!lines[i].Contains("<")))
                            {
                                ValidWords.Add(lines[i]);
                            }
                        }

                    }
                }
            }
            catch (InvalidCastException e)
            {
            }
        }
    }
}
