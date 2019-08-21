using System;
using System.Collections.Generic;
using System.Text;

namespace TianLeClass.Entity.Response
{
    public class ResponseDictTree
    {
        public List<TreeNode> data;
    }


    public class TreeNode
    {
        public int id;
        public string value;
        public List<TreeNode> son;
    }
}
