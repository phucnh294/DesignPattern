using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var document = new List<Document> {new Report(), new Resume()};
            foreach (var item in document)
            {
                Console.WriteLine(item.ToString());
                foreach (var page in item.Pages)
                {
                    Console.WriteLine(page.ToString());
                }
            }
            Console.ReadKey();
        }

    }

    abstract class Page
    {
        public override string ToString()
        {
            return this.GetType().Name;
        }
    }

    class InformationPage : Page
    {
    }

    class SkillPage : Page { }

    class EducationPage : Page { }
    class IntroductionPage : Page { }
    class ConclusionPage : Page { }
    class ExperiencePage : Page { }
    class StatisticPage : Page { }

    abstract class Document
    {
        public Document()
        {
            this.CreatePages();
        }
        public List<Page> Pages { get; protected set; }

        public override string ToString()
        {
            return this.GetType().Name;
        }

        public abstract void CreatePages();
    }

    class Resume : Document
    {
        public override void CreatePages()
        {
            Pages = new List<Page> { 
                    new InformationPage(),
                    new EducationPage(),
                    new SkillPage(),
                    new EducationPage()
                };
        }
    }

    class Report : Document
    {
        public override void CreatePages()
        {
            Pages = new List<Page>
            {
                new ConclusionPage(),
                new ExperiencePage(),
                new StatisticPage()
            };
        }
    }
}
