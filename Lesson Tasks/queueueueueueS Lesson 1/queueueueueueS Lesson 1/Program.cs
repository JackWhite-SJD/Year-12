namespace queueueueueueS_Lesson_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue(7);
            queue.outputArray();

            queue.ENQUEUE(5);
            queue.outputArray();
            queue.ENQUEUE(6);
            queue.outputArray();
            queue.ENQUEUE(9);
            queue.DEQUEUE();
            queue.DEQUEUE();
            queue.outputArray();
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
            length = numberOfItems;
            queueArray = new int[length];
            frontPtr = 0;
            backPtr = 0;
            totalItems = 0;
        }

        private int[] getArr(int noOfItems)
        {
            int[] currentArray = new int[noOfItems];

            for (int i = 0; i < noOfItems; i++)
            {
                
            }
            return currentArray;
        }

        public void outputArray()
        {
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(queueArray[i]);
            }
            Console.WriteLine();
        }

        public int[] getQueueArray() { return queueArray; }
        public void ENQUEUE(int item)
        {
            if (totalItems < length)
            {
                totalItems += 1;
                queueArray[backPtr] = item;
                backPtr += 1;
                if (backPtr == length - 1)
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
                if (frontPtr == length - 1)
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
