namespace StoneSoupAssessment.LinkedList
{
    public class MyNode<T>
    {
        public T data;
        public MyNode<T> next;

        public MyNode(T data)
        {
            this.data = data;
            this.next = null;
        }

        public override string ToString()
        {
            if (data == null)
            {
                return string.Empty;
            }

            return data.ToString();
        }
    }
}
