﻿namespace BalloonsPop.ConsoleUI
{
    using System;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Validators;
    using BalloonsPop.Engine;
    using BalloonsPop.Engine.Commands;
    using System.Collections.Generic;

    using System.Linq;

    public class MainProgram
    {
        public static void Main()
        {
            var consoleUI = new ConsoleUI();
            var commandFactory = new CommandFactory();
            var gameLogicProvider = new GameLogic(MatrixValidator.GetInstance);
            var gameModel = new Game(gameLogicProvider);
            
            var engine = new Engine(consoleUI, UserInputValidator.GetInstance, commandFactory, gameModel, gameLogicProvider);
            engine.Run();
        }
    }

    
}