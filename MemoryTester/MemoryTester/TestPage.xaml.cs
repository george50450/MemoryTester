using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoryTester
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        public List<int> WordsPosition = new List<int>();
        public List<string> ValidWordsPassedList = new List<string>();
        public List<string> WordsToTest = new List<string>();
        public List<string> WordsToCheckMemory = new List<string>();

        public static int numberOfWordsToTest = 10;
        public static int numberOfWordstoCheckMemory = 15;
        public int ValidWordsListlength;

        int updateCnt = 0;
    
        public TestPage(List<string> ValidWords)
        {
            InitializeComponent();
            Init();
           

            //storing valid list of words to a public list of strings
            ValidWordsPassedList = ValidWords;

            ValidWordsListlength = ValidWords.Count;
            createRandomListOfWords();

            gamebegins();

            //readWordsFromtxt();



        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }


        public void Init()
        {
            Title = "Memory Tester";
            BackgroundColor = Constants.BackgroundColor;
            WordLabel.TextColor = Constants.WordTextColor;
        }

       

        public bool update_data()
        {
            //Code to run frequently

            if(updateCnt<numberOfWordsToTest)
            {
                WordLabel.Text = WordsToTest[updateCnt];
                updateCnt = updateCnt + 1;
                Console.WriteLine(updateCnt + " " + DateTime.Now);
                return true;
            }
            else
            {
                //call result page

                // Navigation.PushAsync(new CheckMemory(WordsToTest, WordsToCheckMemory));

                //Navigation.PushModalAsync(new CheckMemory(WordsToTest, WordsToCheckMemory));

                NavigationPage checkmempage = new NavigationPage(new CheckMemory(WordsToTest, WordsToCheckMemory))
                {
                    BarBackgroundColor = Color.FromHex("#00b6a8"),
                    BarTextColor = Color.FromHex("#ffffff")
                };

                Navigation.PushModalAsync(checkmempage);

                return false;
                
            }
            

           
        }

   
        public void createRandomListOfWords()
        {
            //Getting random words position on WordsList table
            int i = 0;
            while(i< numberOfWordsToTest)
            {
                bool wordExist = false;
                Random r = new Random();
                int rInt = r.Next(0, ValidWordsListlength); //for ints
                for (int j = 0; j < WordsPosition.Count; j++)
                {
                    if(rInt == WordsPosition[j])
                    {
                        wordExist = true;
                    }
                   
                }
                if(wordExist == false)
                {
                    WordsPosition.Add(rInt);
                    i++;
                }
              
            }

            //Creating table of words to preview for test
            for (int j = 0; j < numberOfWordsToTest; j++)
            {
                WordsToTest.Add(ValidWordsPassedList[WordsPosition[j]]);
            }           
        }
      
        public void gamebegins()
        {
            WordLabel.Text = WordsToTest[updateCnt];
            updateCnt++;
            createListofCheckMemory();
            Device.StartTimer(TimeSpan.FromSeconds(3), update_data); //replace x with required seconds
          
           
        }

        public void createListofCheckMemory()
        {
            // ValidWordsPassedList
            //WordsToTest  lista me lekseis pou tsekarw 
            // WordsToCheckMemory  lista gia checkmemory
            // numberOfWordstoCheckMemory arithmos leksew pou thelw na tsekarw

            getRandomWords();
        }

        public void getRandomWords()
        {
             List<int> WordsPos = new List<int>();
        //Getting random words position on WordsList table
        int i = 0;
            while (i < numberOfWordsToTest)
            {
                bool wordExist = false;
                Random r = new Random();
                int rInt = r.Next(0, ValidWordsListlength); //for ints
                for (int j = 0; j < WordsPos.Count; j++)
                {
                    if (rInt == WordsPos[j])
                    {
                        wordExist = true;
                    }

                }
                if (wordExist == false)
                {
                    if(!(WordsToTest.Contains(ValidWordsPassedList[rInt])))
                    {
                        WordsPos.Add(rInt);
                        i++;
                    }
                    
                }
            } 

            List<string> RandomWords = new List<string>();
        
            //Creating table of words to preview for test
            for (int j = 0; j<numberOfWordsToTest; j++)
            {
                RandomWords.Add(ValidWordsPassedList[WordsPos[j]]);
            }


            RandomWords.AddRange(WordsToTest);
            List<int> RndWrdPos = new List<int>();
             //Getting random words position on WordsList table
            int k = 0;
            while (k < numberOfWordstoCheckMemory)
            {
                bool wordExist = false;
                Random r = new Random();
                int rInt = r.Next(0, numberOfWordstoCheckMemory); //for ints
                for (int j = 0; j < RndWrdPos.Count; j++)
                {
                    if (rInt == RndWrdPos[j])
                    {
                        wordExist = true;
                    }

                }
                if (wordExist == false)
                {
                    RndWrdPos.Add(rInt);
                    k++;
                }
            }

            //Creating table of words to preview for test
            for (int j = 0; j < numberOfWordstoCheckMemory ; j++)
            {
                WordsToCheckMemory.Add(RandomWords[RndWrdPos[j]]);
            }
        }

    }
}