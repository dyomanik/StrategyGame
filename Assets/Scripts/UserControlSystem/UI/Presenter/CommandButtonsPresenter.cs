using System;
using System.Collections.Generic;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using UserControlSystem.UI.View;
using Utils;

namespace UserControlSystem.UI.Presenter
{
    public sealed class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        [SerializeField] private AssetsContext _context;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _selectable.OnSelected += ONSelected;
            ONSelected(_selectable.CurrentValue);

            _view.OnClick += ONButtonClick;
        }

        private void ONSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }
            _currentSelectable = selectable;

            _view.Clear();
            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }

        private void ONButtonClick(ICommandExecutor commandExecutor)
        {
            var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
            if (unitProducer != null)
            {
                unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
                return;
            }

            var moveComand = commandExecutor as CommandExecutorBase<IMoveCommand>;
            if (moveComand != null)
            {
                moveComand.ExecuteSpecificCommand(_context.Inject(new MoveCommand()));
                return;
            }

            var attackComand = commandExecutor as CommandExecutorBase<IAttackCommand>;
            if (attackComand != null)
            {
                attackComand.ExecuteSpecificCommand(_context.Inject(new AttackComand()));
                return;
            }

            var patrolComand = commandExecutor as CommandExecutorBase<IPatrolCommand>;
            if (patrolComand != null)
            {
                patrolComand.ExecuteSpecificCommand(_context.Inject(new PatrolCommand()));
                return;
            }

            var stopComand = commandExecutor as CommandExecutorBase<IStopCommand>;
            if (stopComand != null)
            {
                stopComand.ExecuteSpecificCommand(_context.Inject(new StopCommand()));
                return;
            }

            throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(ONButtonClick)}: " +
                                           $"Unknown type of commands executor: {commandExecutor.GetType().FullName}!");

        }
    }
}