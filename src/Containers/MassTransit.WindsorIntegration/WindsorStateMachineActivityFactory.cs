﻿namespace MassTransit.WindsorIntegration
{
    using Automatonymous;
    using Castle.MicroKernel;
    using GreenPipes;


    public class WindsorStateMachineActivityFactory :
        IStateMachineActivityFactory
    {
        public static readonly IStateMachineActivityFactory Instance = new WindsorStateMachineActivityFactory();

        public Activity<TInstance, TData> GetActivity<TActivity, TInstance, TData>(BehaviorContext<TInstance, TData> context)
            where TActivity : class, Activity<TInstance, TData>
        {
            var container = context.GetPayload<IKernel>();

            return container.Resolve<TActivity>();
        }

        public Activity<TInstance> GetActivity<TActivity, TInstance>(BehaviorContext<TInstance> context)
            where TActivity : class, Activity<TInstance>
        {
            var container = context.GetPayload<IKernel>();

            return container.Resolve<TActivity>();
        }
    }
}
