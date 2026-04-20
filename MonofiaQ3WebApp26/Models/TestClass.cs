namespace MonofiaQ3WebApp26.Models
{
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
