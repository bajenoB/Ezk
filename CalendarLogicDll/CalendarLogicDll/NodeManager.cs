using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarLogicDll
{
    public class Node
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ChangeTime { get; set; }

        public Node()
        {
            Name = string.Empty;
            Text = string.Empty;
            CreationTime = DateTime.Now;
            ChangeTime = DateTime.Now;
        }

        public Node(string name, string text)
        {
            Name = name;
            Text = text;
            CreationTime = DateTime.Now;
            ChangeTime = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nText: {Text}\nCreation Time: {CreationTime}\nChange Time: {ChangeTime}";
        }

        public override bool Equals(object obj)
        {
            return obj is Node node &&
                   Text == node.Text &&
                   Name == node.Name &&
                   CreationTime == node.CreationTime &&
                   ChangeTime == node.ChangeTime;
        }

        public override int GetHashCode()
        {
            int hashCode = -666272035;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Text);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + CreationTime.GetHashCode();
            hashCode = hashCode * -1521134295 + ChangeTime.GetHashCode();
            return hashCode;
        }
    }
    [Serializable]
    public class NodeManager
    {
         public List<Node> Nodes { get; set; } = new List<Node>();
        
         public string Path { get; set; }
         public NodeManager()
            {

            }

            public NodeManager(List<Node> nodes, string path)
            {
                Nodes = nodes;
                Path = path;
            }

            public void OrderByNameDecreasing() => Nodes = Nodes.OrderBy(x => x.Name).ToList();
            
            public void OrderByNameIncreasing()
            {
                OrderByNameDecreasing();
                Nodes.Reverse();
            }

            public void OrderByCreationTimeDecreasing() => Nodes = Nodes.OrderBy(x => x.CreationTime).ToList();
            
            public void OrderByCreationTimeIncreasing()
            {
                OrderByCreationTimeDecreasing();
                Nodes.Reverse();
            }

            public void OrderByChangeTimeDecreasing() => Nodes = Nodes.OrderBy(x => x.ChangeTime).ToList();
            
            public void OrderByChangeTimeIncreasing()
            {
                OrderByChangeTimeDecreasing();
                Nodes.Reverse();
            }

            public List<Node> SearchByName(string name) => Nodes.Where(x => x.Name.Contains(name)).ToList();

            public List<Node> SearchByCreationTime(DateTime creationTime) => Nodes.Where(x => x.CreationTime.ToString().Contains(creationTime.ToString())).ToList();

            public List<Node> SearchByChangeTime(DateTime changeTime) => Nodes.Where(x => x.ChangeTime.ToString().Contains(changeTime.ToString())).ToList();
    }
}
