using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class TreeNode
    {
        int val;
        TreeNode left, right;

        public TreeNode(int v)
        {
            val = v;
            left = null;
            right = null;
        }

        public int Value 
        { 
            get { return val; }
            set { val = value; }
        }

        public TreeNode Left
        {
            get { return left; }
            set { left = value; }
        }

        public TreeNode Right 
        { 
            get { return right; }
            set { right = value; }
        }

    }
}

