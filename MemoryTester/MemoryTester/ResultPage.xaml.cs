using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoryTester
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultPage : ContentPage
	{
        float correct_answers, wrong_answers;
		public ResultPage (int corr_ans,int wrong_ans)
		{
			InitializeComponent ();
            Init();
            correct_answers = (float) corr_ans;
            wrong_answers = (float) wrong_ans;

            reslbl.Text ="Your result was : "/* +  ((float)(correct_answers / (correct_answers + wrong_answers)) * 100).ToString("0.0") + " %"*/;
            gradelbl.Text = ((float)(correct_answers / (correct_answers + wrong_answers)) * 100).ToString("0.0") + " %";
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void BackToMainMenubtn_Clicked(object sender, EventArgs e)
        {
            NavigationPage mainpage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#00b6a8"),
                BarTextColor = Color.FromHex("#ffffff")
            };

            Navigation.PushModalAsync(mainpage);
        }

        public void Init()
        {
            Title = "Memory Tester";
            reslbl.TextColor = Color.FromHex("#00b6a8");
            gradelbl.TextColor = Color.Red;
            backToMainMenubtn.TextColor = Color.White;
            backToMainMenubtn.BackgroundColor = Constants.MainTextColor;
            BackgroundColor = Constants.BackgroundColor;
      
        }
	}
}