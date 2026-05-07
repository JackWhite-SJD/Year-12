using System.Security;

namespace binary_tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    internal class graph
    {
        string[] label;
        int[] leftPtr;
        int[] rightPtr;
        int currentPtr;
        string ltr;

        public graph()
        {
            label = _initializeLabel(label);
            leftPtr = _initializeLeftPtr(leftPtr);
            rightPtr = _initializeRightPtr(rightPtr);
            currentPtr = 0;
            ltr = label[currentPtr];
        }

        int traverseLeft(int currentPtr)
        {
            if (leftPtr[currentPtr] != -1)
            {
                currentPtr = leftPtr[currentPtr];
                
            }
            return currentPtr;
        }

        int traverseRight(int currentPtr)
        {
            if (rightPtr[currentPtr] != -1)
            {
                currentPtr = rightPtr[currentPtr];

            }
            return currentPtr;
        }


        string[] _initializeLabel(string[] arr)
        {
            arr[0] = "D";
            arr[1] = "B";
            arr[2] = "E";
            arr[3] = "A";
            arr[4] = "C";
            arr[5] = "G";
            arr[6] = "F";
            return arr;
        }

        int[] _initializeLeftPtr(int[] arr)
        {
            arr[0] = 1;
            arr[1] = 3;
            arr[2] = -1;
            arr[3] = -1;
            arr[4] = -1;
            arr[5] = 6;
            arr[6] = -1;

            return arr;
        }

        int[] _initializeRightPtr(int[] arr)
        {
            arr[0] = 2;
            arr[1] = 4;
            arr[2] = 5;
            arr[3] = -1;
            arr[4] = -1;
            arr[5] = -1;
            arr[6] = -1;

            return arr;
        }
           
    }

}
