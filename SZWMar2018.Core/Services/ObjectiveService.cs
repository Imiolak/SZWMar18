﻿using System.Collections.Generic;
using System.Linq;
using MvvmCross.Plugins.Sqlite;
using SZWMar2018.Core.Models;

namespace SZWMar2018.Core.Services
{
    public class ObjectiveService : DataServiceBase, IObjectiveService
    {
        public ObjectiveService(IMvxSqliteConnectionFactory connectionFactory) 
            : base(connectionFactory)
        {
            Connection.CreateTable<Objective>();
            Connection.CreateTable<ObjectiveStepBase>();
            Connection.CreateTable<TextObjectiveStep>();
            Connection.CreateTable<QuestionObjectiveStep>();
            Connection.CreateTable<GoToLocationObjectiveStep>();
        }

        public Objective GetObjectiveByObjectiveNo(int objectiveNo)
        {
            return Connection.Find<Objective>(o => o.ObjectiveNo == objectiveNo);
        }

        public T GetObjectiveStep<T>(int objectiveNo, int orderInObjective)
            where T : ObjectiveStepBase, new()
        {
            return Connection.Find<T>(os => os.ObjectiveNo == objectiveNo
                                            && os.OrderInObjective == orderInObjective);
        }

        public int GetNumberOfObjectiveStepsByObjectiveNo(int objectiveNo)
        {
            return GetObjectiveStepsForObjective(objectiveNo).Count;
        }

        public string GetObjectiveStepType(int objectiveNo, int orderInObjective)
        {
            return GetObjectiveStepsForObjective(objectiveNo)
                .Single(os => os.OrderInObjective == orderInObjective)
                .Type;
        }

        public void AddObjective(Objective objective)
        {
            Connection.Insert(objective);
        }

        public void AddObjectiveStep(ObjectiveStepBase objectiveStep)
        {
            Connection.Insert(objectiveStep, objectiveStep.GetType());
        }

        public void RemoveAllObjectives()
        {
            Connection.DeleteAll<Objective>();
            Connection.DeleteAll<GoToLocationObjectiveStep>();
            Connection.DeleteAll<QuestionObjectiveStep>();
            Connection.DeleteAll<TextObjectiveStep>();
            Connection.DeleteAll<ObjectiveStepBase>();
        }

        private IList<ObjectiveStepBase> GetObjectiveStepsForObjective(int objectiveNo)
        {
            var objectiveSteps = new List<ObjectiveStepBase>();
            objectiveSteps.AddRange(Connection.Table<TextObjectiveStep>()
                .Where(os => os.ObjectiveNo == objectiveNo));
            objectiveSteps.AddRange(Connection.Table<QuestionObjectiveStep>()
                .Where(os => os.ObjectiveNo == objectiveNo));
            objectiveSteps.AddRange(Connection.Table<GoToLocationObjectiveStep>()
                .Where(os => os.ObjectiveNo == objectiveNo));

            return objectiveSteps;
        }
    }
}
