using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
//            Context context;
//            context= new Context(new StrategyA());
//            context.ContextInterface();
//
//            context = new Context(new StrategyB());
//            context.ContextInterface();
//
//            context = new Context(new StrategyC());
//            context.ContextInterface();
//
//            context = new Context(new StrategyD());
//            context.ContextInterface();
//
//            Console.ReadKey();

            SortList sortList = new SortList();

            sortList.SortInteface = new MergeSort();
            sortList.Sort();

            sortList.SortInteface = new QuickSort();
            sortList.Sort();

            sortList.SortInteface = new ShellSort();
            sortList.Sort();

            Console.ReadKey();
        }
    }

    #region Simple Structure
    abstract class Strategy
    {
        public abstract void AlgorithmInterface();
    }
    class StrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(this.GetType().Name);
        }
    }

    class StrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(this.GetType().Name);
        }
    }

    class StrategyC : Strategy {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(this.GetType().Name);
        }
    }

    class StrategyD: Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(this.GetType().Name);
        }
    }

    class Context
    {
        Strategy strategy;

        public Context(Strategy strategy)
        {
            this.strategy = strategy;
        }

        public void ContextInterface()
        {
            strategy.AlgorithmInterface();
        }
    }

    #endregion

    #region C#

    interface ISortInteface
    {
        void Sort();
    } 

    class QuickSort : ISortInteface {
        public void Sort()
        {
            Console.WriteLine(this.GetType().Name);
        }
    }

    class MergeSort : ISortInteface {
        public void Sort()
        {
            Console.WriteLine(this.GetType().Name);
        }
    }

    class ShellSort : ISortInteface
    {
        public void Sort()
        {
            Console.WriteLine(this.GetType().Name);
        }
    }


    class SortList
    {
        public ISortInteface SortInteface { get; set; }

        public void Sort()
        {
            SortInteface.Sort();
        }


    }
    #endregion
}
