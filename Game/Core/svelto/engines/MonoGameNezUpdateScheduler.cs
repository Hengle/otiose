﻿using Nez;
using Svelto.ECS.Schedulers;
using Svelto.WeakEvents;

namespace Otiose.svelto.engines
{
    public sealed class MonoGameNezUpdateScheduler : EntitySubmissionScheduler
    {
        private Scheduler scheduler;

        public MonoGameNezUpdateScheduler()
        {
            scheduler = new Scheduler();
        }

        public override void Schedule(WeakAction submitEntityViews)
        {
            scheduler.OnUpdate = submitEntityViews;
        }

        class Scheduler : IUpdatableManager
        {
            internal WeakAction OnUpdate;

            public void update()
            {
                if (OnUpdate.IsValid)
                    OnUpdate.Invoke();
            }

        }

    }
}