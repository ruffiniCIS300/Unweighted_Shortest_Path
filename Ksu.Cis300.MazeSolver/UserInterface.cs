/* UserInterface.cs
 * Author: Rod Howell
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
using Ksu.Cis300.MazeLibrary;
using Ksu.Cis300.Graphs;

namespace Ksu.Cis300.MazeSolver
{
    /// <summary>
    /// A user interface for a maze solver.
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
        /// Handles a New event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNew_Click(object sender, EventArgs e)
        {
            uxMaze.Generate();
        }

        /// <summary>
        /// Gets a graph representing the given maze. The Direction associated with each edge
        /// is the direction from the source to the destination.
        /// </summary>
        /// <param name="maze">The maze to be represented.</param>
        /// <returns>The graph representation.</returns>
        private DirectedGraph<Cell, Direction> GetGraph(Maze maze)
        {
            DirectedGraph<Cell, Direction> graph = new DirectedGraph<Cell, Direction>();
            for (int i = 0; i < maze.MazeHeight; i++)
            {
                for (int j = 0; j < maze.MazeWidth; j++)
                {
                    Cell cell = new Cell(i, j);
                    if (!graph.ContainsNode(cell))
                    {
                        graph.AddNode(cell);
                    }
                    for (Direction d = Direction.North; d <= Direction.West; d++)
                    {
                        if (maze.IsClear(cell, d))
                        {
                            graph.AddEdge(cell, maze.Step(cell, d), d);
                        }
                    }
                }
            }
            return graph;
        }
    }
}
