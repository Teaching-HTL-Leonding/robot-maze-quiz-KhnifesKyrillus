using Maze.Library;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Maze.Solver
{
    /// <summary>
    /// Moves a robot from its current position towards the exit of the maze
    /// </summary>
    public class RobotController
    {
        private readonly IRobot robot;
        /// <summary>
        /// Initializes a new instance of the <see cref="RobotController"/> class
        /// </summary>
        /// <param name="robot">Robot that is controlled</param>
        public RobotController(IRobot robot)
        {
            // Store robot for later use
            this.robot = robot;
        }

        /// <summary>
        /// Moves the robot to the exit
        /// </summary>
        /// <remarks>
        /// This function uses methods of the robot that was passed into this class'
        /// constructor. It has to move the robot until the robot's event
        /// <see cref="IRobot.ReachedExit"/> is fired. If the algorithm finds out that
        /// the exit is not reachable, it has to call <see cref="IRobot.HaltAndCatchFire"/>
        /// and exit.
        /// </remarks>
        public void MoveRobotToExit()
        {
            // Here you have to add your code

            // Trivial sample algorithm that can just move right
            var reachedEnd = false;
            Random rnd = new Random();

            robot.ReachedExit += (_, __) => reachedEnd = true;
            int counter = 0;
            while (!reachedEnd)
            {
                robot.TryMove((Direction)rnd.Next(0, 4));

                counter++;
                if (counter == 10000000)
                {
                    robot.HaltAndCatchFire();
                    break;
                }
            }

        }
    }
}