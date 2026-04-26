namespace MonofiaQ3WebApp26.Models
{
    interface ISort
    {
        void Sort(int[] arr);
    }
    class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        {
            //soty usoing bubble sort alg
        }
    }
    class SelectionSort:ISort//exetnd
    {
        public void Sort(int[] arr) { }
    }

    class Chris : ISort
    {
        public void Sort(int[] arr)
        {
            throw new NotImplementedException();
        }
    }
    //lossly couple
    class MyList //high level
    {
        int[] arr;
        ISort sortAlg=null;//abstartcion  class or interface 
        public MyList(ISort _sortAlg)//Depency Inject (ask[constructoe])
        {
            arr = new int[10];
            sortAlg =_sortAlg;//dont creatwee but ask (consurto parameter ,method parameter)
        }
        public void SortList()//[methoid]
        {
            sortAlg.Sort(this.arr);
        }
    }

    class Test2
    {
        object data;//private field
        public object Data { 
            get {
                return data;
            }
            set {
                data = value;
            }
        }  
        public dynamic Bag
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }
    }
    class Parent<T>
    {
        public T Model { get; set; }
    }
    //inhroity
    //class Child : Parent<int>
    //{

    //}
    class Child<T> : Parent<T>
    {

    }
    public class TestClass
    {
        public void Test()
        {
            MyList l1=new MyList(new Chris());//inject 
            l1.SortList();//using bu
            MyList l2 = new MyList(new SelectionSort());
            l2.SortList();//using sel






            Test2 t = new Test2();
            t.Data = 1;
            t.Bag = "ahmed";

            Console.WriteLine(t.Data);
            //create object
            Parent<int> p = new Parent<int>();
            Child<string> c=new Child<string>();
            






            int x = 12;
            string name = "Ahmed";
            //----------------------------
            dynamic age = 10;//int
            dynamic address = "Alex";
            dynamic obj = new Student();
           
            address = age + obj;//exception
        }
    }
}
