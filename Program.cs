using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialiser une liste de 20 éléments de type Node
        Node<int> head = null;
        for (int i = 0; i < 20; i++)
        {
            head = AddNode(head, new Node<int>(new Random().Next(100))); // Ajouter des valeurs aléatoires entre 0 et 99
        }

        // Trier les éléments en ordre croissant
        head = SortList(head);

        // Imprimer les valeurs sur l'écran
        PrintList(head);
    }

    static Node<T> AddNode<T>(Node<T> head, Node<T> newNode) where T : IComparable<T>
    {
        if (head == null)
        {
            return newNode;
        }
        Node<T> current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
        return head;
    }

    static Node<T> SortList<T>(Node<T> head) where T : IComparable<T>
    {
        if (head == null || head.Next == null)
        {
            return head;
        }

        Node<T> sortedHead = null;
        Node<T> current = head;
        while (current != null)
        {
            Node<T> next = current.Next;
            sortedHead = SortedInsert(sortedHead, current);
            current = next;
        }
        return sortedHead;
    }

    static Node<T> SortedInsert<T>(Node<T> head, Node<T> newNode) where T : IComparable<T>
    {
        if (head == null || head.Value.CompareTo(newNode.Value) >= 0)
        {
            newNode.Next = head;
            return newNode;
        }
        Node<T> current = head;
        while (current.Next != null && current.Next.Value.CompareTo(newNode.Value) < 0)
        {
            current = current.Next;
        }
        newNode.Next = current.Next;
        current.Next = newNode;
        return head;
    }

    static void PrintList<T>(Node<T> head) where T : IComparable<T>
    {
        Node<T> current = head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}
