﻿using System;
using System.Collections;
using Core.svelto.entityviews;
using Svelto.ECS;
using Svelto.Tasks;

namespace Core.svelto.engines
{

    public class PhysicsForceEngine : SingleEntityViewEngine<PhysicsEntityView>
    {
        public PhysicsForceEngine()
        {
            _taskRoutine = TaskRunner.Instance.AllocateNewTaskRoutine().SetEnumerator(ApplyForce());
        }

        IEnumerator ApplyForce()
        {
            while (true)
            {
                var force = _physicsEntityView.Force.Force;
                 if (force.X != 0 || force.Y != 0)
                {
                    _physicsEntityView.RigidBody.Body.ApplyForce(force);
//                    Console.WriteLine($"Entity position: {_physicsEntityView.RigidBody.Body.Position}");
                }

                yield return null;
            }
        }

        protected override void Add(PhysicsEntityView entityView)
        {
            _physicsEntityView = entityView;
            _taskRoutine.Start();
        }

        protected override void Remove(PhysicsEntityView entityView)
        {
            _taskRoutine.Stop();
            _physicsEntityView = null;
        }

        ITaskRoutine _taskRoutine;
        PhysicsEntityView _physicsEntityView;
    }
}
