namespace queueueueueueS_Lesson_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue(7);
            queue.ENQUEUE(1);
            queue

                .ENQUEUE(2);
            queue.ENQUEUE(3);
            queue.ENQUEUE(4);

            queue.ENQUEUE(5);
            queue.ENQUEUE(6);
            queue.DEQUEUE();
            queue.outputArray();
        }
    }

    class Queue
    {
        private int[] queueArray;
        private int length;
        private int frontPtr;
        private int backPtr;
        private int totalItems;

        public Queue(int numberOfItems)
        {
            length = numberOfItems + 1;
            queueArray = new int[length];
            frontPtr = 0;
            backPtr = 0;
            totalItems = 0;
        }


        public void outputArray()
           
        {
            for (int i = frontPtr; i < length; i++)
            {
                if (queueArray[i] != 0)
                {
                Console.WriteLine(queueArray[i]);

                }
            }s
            Console.WriteLine();
        }

        public int[] getQueueArray() { return queueArray; }
        public void ENQUEUE(int item)
        {
            if (totalItems < length-1)
            {
                totalItems += 1;
                queueArray[backPtr] = item;
                backPtr += 1;
                if (backPtr == length - 2)
                {
                    backPtr = 0;
                }
            }
        }

        public int DEQUEUE()
        {
            int finalItem = -999;
            if (totalItems  != 0)
            {
                finalItem = queueArray[frontPtr];
                frontPtr += 1;
                if (frontPtr == length - 2)
                {
                    frontPtr = 0;
                }
            }
            else
            {
                Console.WriteLine("Full");
            }
            return finalItem;
        }

    }
}
