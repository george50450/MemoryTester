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
    public partial class CheckMemory : ContentPage
    {
        public List<string> WordsToTestSTOR = new List<string>();
        public List<string> WordsToCheckMemorySTOR = new List<string>();

        public List<int> RightAnswers = new List<int>();
        public List<int> UserAnswers = new List<int>();

        public int ansCNTR = 0;

        int correct_answers = 0;
        int wrong_answers = 0;

        int answers = 0;
        public CheckMemory(List<string> WordsToTest, List<string> WordsToCheckMemory)
        {

            InitializeComponent();
            Init();

            WordsToTestSTOR = WordsToTest;
            WordsToCheckMemorySTOR = WordsToCheckMemory;

            wordlbl.Text = WordsToCheckMemorySTOR[ansCNTR];
            
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        public void Init()
        {
            Title = "Memory Tester";
            BackgroundColor = Constants.BackgroundColor;
            txtlbl.TextColor = Color.FromHex("#00b6a8");
            wordlbl.TextColor = Constants.WordTextColor;
            yes.TextColor=Color.White;
            yes.BackgroundColor = Constants.MainTextColor;
            no.TextColor = Color.White;
            no.BackgroundColor = Constants.MainTextColor;
        }

        private void Yes_Clicked(object sender, EventArgs e)
        {
            
            
            if(ansCNTR<WordsToCheckMemorySTOR.Count)
            {
                UserAnswers.Add(1);
                answers++;
                if(answers< WordsToCheckMemorySTOR.Count)
                {
                    wordlbl.Text = WordsToCheckMemorySTOR[answers];
                    ansCNTR++;
                }
                else
                {
                    yes.IsVisible = false;
                    no.IsVisible = false;
                    letsSeeWhatUveGot();
                }

            }
            
        }

        private void No_Clicked(object sender, EventArgs e)
        {
           
            
            if (ansCNTR < WordsToCheckMemorySTOR.Count)
            {
                UserAnswers.Add(0);

                answers++;
                if (answers < WordsToCheckMemorySTOR.Count)
                {
                    wordlbl.Text = WordsToCheckMemorySTOR[answers];
                    ansCNTR++;
                }
                else
                {
                    yes.IsVisible = false;
                    no.IsVisible = false;
                    letsSeeWhatUveGot();
                }
            }
           

                
        }

     

        public void createAnswersTable()
        {
            int[] pos = new int[WordsToCheckMemorySTOR.Count];
            for(int k=0; k<WordsToCheckMemorySTOR.Count; k++)
            {
                pos[k] = 0;
            }
            for (int i=0; i< WordsToCheckMemorySTOR.Count; i++)
            {
                for(int j=0; j<WordsToTestSTOR.Count; j++)
                {
                    if(WordsToCheckMemorySTOR[i].Equals(WordsToTestSTOR[j], StringComparison.InvariantCulture) )
                    {
                        pos[i] = 1;
                    }
                }
            }
            RightAnswers = pos.OfType<int>().ToList();
           // resulttest.Text = WordsToCheckMemorySTOR.Count + " " + UserAnswers.Count + " " + RightAnswers.Count;
        }

        public void letsSeeWhatUveGot()
        {
            createAnswersTable();
          
            
            for(int i=0; i<WordsToCheckMemorySTOR.Count; i++)
            {
                if(UserAnswers[i] == RightAnswers[i])
                {
                    correct_answers++;
                }
                else
                {
                    wrong_answers++;
                }
            }
           


            //  Navigation.PushAsync(new ResultPage(correct_answers, wrong_answers));
            //Navigation.PushModalAsync(new ResultPage(correct_answers, wrong_answers));

            NavigationPage resultpage = new NavigationPage(new ResultPage(correct_answers, wrong_answers))
            {
                BarBackgroundColor = Color.FromHex("#00b6a8"),
                BarTextColor = Color.FromHex("#ffffff")
            };

            Navigation.PushModalAsync(resultpage);
        }
    }
}