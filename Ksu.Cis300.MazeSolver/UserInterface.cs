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

        /// <summary>
        /// Finds the shortest path to a node outside the maze!
        /// </summary>
        /// <param name="graph"> Graph we are working with </param>
        /// <param name="u"> Starting cell! </param>
        /// <param name="maze"> Maze that is generated in </param>
        /// <param name="paths"> Dictionary whose key are a cell, and whose values are the previous cells </param>
        /// <returns> The final cell in the path! </returns>
        private static Cell FindPath(DirectedGraph<Cell, Direction> graph, Cell u, Maze maze, out Dictionary<Cell, Cell> paths)
        {
            paths = new Dictionary<Cell, Cell>();
            paths.Add(u, u);

            Queue<Edge<Cell, Direction>> q = new Queue<Edge<Cell, Direction>>();

            foreach (Edge<Cell, Direction> edge in graph.OutgoingEdges(u))
            {
                //q.Add(edge.Data, edge);
                q.Enqueue(edge);
            }

            while (q.Count != 0)
            {
                Edge<Cell, Direction> nextEdge = q.Dequeue();

                if (paths.ContainsKey(nextEdge.Destination) != true)
                {
                    paths.Add(nextEdge.Destination, nextEdge.Source);
                    if (maze.IsInMaze(nextEdge.Destination) == false)
                    {
                        //check
                        return nextEdge.Destination;
                    }
                    else
                    {
                        foreach (Edge<Cell, Direction> edge in graph.OutgoingEdges(nextEdge.Destination))
                        {
                            q.Enqueue(edge);
                        }
                    }
                }
            }
            return new Cell(0, 0);
        }

        /// <summary>
        /// Draws the shortest path from Cell u to v
        /// </summary>
        /// <param name="u"> Start Cell </param>
        /// <param name="v"> End Cell </param>
        /// <param name="maze"> Maze we are referencing </param>
        /// <param name="paths"> Dictionary whose keys are a cell, and the values are the previous cell </param>
        /// <param name="graph"></param>
        private static void DisplayPath(Cell u, Cell v, Maze maze, Dictionary<Cell, Cell> paths, DirectedGraph<Cell, Direction> graph)
        {
            Cell cur = v;

            while (cur != u)
            {
                Cell prev = paths[cur];
                Direction dir;
                graph.TryGetEdge(prev, cur, out dir);
                maze.DrawPath(prev, dir);

                cur = paths[cur];
            }
        }

        /// <summary>
        /// Event handler for clicking on a cell in the maze!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxMaze_MouseClick(object sender, MouseEventArgs e)
        {
            Cell cell = uxMaze.GetCellFromPixel(e.Location);
            if (uxMaze.IsInMaze(cell))
            {
                uxMaze.EraseAllPaths();
                DirectedGraph<Cell, Direction> graph = GetGraph(uxMaze);
                Dictionary<Cell, Cell> paths;
                Cell exit = FindPath(graph, cell, uxMaze, out paths);
                if (exit == new Cell(0, 0))
                {
                    MessageBox.Show("There is no path from this cell.");
                }
                else
                {
                    DisplayPath(cell, exit, uxMaze, paths, graph);
                }
                uxMaze.Invalidate();
            }
        }
    }
}
