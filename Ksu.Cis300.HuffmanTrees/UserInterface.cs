/* UserInterface.cs
 * Author: Nick Ruffini
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KansasStateUniversity.TreeViewer2;
using Ksu.Cis300.PriorityQueueLibrary;
using Ksu.Cis300.ImmutableBinaryTrees;
using System.IO;

namespace Ksu.Cis300.HuffmanTrees
{
    /// <summary>
    /// A GUI for a program that builds a Huffman tree for a given input file.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a Click event on the "Select a File" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSelectFile_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryTreeNode<byte> t = null;

                    // Add code to build the Huffman tree and assign it to t.
                    long[] array = CountFrequencies(uxOpenDialog.FileName);
                    MinPriorityQueue<long, BinaryTreeNode<byte>> leaves = BuildLeaves(array);
                    t = GetHuffmanTree(leaves);

                    new TreeForm(t, 100).Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Accident
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInterface_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Creates a frequency table from the given file!
        /// </summary>
        /// <param name="fileName"> file that the frequency table is being made from </param>
        /// <returns> returns an array of long values showing the frequency of bytes in the file </returns>
        private static long[] CountFrequencies(string fileName)
        {
            long[] array = new long[256];
            using (FileStream inFile = File.OpenRead(fileName))
            {
                int k;
                while ((k = inFile.ReadByte()) != -1)
                {
                    byte b = (byte)k;
                    array[b]++;
                }
            }
            return array;
        }

        /// <summary>
        /// Creates a bunch of singleton tree nodes from the nonzero values in the array and adds them to
        /// a Min Priority Queue
        /// </summary>
        /// <param name="bytes"> Array of long values being used </param>
        /// <returns> Min Priority Queue full of singleton tree nodes</returns>
        private static MinPriorityQueue<long, BinaryTreeNode<byte>> BuildLeaves(long[] bytes)
        {
            MinPriorityQueue<long, BinaryTreeNode<byte>> queue = new MinPriorityQueue<long, BinaryTreeNode<byte>>();
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] != 0)
                {
                    byte b = (byte)i;
                    BinaryTreeNode<byte> singleton = new BinaryTreeNode<byte>(b, null, null);
                    queue.Add(bytes[i], singleton);
                }
            }
            return queue;
        }

        /// <summary>
        /// Merges all of the singleton trees into a Huffman tree
        /// </summary>
        /// <param name="leaves"> Min Priority Queue containing all the singleton trees </param>
        /// <returns> Returns the resulting Huffman Tree</returns>
        private static BinaryTreeNode<byte> GetHuffmanTree(MinPriorityQueue<long , BinaryTreeNode<byte>> leaves)
        {
            while (leaves.Count > 1)
            {
                long p1 = leaves.MinimumPriority;
 
                BinaryTreeNode<byte> firstRemoved = leaves.RemoveMinimumPriority();

                long p2 = leaves.MinimumPriority;
                BinaryTreeNode<byte> secondRemoved = leaves.RemoveMinimumPriority();

                BinaryTreeNode<byte> newRoot = new BinaryTreeNode<byte>(0, firstRemoved, secondRemoved);
                leaves.Add(p1 + p2, newRoot);
            }
            return leaves.RemoveMinimumPriority();
        }
    }
}
