﻿using System;
using System.Collections.Generic;

namespace Pulsar4X.ECSLib
{
    internal class ProcessorManager
    {
     
        private readonly Dictionary<Type, IHotloopProcessor> _hotloopProcessors = new Dictionary<Type, IHotloopProcessor>();
        private readonly List<IRecalcProcessor> _recalcProcessors = new List<IRecalcProcessor>();
        private StaticDataStore _staticData;
        internal ProcessorManager(Game game)
        {
            _staticData = game.StaticData;
            CreateProcessors(game);
        }

        internal void AddHotloopProcessor<T>(IHotloopProcessor processor) where T: BaseDataBlob
        {
            _hotloopProcessors.Add(typeof(T), processor);
        }

        internal void AddRecalcProcessor(IRecalcProcessor processor)
        {
            if (processor.ProcessPriority <= _recalcProcessors.Count)
                _recalcProcessors.Insert(processor.ProcessPriority, processor);
            else
                _recalcProcessors.Add(processor);
        }

        internal void Hotloop<T>(EntityManager manager, int deltaSeconds) where T: BaseDataBlob
        {
            var type = typeof(T);
            var entities = manager.GetAllEntitiesWithDataBlob<T>();
            foreach (var entity in entities)
            {               
                _hotloopProcessors[type].ProcessEntity(entity, deltaSeconds);
            }
        }

        internal void RecalcEntity(Entity entity)
        {
            foreach (var processor in _recalcProcessors)
            {
                processor.RecalcEntity(entity);
            }
        }



        private void CreateProcessors(Game game)
        {
            AddHotloopProcessor<MiningDB>(new MineResourcesProcessor(_staticData));
            AddHotloopProcessor<RefiningDB>(new RefineResourcesProcessor(_staticData.ProcessedMaterials));
            AddHotloopProcessor<ConstructionDB>(new ConstructEntitiesProcessor());
            AddHotloopProcessor<PropulsionDB>(new ShipMovement());
            AddHotloopProcessor<OrbitDB>(new OrbitProcessor());
        }
    }


    internal interface IHotloopProcessor
    {   
        void ProcessEntity(Entity entity, int deltaSeconds);
        void ProcessManager(EntityManager manager, int deltaSeconds);
    }

    internal interface IRecalcProcessor
    {
        byte ProcessPriority { get; set; }
        void RecalcEntity(Entity entity);
    }
}